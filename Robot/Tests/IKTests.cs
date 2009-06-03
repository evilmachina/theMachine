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
            Assert.AreEqual(90, jointAngeles.FemurAngle,2);
            Assert.AreEqual(90, jointAngeles.TibiaAngle);
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
            Assert.AreEqual(159.26, Math.Round(jointAngeles.TibiaAngle, 2, MidpointRounding.ToEven));
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
            Assert.AreEqual(50.88, Math.Round(jointAngeles.TibiaAngle, 2, MidpointRounding.ToEven));
        }


        [Test]
        public void TestCanCalculateIKForAngleInFirstQuadrant()
        {
            double angle = IK.CalculateIKOneJoint(1, 1);
            Assert.AreEqual(45, angle);
        }

        [Test]
        public void TestCanCalculateIKForAngleInSecondQuadrant()
        {
            double angle = IK.CalculateIKOneJoint(-1, 1);
            Assert.AreEqual(135, angle);
        }

        [Test]
        public void TestCanCalculateIKForAngleInThirdQuadrant()
        {
            double angle = IK.CalculateIKOneJoint(-1, -1);
            Assert.AreEqual(-135, angle);
        }

        [Test]
        public void TestCanCalculateIKForAngleInForthQuadrant()
        {
            double angle = IK.CalculateIKOneJoint(1, -1);
            Assert.AreEqual(-45, angle);
        }

        [Test]
        public void TestCanRotateAngelInFirstQuadrant180Degrees()
        {
            double angleToRotate = 45;
            double newAngle = IK.Rotate180Degrees(angleToRotate);
            Assert.AreEqual(135,newAngle);
        }

        [Test]
        public void TestCanRotateAngelInSecondQuadrant180Degrees()
        {
            double angleToRotate = 135;
            double newAngle = IK.Rotate180Degrees(angleToRotate);
            Assert.AreEqual(45, newAngle);
        }

        [Test]
        public void TestCanRotateAngelInThirdQuadrant180Degrees()
        {
            double angleToRotate = -135;
            double newAngle = IK.Rotate180Degrees(angleToRotate);
            Assert.AreEqual(-45, newAngle);
        }

        [Test]
        public void TestCanRotateAngelInForthQuadrant180Degrees()
        {
            double angleToRotate = -45;
            double newAngle = IK.Rotate180Degrees(angleToRotate);
            Assert.AreEqual(-135, newAngle);
        }

        [Test]
        public void TestCanRotateAngelOf180180Degrees()
        {
            double angleToRotate = 180;
            double newAngle = IK.Rotate180Degrees(angleToRotate);
            Assert.AreEqual(0, newAngle);
        }

        [Test]
        public void TestCanRotateAngelOfZero180Degrees()
        {
            double angleToRotate = 0;
            double newAngle = IK.Rotate180Degrees(angleToRotate);
            Assert.AreEqual(180, newAngle);
        }

   
    }
}