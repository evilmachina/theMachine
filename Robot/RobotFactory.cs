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
namespace Robot
{
    public class RobotFactory
    {
        public static Phoenix CreatePhoenix(HomePosition startPosition)
        {
            Phoenix phoenix = new Phoenix
                                  {
                                      LeftFrontLeg = createLeg(Side.Left, Position.Front, 60, 1, 3, 5, 4.3, -8.2, startPosition.LeftFrontLeg),
                                      RightFrontLeg = createLeg(Side.Right, Position.Front, -60, 2, 4, 6, -4.3, -8.2, startPosition.RightFrontLeg),
                                      LeftMiddleLeg = createLeg(Side.Left, Position.Middle, 0, 7, 9, 11, 6.3, 0, startPosition.LeftMiddleLeg),
                                      RightMiddleLeg = createLeg(Side.Right, Position.Middle, 0, 8, 10, 12, -6.3, 0, startPosition.RightMiddleLeg),
                                      LeftRearLeg = createLeg(Side.Left, Position.Rear, -60, 13, 15, 17, 4.3, 8.2, startPosition.LeftRearLeg),
                                      RightRearLeg = createLeg(Side.Right, Position.Rear, 60, 14, 16, 18, -4.3, 8.2, startPosition.RightRearLeg)
                                  };
            phoenix.MoveBody(0, 90);// calculates start posisions for angles
            return phoenix;
        }

        protected internal static Leg createLeg(Side side, Position position, double legOffset, short coxaId, short femurId, short tibiaId, double distanceToX, double distanceToZ, LegPosition legPosition)
        {
            Leg leg = new Leg(distanceToX, distanceToZ)
                          {
                              Side = side,
                              Position = position,
                              Offset = legOffset,
                              X = legPosition.X,
                              Y = legPosition.Y,
                              Z = legPosition.Z,
                              Coxa = new Coxa(3.8, legOffset, coxaId, 0, 0, side),
                              Femur = new Femur(7.6, -90, femurId, 0, 0, side),
                              Tibia = new Tibia(10.4, 120, tibiaId, 0, 0, side)
                          };

            return leg;

        }
    }
}