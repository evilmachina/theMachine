using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WebCamCapture;

namespace Cam3DForm
{
    public partial class Form1 : Form
    {
        private Timer imageUpdateTimer;
        private WebCamCaptur cammeraLeft;
        private WebCamCaptur cammeraRight;
        private bool right;
        private VR920Sterio _VR920Sterio;

        public Form1()
        {
            InitializeComponent();
            cammeraLeft = new WebCamCaptur();
            cammeraRight = new WebCamCaptur();
            _VR920Sterio = new VR920Sterio();
            SetUpUpdateTimer();
        }

        private void SetUpUpdateTimer()
        {
            imageUpdateTimer = new Timer();
            imageUpdateTimer.Interval = 30;
            imageUpdateTimer.Tick += OnimageUpdateTimerTick;
        }


        private void OnimageUpdateTimerTick(object sender, EventArgs e)
        {
            imageUpdateTimer.Stop();
            if(right)
            {
                rightCameraImage.Image = cammeraRight.GetNextFrame();
               
            }
            else
            {
                leftCameraImage.Image = cammeraLeft.GetNextFrame();
            }
            
            rightCameraImage.Visible = right;
            leftCameraImage.Visible = !right;
           
            _VR920Sterio.SetEye(right);
            right = !right;
            
           imageUpdateTimer.Start();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            cammeraLeft.Start(Handle.ToInt32());
            cammeraRight.Start(Handle.ToInt32());
            _VR920Sterio.Start();
            imageUpdateTimer.Start();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _VR920Sterio.Dispose();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S)
            {
                Point newLocation = rightCameraImage.Location;
                newLocation.Y++;
                rightCameraImage.Location = newLocation;
            }
            else if (e.KeyCode == Keys.W)
            {
                Point newLocation = rightCameraImage.Location;
                newLocation.Y--;
                rightCameraImage.Location = newLocation;
            }
            else if (e.KeyCode == Keys.A)
            {
                Point newLocation = rightCameraImage.Location;
                newLocation.X++;
                rightCameraImage.Location = newLocation;
            }
            else if (e.KeyCode == Keys.D)
            {
                Point newLocation = rightCameraImage.Location;
                newLocation.X--;
                rightCameraImage.Location = newLocation;
            }
        }
    }
}
