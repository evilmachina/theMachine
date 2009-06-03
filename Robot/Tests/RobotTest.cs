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
using NUnit.Framework;

namespace Robot.Tests
{
    ///<summary>
    ///Tests for the legs
    ///</summary>
    [TestFixture]
    public class RobotTest
    {
        [Test]
        public void SetUpLeftFrontCoxa()
        {
            var lfCoxa = new ServoBase(3.8, 60, 1, -90, 90, Side.Left);

            Assert.AreEqual(3.8, lfCoxa.Length);
            Assert.AreEqual(60, lfCoxa.Offset);
            Assert.AreEqual(1,lfCoxa.ServoId);
            Assert.AreEqual(-90, lfCoxa.MinAngle);
            Assert.AreEqual(90, lfCoxa.MaxAngle);
            Assert.AreEqual(Side.Left, lfCoxa.Side);
        }

        [Test]
        public void SetUpLeftFrontFemur()
        {
            var lfFemur = new ServoBase(3.8, 60, 3, -90, 90, Side.Left);

            Assert.AreEqual(3.8, lfFemur.Length);
            Assert.AreEqual(60, lfFemur.Offset);
            Assert.AreEqual(3, lfFemur.ServoId);
            Assert.AreEqual(-90, lfFemur.MinAngle);
            Assert.AreEqual(90, lfFemur.MaxAngle);
            Assert.AreEqual(Side.Left, lfFemur.Side);
        }

        [Test]
        public void SetUpLeftFrontTibia()
        {
            var lfTibia = new ServoBase(3.8, 60, 5, -90, 90, Side.Left);

            Assert.AreEqual(3.8, lfTibia.Length);
            Assert.AreEqual(60, lfTibia.Offset);
            Assert.AreEqual(5, lfTibia.ServoId);
            Assert.AreEqual(-90, lfTibia.MinAngle);
            Assert.AreEqual(90, lfTibia.MaxAngle); 
            Assert.AreEqual(Side.Left, lfTibia.Side);
        }

        [Test]
        public void CanSetUpLeftFrontLegToPosisionXYZ()
        {
            //var lfCoxa = new Coxa(3.8, 60, 1, -141, 19, Side.Left);
            //var lfFemur = new Femur(7.6, 90, 3, -90, 90, Side.Left);
            //var lfTibia = new Tibia(10.4, 110, 5, -77, 90, Side.Left);


            //Leg LFL = new Leg(lfCoxa, lfFemur, lfTibia, LegPositions.Front, Side.Left);
            //LFL.newPosison(x, y, z);



            //Vill ha vilka vinklar de olika lederna ska vara i med offset;

        }

