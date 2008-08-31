using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;

namespace Robot.Tests
{
    [TestFixture]
    public class MovmentTest
    {
  
        [Test]
        public void CanGetMovementFromLeftTibiaZeroOffset()
        {
            ServoBase tibia = new ServoBase(10.4, 0, 5, 0, 0, Side.Left);
            MovmentComandAX12 movmentComandAX12 = tibia.GetMovement();

            List<byte> movmentInBytes = (List<byte>) movmentComandAX12.ToByte();
            Assert.AreEqual(5, movmentInBytes[0]); //ServoId
            Assert.AreEqual(0x1ff, BitConverter.ToInt16(movmentInBytes.ToArray(), 1));
            Assert.AreEqual(0x050, BitConverter.ToInt16(movmentInBytes.ToArray(), 3));
        }


        [Test]
        public void CanGetMovementForLeftTibiaWithOffset()
        {

            ServoBase tibia = new ServoBase(10.4, 20, 5, 0, 0, Side.Left);
            MovmentComandAX12 movmentComandAX12 = tibia.GetMovement();

            List<byte> movmentInBytes = (List<byte>)movmentComandAX12.ToByte();
            Assert.AreEqual(5, movmentInBytes[0]); //ServoId
            Assert.AreEqual(0x1BB, BitConverter.ToInt16(movmentInBytes.ToArray(), 1));
            Assert.AreEqual(0x050, BitConverter.ToInt16(movmentInBytes.ToArray(), 3));
        }

        [Test]
        public void CanGetMovementForRightTibiaWithOffset()
        {
            ServoBase tibia = new ServoBase(10.4, 20, 5, 0, 0, Side.Right);
            MovmentComandAX12 movmentComandAX12 = tibia.GetMovement();

            List<byte> movmentInBytes = (List<byte>)movmentComandAX12.ToByte();
            Assert.AreEqual(5, movmentInBytes[0]); //ServoId
            Assert.AreEqual(0x243, BitConverter.ToInt16(movmentInBytes.ToArray(), 1));
            Assert.AreEqual(0x050, BitConverter.ToInt16(movmentInBytes.ToArray(), 3));
        }


        [Test]
        public void CanGetMovementForLeftFemurWithZeroOffset()
        {

            ServoBase servoBase = new ServoBase(10.4, 0, 5, 0, 0, Side.Left);
            MovmentComandAX12 movmentComandAX12 = servoBase.GetMovement();

            List<byte> movmentInBytes = (List<byte>)movmentComandAX12.ToByte();
            Assert.AreEqual(5, movmentInBytes[0]); //ServoId
            Assert.AreEqual(0x1FF, BitConverter.ToInt16(movmentInBytes.ToArray(), 1));
            Assert.AreEqual(0x050, BitConverter.ToInt16(movmentInBytes.ToArray(), 3));
        }



        [Test]
        public void CanGetMovementForLeftFemurWithOffset()
        {
            ServoBase servoBase = new ServoBase(10.4, 20, 5, 0, 0, Side.Left);
            MovmentComandAX12 movmentComandAX12 = servoBase.GetMovement();

            List<byte> movmentInBytes = (List<byte>)movmentComandAX12.ToByte();
            Assert.AreEqual(5, movmentInBytes[0]); //ServoId
            Assert.AreEqual(0x1BB, BitConverter.ToInt16(movmentInBytes.ToArray(), 1));
            Assert.AreEqual(0x050, BitConverter.ToInt16(movmentInBytes.ToArray(), 3));
        }

