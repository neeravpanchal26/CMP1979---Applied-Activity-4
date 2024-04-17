using Microsoft.Extensions.DependencyInjection;
using Microsoft.FeatureManagement;
using Microsoft.Extensions.Configuration;
using Geometry.Library;

// Your configuration setup
var featureManagement = new Dictionary<string, string> 
{ 
    { "FeatureManagement:Square", "true" }, 
    { "FeatureManagement:Rectangle", "false" }, 
    { "FeatureManagement:Triangle", "true" }
};

IConfigurationRoot configuration = new ConfigurationBuilder()
    .AddInMemoryCollection(featureManagement)
    .Build();

// Dependency injection setup
var services = new ServiceCollection();
services.AddFeatureManagement(configuration);
var serviceProvider = services.BuildServiceProvider();

var featureManager = serviceProvider.GetRequiredService<IFeatureManager>();
Console.WriteLine("Choose a shape to calculate (1: Square, 2: Rectangle, 3: Triangle):");
int choice = int.Parse(Console.ReadLine());

switch (choice)
{
    case 1: // Square
        Console.WriteLine("Enter side length for the Square:");
        double squareSideLength = double.Parse(Console.ReadLine());
        if (await featureManager.IsEnabledAsync("Square"))
        {
            // Provide access to Square
            var square = new Square(squareSideLength);
            Console.WriteLine("Square - Area: " + square.CalculateArea() + ", Perimeter: " + square.CalculatePerimeter());
        }
        else
        {
            Console.WriteLine("Square feature is disabled.");
        }
        break;

    case 2: // Rectangle
        Console.WriteLine("Enter length and width for the Rectangle (separated by space):");
        string[] rectangleDimensions = Console.ReadLine().Split(' ');
        double rectangleLength = double.Parse(rectangleDimensions[0]);
        double rectangleWidth = double.Parse(rectangleDimensions[1]);
        if (await featureManager.IsEnabledAsync("Rectangle"))
        {
            // Provide access to Rectangle
            var rectangle = new Rectangle(rectangleLength, rectangleWidth);
            Console.WriteLine("Rectangle - Area: " + rectangle.CalculateArea() + ", Perimeter: " + rectangle.CalculatePerimeter());
        }
        else
        {
            Console.WriteLine("Rectangle feature is disabled.");
        }
        break;

    case 3: // Triangle
        Console.WriteLine("Enter three side lengths for the Triangle (separated by space):");
        string[] triangleDimensions = Console.ReadLine().Split(' ');
        double triangleSideA = double.Parse(triangleDimensions[0]);
        double triangleSideB = double.Parse(triangleDimensions[1]);
        double triangleSideC = double.Parse(triangleDimensions[2]);
        if (await featureManager.IsEnabledAsync("Triangle"))
        {
            // Provide access to Triangle
            var triangle = new Triangle(triangleSideA, triangleSideB, triangleSideC);
            Console.WriteLine("Triangle - Area: " + triangle.CalculateArea() + ", Perimeter: " + triangle.CalculatePerimeter());
        }
        else
        {
            Console.WriteLine("Triangle feature is disabled.");
        }
        break;

    default:
        Console.WriteLine("Invalid choice. Please choose a number between 1 and 3.");
        break;
}