        [Test]
        public void CanSetUpStartPosisionForPhoenix()
        {
            //Startposision all axis to 0
            HomePosition startPosition = HomePositionFactory.CreateHomePosition3();
            Phoenix phoenix = RobotFactory.CreatePhoenix(startPosition);

            Assert.AreEqual(-60, phoenix.LeftFrontLeg.Coxa.Angle);
            Assert.AreEqual(90, phoenix.LeftFrontLeg.Femur.Angle);
            Assert.AreEqual(90, phoenix.LeftFrontLeg.Tibia.Angle);
            Assert.AreEqual(5.7, phoenix.LeftFrontLeg.X);
            Assert.AreEqual(10.4, phoenix.LeftFrontLeg.Y);
            Assert.AreEqual(-9.9, Math.Round(phoenix.LeftFrontLeg.Z, 1, MidpointRounding.ToEven));

            Assert.AreEqual(-120, phoenix.RightFrontLeg.Coxa.Angle);
            Assert.AreEqual(90, phoenix.RightFrontLeg.Femur.Angle);
            Assert.AreEqual(90, phoenix.RightFrontLeg.Tibia.Angle);
            Assert.AreEqual(-5.7, phoenix.RightFrontLeg.X);
            Assert.AreEqual(10.4, phoenix.RightFrontLeg.Y);
            Assert.AreEqual(-9.9, Math.Round(phoenix.RightFrontLeg.Z,1,MidpointRounding.ToEven));

            Assert.AreEqual(0, phoenix.LeftMiddleLeg.Coxa.Angle);
            Assert.AreEqual(90, phoenix.LeftMiddleLeg.Femur.Angle);
            Assert.AreEqual(90, phoenix.LeftMiddleLeg.Tibia.Angle);
            Assert.AreEqual(11.4, phoenix.LeftMiddleLeg.X);
            Assert.AreEqual(10.4, phoenix.LeftMiddleLeg.Y);
            Assert.AreEqual(0.0, Math.Round(phoenix.LeftMiddleLeg.Z,1,MidpointRounding.ToEven));

            Assert.AreEqual(180, phoenix.RightMiddleLeg.Coxa.Angle);
            Assert.AreEqual(90, phoenix.RightMiddleLeg.Femur.Angle);
            Assert.AreEqual(90, phoenix.RightMiddleLeg.Tibia.Angle);
            Assert.AreEqual(-11.4, phoenix.RightMiddleLeg.X);
            Assert.AreEqual(10.4, phoenix.RightMiddleLeg.Y);
            Assert.AreEqual(0.0, Math.Round(phoenix.RightMiddleLeg.Z,1,MidpointRounding.ToEven));

            Assert.AreEqual(60, phoenix.LeftRearLeg.Coxa.Angle);
            Assert.AreEqual(90, phoenix.LeftRearLeg.Femur.Angle);
            Assert.AreEqual(90, phoenix.LeftRearLeg.Tibia.Angle);
            Assert.AreEqual(5.7, phoenix.LeftRearLeg.X);
            Assert.AreEqual(10.4, phoenix.LeftRearLeg.Y);
            Assert.AreEqual(9.9, Math.Round(phoenix.LeftRearLeg.Z,1,MidpointRounding.ToEven));

            Assert.AreEqual(120, phoenix.RightRearLeg.Coxa.Angle);
            Assert.AreEqual(90, phoenix.RightRearLeg.Femur.Angle);
            Assert.AreEqual(90, phoenix.RightRearLeg.Tibia.Angle);
            Assert.AreEqual(-5.7, phoenix.RightRearLeg.X);
            Assert.AreEqual(10.4, phoenix.RightRearLeg.Y);
            Assert.AreEqual(9.9, Math.Round(phoenix.RightRearLeg.Z,1,MidpointRounding.ToEven));
        }


        [Test]
        public void CanMoveBody1cmFovard()
        {
            //Startposision all axis to 0
            var phoenix = RobotFactory.CreatePhoenix(HomePositionFactory.CreateHomePosition3());

            double distance = 1;
            double direction = 90; //90 is forward
            phoenix.MoveBody(distance, direction);


            Assert.AreEqual(-60 + 2.7, phoenix.LeftFrontLeg.Coxa.Angle);
            Assert.AreEqual(90 - 0.3 , phoenix.LeftFrontLeg.Femur.Angle);
            Assert.AreEqual(90 + - 4.4 , phoenix.LeftFrontLeg.Tibia.Angle);
            Assert.AreEqual(5.7, phoenix.LeftFrontLeg.X);
            Assert.AreEqual(10.4, phoenix.LeftFrontLeg.Y);
            Assert.AreEqual(-8.9, Math.Round(phoenix.LeftFrontLeg.Z,1,MidpointRounding.ToEven));
      

            Assert.AreEqual(-120 - 2.7, phoenix.RightFrontLeg.Coxa.Angle);
            Assert.AreEqual(90 - 0.3, phoenix.RightFrontLeg.Femur.Angle);
            Assert.AreEqual(90 + - 4.4, phoenix.RightFrontLeg.Tibia.Angle);
            Assert.AreEqual(-5.7, phoenix.RightFrontLeg.X);
            Assert.AreEqual(10.4, phoenix.RightFrontLeg.Y);
            Assert.AreEqual(-8.9, Math.Round(phoenix.RightFrontLeg.Z,1,MidpointRounding.ToEven));

            Assert.AreEqual(5.0, phoenix.LeftMiddleLeg.Coxa.Angle);
            Assert.AreEqual(90 - 0, phoenix.LeftMiddleLeg.Femur.Angle);
            Assert.AreEqual(90 + 0.2, phoenix.LeftMiddleLeg.Tibia.Angle);
            Assert.AreEqual(11.4, phoenix.LeftMiddleLeg.X);
            Assert.AreEqual(10.4, phoenix.LeftMiddleLeg.Y);
            Assert.AreEqual(1.0, Math.Round(phoenix.LeftMiddleLeg.Z,1,MidpointRounding.ToEven));

            Assert.AreEqual(180 - 5.0, phoenix.RightMiddleLeg.Coxa.Angle);
            Assert.AreEqual(90, phoenix.RightMiddleLeg.Femur.Angle);
            Assert.AreEqual(90 + 0.2, phoenix.RightMiddleLeg.Tibia.Angle);
            Assert.AreEqual(-11.4, phoenix.RightMiddleLeg.X);
            Assert.AreEqual(10.4, phoenix.RightMiddleLeg.Y);
            Assert.AreEqual(1.0, Math.Round(phoenix.RightMiddleLeg.Z,1,MidpointRounding.ToEven));

            Assert.AreEqual(60 + 2.3, phoenix.LeftRearLeg.Coxa.Angle);
            Assert.AreEqual(90 - 0.3, phoenix.LeftRearLeg.Femur.Angle);
            Assert.AreEqual(90 + 5.1, phoenix.LeftRearLeg.Tibia.Angle);
            Assert.AreEqual(5.7, phoenix.LeftRearLeg.X);
            Assert.AreEqual(10.4, phoenix.LeftRearLeg.Y);
            Assert.AreEqual(10.9, Math.Round(phoenix.LeftRearLeg.Z,1,MidpointRounding.ToEven));

            Assert.AreEqual(120 - 2.3, phoenix.RightRearLeg.Coxa.Angle);
            Assert.AreEqual(90 - 0.3, phoenix.RightRearLeg.Femur.Angle);
            Assert.AreEqual(90 + 5.1, phoenix.RightRearLeg.Tibia.Angle);
            Assert.AreEqual(-5.7, phoenix.RightRearLeg.X);
            Assert.AreEqual(10.4, phoenix.RightRearLeg.Y);
            Assert.AreEqual(10.9, Math.Round(phoenix.RightRearLeg.Z, 1, MidpointRounding.ToEven));
        }