        [Test]
        public void CanGetMovementForRightFemurWithOffset()
        {
            ServoBase servoBase = new ServoBase(10.4, 20, 5, 0, 0, Side.Right);
            MovmentComandAX12 movmentComandAX12 = servoBase.GetMovement();

            List<byte> movmentInBytes = (List<byte>)movmentComandAX12.ToByte();
            Assert.AreEqual(5, movmentInBytes[0]); //ServoId
            Assert.AreEqual(0x243, BitConverter.ToInt16(movmentInBytes.ToArray(), 1));
            Assert.AreEqual(0x050, BitConverter.ToInt16(movmentInBytes.ToArray(), 3));
        }


        
        [Test]
        public void CanGetMovementForLeftCoxaWithZeroOffset()
        {

            ServoBase coxa = new ServoBase(10.4, 0, 5, 0, 0, Side.Left);
            MovmentComandAX12 movmentComandAX12 = coxa.GetMovement();

            List<byte> movmentInBytes = (List<byte>)movmentComandAX12.ToByte();
            Assert.AreEqual(5, movmentInBytes[0]); //ServoId
            Assert.AreEqual(0x1FF, BitConverter.ToInt16(movmentInBytes.ToArray(), 1));
            Assert.AreEqual(0x050, BitConverter.ToInt16(movmentInBytes.ToArray(), 3));
        }

        [Test]
        public void CanGetMovementForLeftCoxaWithOffset()
        {
            ServoBase coxa = new ServoBase(10.4, 20, 5, 0, 0, Side.Left);
            MovmentComandAX12 movmentComandAX12 = coxa.GetMovement();

            List<byte> movmentInBytes = (List<byte>)movmentComandAX12.ToByte();
            Assert.AreEqual(5, movmentInBytes[0]); //ServoId
            Assert.AreEqual(0x1BB, BitConverter.ToInt16(movmentInBytes.ToArray(), 1));
            Assert.AreEqual(0x050, BitConverter.ToInt16(movmentInBytes.ToArray(), 3));
        }

        [Test]
        public void CanGetMovementForRightCoxaWithOffset()
        {
            ServoBase coxa = new ServoBase(10.4, 20, 5, 0, 0, Side.Right);
            MovmentComandAX12 movmentComandAX12 = coxa.GetMovement();

            List<byte> movmentInBytes = (List<byte>)movmentComandAX12.ToByte();
            Assert.AreEqual(5, movmentInBytes[0]); //ServoId
            Assert.AreEqual(0x243, BitConverter.ToInt16(movmentInBytes.ToArray(), 1));
            Assert.AreEqual(0x050, BitConverter.ToInt16(movmentInBytes.ToArray(), 3));
        }

