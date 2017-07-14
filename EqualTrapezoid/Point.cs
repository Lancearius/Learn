class Point
{
    public int X;
    public int Y;

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

   /* public void PrintPoit()
    {
        System.Console.WriteLine("X: {0} Y:{1}", X,Y);
    }

    public static void CheckPoint(Point p)
    {

    }*/
    public static Point CreatePoint(int x, int y)
    {
        Point point = new Point(x, y);
        return point;
    }
}




