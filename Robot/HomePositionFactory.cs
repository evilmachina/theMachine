// Copyright (c) 2009 Marcus Olsson
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
// 
namespace Robot
{
    public class HomePositionFactory
    {
        public static HomePosition CreateHomePosition()
        {
            var Y = 5;
            HomePosition homePosition = new HomePosition
                (
                new LegPosition(5.7, Y, -9.8726896031426),
                new LegPosition(-5.7, Y, -9.8726896031426),
                new LegPosition(11.4, Y, 0.0),
                new LegPosition(-11.4, Y, 0.0),
                new LegPosition(5.7, Y, 9.8726896031426),
                new LegPosition(-5.7, Y, 9.8726896031426)
                );
            return homePosition;
        }

        public static HomePosition CreateHomePosition2()
        {
            var Y = 10.4;
            HomePosition homePosition = new HomePosition(new LegPosition(11.4, Y, 0.0), new LegPosition(-11.4, Y, 0.0),
                                                         new LegPosition(11.4, Y, 0.0), new LegPosition(-11.4, Y, 0.0),
                                                         new LegPosition(11.4, Y, 0.0), new LegPosition(-11.4, Y, 0.0));
            return homePosition;
        }

        public static HomePosition CreateHomePosition3()
        {
            var Y = 10.4;
            HomePosition homePosition = new HomePosition(

                new LegPosition(5.7, Y, -9.8726896031426),
                new LegPosition(-5.7, Y, -9.8726896031426),
                new LegPosition(11.4, Y, 0.0),
                new LegPosition(-11.4, Y, 0.0),
                new LegPosition(5.7, Y, 9.8726896031426),
                new LegPosition(-5.7, Y, 9.8726896031426)

                );
            return homePosition;
        }

        public static HomePosition CreateHomePosition4()
        {
            var Y = 10.4;
            HomePosition homePosition = new HomePosition(

                new LegPosition(5.7, Y, -9.8726896031426),
                new LegPosition(-5.7, Y, -9.8726896031426),
                new LegPosition(11.4, Y, 0.0),
                new LegPosition(-11.4, Y, 0.0),
                new LegPosition(5.7, Y, 9.8726896031426),
                new LegPosition(-5.7, Y, 9.8726896031426)
                );
            return homePosition;
        }

        public static HomePosition CreateHomePosition5()
        {
            var Y = 17;
            HomePosition homePosition = new HomePosition(

                new LegPosition(5.7/2, Y, -9.8726896031426/2),
                new LegPosition(-5.7 / 2, Y, -9.8726896031426 / 2),
                new LegPosition(11.4 / 2, Y, 0.0),
                new LegPosition(-11.4 / 2, Y, 0.0),
                new LegPosition(5.7 / 2, Y, 9.8726896031426 / 2),
                new LegPosition(-5.7 / 2, Y, 9.8726896031426 / 2)
                );
            return homePosition;
        }

       
    }
}