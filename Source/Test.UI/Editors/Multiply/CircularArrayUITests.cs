﻿using Macad.Test.UI.Framework;
using NUnit.Framework;

namespace Macad.Test.UI.Editors.Multiply;

[TestFixture]
public class CircularArrayUITests : UITestBase
{
    [SetUp]
    public void SetUp()
    {
        Reset();
    }

    //--------------------------------------------------------------------------------------------------

    [Test]
    public void CreateFromSketch()
    {
        _CreateSketchBased();
        Assert.AreEqual("Circular Array", Pipe.GetValue<string>("$Selected.Shape.Name"));
    }

    //--------------------------------------------------------------------------------------------------

    [Test]
    public void CreateFromSolid()
    {
        _CreateSolidBased();
        Assert.AreEqual("Circular Array", Pipe.GetValue<string>("$Selected.Shape.Name"));
    }
    
    //--------------------------------------------------------------------------------------------------
    //--------------------------------------------------------------------------------------------------

    void _CreateSketchBased()
    {
        TestDataGenerator.GenerateSketch(MainWindow);
        MainWindow.Ribbon.ClickButton("CloseSketchEditor");

        // Create pipe on existing sketch
        MainWindow.Ribbon.SelectTab("Model");
        MainWindow.Ribbon.ClickButton("CreateCircularArray");
    }

    //--------------------------------------------------------------------------------------------------

    void _CreateSolidBased()
    {
        TestDataGenerator.GenerateBox(MainWindow);

        // Create pipe on existing sketch
        MainWindow.Ribbon.SelectTab("Model");
        MainWindow.Ribbon.ClickButton("CreateCircularArray");
        Assert.IsTrue(MainWindow.Ribbon.IsButtonChecked("CreateCircularArray"));

        MainWindow.Viewport.ClickRelative(0.3, 0.33);
        Assert.IsFalse(MainWindow.Ribbon.IsButtonChecked("CreateCircularArray"));
    }
}