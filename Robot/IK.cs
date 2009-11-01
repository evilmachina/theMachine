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
using System;

namespace Robot
{
    public class IK
    {
        public static JointAngeles CalculateIK(double coxaLength, double femurLength, double tibiaLength, double x,
                                               double y)
        {
            //The location of the wrist.
            double xWristLocation = locationOfWristX(x, coxaLength);
            double yWristLocation = y;

            double lengthSW = lengthBetwenSolderandWrist(xWristLocation, yWristLocation);
            double a1 = Math.Atan2(xWristLocation, yWristLocation);
            double a2 =
                Math.Acos(
                    ((femurLength * femurLength) - (tibiaLength * tibiaLength) + (lengthSW * lengthSW))
                    / ((2 * femurLength) * lengthSW));

            double femurAngleInRad = a1 + a2;
            double tibiaAngleInRad = Math.Acos(
                ((femurLength * femurLength) + (tibiaLength * tibiaLength) - (lengthSW * lengthSW))
                / ((2 * femurLength) * tibiaLength));

            double femurAngle = RadToDeg(femurAngleInRad);
            double tibiaAngle = RadToDeg(tibiaAngleInRad );

            return new JointAngeles(femurAngle, tibiaAngle);
        }

        public static double lengthBetwenSolderandWrist(double location, double wristLocation)
        {
            return Math.Sqrt(location*location + wristLocation*wristLocation);
        }

        private static double locationOfWristX(double x, double length)
        {
            return x - length;
        }

        public static double CalculateIKOneJoint(double X, double Y)
        {
            return RadToDeg(Math.Atan2(Y, X));
        }

        public static double RadToDeg(double angleInRad)
        {
            return angleInRad*180/Math.PI;
        }

        public static double DegToRad(double degrees)
        {
            return degrees*Math.PI/180;
        }

        public static double Rotate180Degrees(double angleToRotate)
        {
            if(angleToRotate < 0)
            {
                return  -angleToRotate - 180;
            }

            return 180 - angleToRotate;
        }
    }
}