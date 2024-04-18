using Geometry.Library;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;

[TestFixture]
public class RectangleTests
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
        
        driver.Quit();
    }

    [Test]
    public void TestRectangleArea()
    {
        // Arrange
        double length = 10;
        double width = 5;
        Rectangle rectangle = new Rectangle(length, width);

        // Act
        double area = rectangle.CalculateArea();

        // Assert
        Assert.That(area, Is.EqualTo(length * width));
    }

    [Test]
    public void TestRectanglePerimeter()
    {
        // Arrange
        double length = 10;
        double width = 5;
        Rectangle rectangle = new Rectangle(length, width);

        // Act
        double perimeter = rectangle.CalculatePerimeter();

        // Assert
        Assert.That(perimeter, Is.EqualTo(2 * (length + width)));
    }
}
