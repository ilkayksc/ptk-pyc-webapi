namespace PycTest.Test
{
    public abstract class ShapeBase
    {
    }
    public abstract class Shape  : ShapeBase
    {        
        public abstract double area();
    }
    class Circle : Shape
    {
        private double radius;
        public Circle(double r)
        {
            radius = r;
        }

        public override double area()
        {
            return (3.14 * radius * radius);
        }
    }
    class Square : Shape
    {
        private double side;
        public Square(double s)
        {
            side = s;
        }
        public override double area()
        {
            return (side * side);
        }
    }
    class Triangle : Shape
    {
        private double tbase;
        private double theight;
        public Triangle(double b, double h)
        {
            tbase = b;
            theight = h;
        }
        public override double area()
        {
            return (0.5 * tbase * theight);
        }
    }

    public class AbstractionTest
    {
        public void Test()
        {
            Circle circle = new Circle(4);
            var circleArea = circle.area();

            Triangle triangle = new Triangle(3, 5);
            var triangleArea = triangle.area();

            Square square = new Square(6);
            var squareArea = square.area(); 
        }
    }
}
