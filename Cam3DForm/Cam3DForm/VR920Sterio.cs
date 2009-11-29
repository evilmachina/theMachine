using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace WebCamCapture
{
    class VR920Sterio : IDisposable
    {
        [DllImport("iWrstDrv.dll", EntryPoint = "IWRSTEREO_Open", SetLastError = true)]
        public static extern IntPtr OpenStereo();

        [DllImport("iWrstDrv.dll", EntryPoint = "IWRSTEREO_SetStereo")]
        public static extern Boolean SetStereoEnabled(IntPtr handle, Boolean enabled);

        [DllImport("iWrstDrv.dll", EntryPoint = "IWRSTEREO_SetLR")]
        public static extern Boolean SetStereoLR(IntPtr handle, Boolean eye);

        [DllImport("iWrstDrv.dll", EntryPoint = "IWRSTEREO_WaitForAck")]
        public static extern Byte WaitForOpenFrame(IntPtr handle, Boolean eye);

        private static readonly IntPtr INVALID_FILE_HANDLE = (IntPtr)(-1);

        private IntPtr _hStereo = INVALID_FILE_HANDLE;
        private bool _stereoEnabled = true;


        public void Start()
        {
             _hStereo = OpenStereo();
            if (_hStereo != INVALID_FILE_HANDLE)
                SetStereoEnabled(_hStereo, true);
            else
                _stereoEnabled = false;
        }

        public void SetEye(bool rightEye)
        {
            SetStereoLR(_hStereo, rightEye);
            WaitForOpenFrame(_hStereo, rightEye);
        }

        public void Dispose()
        {
            SetStereoEnabled(_hStereo, false);
        }
    }
}
