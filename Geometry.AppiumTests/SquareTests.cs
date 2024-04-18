namespace Geometry.AppiumTests;
using Geometry.Library;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;

[TestFixture]
public class SquareTests
{
    private WindowsDriver<WindowsElement> driver;

    [SetUp]
    public void Setup()
    {
        // Set up Appium options
        AppiumOptions options = new AppiumOptions();
        options.AddAdditionalCapability("app", "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App");
        options.AddAdditionalCapability("deviceName", "WindowsPC");

        // Initialize Windows driver
        driver = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), options);
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
    }

    [TearDown]
    public void TearDown()
    {
        // Quit the driver after each test
        driver.Dispose();
    }

    [Test]
    public void TestSquareArea()
    {
        // Arrange
        double sideLength = 5;
        Square square = new Square(sideLength);

        // Act
        double area = square.CalculateArea();

        // Assert
        Assert.That(area, Is.EqualTo(sideLength * sideLength));
    }

    [Test]
    public void TestSquarePerimeter()
    {
        // Arrange
        double sideLength = 5;
        Square square = new Square(sideLength);

        // Act
        double perimeter = square.CalculatePerimeter();

        // Assert
        Assert.That(perimeter, Is.EqualTo(4 * sideLength));
    }

}