        [Test]
        public void CanMoveBody1cmIn46Degrees()
        {
            //Startposision all axis to Zerro
            var phoenix = RobotFactory.CreatePhoenix(HomePositionFactory.CreateHomePosition3());

            double distance = -1;
            double direction = 46; 
            phoenix.MoveBody(distance, direction);


            Assert.AreEqual(-60 + -6.5, phoenix.LeftFrontLeg.Coxa.Angle);
            Assert.AreEqual(90 - 0.1, phoenix.LeftFrontLeg.Femur.Angle);
            Assert.AreEqual(90 + 2.6, phoenix.LeftFrontLeg.Tibia.Angle);
            Assert.AreEqual(4.7, Math.Round(phoenix.LeftFrontLeg.X, 1, MidpointRounding.ToEven));
            Assert.AreEqual(10.4, Math.Round(phoenix.LeftFrontLeg.Y, 1, MidpointRounding.ToEven));
            Assert.AreEqual(-10.9, Math.Round(phoenix.LeftFrontLeg.Z, 1, MidpointRounding.ToEven));

            

            Assert.AreEqual(-120 + -1.5, phoenix.RightFrontLeg.Coxa.Angle);
            Assert.AreEqual(90 - 0.7, phoenix.RightFrontLeg.Femur.Angle);
            Assert.AreEqual(90 + 8.1, phoenix.RightFrontLeg.Tibia.Angle);
            Assert.AreEqual(-6.7, Math.Round(phoenix.RightFrontLeg.X, 1, MidpointRounding.ToEven));
            Assert.AreEqual(10.4, Math.Round(phoenix.RightFrontLeg.Y, 1, MidpointRounding.ToEven));
            Assert.AreEqual(-10.9, Math.Round(phoenix.RightFrontLeg.Z, 1, MidpointRounding.ToEven));

            Assert.AreEqual(-5.5, phoenix.LeftMiddleLeg.Coxa.Angle);
            Assert.AreEqual(90 - 0.3, phoenix.LeftMiddleLeg.Femur.Angle);
            Assert.AreEqual(90 + -4.8, phoenix.LeftMiddleLeg.Tibia.Angle);
            Assert.AreEqual(10.4, Math.Round(phoenix.LeftMiddleLeg.X, 1, MidpointRounding.ToEven));
            Assert.AreEqual(10.4, Math.Round(phoenix.LeftMiddleLeg.Y, 1, MidpointRounding.ToEven));
            Assert.AreEqual(-1.0, Math.Round(phoenix.LeftMiddleLeg.Z, 1, MidpointRounding.ToEven));

            Assert.AreEqual(-180 + 4.6, phoenix.RightMiddleLeg.Coxa.Angle); //hmmm
            Assert.AreEqual(90 - 0.4, phoenix.RightMiddleLeg.Femur.Angle);
            Assert.AreEqual(90 + 5.9, phoenix.RightMiddleLeg.Tibia.Angle);
            Assert.AreEqual(-12.4, Math.Round(phoenix.RightMiddleLeg.X, 1, MidpointRounding.ToEven));
            Assert.AreEqual(10.4, Math.Round(phoenix.RightMiddleLeg.Y, 1, MidpointRounding.ToEven));
            Assert.AreEqual(-1.0, Math.Round(phoenix.RightMiddleLeg.Z, 1, MidpointRounding.ToEven));

            Assert.AreEqual(60 + 1.9, phoenix.LeftRearLeg.Coxa.Angle);
            Assert.AreEqual(90 - 0.7, phoenix.LeftRearLeg.Femur.Angle);
            Assert.AreEqual(90 + -6.8, phoenix.LeftRearLeg.Tibia.Angle);
            Assert.AreEqual(4.7, Math.Round(phoenix.LeftRearLeg.X, 1, MidpointRounding.ToEven));
            Assert.AreEqual(10.4, Math.Round(phoenix.LeftRearLeg.Y, 1, MidpointRounding.ToEven));
            Assert.AreEqual(8.9, Math.Round(phoenix.LeftRearLeg.Z, 1, MidpointRounding.ToEven));

            Assert.AreEqual(120 - -6.9, phoenix.RightRearLeg.Coxa.Angle);
            Assert.AreEqual(90 - 0.0, phoenix.RightRearLeg.Femur.Angle);
            Assert.AreEqual(90 + -1.6, phoenix.RightRearLeg.Tibia.Angle);
            Assert.AreEqual(-6.7, Math.Round(phoenix.RightRearLeg.X, 1, MidpointRounding.ToEven));
            Assert.AreEqual(10.4, Math.Round(phoenix.RightRearLeg.Y, 1, MidpointRounding.ToEven));
            Assert.AreEqual(8.9, Math.Round(phoenix.RightRearLeg.Z, 1, MidpointRounding.ToEven));
        }

