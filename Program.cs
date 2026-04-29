using System;

struct Point {
    public double X { get; set; }
    public double Y { get; set; }

    public Point(double x, double y) {
        this.X = x;
        this.Y = y;
    }
}

struct Circle {
    private double _radius;
    public double Radius {
        get => _radius;
        set {
            if (value < 0) {
                Console.WriteLine("Создание невозможно: радиус не может быть отрицательным.");
            } else {
                _radius = value;
            }
        }
    }
    public Point Center { get; set; }

    public Circle(double r, Point p) {
        this._radius = 0;
        this.Center = p;
        this.Radius = r;
    }

    public void Deconstruct(out double r, out Point p) {
        r = Radius;
        p = Center;
    }

    public double GetArea() => Math.PI * Math.Pow(Radius, 2);
    public double GetPerimeter() => 2 * Math.PI * Radius;

    public void CheckPoint(Point p) {
        double distance = Math.Sqrt(Math.Pow(p.X - Center.X, 2) + Math.Pow(p.Y - Center.Y, 2));
        if (distance < Radius) Console.WriteLine("Точка внутри");
        else if (distance > Radius) Console.WriteLine("Точка снаружи");
        else Console.WriteLine("Точка на границе");
    }
}

class Program {
    static void Main() {
        Circle errorCircle = new Circle(-5, new Point(0, 0));

        Circle myCircle = new Circle(10, new Point(0, 0));
        
        var (r, center) = myCircle;
        Console.WriteLine($"Круг: R={r}, Center=({center.X}, {center.Y})");

        Console.WriteLine($"Площадь: {myCircle.GetArea()}");
        Console.WriteLine($"Периметр: {myCircle.GetPerimeter()}");

        myCircle.Radius = 15;
        myCircle.Center = new Point(1, 1);
        
        Console.WriteLine($"Новая площадь: {myCircle.GetArea()}");

        myCircle.CheckPoint(new Point(5, 5));
        myCircle.CheckPoint(new Point(20, 20));
        myCircle.CheckPoint(new Point(16, 1));
    }
}