        [Test]
        public void CanGetMovmentFromLeftFrontLeg()
        {
            Leg leg = new Leg(1,1)
            {
                Side = Side.Left,
                Position = Position.Front,
                Offset = 00,
                X = 5.7,
                Y = 10.4,
                Z = -9.8726896031426,
                Coxa = new ServoBase(3.8, 60, 1, 0, 0, Side.Left),
                Femur = new ServoBase(7.6, -90, 3, 0, 0, Side.Left),
                Tibia = new ServoBase(10.4, -70, 5, 0, 0, Side.Left)
            };

            Leg.CalculateNewPosition(leg, 0,1);

            MovmentComandAX12[] movement = leg.GetMovements();

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

        [Test]
        public void test()
        {
            double i = Math.Atan2(-5, 5);
            double i2 = Math.Atan2(5, -5); 
            double i3 = Math.Atan(5.0/-5.0); 
            double i4 = Math.Atan(-5.0/5); 
      

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
        public void MoveBodyToStartPosition2()
        {
            ISender sender = new CommunicationObject();
            Phoenix phoenix = RobotFactory.CreatePhoenix2();


            var movments = phoenix.GetMovements();


            var instructionPacket = new InstructionPacketSyncMovment(sender, movments);
            instructionPacket.Send();

            ((CommunicationObject)sender).Dispose();
        }
        [Test, Ignore("Ned to be connected to robot")]
        public void MoveBodyToStartPosition3()
        {
            ISender sender = new CommunicationObject();
            Phoenix phoenix = RobotFactory.CreatePhoenix3();


            var movments = phoenix.GetMovements();
            var instructionPacket = new InstructionPacketSyncMovment(sender, movments);
            instructionPacket.Send();
            Thread.Sleep((int)ServoBase.TimeBox * 1000);
            for (int i = 0; i < 15; i++)
            {
                
                phoenix.MoveBody(0, 90, -1);
                movments = phoenix.GetMovements();
                instructionPacket = new InstructionPacketSyncMovment(sender, movments);
                instructionPacket.Send();
                Thread.Sleep((int)ServoBase.TimeBox * 1000 - 10);
            }
            for (int i = 0; i < 15; i++)
            {
              
                phoenix.MoveBody(0, 90, 1);
                movments = phoenix.GetMovements();
                instructionPacket = new InstructionPacketSyncMovment(sender, movments);
                instructionPacket.Send();
                Thread.Sleep((int)ServoBase.TimeBox * 1000 + 10);
            }

          
            ((CommunicationObject)sender).Dispose();
        }

        [Test, Ignore("Ned to be connected to robot")]
        public void MoveBody5cmFovard()
        {
            ISender sender = new CommunicationObject();
            Phoenix phoenix = RobotFactory.CreatePhoenix();
            phoenix.GetMovements();

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
            phoenix.GetMovements();
            phoenix.MoveBody(-5, 90);

            var movments = phoenix.GetMovements();


            var instructionPacket = new InstructionPacketSyncMovment(sender, movments);
            instructionPacket.Send();

            ((CommunicationObject)sender).Dispose();
        }

        [Test, Ignore("Ned to be connected to robot")]
        public void RotateBody15degresCW()
        {
            ISender sender = new CommunicationObject();
            Phoenix phoenix = RobotFactory.CreatePhoenix();
            phoenix.RotateBody(40,1);

            var movments = phoenix.GetMovements();


            var instructionPacket = new InstructionPacketSyncMovment(sender, movments);
            instructionPacket.Send();

            ((CommunicationObject)sender).Dispose();
        }

        [Test, Ignore("Ned to be connected to robot")]
        public void RotateBody15degresCCW()
        {
            ISender sender = new CommunicationObject();
            Phoenix phoenix = RobotFactory.CreatePhoenix();
            phoenix.RotateBody(-15, -1);

            var movments = phoenix.GetMovements();


            var instructionPacket = new InstructionPacketSyncMovment(sender, movments);
            instructionPacket.Send();

            ((CommunicationObject)sender).Dispose();
        }

        [Test, Ignore("Ned to be connected to robot")]
        public void CanWakeForward()
        {
            ISender sender = new CommunicationObject();
            HomePosition homePosition = RobotFactory.CreateHomePosition();
            Phoenix phoenix = RobotFactory.CreatePhoenix();

            RippelGate6 rippelGate6 = new RippelGate6(phoenix, homePosition);
            for (int i = 0; i < 24; i++)
            {
                double direction = 90;
                double stepValue = 1;
                ServoBase.TimeBox = 1;
                new InstructionPacketSyncMovment(sender, rippelGate6.NextSequence(direction, stepValue)).Send();
                Thread.Sleep((int)ServoBase.TimeBox * 1000);
            }

            ((CommunicationObject)sender).Dispose();
        }

        [Test, Ignore("Ned to be connected to robot")]
        public void CanWakeFastForward()
        {
            ISender sender = new CommunicationObject();
            HomePosition homePosition = RobotFactory.CreateHomePosition();
            Phoenix phoenix = RobotFactory.CreatePhoenix();

            RippelGate6 rippelGate6 = new RippelGate6(phoenix, homePosition);
            for (int i = 0; i < 24; i++)
            {
                double direction = 90;
                double stepValue = 2;
                ServoBase.TimeBox = 1;
                new InstructionPacketSyncMovment(sender, rippelGate6.NextSequence(direction, stepValue)).Send();
                Thread.Sleep((int)ServoBase.TimeBox * 1000);
            }

            ((CommunicationObject)sender).Dispose();
        }


        [Test, Ignore("Ned to be connected to robot")]
        public void CanWakeSideways()
        {
            ISender sender = new CommunicationObject();
            HomePosition homePosition = RobotFactory.CreateHomePosition();
            Phoenix phoenix = RobotFactory.CreatePhoenix();

            RippelGate6 rippelGate6 = new RippelGate6(phoenix, homePosition);
            for (int i = 0; i < 24; i++)
            {
                double direction = 0;
                double stepValue = 2;
                ServoBase.TimeBox = 0.5;
                new InstructionPacketSyncMovment(sender, rippelGate6.NextSequence(direction, stepValue)).Send();
                Thread.Sleep((int)ServoBase.TimeBox * 1000);
            }

            ((CommunicationObject)sender).Dispose();
        }

        [Test, Ignore("Ned to be connected to robot")]
        public void CanTurnCW()
        {
            ISender sender = new CommunicationObject();
            HomePosition homePosition = RobotFactory.CreateHomePosition();
            Phoenix phoenix = RobotFactory.CreatePhoenix();

            RippelGate6 rippelGate6 = new RippelGate6(phoenix, homePosition);
            for (int i = 0; i < 24; i++)
            {
                
                double stepValue = 10;
                ServoBase.TimeBox = 1;
                new InstructionPacketSyncMovment(sender, rippelGate6.NextSequenceRotation(stepValue,0,0)).Send();
                Thread.Sleep((int)ServoBase.TimeBox * 1000);
            }

            ((CommunicationObject)sender).Dispose();
        }


        [Test, Ignore("Ned to be connected to robot")]
        public void CanTurnCWZ30()
        {
            ISender sender = new CommunicationObject();
            HomePosition homePosition = RobotFactory.CreateHomePosition();
            Phoenix phoenix = RobotFactory.CreatePhoenix();

            RippelGate6 rippelGate6 = new RippelGate6(phoenix, homePosition);
            for (int i = 0; i < 24; i++)
            {

                double stepValue = 5;
                ServoBase.TimeBox = 1;
                double Z = -30;
                new InstructionPacketSyncMovment(sender, rippelGate6.NextSequenceRotation(stepValue,0,Z)).Send();
                Thread.Sleep((int)ServoBase.TimeBox * 1000);
            }

            ((CommunicationObject)sender).Dispose();
        }

         [Test, Ignore("Ned to be connected to robot")]
        public void CanCalculateRippelGate6()
         {
             ISender sender = new CommunicationObject();
             HomePosition homePosition = RobotFactory.CreateHomePosition();
             Phoenix phoenix = RobotFactory.CreatePhoenix();
             
             RippelGate6 rippelGate6 = new RippelGate6(phoenix, homePosition);
             for (int i = 0; i < 20; i++)
             {
                 double direction = 90;
                 double stepValue = 1;
                 ServoBase.TimeBox = 0.2;
                 new InstructionPacketSyncMovment(sender, rippelGate6.NextSequence(direction,stepValue)).Send();
                 Thread.Sleep((int) ServoBase.TimeBox * 1000);
             }
             for (int i = 0; i < 20; i++)
             {
                 double direction = 0;
                 double stepValue = 2;
                 ServoBase.TimeBox = 1;
                 new InstructionPacketSyncMovment(sender, rippelGate6.NextSequence(direction, stepValue)).Send();
                 Thread.Sleep((int)ServoBase.TimeBox * 1000);
             }
             for (int i = 0; i < 20; i++)
             {
                 double direction = -45;
                 double stepValue = 1;
                 ServoBase.TimeBox = 1;
                 new InstructionPacketSyncMovment(sender, rippelGate6.NextSequence(direction, stepValue)).Send();
                 Thread.Sleep((int)ServoBase.TimeBox * 1000);
             }
             for (int i = 0; i < 20; i++)
             {
                 double direction = 135;
                 double stepValue = 2;
                 ServoBase.TimeBox = 1;
                 new InstructionPacketSyncMovment(sender, rippelGate6.NextSequence(direction, stepValue)).Send();
                 Thread.Sleep((int)ServoBase.TimeBox * 1000);
             }


             ((CommunicationObject)sender).Dispose();
         }
    }
}