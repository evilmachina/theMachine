using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using IDataObject = System.Runtime.InteropServices.ComTypes.IDataObject;

namespace WebCamCapture
{
    public class WebCamCaptur : IDisposable
    {
        private int m_TimeToCapture_milliseconds = 100;
        private int m_Width = 320;
        private int m_Height = 240;
        private int mCapHwnd;
        private ulong m_FrameNumber = 0;

		
        private System.Windows.Forms.IDataObject tempObj;
        private Image tempImg;
		


        #region API Declarations

        [DllImport("user32", EntryPoint="SendMessage")]
        public static extern int SendMessage(int hWnd, uint Msg, int wParam, int lParam);

        [DllImport("avicap32.dll", EntryPoint="capCreateCaptureWindowA")]
        public static extern int capCreateCaptureWindowA(string lpszWindowName, int dwStyle, int X, int Y, int nWidth, int nHeight, int hwndParent, int nID);

        [DllImport("user32", EntryPoint="OpenClipboard")]
        public static extern int OpenClipboard(int hWnd);

        [DllImport("user32", EntryPoint="EmptyClipboard")]
        public static extern int EmptyClipboard();

        [DllImport("user32", EntryPoint="CloseClipboard")]
        public static extern int CloseClipboard();

        #endregion

        #region API Constants

        public const int WM_USER = 1024;

        public const int WM_CAP_CONNECT = 1034;
        public const int WM_CAP_DISCONNECT = 1035;
        public const int WM_CAP_GET_FRAME = 1084;
        public const int WM_CAP_COPY = 1054;

        public const int WM_CAP_START = WM_USER;

        public const int WM_CAP_DLG_VIDEOFORMAT = WM_CAP_START + 41;
        public const int WM_CAP_DLG_VIDEOSOURCE = WM_CAP_START + 42;
        public const int WM_CAP_DLG_VIDEODISPLAY = WM_CAP_START + 42;
        public const int WM_CAP_GET_VIDEOFORMAT = WM_CAP_START + 44;
        public const int WM_CAP_SET_VIDEOFORMAT = WM_CAP_START + 45;
        public const int WM_CAP_DLG_VIDEOCOMPRESSION = WM_CAP_START + 46;
        public const int WM_CAP_SET_PREVIEW = WM_CAP_START + 50;

        #endregion

        #region NOTES

        /*
		 * If you want to allow the user to change the display size and 
		 * color format of the video capture, call:
		 * SendMessage (mCapHwnd, WM_CAP_DLG_VIDEOFORMAT, 0, 0);
		 * You will need to requery the capture device to get the new settings
		*/

        #endregion


      



        /// <summary>
        /// The height of the video capture image
        /// </summary>
        public int CaptureHeight
        {
            get
            { return m_Height; }
			
            set
            { m_Height = value; }
        }

        /// <summary>
        /// The width of the video capture image
        /// </summary>
        public int CaptureWidth
        {
            get
            { return m_Width; }

            set
            { m_Width = value; }
        }

        public void ShowVideoDialog()
        {
            SendMessage(mCapHwnd, WM_CAP_DLG_VIDEODISPLAY, 0, 0);
        }


        /// <summary>
        /// Starts the video capture
        /// </summary>
        /// <param name="FrameNumber">the frame number to start at. 
        /// Set to 0 to let the control allocate the frame number</param>
        public void Start( int handle)
        {
            try
            {
                
                this.Stop();

                mCapHwnd = capCreateCaptureWindowA("WebCap", 0, 0, 0, m_Width, m_Height, handle, 0);

                SendMessage(mCapHwnd, WM_CAP_CONNECT, 0, 0);
                SendMessage(mCapHwnd, WM_CAP_SET_PREVIEW, 0, 0);

                ShowVideoDialog();
				
            }

            catch (Exception excep)
            { 
                this.Stop();
            }
        }

        /// <summary>
        /// Stops the video capture
        /// </summary>
        public void Stop()
        {
            try
            {
                SendMessage(mCapHwnd, WM_CAP_DISCONNECT, 0, 0);
            }

            catch (Exception excep)
            { // don't raise an error here.
            }

        }

        #region Video Capture Code

        /// <summary>
        /// Capture the next frame from the video feed
        /// </summary>
        public Image GetNextFrame()
        {

            try
            {
				
                // get the next frame;
                SendMessage(mCapHwnd, WM_CAP_GET_FRAME, 0, 0);

                // copy the frame to the clipboard
                SendMessage(mCapHwnd, WM_CAP_COPY, 0, 0);

                //if (ImageCaptured != null)
                {
                    // get from the clipboard
                    tempObj = Clipboard.GetDataObject();
                    tempImg = (System.Drawing.Bitmap) tempObj.GetData(System.Windows.Forms.DataFormats.Bitmap);

               
                   // return tempImg.GetThumbnailImage(m_Width, m_Height, null, System.IntPtr.Zero);

					
                }
			   
            }

            catch (Exception excep)
            { 
                //MessageBox.Show("An error ocurred while capturing the video image. The video capture will now be terminated.\r\n\n" + excep.Message);
                //	this.Stop(); // stop the process
            }

            return tempImg;
        }

        #endregion

        public void Dispose()
        {
            Stop();
        }
    }
}


