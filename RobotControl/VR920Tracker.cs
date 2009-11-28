using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;


namespace RobotControl
{
    public class VR920Tracker : IInputDeviceHead
    {
        [DllImport("IWEARDRV.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern int IWROpenTracker();

        [DllImport("IWEARDRV.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern void IWRZeroSet();

        [DllImport("IWEARDRV.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern int IWRGetTracking(out int yaw, out int pitch, out int roll);

        private const int ERROR_SUCCESS = 0;

        private const int TimerPeriod = 1;

      //  private MainForm _mainForm;
        private Timer _timer;

        // collection of values for averaging
        private List<double> _yawValues = new List<double>();
        private List<double> _rollValues = new List<double>();
        private List<double> _pitchValues = new List<double>();

        // last calculated values
        private double _lastYaw;
        private double _lastPitch;
        private double _lastRoll;

        public VR920Tracker()
        {
            ConnectToVR920();
            StartPollingVR920();
        }

        private void ConnectToVR920()
        { 
            int openResult = IWROpenTracker();
            if (openResult != ERROR_SUCCESS)
                throw new ApplicationException("Could not connect to VR920: " + openResult);
        }

        private void StartPollingVR920()
        {
            _timer = new Timer(VR920Poller, null, Timeout.Infinite, TimerPeriod);
        }

     
        private void VR920Poller(object state)
        {
            lock (this)
            {
                int yaw, pitch, roll;

                GetTracking(out yaw, out roll, out pitch);

                _yawValues.Add(VR920ToDegrees(yaw));
                _rollValues.Add(VR920ToDegrees(roll));
                _pitchValues.Add(VR920ToDegrees(pitch));

                if (_yawValues.Count == 5)
                {
                    double y = Average(_yawValues, _lastYaw);
                    if (Math.Abs(y - _lastYaw) > 0.026)
                        _lastYaw = y;

                    double p = Average(_pitchValues, _lastPitch);
                    if (Math.Abs(p - _lastPitch) > 0.017)
                        _lastPitch = p;

                    _lastRoll = Average(_rollValues, _lastRoll);

                    _yawValues.Clear();
                    _pitchValues.Clear();
                    _rollValues.Clear();
                    

                    RollPitchYaw rollPitchYaw = new RollPitchYaw(_lastRoll, _lastPitch, _lastYaw);
                    MovmentEventHeadArg movmentEventHeadArg = new MovmentEventHeadArg(rollPitchYaw);
                    InvokeMovmentInput(movmentEventHeadArg);
                }
            }
        }

        private void GetTracking(out int yaw, out int roll, out int pitch)
        {
            int result = IWRGetTracking(out yaw, out pitch, out roll);

            if (result != ERROR_SUCCESS)
                throw new ApplicationException("Could not get VR920 tracking information: " + result);
        }

        private double Average(List<double> values, double last)
        {
            double total = 0;

            foreach (double value in values)
                total += value;

            total += last;

            return total / (values.Count + 1);
        }


        private static double VR920ToDegrees(int vr920Value)
        {
            return (vr920Value * .00549);
        }

        public void SetZero()
        {
            IWRZeroSet();
        }

        public void Enable()
        {
            _timer.Change(0, TimerPeriod);
        }

        public void Disable()
        {
            _timer.Change(Timeout.Infinite, TimerPeriod);
        }

        public event EventHandler<MovmentEventHeadArg> MovmentInput;

        public void InvokeMovmentInput(MovmentEventHeadArg e)
        {
            EventHandler<MovmentEventHeadArg> handler = MovmentInput;
            if (handler != null) handler(this, e);
        }
    }
}