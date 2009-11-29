using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace AvCapWPF
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private int i = 0;
        private bool _rightEye;


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
        private bool _stereoEnabled =  true;

        public Window1()
        {
            InitializeComponent();
            
        }

        

        private void onUpdate(object sender, ElapsedEventArgs e)
        {
            update();
        }
        

        private void update()
        {
            lock (this)
            {


                if (_hStereo != INVALID_FILE_HANDLE && _stereoEnabled)
                {
                    if (_rightEye)
                    {
                        playerR.Visibility = Visibility.Hidden;
                        playerL.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        playerR.Visibility = Visibility.Visible;
                        playerL.Visibility = Visibility.Hidden;
                    }

                    SetStereoLR(_hStereo, _rightEye);
                    WaitForOpenFrame(_hStereo, _rightEye);
                    _rightEye = !_rightEye;
                }
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            _hStereo = OpenStereo();
            if (_hStereo != INVALID_FILE_HANDLE)
                SetStereoEnabled(_hStereo, true);
            else
                _stereoEnabled = false;

            DispatcherTimer timer = new DispatcherTimer(TimeSpan.FromMilliseconds(100), DispatcherPriority.Normal, delegate
            {
                update();
            }, this.Dispatcher);
        }

        private void wnd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down)
            {
                Thickness t = playerL.Margin;
                t.Top++;
                t.Bottom--;
                playerL.Margin = t;
            }
            else if (e.Key == Key.Up)
            {
                Thickness t = playerL.Margin;
                t.Top--;
                t.Bottom++;
                playerL.Margin = t;
            }
            else if (e.Key == Key.Left)
            {
                Thickness t = playerL.Margin;
                t.Left--;
                t.Right++;
                playerL.Margin = t;
            }
            else if (e.Key == Key.Right)
            {
                Thickness t = playerL.Margin;
                t.Left++;
                t.Right--;
                playerL.Margin = t;
            }
        }

      
       
    }

    

    public class ScaleConverter : IMultiValueConverter
    {


        #region IMultiValueConverter Members

        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            float v = (float)values[0];
            double m = (double)values[1];
            return v * m / 50;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

}
