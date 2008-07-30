using System;
using NUnit.Framework;
using TestProj;

namespace Robot.Tests
{
    [TestFixture]
    public class IKTests
    {
        [Test]
        public void CanCalculateIKForX10_5Y10_4()
        {
            double coxaLength = 2.9;
            double femurLength = 7.6;
            double tibiaLength = 10.4;

            double X = 10.5;
            double Y = 10.4;

            JointAngeles jointAngeles = IK.CalculateIK(coxaLength, femurLength, tibiaLength, X, Y);
            Assert.AreEqual(90, jointAngeles.FemurAngle);
            Assert.AreEqual(-90, jointAngeles.TibiaAngle);
        }


        [Test]
        public void CanCalculateIKForX10_5Y16()
        {
            double coxaLength = 2.9;
            double femurLength = 7.6;
            double tibiaLength = 10.4;

            double X = 10.5;
            double Y = 16;

            JointAngeles jointAngeles = IK.CalculateIK(coxaLength, femurLength, tibiaLength, X, Y);

            Assert.AreEqual(37.41, Math.Round(jointAngeles.FemurAngle, 2, MidpointRounding.ToEven));
            Assert.AreEqual(-20.74, Math.Round(jointAngeles.TibiaAngle, 2, MidpointRounding.ToEven));
        }

        [Test]
        public void CanCalculateIKForX10_5Y2_9()
        {
            double coxaLength = 2.9;
            double femurLength = 7.6;
            double tibiaLength = 10.4;

            double X = 10.5;
            double Y = 2.9;

            JointAngeles jointAngeles = IK.CalculateIK(coxaLength, femurLength, tibiaLength, X, Y);

            Assert.AreEqual(151.79, Math.Round(jointAngeles.FemurAngle, 2, MidpointRounding.ToEven));
            Assert.AreEqual(-129.12, Math.Round(jointAngeles.TibiaAngle, 2, MidpointRounding.ToEven));
        }
    }
}