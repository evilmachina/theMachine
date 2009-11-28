using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace Robot.Tests
{   
    [TestFixture]
    public class HeadTests
    {
        [Test]
        public void SetUpHeadTest()
        {

            HeadServo yawServo = new HeadServo(0, 1, 90, -90);
            HeadServo pitchServo = new HeadServo(90, 2, 90, -80);
            HeadServo rollServo = new HeadServo(90, 3, 90, -80);

            IHead head = new Head(yawServo, pitchServo, rollServo);

            Assert.That(head.Yaw, Is.EqualTo(0));
            Assert.That(head.Pitch, Is.EqualTo(0));
            // Assert.That(head.Roll, Is.EqualTo(0));
        }
        
        [Test]
        public void CanGetMovmentIstructions()
        {

            HeadServo yawServo = new HeadServo(0,1,90,-90);
            HeadServo pitchServo = new HeadServo(90, 2, 90, -80);
            HeadServo rollServo = new HeadServo(90, 3, 90, -80);

            IHead head = new Head(yawServo, pitchServo, rollServo);

            MovmentComandAX12[] movmentComandAx12 = head.GetMovements();
            Assert.That(movmentComandAx12[0], Is.Not.Null);
            Assert.That(movmentComandAx12[1], Is.Not.Null);
        }

    }
}