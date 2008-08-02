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
            var lfCoxa = new Coxa(3.8, 60, 1, -90, 90, Side.Left);

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
            var lfFemur = new Femur(3.8, 60, 3, -90, 90, Side.Left);

            Assert.AreEqual(3.8, lfFemur.Length);
            Assert.AreEqual(60, lfFemur.Offset);
            Assert.AreEqual(1, lfFemur.ServoId);
            Assert.AreEqual(-90, lfFemur.MinAngle);
            Assert.AreEqual(90, lfFemur.MaxAngle);
            Assert.AreEqual(Side.Left, lfFemur.Side);
        }

        [Test]
        public void SetUpLeftFrontTibia()
        {
            var lfTibia = new Tibia(3.8, 60, 5, -90, 90, Side.Left);

            Assert.AreEqual(3.8, lfTibia.Length);
            Assert.AreEqual(60, lfTibia.Offset);
            Assert.AreEqual(1, lfTibia.ServoId);
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
            Phoenix phoenix = RobotFactory.CreatePhoenix();

            Assert.AreEqual(0, phoenix.lfl.Coxa.Angle);
            Assert.AreEqual(0, phoenix.lfl.Femur.Angle);
            Assert.AreEqual(0, phoenix.lfl.Tibia.Angle);
            Assert.AreEqual(5.7, phoenix.lfl.X);
            Assert.AreEqual(10.4, phoenix.lfl.Y);
            Assert.AreEqual(-9.9, Math.Round(phoenix.lfl.Z, 1, MidpointRounding.ToEven));

            Assert.AreEqual(0, phoenix.rfl.Coxa.Angle);
            Assert.AreEqual(0, phoenix.rfl.Femur.Angle);
            Assert.AreEqual(0, phoenix.rfl.Tibia.Angle);
            Assert.AreEqual(5.7, phoenix.rfl.X);
            Assert.AreEqual(10.4, phoenix.rfl.Y);
            Assert.AreEqual(-9.9, Math.Round(phoenix.rfl.Z,1,MidpointRounding.ToEven));

            Assert.AreEqual(0, phoenix.lml.Coxa.Angle);
            Assert.AreEqual(0, phoenix.lml.Femur.Angle);
            Assert.AreEqual(0, phoenix.lml.Tibia.Angle);
            Assert.AreEqual(11.4, phoenix.lml.X);
            Assert.AreEqual(10.4, phoenix.lml.Y);
            Assert.AreEqual(0.0, Math.Round(phoenix.lml.Z,1,MidpointRounding.ToEven));

            Assert.AreEqual(0, phoenix.rml.Coxa.Angle);
            Assert.AreEqual(0, phoenix.rml.Femur.Angle);
            Assert.AreEqual(0, phoenix.rml.Tibia.Angle);
            Assert.AreEqual(11.4, phoenix.rml.X);
            Assert.AreEqual(10.4, phoenix.rml.Y);
            Assert.AreEqual(0.0, Math.Round(phoenix.rml.Z,1,MidpointRounding.ToEven));

            Assert.AreEqual(0, phoenix.lrl.Coxa.Angle);
            Assert.AreEqual(0, phoenix.lrl.Femur.Angle);
            Assert.AreEqual(0, phoenix.lrl.Tibia.Angle);
            Assert.AreEqual(5.7, phoenix.lrl.X);
            Assert.AreEqual(10.4, phoenix.lrl.Y);
            Assert.AreEqual(9.9, Math.Round(phoenix.lrl.Z,1,MidpointRounding.ToEven));

            Assert.AreEqual(0, phoenix.rrl.Coxa.Angle);
            Assert.AreEqual(0, phoenix.rrl.Femur.Angle);
            Assert.AreEqual(0, phoenix.rrl.Tibia.Angle);
            Assert.AreEqual(5.7, phoenix.rrl.X);
            Assert.AreEqual(10.4, phoenix.rrl.Y);
            Assert.AreEqual(9.9, Math.Round(phoenix.rrl.Z,1,MidpointRounding.ToEven));
        }


        [Test]
        public void CanMoveBody1cmFovard()
        {
            //Startposision all axis to 0
            var phoenix = RobotFactory.CreatePhoenix();

            double distance = 1;
            double direction = 90; //90 is forward
            phoenix.MoveBody(distance, direction);

            Assert.AreEqual(5.7, phoenix.lfl.X);
            Assert.AreEqual(10.4, phoenix.lfl.Y);
            Assert.AreEqual(-8.9, Math.Round(phoenix.lfl.Z,1,MidpointRounding.ToEven));

            Assert.AreEqual(0.3, phoenix.lfl.Femur.Angle);
            Assert.AreEqual(-4.4, phoenix.lfl.Tibia.Angle);
            Assert.AreEqual(2.7, phoenix.lfl.Coxa.Angle);

            Assert.AreEqual(2.7, phoenix.rfl.Coxa.Angle);
            Assert.AreEqual(0.3, phoenix.rfl.Femur.Angle);
            Assert.AreEqual(-4.4, phoenix.rfl.Tibia.Angle);
            Assert.AreEqual(5.7, phoenix.rfl.X);
            Assert.AreEqual(10.4, phoenix.rfl.Y);
            Assert.AreEqual(-8.9, Math.Round(phoenix.rfl.Z,1,MidpointRounding.ToEven));

            Assert.AreEqual(5.0, phoenix.lml.Coxa.Angle);
            Assert.AreEqual(0, phoenix.lml.Femur.Angle);
            Assert.AreEqual(0.2, phoenix.lml.Tibia.Angle);
            Assert.AreEqual(11.4, phoenix.lml.X);
            Assert.AreEqual(10.4, phoenix.lml.Y);
            Assert.AreEqual(1.0, Math.Round(phoenix.lml.Z,1,MidpointRounding.ToEven));

            Assert.AreEqual(5.0, phoenix.rml.Coxa.Angle);
            Assert.AreEqual(0, phoenix.rml.Femur.Angle);
            Assert.AreEqual(0.2, phoenix.rml.Tibia.Angle);
            Assert.AreEqual(11.4, phoenix.rml.X);
            Assert.AreEqual(10.4, phoenix.rml.Y);
            Assert.AreEqual(1.0, Math.Round(phoenix.rml.Z,1,MidpointRounding.ToEven));

            Assert.AreEqual(2.3, phoenix.lrl.Coxa.Angle);
            Assert.AreEqual(0.3, phoenix.lrl.Femur.Angle);
            Assert.AreEqual(5.1, phoenix.lrl.Tibia.Angle);
            Assert.AreEqual(5.7, phoenix.lrl.X);
            Assert.AreEqual(10.4, phoenix.lrl.Y);
            Assert.AreEqual(10.9, Math.Round(phoenix.lrl.Z,1,MidpointRounding.ToEven));

            Assert.AreEqual(2.3, phoenix.rrl.Coxa.Angle);
            Assert.AreEqual(0.3, phoenix.rrl.Femur.Angle);
            Assert.AreEqual(5.1, phoenix.rrl.Tibia.Angle);
            Assert.AreEqual(5.7, phoenix.rrl.X);
            Assert.AreEqual(10.4, phoenix.rrl.Y);
            Assert.AreEqual(10.9, Math.Round(phoenix.rrl.Z, 1, MidpointRounding.ToEven));
        }

      
    }
}
