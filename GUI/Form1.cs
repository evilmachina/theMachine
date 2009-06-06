using System;
using System.Threading;
using System.Windows.Forms;
using Robot;
using Robot.InstructionPackets;


namespace GUI
{
    public partial class frmBase : Form
    {
        readonly ISender _sender = new CommunicationObject("COM5");
        HomePosition _homePosition = HomePositionFactory.CreateHomePosition();
        Phoenix _phoenix = RobotFactory.CreatePhoenix(HomePositionFactory.CreateHomePosition());
        RippelGate6 _rippelGate6;
        int i = 0;

        public frmBase()
        {
            InitializeComponent();
            _rippelGate6 = new RippelGate6(_phoenix, _homePosition);
            KeyPreview = true;
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
                new InstructionPacketSyncMovment(_sender, _rippelGate6.NextSequence(dir, Convert.ToDouble(StepValue.Text) * dir2)).Send();
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
                    Move(90, -1);
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

 
    }
}
