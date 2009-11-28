using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace AvCapWPF
{
    internal static class CapHelper
    {
        public static IPin GetPin(this IBaseFilter filter, PinDirection dir, int num)
        {
            IPin[] pin = new IPin[1];
            IEnumPins pinsEnum = null;

            if (filter.EnumPins(out pinsEnum) == 0)
            {
                PinDirection pinDir;
                int n;

                while (pinsEnum.Next(1, pin, out n) == 0)
                {
                   pin[0].QueryDirection(out pinDir);

                    if (pinDir == dir)
                    {
                        if (num == 0)
                            return pin[0];
                        num--;
                    }

                    Marshal.ReleaseComObject(pin[0]);
                    pin[0] = null;
                }
            }
            return null;
        }
    }
}
