using Geometry.Library;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;

[TestFixture]
public class TriangleTests
{
    private WindowsDriver<WindowsElement> driver;

    [SetUp]
    public void Setup()
    {
        // Set up Appium options for a Windows application
        AppiumOptions options = new AppiumOptions();
        options.AddAdditionalCapability("app", "YourAppIdentifierHere");
        options.AddAdditionalCapability("deviceName", "WindowsPC");

        // Initialize the Windows driver
        driver = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), options);
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
    }

    [TearDown]
    public void TearDown()
    {
        
        driver.Dispose();
    }

    [Test]
    public void TestTriangleArea()
    {
        // Arrange
        double sideA = 3;
        double sideB = 4;
        double sideC = 5; 
        Triangle triangle = new Triangle(sideA, sideB, sideC);

        // Act
        double area = triangle.CalculateArea();

        // Assert
        Assert.That(area, Is.EqualTo(6)); 
    }

    [Test]
    public void TestTrianglePerimeter()
    {
        // Arrange
        double sideA = 3;
        double sideB = 4;
        double sideC = 5;
        Triangle triangle = new Triangle(sideA, sideB, sideC);

        // Act
        double perimeter = triangle.CalculatePerimeter();

        // Assert
        Assert.That(perimeter, Is.EqualTo(12));
    }
}
