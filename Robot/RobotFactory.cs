using System;

namespace Robot
{
    public class RobotFactory
    {
        public static Phoenix CreatePhoenix()
        {
            Phoenix phoenix = new Phoenix
                                  {
                                      lfl = createLeg(Side.Left, Position.Front, 4.3, 8.2, 1, 3, 5),
                                      rfl = createLeg(Side.Right, Position.Front, 4.3, 8.2, 2, 4, 6),
                                      lml = createLeg(Side.Left, Position.Middle,6.3, 0, 7, 9, 11),
                                      rml = createLeg(Side.Right, Position.Middle, 6.3, 0, 8, 10, 12),
                                      lrl = createLeg(Side.Left, Position.Rear, 4.3, 8.2, 13, 15, 17),
                                      rrl = createLeg(Side.Right, Position.Rear, 4.3, 8.2, 14, 16, 18)
                                  };
            return phoenix;
        }

        private static Leg createLeg(Side side, Position position, double distanceToX, double distanceToZ, int coxaId, int femurId, int tibiaId)
        {
            Leg leg = new Leg
                          {
                              Side = side,
                              Position = position,
                              DistanceToX = distanceToX,
                              DistanceToZ = distanceToZ,
                              Coxa = new Coxa(3.8, 0, coxaId, 0, 0, side),
                              Femur = new Femur(7.6, 0, femurId, 0, 0, side),
                              Tibia = new Tibia(10.4, 0, tibiaId, 0, 0, side)
                          };

            return leg;
            
        }

    }
}