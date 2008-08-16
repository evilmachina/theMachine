using System;
using Robot;

namespace Robot
{
    public class IK
    {


        public static JointAngeles CalculateIK_Old(double coxaLength, double femurLength, double tibiaLength, double x,
                                               double y)
        {
            //The location of the wrist.
            double xWristLocation = locationOfWristX(x, coxaLength);
            double yWristLocation = y;

            double lengthSW = lengthBetwenSolderandWrist(xWristLocation, yWristLocation);
            double a1 = Math.Atan2(xWristLocation, yWristLocation);
            double a2 =
                Math.Acos(
                    ((femurLength*femurLength) - (tibiaLength*tibiaLength) + (lengthSW*lengthSW))
                    /((2*femurLength)*lengthSW));

            double femurAngleInRad = a1 + a2;
            double tibiaAngleInRad = Math.Acos(
                ((femurLength*femurLength) + (tibiaLength*tibiaLength) - (lengthSW*lengthSW))
                /((2*femurLength)*tibiaLength));

            double femurAngle = femurAngleInRad*180/Math.PI;
            double tibiaAngle = -(180 - RadToDeg(tibiaAngleInRad));

            return new JointAngeles(femurAngle, tibiaAngle);
        }

       

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

            double femurAngle = -(femurAngleInRad * 180 / Math.PI) + 90;
            double tibiaAngle = -(90 -((tibiaAngleInRad * 180 / Math.PI))) ;

            return new JointAngeles(femurAngle, tibiaAngle);
        }

        private static double lengthBetwenSolderandWrist(double location, double wristLocation)
        {
            return Math.Sqrt(location*location + wristLocation*wristLocation);
        }

        private static double locationOfWristX(double x, double length)
        {
            return x - length;
        }

        public static double CalculateIKOneJoint(double X, double Z)
        {
            return (Math.Atan2(Z, X) * 180 / Math.PI);
        }

        public static double RadToDeg(double angleInRad)
        {
            return angleInRad*180/Math.PI;
        }

        public static double DegToRad(double degrees)
        {
            return degrees*Math.PI/180;
        }
    }
}