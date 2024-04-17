namespace Geometry.Library;

public class Square : IShape
{
    private double sideLength;

    public Square(double sideLength)
    {
        if (sideLength <= 0)
        {
            throw new ArgumentException("Side length must be a positive number.", nameof(sideLength));
        }

        this.sideLength = sideLength;
    }

    public double CalculateArea()
    {
        return sideLength * sideLength;
    }

    public double CalculatePerimeter()
    {
        return 4 * sideLength;
    }
}