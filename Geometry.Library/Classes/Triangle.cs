namespace Geometry.Library;

public class Triangle : IShape
{    
    private double sideA;
    private double sideB;
    private double sideC;

    public Triangle(double sideA, double sideB, double sideC)
    {
        if (sideA <= 0 || sideB <= 0 || sideC <= 0)
        {
            throw new ArgumentException("Side lengths must be positive numbers.", nameof(sideA));
        }

        if (sideA + sideB <= sideC || sideA + sideC <= sideB || sideB + sideC <= sideA)
        {
            throw new ArgumentException("Invalid side lengths for a triangle.", nameof(sideA));
        }

        this.sideA = sideA;
        this.sideB = sideB;
        this.sideC = sideC;
    }

    public double CalculateArea()
    {
        // Using Heron's formula to calculate the area of the triangle
        double s = (sideA + sideB + sideC) / 2;
        return Math.Sqrt(s * (s - sideA) * (s - sideB) * (s - sideC));
    }

    public double CalculatePerimeter()
    {
        return sideA + sideB + sideC;
    }
}