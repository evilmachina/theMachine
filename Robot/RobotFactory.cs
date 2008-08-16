using System;

namespace Robot
{
    public class RobotFactory
    {
        public static Phoenix CreatePhoenix()
        {
            var Y = 5;
            Phoenix phoenix = new Phoenix
                                  {
                                      lfl = createLeg(Side.Left, Position.Front, 60, 1, 3, 5, 5.7, Y, -9.8726896031426, -4.3, 8.2),
                                      rfl = createLeg(Side.Right, Position.Front, 60, 2, 4, 6, 5.7, Y, -9.8726896031426, 4.3, 8.2),
                                      lml = createLeg(Side.Left, Position.Middle, 0, 7, 9, 11, 11.4, Y, 0.0,-6.3, 0),
                                      rml = createLeg(Side.Right, Position.Middle, 0, 8, 10, 12, 11.4, Y, 0.0, 6.3, 0),
                                      lrl = createLeg(Side.Left, Position.Rear, -60, 13, 15, 17, 5.7, Y, 9.8726896031426, -4.3, -8.2),
                                      rrl = createLeg(Side.Right, Position.Rear, -60, 14, 16, 18, 5.7, Y, 9.8726896031426, 4.3, -8.2)
                                  };
           phoenix.MoveBody(0,90);// calculates start posisions for angles
            return phoenix;
        }

        private static Leg createLeg(Side side, Position position, double legOffset, short coxaId, short femurId, short tibiaId, double X, double Y, double Z, double distanceToX, double distanceToY)
        {
            Leg leg = new Leg(distanceToX, distanceToY)
                          {
                              Side = side,
                              Position = position,
                              Offset = legOffset,
                              X = X,
                              Y = Y,
                              Z = Z,
                              Coxa = new Coxa(3.8, 0, coxaId, 0, 0, side),
                              Femur = new Femur(7.6, 0, femurId, 0, 0, side),
                              Tibia = new Tibia(10.4, -20, tibiaId, 0, 0, side)
                          };

            return leg;
            
        }

        public static HomePosition CreateHomePosition()
        {
            var Y = 5;
            HomePosition homePosition = new HomePosition
                                            {
                                                lfl = new LegPosition(5.7, Y, -9.8726896031426),
                                                rfl = new LegPosition(5.7, Y, -9.8726896031426),
                                                lml = new LegPosition(11.4, Y, 0.0),
                                                rml = new LegPosition(11.4, Y, 0.0),
                                                lrl = new LegPosition(5.7, Y, 9.8726896031426),
                                                rrl = new LegPosition(5.7, Y, 9.8726896031426)
                                            };
            return homePosition;
        }
    }
}