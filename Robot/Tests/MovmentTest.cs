using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;

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

        [Test,Ignore("Ned to be connected to robot")]
        public void Pushups()
        {
            ISender sender = new CommunicationObject();

           
            double X = 7;
            double Y = 10.4;

           
            JointAngeles jointAngeles = IK.CalculateIK_Old(coxaLength, femurLength, tibiaLength, X, Y);

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

        [Test, Ignore("Ned to be connected to robot")]
        public void Pushups_down()
        {
            ISender sender = new CommunicationObject();
          
            double X = 7;
            double Y = 3;

            JointAngeles jointAngeles = IK.CalculateIK_Old(coxaLength, femurLength, tibiaLength, X, Y);

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

        [Test, Ignore("Ned to be connected to robot")]
        public void Pushups_upp()
        {
            ISender sender = new CommunicationObject();

            double X = 7;
            double Y = 8;

            JointAngeles jointAngeles = IK.CalculateIK_Old(coxaLength, femurLength, tibiaLength, X, Y);

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
        public void CanGetMovementFromLeftTibiaZeroOffset()
        {
            Tibia tibia  = new Tibia(10.4, 0, 5, 0, 0, Side.Left);
            Movment movment = tibia.GetMovment();

            List<byte> movmentInBytes = (List<byte>) movment.ToByte();
            Assert.AreEqual(5, movmentInBytes[0]); //ServoId
            Assert.AreEqual(0x1ff, BitConverter.ToInt16(movmentInBytes.ToArray(), 1));
            Assert.AreEqual(0x050, BitConverter.ToInt16(movmentInBytes.ToArray(), 3));
        }


        [Test]
        public void CanGetMovementForLeftTibiaWithOffset()
        {

            Tibia tibia = new Tibia(10.4, 20, 5, 0, 0, Side.Left);
            Movment movment = tibia.GetMovment();

            List<byte> movmentInBytes = (List<byte>)movment.ToByte();
            Assert.AreEqual(5, movmentInBytes[0]); //ServoId
            Assert.AreEqual(0x1BB, BitConverter.ToInt16(movmentInBytes.ToArray(), 1));
            Assert.AreEqual(0x050, BitConverter.ToInt16(movmentInBytes.ToArray(), 3));
        }

        [Test]
        public void CanGetMovementForRightTibiaWithOffset()
        {
            Tibia tibia = new Tibia(10.4, 20, 5, 0, 0, Side.Right);
            Movment movment = tibia.GetMovment();

            List<byte> movmentInBytes = (List<byte>)movment.ToByte();
            Assert.AreEqual(5, movmentInBytes[0]); //ServoId
            Assert.AreEqual(0x243, BitConverter.ToInt16(movmentInBytes.ToArray(), 1));
            Assert.AreEqual(0x050, BitConverter.ToInt16(movmentInBytes.ToArray(), 3));
        }


        [Test]
        public void CanGetMovementForLeftFemurWithZeroOffset()
        {

            Femur femur = new Femur(10.4, 0, 5, 0, 0, Side.Left);
            Movment movment = femur.GetMovment();

            List<byte> movmentInBytes = (List<byte>)movment.ToByte();
            Assert.AreEqual(5, movmentInBytes[0]); //ServoId
            Assert.AreEqual(0x1FF, BitConverter.ToInt16(movmentInBytes.ToArray(), 1));
            Assert.AreEqual(0x050, BitConverter.ToInt16(movmentInBytes.ToArray(), 3));
        }



        [Test]
        public void CanGetMovementForLeftFemurWithOffset()
        {
            Femur femur = new Femur(10.4, 20, 5, 0, 0, Side.Left);
            Movment movment = femur.GetMovment();

            List<byte> movmentInBytes = (List<byte>)movment.ToByte();
            Assert.AreEqual(5, movmentInBytes[0]); //ServoId
            Assert.AreEqual(0x1BB, BitConverter.ToInt16(movmentInBytes.ToArray(), 1));
            Assert.AreEqual(0x050, BitConverter.ToInt16(movmentInBytes.ToArray(), 3));
        }

        [Test]
        public void CanGetMovementForRightFemurWithOffset()
        {
            Femur femur = new Femur(10.4, 20, 5, 0, 0, Side.Right);
            Movment movment = femur.GetMovment();

            List<byte> movmentInBytes = (List<byte>)movment.ToByte();
            Assert.AreEqual(5, movmentInBytes[0]); //ServoId
            Assert.AreEqual(0x243, BitConverter.ToInt16(movmentInBytes.ToArray(), 1));
            Assert.AreEqual(0x050, BitConverter.ToInt16(movmentInBytes.ToArray(), 3));
        }


        
        [Test]
        public void CanGetMovementForLeftCoxaWithZeroOffset()
        {

            Coxa coxa = new Coxa(10.4, 0, 5, 0, 0, Side.Left);
            Movment movment = coxa.GetMovment();

            List<byte> movmentInBytes = (List<byte>)movment.ToByte();
            Assert.AreEqual(5, movmentInBytes[0]); //ServoId
            Assert.AreEqual(0x1FF, BitConverter.ToInt16(movmentInBytes.ToArray(), 1));
            Assert.AreEqual(0x050, BitConverter.ToInt16(movmentInBytes.ToArray(), 3));
        }

        [Test]
        public void CanGetMovementForLeftCoxaWithOffset()
        {
            Coxa coxa = new Coxa(10.4, 20, 5, 0, 0, Side.Left);
            Movment movment = coxa.GetMovment();

            List<byte> movmentInBytes = (List<byte>)movment.ToByte();
            Assert.AreEqual(5, movmentInBytes[0]); //ServoId
            Assert.AreEqual(0x1BB, BitConverter.ToInt16(movmentInBytes.ToArray(), 1));
            Assert.AreEqual(0x050, BitConverter.ToInt16(movmentInBytes.ToArray(), 3));
        }

        [Test]
        public void CanGetMovementForRightCoxaWithOffset()
        {
            Coxa coxa = new Coxa(10.4, 20, 5, 0, 0, Side.Right);
            Movment movment = coxa.GetMovment();

            List<byte> movmentInBytes = (List<byte>)movment.ToByte();
            Assert.AreEqual(5, movmentInBytes[0]); //ServoId
            Assert.AreEqual(0x243, BitConverter.ToInt16(movmentInBytes.ToArray(), 1));
            Assert.AreEqual(0x050, BitConverter.ToInt16(movmentInBytes.ToArray(), 3));
        }

        [Test]
        public void CanGetMovmentFromLeg()
        {
            Leg leg = new Leg
            {
                Side = Side.Left,
                Position = Position.Front,
                Offset = 60,
                DistanceToX = 4.3,
                DistanceToZ = 8.2,
                X = 5.7,
                Y = 10.4,
                Z = -9.8726896031426,
                Coxa = new Coxa(3.8, 0, 1, 0, 0, Side.Left),
                Femur = new Femur(7.6, 0, 3, 0, 0, Side.Left),
                Tibia = new Tibia(10.4, 20, 5, 0, 0, Side.Left)
            };

            leg.CalculateNewPosision(0,1);

            Movment[] movement = leg.GetMovements();

            List<byte> movmentInBytes;

            //coxa
            movmentInBytes = (List<byte>)movement[0].ToByte();
            Assert.AreEqual(1, movmentInBytes[0]); //ServoId
            Assert.AreEqual(0x1FF, BitConverter.ToInt16(movmentInBytes.ToArray(), 1));
            Assert.AreEqual(0x050, BitConverter.ToInt16(movmentInBytes.ToArray(), 3));

            //femur
            movmentInBytes = (List<byte>)movement[1].ToByte();
            Assert.AreEqual(3, movmentInBytes[0]); //ServoId
            Assert.AreEqual(0x1FF, BitConverter.ToInt16(movmentInBytes.ToArray(), 1));
            Assert.AreEqual(0x050, BitConverter.ToInt16(movmentInBytes.ToArray(), 3));

            //Coxa
            movmentInBytes = (List<byte>)movement[2].ToByte();
            Assert.AreEqual(5, movmentInBytes[0]); //ServoId
            Assert.AreEqual(0x1BB, BitConverter.ToInt16(movmentInBytes.ToArray(), 1));
            Assert.AreEqual(0x050, BitConverter.ToInt16(movmentInBytes.ToArray(), 3));
        }


        

        [Test, Ignore("Ned to be connected to robot")]
        public void MoveBodyToStartPosition()
         {
            ISender sender = new CommunicationObject();
            Phoenix phoenix = RobotFactory.CreatePhoenix();


            var movments = phoenix.GetMovements();


             var instructionPacket = new InstructionPacketSyncMovment(sender, movments);
             instructionPacket.Send();

             ((CommunicationObject)sender).Dispose();
         }

        [Test, Ignore("Ned to be connected to robot")]
        public void MoveBody5cmFovard()
        {
            ISender sender = new CommunicationObject();
            Phoenix phoenix = RobotFactory.CreatePhoenix();
            phoenix.MoveBody(5,90);

            var movments = phoenix.GetMovements();


            var instructionPacket = new InstructionPacketSyncMovment(sender, movments);
            instructionPacket.Send();

            ((CommunicationObject)sender).Dispose();
        }

        [Test, Ignore("Ned to be connected to robot")]
        public void MoveBody5cmBack()
        {
            ISender sender = new CommunicationObject();
            Phoenix phoenix = RobotFactory.CreatePhoenix();
            phoenix.MoveBody(-5, 90);

            var movments = phoenix.GetMovements();


            var instructionPacket = new InstructionPacketSyncMovment(sender, movments);
            instructionPacket.Send();

            ((CommunicationObject)sender).Dispose();
        }

        [Test, Ignore("Ned to be connected to robot")]
        public void CanWake()
        {
            ISender sender = new CommunicationObject();
            Phoenix phoenix = RobotFactory.CreatePhoenix();
            var startmovments = phoenix.GetMovements();


           // new InstructionPacketSyncMovment(sender, startmovments).Send();
            Thread.Sleep(500);

            var distance = 10;
            RippelGate6 gate6 = phoenix.CreateRippelGate6(2, 90, distance);

            for (int i = 0; i < 10; i++)
            {
                foreach (var movments in gate6.Positions)
                {
                    var instructionPacket = new InstructionPacketSyncMovment(sender, movments.ToArray());
                    instructionPacket.Send();
                    Thread.Sleep(600);
                }
            }
            

            ((CommunicationObject)sender).Dispose();
        }
    }
}