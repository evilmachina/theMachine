namespace Robot
{
    public class HomePositionFactory
    {
        public static HomePosition CreateHomePosition()
        {
            var Y = 5;
            HomePosition homePosition = new HomePosition
                (
                new LegPosition(5.7, Y, -9.8726896031426),
                new LegPosition(-5.7, Y, -9.8726896031426),
                new LegPosition(11.4, Y, 0.0),
                new LegPosition(-11.4, Y, 0.0),
                new LegPosition(5.7, Y, 9.8726896031426),
                new LegPosition(-5.7, Y, 9.8726896031426)
                );
            return homePosition;
        }

        public static HomePosition CreateHomePosition2()
        {
            var Y = 10.4;
            HomePosition homePosition = new HomePosition(new LegPosition(11.4, Y, 0.0), new LegPosition(-11.4, Y, 0.0),
                                                         new LegPosition(11.4, Y, 0.0), new LegPosition(-11.4, Y, 0.0),
                                                         new LegPosition(11.4, Y, 0.0), new LegPosition(-11.4, Y, 0.0));
            return homePosition;
        }

        public static HomePosition CreateHomePosition3()
        {
            var Y = 10.4;
            HomePosition homePosition = new HomePosition(new LegPosition(5.7, Y, -9.8726896031426), new LegPosition(-5.7, Y, -9.8726896031426),
                                                         new LegPosition(11.4, Y, 0.0), new LegPosition(-11.4, Y, 0.0),
                                                         new LegPosition(5.7, Y, 9.8726896031426), new LegPosition(-5.7, Y, 9.8726896031426)
                );
            return homePosition;
        }

        public static HomePosition CreateHomePosition4()
        {
            var Y = 10.4;
            HomePosition homePosition = new HomePosition(

                new LegPosition(5.7, Y, -9.8726896031426),
                new LegPosition(-5.7, Y, -9.8726896031426),
                new LegPosition(11.4, Y, 0.0),
                new LegPosition(-11.4, Y, 0.0),
                new LegPosition(5.7, Y, 9.8726896031426),
                new LegPosition(-5.7, Y, 9.8726896031426)
                );
            return homePosition;
        }

       
    }
}