        [Test]
        public void CanMoveBody1cmIn45Degrees()
        {
            //Startposision all axis to Zerro
            var phoenix = RobotFactory.CreatePhoenix(HomePositionFactory.CreateHomePosition3());

            double distance = -1;
            double direction = 45;
            phoenix.MoveBody(distance, direction);

            Assert.AreEqual(-60 + -6.6, phoenix.LeftFrontLeg.Coxa.Angle);
            Assert.AreEqual(90 - 0.1, phoenix.LeftFrontLeg.Femur.Angle);
            Assert.AreEqual(90 + 2.5, phoenix.LeftFrontLeg.Tibia.Angle);
            Assert.AreEqual(4.7, Math.Round(phoenix.LeftFrontLeg.X, 1, MidpointRounding.ToEven));
            Assert.AreEqual(10.4, Math.Round(phoenix.LeftFrontLeg.Y, 1, MidpointRounding.ToEven));
            Assert.AreEqual(-10.9, Math.Round(phoenix.LeftFrontLeg.Z, 1, MidpointRounding.ToEven));

          

            Assert.AreEqual(-120  -1.6, phoenix.RightFrontLeg.Coxa.Angle);
            Assert.AreEqual(90 - 0.7, phoenix.RightFrontLeg.Femur.Angle);
            Assert.AreEqual(90 + 8.3, phoenix.RightFrontLeg.Tibia.Angle);
            Assert.AreEqual(-6.7, Math.Round(phoenix.RightFrontLeg.X, 1, MidpointRounding.ToEven));
            Assert.AreEqual(10.4, Math.Round(phoenix.RightFrontLeg.Y, 1, MidpointRounding.ToEven));
            Assert.AreEqual(-10.9, Math.Round(phoenix.RightFrontLeg.Z, 1, MidpointRounding.ToEven));

            Assert.AreEqual(-5.5, phoenix.LeftMiddleLeg.Coxa.Angle);
            Assert.AreEqual(90 - 0.3, phoenix.LeftMiddleLeg.Femur.Angle);
            Assert.AreEqual(90 + -4.9, phoenix.LeftMiddleLeg.Tibia.Angle);
            Assert.AreEqual(10.4, Math.Round(phoenix.LeftMiddleLeg.X, 1, MidpointRounding.ToEven));
            Assert.AreEqual(10.4, Math.Round(phoenix.LeftMiddleLeg.Y, 1, MidpointRounding.ToEven));
            Assert.AreEqual(-1.0, Math.Round(phoenix.LeftMiddleLeg.Z, 1, MidpointRounding.ToEven));

            Assert.AreEqual(-180 + 4.6, phoenix.RightMiddleLeg.Coxa.Angle);  //hmmm
            Assert.AreEqual(90 - 0.4, phoenix.RightMiddleLeg.Femur.Angle);
            Assert.AreEqual(90 + 6.1, phoenix.RightMiddleLeg.Tibia.Angle);
            Assert.AreEqual(-12.4, Math.Round(phoenix.RightMiddleLeg.X, 1, MidpointRounding.ToEven));
            Assert.AreEqual(10.4, Math.Round(phoenix.RightMiddleLeg.Y, 1, MidpointRounding.ToEven));
            Assert.AreEqual(-1.0, Math.Round(phoenix.RightMiddleLeg.Z, 1, MidpointRounding.ToEven));

            Assert.AreEqual(60 + 2.1, phoenix.LeftRearLeg.Coxa.Angle);
            Assert.AreEqual(90 - 0.7, phoenix.LeftRearLeg.Femur.Angle);
            Assert.AreEqual(90 + -6.8, phoenix.LeftRearLeg.Tibia.Angle);
            Assert.AreEqual(4.7, Math.Round(phoenix.LeftRearLeg.X, 1, MidpointRounding.ToEven));
            Assert.AreEqual(10.4, Math.Round(phoenix.LeftRearLeg.Y, 1, MidpointRounding.ToEven));
            Assert.AreEqual(8.9, Math.Round(phoenix.LeftRearLeg.Z, 1, MidpointRounding.ToEven));

            Assert.AreEqual(120 - -7.1, phoenix.RightRearLeg.Coxa.Angle);
            Assert.AreEqual(90 - 0.0, phoenix.RightRearLeg.Femur.Angle);
            Assert.AreEqual(90 + -1.5, phoenix.RightRearLeg.Tibia.Angle);
            Assert.AreEqual(-6.7, Math.Round(phoenix.RightRearLeg.X, 1, MidpointRounding.ToEven));
            Assert.AreEqual(10.4, Math.Round(phoenix.RightRearLeg.Y, 1, MidpointRounding.ToEven));
            Assert.AreEqual(8.9, Math.Round(phoenix.RightRearLeg.Z, 1, MidpointRounding.ToEven));
        }

