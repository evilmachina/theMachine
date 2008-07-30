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
    }
}
