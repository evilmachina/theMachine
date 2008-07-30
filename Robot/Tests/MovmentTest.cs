using System.Collections.Generic;
using NUnit.Framework;
using TestProj;

namespace Robot.Tests
{
    [TestFixture]
    public class MovmentTest
    {
        const double coxaLength = 3.8;
        const double femurLength = 7.6;
        const double tibiaLength = 10.4;
        const short speed = 0x050;

        private short Convert(double d)
        {
            return (short) ((0x3ff/(double) 300)*(150 - d));
        }

        [Test]
        public void Pushups()
        {
            ISender sender = new CommunicationObject();

           
            double X = 7;
            double Y = 10.4;

           
            JointAngeles jointAngeles = IK.CalculateIK(coxaLength, femurLength, tibiaLength, X, Y);

            short femurAngleLeft = Convert(90 - jointAngeles.FemurAngle);
            short tibiaAngleLeft = Convert((jointAngeles.TibiaAngle + 90));

            short femurAngleRight = Convert((jointAngeles.FemurAngle - 90));
            short tibiaAngleRight = Convert(-(jointAngeles.TibiaAngle + 90));


            var movments = new List<Movment>
                               {
                                   new Movment(3, femurAngleLeft, speed),
                                   new Movment(5, tibiaAngleLeft, speed),
                                   new Movment(4, femurAngleRight, speed),
                                   new Movment(6, tibiaAngleRight, speed),
                                   new Movment(9, femurAngleLeft, speed),
                                   new Movment(11, tibiaAngleLeft, speed),
                                   new Movment(10, femurAngleRight, speed),
                                   new Movment(12, tibiaAngleRight, speed),
                                   new Movment(15, femurAngleLeft, speed),
                                   new Movment(17, tibiaAngleLeft, speed),
                                   new Movment(16, femurAngleRight, speed),
                                   new Movment(18, tibiaAngleRight, speed)
                               };


            var instructionPacket = new InstructionPacketSyncMovment(sender, movments.ToArray());
            instructionPacket.Send();

            ((CommunicationObject) sender).Dispose();
        }


        [Test]
        public void Pushups_down()
        {
            ISender sender = new CommunicationObject();
          
            double X = 7;
            double Y = 3;

            JointAngeles jointAngeles = IK.CalculateIK(coxaLength, femurLength, tibiaLength, X, Y);

            short femurAngleLeft = Convert(90 - jointAngeles.FemurAngle);
            short tibiaAngleLeft = Convert((jointAngeles.TibiaAngle + 90));

            short femurAngleRight = Convert((jointAngeles.FemurAngle - 90));
            short tibiaAngleRight = Convert(-(jointAngeles.TibiaAngle + 90));


            var movments = new List<Movment>
                               {
                                   new Movment(3, femurAngleLeft, speed),
                                   new Movment(5, tibiaAngleLeft, speed),
                                   new Movment(4, femurAngleRight, speed),
                                   new Movment(6, tibiaAngleRight, speed),
                                   new Movment(9, femurAngleLeft, speed),
                                   new Movment(11, tibiaAngleLeft, speed),
                                   new Movment(10, femurAngleRight, speed),
                                   new Movment(12, tibiaAngleRight, speed),
                                   new Movment(15, femurAngleLeft, speed),
                                   new Movment(17, tibiaAngleLeft, speed),
                                   new Movment(16, femurAngleRight, speed),
                                   new Movment(18, tibiaAngleRight, speed)
                               };


            var instructionPacket = new InstructionPacketSyncMovment(sender, movments.ToArray());
            instructionPacket.Send();

            ((CommunicationObject) sender).Dispose();
        }

        [Test]
        public void Pushups_upp()
        {
            ISender sender = new CommunicationObject();

            double X = 7;
            double Y = 8;

            JointAngeles jointAngeles = IK.CalculateIK(coxaLength, femurLength, tibiaLength, X, Y);

            short femurAngleLeft = Convert(90 - jointAngeles.FemurAngle);
            short tibiaAngleLeft = Convert((jointAngeles.TibiaAngle + 90));

            short femurAngleRight = Convert((jointAngeles.FemurAngle - 90));
            short tibiaAngleRight = Convert(-(jointAngeles.TibiaAngle + 90));


            var movments = new List<Movment>
                               {
                                   new Movment(3, femurAngleLeft, speed),
                                   new Movment(5, tibiaAngleLeft, speed),
                                   new Movment(4, femurAngleRight, speed),
                                   new Movment(6, tibiaAngleRight, speed),
                                   new Movment(9, femurAngleLeft, speed),
                                   new Movment(11, tibiaAngleLeft, speed),
                                   new Movment(10, femurAngleRight, speed),
                                   new Movment(12, tibiaAngleRight, speed),
                                   new Movment(15, femurAngleLeft, speed),
                                   new Movment(17, tibiaAngleLeft, speed),
                                   new Movment(16, femurAngleRight, speed),
                                   new Movment(18, tibiaAngleRight, speed)
                               };


            var instructionPacket = new InstructionPacketSyncMovment(sender, movments.ToArray());
            instructionPacket.Send();

            ((CommunicationObject) sender).Dispose();
        }
    }
}