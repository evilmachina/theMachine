﻿using System;
using System.Threading;
using System.Windows.Forms;
using Robot;
using Robot.InstructionPackets;
using RobotControl;
using TDx.TDxInput;


namespace GUI
{
    public partial class frmBase : Form
    {
        readonly ISender _sender = new CommunicationObject("COM3");
        HomePosition _homePosition = HomePositionFactory.CreateHomePosition();
        Phoenix _phoenix = RobotFactory.CreatePhoenix(HomePositionFactory.CreateHomePosition());
        RippelGate6 _rippelGate6;
        int i = 0;
        private IInputDeviceBody _inputDeviceBody;
        private DateTime _lastsent = DateTime.Now;
        private object lockobject = new object();
        private IInputDeviceHead _inputDeviceHead;
        private Keyboard _keyboard;
        private IHead _head;
        private DateTime _lastsenthead;

        public frmBase()
        {
            InitializeComponent();
            _rippelGate6 = new RippelGate6(_phoenix, _homePosition);
            KeyPreview = true;

            SetUpHead();
            

            SetUpInputDevises();
            
            _rippelGate6._stepHeight = 2;
        }

        private void SetUpHead()
        {
            HeadServo yawServo = new HeadServo(0, 19, -150, 150);
            HeadServo pitchServo = new HeadServo(0, 20, -90, 80);
            HeadServo rollServo = new HeadServo(-45, 21, -90, 90);
            _head = new Head(yawServo, pitchServo, rollServo);
        }

        private void SetUpInputDevises()
        {
            SetUpInputDeviceForBody();
            SetUpInputDeviceForHead();
         
        }

        private void keyboard_KeyDown(int keycode)
        {
           ((VR920Tracker)_inputDeviceHead).SetZero();
        }

        private void SetUpInputDeviceForHead()
        {
            _inputDeviceHead = new VR920Tracker();
            _inputDeviceHead.MovmentInput += OnHeadMovmentInput;
            ((VR920Tracker)_inputDeviceHead).Enable();
        }

        private void OnHeadMovmentInput(object sender, MovmentEventHeadArg e)
        {
            SetLabelText(e.RollPitchYaw);
            _head.SetPosition(e.RollPitchYaw.LastYaw, e.RollPitchYaw.LastPitch, e.RollPitchYaw.LastRoll);
            if (ReadyToSendHeadCommand())
                SendCommand(_head.GetMovements());
        }

        private void SetLabelText(RollPitchYaw number)
        {
            // label.Text = number.ToString();
            // Do NOT do this, as we are on a different thread.

            // Check if we need to call BeginInvoke.
            if (this.InvokeRequired)
            {
                // Pass the same function to BeginInvoke,
                // but the call would come on the correct
                // thread and InvokeRequired will be false.
                Invoke(new Action<RollPitchYaw>(SetLabelText),new object[] { number});
                return;
            }

            lbRoll.Text = number.LastRoll.ToString();
            lbPitch.Text = number.LastPitch.ToString();
            lbYaw.Text = number.LastYaw.ToString();
            
        }

      


        private void SetUpInputDeviceForBody()
        {
            _inputDeviceBody = new SpaceNavigator();
            _inputDeviceBody.MovmentInput += OnMovmentInput;
        }

        private void OnMovmentInput(object sender, MovmentEventBodyArg e)
        {
            Console.WriteLine("R: " + e.Movment.Rotation);
            if (Math.Abs(e.Movment.Rotation) > 0.1)
            {
                Rotate2(e.Movment);
            }
            else
            {
                Move2(e.Movment);
            }
        }

        private void Move2(Movment movment)
        {
            try
            {
                if (ReadyToSendBodyCommand())
                {
                    Console.WriteLine(movment.Angle);
                    ServoBase.TimeBox = Convert.ToDouble(textBox2.Text);
                    
                    var stepValue = Convert.ToDouble(StepValue.Text) * movment.Direction * movment.Speed;
                    SendCommand(_rippelGate6.NextSequence(movment.Angle, stepValue));
                }

            }
            catch (Exception e)
            {

                MessageBox.Show("timebox");
            }

        }

        private void SendCommand(MovmentComandAX12[] movmentComandAx12S)
        {
            new InstructionPacketSyncMovment(_sender, movmentComandAx12S).Send();
        }

        private void Rotate2(Movment movment)
        {
            try
            {
                if (ReadyToSendBodyCommand())
                {
                    ServoBase.TimeBox = Convert.ToDouble(textBox2.Text);
                    new InstructionPacketSyncMovment(_sender,
                                                     _rippelGate6.NextSequenceRotation(
                                                         movment.Rotation*Convert.ToDouble(degrees.Text),
                                                         movment.CenterX,  movment.CenterY))
                        .Send();
                }

            }
            catch (Exception)
            {

                MessageBox.Show("timebox");
            }
        }

        private bool ReadyToSendBodyCommand()
        {
            lock (lockobject)
            {


                if (_lastsent.AddMilliseconds((int) (ServoBase.TimeBox*1000)) <= DateTime.Now)
                {
                    _lastsent = DateTime.Now;
                    return true;
                }
            }
            return false;
        }

        private bool ReadyToSendHeadCommand()
        {
            lock (lockobject)
            {


                if (_lastsenthead.AddMilliseconds((int)(10)) <= DateTime.Now)
                {
                    _lastsenthead = DateTime.Now;
                    return true;
                }
            }
            return false;
        }


        private void ForwardButton_Click(object sender, EventArgs e)
        {
            Move(90, 1);
        }



        private new void Move(double dir, double dir2)
        {
            try
            {
                ServoBase.TimeBox = Convert.ToDouble(textBox2.Text);
                var stepValue = Convert.ToDouble(StepValue.Text) * dir2;
                new InstructionPacketSyncMovment(_sender, _rippelGate6.NextSequence(dir, stepValue)).Send();
                Thread.Sleep((int)(ServoBase.TimeBox * 1000));
            }
            catch (Exception)
            {

                MessageBox.Show("timebox");
            }
            
        }

        private void Rotate(int i1)
        {
            try
            {
                ServoBase.TimeBox = Convert.ToDouble(textBox2.Text);
                new InstructionPacketSyncMovment(_sender, _rippelGate6.NextSequenceRotation( i1 * Convert.ToDouble(degrees.Text),Convert.ToDouble(xCenter.Text),Convert.ToDouble(zCenter.Text))).Send();
                Thread.Sleep((int)(ServoBase.TimeBox * 1000));
            }
            catch (Exception)
            {

                MessageBox.Show("timebox");
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

          
            switch (e.KeyChar)
            {
                case '8':
                    Move(90, 1);
                    break;
                case '9':
                    Move(45, 1);
                    break;
                case '6':
                    Move(0, 1);
                    break;
                case '3':
                    Move(135, -1);
                    break;
                case '2':
                    Move(270, 1);
                    break;
                case '1':
                    Move(45, -1);
                    break;
                case '4':
                    Move(0, -1);
                    break;
                case '7':
                    Move(135, 1);
                    break;
                case 'a':
                    Rotate(1);
                    break;
                case 'd':
                    Rotate(-1);
                    break;
            }
        }

      

        private void StepValue_Enter(object sender, EventArgs e)
        {
            KeyPreview = false;
        }

        private void StepValue_Leave(object sender, EventArgs e)
        {
            KeyPreview = true;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmBase_Load(object sender, EventArgs e)
        {

        }

        private void btnSetZero_Click(object sender, EventArgs e)
        {
            ((VR920Tracker)_inputDeviceHead).SetZero();
        }

 
    }
}
