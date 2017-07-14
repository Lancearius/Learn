using System;
using System.Collections.Generic;
using System.Linq; //<<<
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
/*
У меня в шаре лежит книга «Pro C# 5.0 and the .NET 4.5 Framework 6th ed. - A. Troelsen (Apress, 2012) WW.pdf». 
Освоить страницы с 161 по 203 (Understanding Object Initialization Syntax можно не читать ну а там по желанию). 
Если что в этой книге есть описание операторов(if, for, switch и т.д.) в первых главах.

Задача.
Класс Равнобочная трапеция, члены класса: координаты 4-х точек.
Предусмотреть в классе конструктор и методы: проверка, является ли фигура равнобочной трапецией; 
вычисления и вывода сведений о фигуре: длины сторон, периметр, площадь. 

В функции main продемонстрировать работу с классом: дано N трапеций, найти количество трапеций, у которых площадь больше средней площади.

Выполнить задание в консольном проекте.
*/
namespace EqualTrapezoidNamespace
{
    class prog
    {


        static void Main(string[] args)
        {

            List<EqualTrapezoid> trapezoids = new List<EqualTrapezoid>();

            Console.Clear();

            Console.WriteLine("Do you want to create Equal Trapezoid? Press 'y'");
            string answer = Console.ReadLine();

            if (answer != "y")
                return;

            while (answer == "y")
            {
                Console.WriteLine("enter 4 points");

                Point point;
                List<Point> points = new List<Point>(4);

                //add points
                for (int j = 0; j < 4; j++)
                {
                    Console.WriteLine("enter coordinates for {0} point", j+1);
                    Console.WriteLine("x=");
                    int x_coord = int.Parse(Console.ReadLine());

                    Console.WriteLine("y=");
                    int y_coord = int.Parse(Console.ReadLine());

                    point = Point.CreatePoint(x_coord, y_coord);
                    points.Add(point);
                }
                //create Trapezoid
                trapezoids.Add(new EqualTrapezoid(points));

                Console.WriteLine("Do you want to create one more Equal Trapezoid? Press 'y'");
                answer = Console.ReadLine();
            }


            //for (int i = 0; i < trapezoids.Count; i++)
            //{
            //    trapezoids[i].A.X += 5;
            //    trapezoids[i].A.X += 10;
            //}

            /*
            //<<<
            double averageArea = trapezoids.Average(Mth);
            double averageArea1 = trapezoids.Average(p => { return (p.A.X + 5); });
            double averageArea2 = trapezoids.Average(p => p.A.X + 5);
            */
            double averageArea = trapezoids.Average(trzd => { return (trzd.area); });

            List<EqualTrapezoid> bigTrapezoids = new List<EqualTrapezoid>();
            for (int i = 0; i < trapezoids.Count; i++)
            {
                if (trapezoids[i].area > averageArea)
                    bigTrapezoids.Add(trapezoids[i]);
            };


            Console.WriteLine("-------");
            Console.WriteLine("amount of entered equal trapezoids is: {0}", trapezoids.Count);
            Console.WriteLine("Average area is: {0}", averageArea);
            Console.WriteLine("Next number of equal trapezoids have area more then average: {0}", bigTrapezoids.Count);

            Console.ReadLine();

        }

        /*
        //<<<
        static int Mth(EqualTrapezoid p)
        {
            int result = 0;
            result = p.A.X + 5;

            return result;
        }
        */


    }

}


class EqualTrapezoid
{
    public Point A;
    public Point B;
    public Point C;
    public Point D;

    private int longBase;
    private int shortBase;
    private int leftLeg;
    private int rightLeg;

    public Double perimeter;
    public Double area;

    //public int numTrapezoids = 0;
    public EqualTrapezoid(List<Point> points)
    {
        //++numTrapezoids;

        A = points[0];
        B = points[1];
        C = points[2];
        D = points[3];

        longBase = EqualTrapezoid.CalculateDistace(A, D);
        shortBase = EqualTrapezoid.CalculateDistace(B, C);
        leftLeg = EqualTrapezoid.CalculateDistace(A, B);
        rightLeg = EqualTrapezoid.CalculateDistace(C, D);

        //check IfEqualTrapezoid
        if (!EqualTrapezoid.IfEqualTrapezoid(shortBase, longBase, rightLeg, leftLeg))
        {
            Console.WriteLine("Error. It's not an Equal Trapezoid");
            return;
        }

        //calculations
        perimeter = EqualTrapezoid.CalculateTrapezoidPerimeter(longBase, shortBase, leftLeg, rightLeg);
        area = EqualTrapezoid.CalculateTrapezoidArea(longBase, shortBase, leftLeg);
    }

    public static EqualTrapezoid CreateEqualTrapezoid(List<Point> points)
    {
        EqualTrapezoid equalTrapezoid = new EqualTrapezoid(points);
        return equalTrapezoid;
    }




    private static int CalculateDistace(Point a, Point b)
    {
        int distace = Math.Abs((a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y));
        return distace;
    }

    private static int CalculateTrapezoidPerimeter(int longBase, int shortBase, int leftLeg, int rightLeg)
    {
        int perimeter = longBase + shortBase + leftLeg + rightLeg;
        return perimeter;
    }


    private static double CalculateTrapezoidArea(int longBase, int shortBase, int leftLeg)
    {
        double h = Math.Sqrt(Math.Abs((leftLeg * leftLeg) - ((longBase - shortBase) * (longBase - shortBase)) / 4));
        double area = (((shortBase + longBase) / 2) * h);
        return area;
    }


    public static bool IfEqualTrapezoid(int shortBase, int longBase, int rightLeg, int leftLeg)
    {
        if ((shortBase >= longBase) || (rightLeg != leftLeg))
        {
            return false;
        }
        return true;
    }

}