        [Test]
        public void CanRotationforLFL()
        {
            //Startposision all axis to Zerro
            var lfl = RobotFactory.createLeg(Side.Left, Position.Front, 60, 1, 3, 5, 4.3, -8.2, new LegPosition(5.7, 10.4, -9.8726896031426));

            double degrees = 5.0;
            double direction = 1;
            Leg.RotateLeg(lfl,degrees,direction,0,0);

            Assert.AreEqual(-60 + 9, lfl.Coxa.Angle);
            Assert.AreEqual(90 - 0.0, lfl.Femur.Angle);
            Assert.AreEqual(90 + 0.5, lfl.Tibia.Angle);

            Assert.AreEqual(7.2, Math.Round(lfl.X, 1, MidpointRounding.ToEven));
            Assert.AreEqual(10.4, Math.Round(lfl.Y, 1, MidpointRounding.ToEven));
            Assert.AreEqual(-8.9, Math.Round(lfl.Z, 1, MidpointRounding.ToEven));
        }

        [Test]
        public void CanRotateBody5DegCW()
        {
            //Startposision all axis to Zerro
            var phoenix = RobotFactory.CreatePhoenix(HomePositionFactory.CreateHomePosition3());

            double degrees = 5.0;
            double direction = 1;
            phoenix.RotateBody(degrees, direction);

            Assert.AreEqual(-60 + 9, phoenix.LeftFrontLeg.Coxa.Angle);
            Assert.AreEqual(90 - 0.0, phoenix.LeftFrontLeg.Femur.Angle);
            Assert.AreEqual(90 +0.5, phoenix.LeftFrontLeg.Tibia.Angle);
            Assert.AreEqual(7.2, Math.Round(phoenix.LeftFrontLeg.X, 1, MidpointRounding.ToEven));
            Assert.AreEqual(10.4, Math.Round(phoenix.LeftFrontLeg.Y, 1, MidpointRounding.ToEven));
            Assert.AreEqual(-8.9, Math.Round(phoenix.LeftFrontLeg.Z, 1, MidpointRounding.ToEven));

            Assert.AreEqual(-120 - -9.1, phoenix.RightFrontLeg.Coxa.Angle); //hmmm
            Assert.AreEqual(90 - 0.0, phoenix.RightFrontLeg.Femur.Angle);
            Assert.AreEqual(90 + 0.2, phoenix.RightFrontLeg.Tibia.Angle);
            Assert.AreEqual(-4.1, Math.Round(phoenix.RightFrontLeg.X, 1, MidpointRounding.ToEven));
            Assert.AreEqual(10.4, Math.Round(phoenix.RightFrontLeg.Y, 1, MidpointRounding.ToEven));
            Assert.AreEqual(-10.7, Math.Round(phoenix.RightFrontLeg.Z, 1, MidpointRounding.ToEven));

            Assert.AreEqual(7.8, phoenix.LeftMiddleLeg.Coxa.Angle);
            Assert.AreEqual(90 - 0.0, phoenix.LeftMiddleLeg.Femur.Angle);
            Assert.AreEqual(90 + 0.2, phoenix.LeftMiddleLeg.Tibia.Angle);
            Assert.AreEqual(11.3, Math.Round(phoenix.LeftMiddleLeg.X, 1, MidpointRounding.ToEven));
            Assert.AreEqual(10.4, Math.Round(phoenix.LeftMiddleLeg.Y, 1, MidpointRounding.ToEven));
            Assert.AreEqual(1.5, Math.Round(phoenix.LeftMiddleLeg.Z, 1, MidpointRounding.ToEven));

            Assert.AreEqual(-180 + 7.8, phoenix.RightMiddleLeg.Coxa.Angle); //hmmm
            Assert.AreEqual(90  - 0.0, phoenix.RightMiddleLeg.Femur.Angle);
            Assert.AreEqual(90 + 0.2, phoenix.RightMiddleLeg.Tibia.Angle);
            Assert.AreEqual(-11.3, Math.Round(phoenix.RightMiddleLeg.X, 1, MidpointRounding.ToEven));
            Assert.AreEqual(10.4, Math.Round(phoenix.RightMiddleLeg.Y, 1, MidpointRounding.ToEven));
            Assert.AreEqual(-1.5, Math.Round(phoenix.RightMiddleLeg.Z, 1, MidpointRounding.ToEven));

            Assert.AreEqual(60 + 9.1, phoenix.LeftRearLeg.Coxa.Angle);
            Assert.AreEqual(90 - 0.0, phoenix.LeftRearLeg.Femur.Angle);
            Assert.AreEqual(90 + 0.2, phoenix.LeftRearLeg.Tibia.Angle);
            Assert.AreEqual(4.1, Math.Round(phoenix.LeftRearLeg.X, 1, MidpointRounding.ToEven));
            Assert.AreEqual(10.4, Math.Round(phoenix.LeftRearLeg.Y, 1, MidpointRounding.ToEven));
            Assert.AreEqual(10.7, Math.Round(phoenix.LeftRearLeg.Z, 1, MidpointRounding.ToEven));

            Assert.AreEqual(120 - -9.0, phoenix.RightRearLeg.Coxa.Angle);
            Assert.AreEqual(90 - 0.0, phoenix.RightRearLeg.Femur.Angle);
            Assert.AreEqual(90 + 0.5, phoenix.RightRearLeg.Tibia.Angle);
            Assert.AreEqual(-7.2, Math.Round(phoenix.RightRearLeg.X, 1, MidpointRounding.ToEven));
            Assert.AreEqual(10.4, Math.Round(phoenix.RightRearLeg.Y, 1, MidpointRounding.ToEven));
            Assert.AreEqual(8.9, Math.Round(phoenix.RightRearLeg.Z, 1, MidpointRounding.ToEven));
        }

    }
}
