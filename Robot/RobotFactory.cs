using System;

namespace Robot
{
    public class RobotFactory
    {
        public static Phoenix CreatePhoenix()
        {
            Phoenix phoenix = new Phoenix
                                  {
                                      lfl = createLeg(Side.Left, Position.Front, 60, 4.3, 8.2, 1, 3, 5, 5.7, 10.4, -9.8726896031426),
                                      rfl = createLeg(Side.Right, Position.Front, 60, 4.3, 8.2, 2, 4, 6, 5.7, 10.4, -9.8726896031426),
                                      lml = createLeg(Side.Left, Position.Middle, 0, 6.3, 0, 7, 9, 11, 11.4, 10.4, 0.0),
                                      rml = createLeg(Side.Right, Position.Middle, 0, 6.3, 0, 8, 10, 12, 11.4, 10.4, 0.0),
                                      lrl = createLeg(Side.Left, Position.Rear, 60, 4.3, 8.2, 13, 15, 17, 5.7, 10.4, 9.8726896031426),
                                      rrl = createLeg(Side.Right, Position.Rear, 60, 4.3, 8.2, 14, 16, 18, 5.7, 10.4, 9.8726896031426)
                                  };
           phoenix.MoveBody(0,90);// calculates start posisions for angles
            return phoenix;
        }

        private static Leg createLeg(Side side, Position position, double legOffset, double distanceToX, double distanceToZ, short coxaId, short femurId, short tibiaId, double X, double Y, double Z)
        {
            Leg leg = new Leg
                          {
                              Side = side,
                              Position = position,
                              Offset = legOffset,
                              DistanceToX = distanceToX,
                              DistanceToZ = distanceToZ,
                              X = X,
                              Y = Y,
                              Z = Z,
                              Coxa = new Coxa(3.8, 0, coxaId, 0, 0, side),
                              Femur = new Femur(7.6, 0, femurId, 0, 0, side),
                              Tibia = new Tibia(10.4, -20, tibiaId, 0, 0, side)
                          };

            return leg;
            
        }

    }
}