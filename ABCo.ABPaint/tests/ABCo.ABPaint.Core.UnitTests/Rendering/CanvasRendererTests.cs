using ABCo.ABPaint.Core.Rendering;
using ABCo.ABPaint.Core.Representation.Documents;
using ABCo.ABPaint.Core.Representation.Patterns;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCo.ABPaint.Core.UnitTests.Rendering
{
    [TestClass]
    public class CanvasRendererTests
    {
        [TestMethod]
        public void Render_SquareCanvas_CenteredFill()
        {
            var output = Substitute.For<IDrawTarget>();
            output.PixelWidth.Returns(150);
            output.PixelHeight.Returns(150);

            var canvasRenderer = new CanvasRenderer(output);
            var canvas = new Canvas(100, 100);

            canvasRenderer.Render(canvas);
            output.Received().FillRectangle(25, 25, canvas.PixelWidth, canvas.PixelHeight, Pattern.White);
        }

        [TestMethod]
        public void Render_SquareCanvas_CenteredFill()
        {
            var output = Substitute.For<IDrawTarget>();
            output.PixelWidth.Returns(150);
            output.PixelHeight.Returns(150);

            var canvasRenderer = new CanvasRenderer(output);
            var canvas = new Canvas(100, 100);

            canvasRenderer.Render(canvas);
            output.Received().FillRectangle(25, 25, canvas.PixelWidth, canvas.PixelHeight, Pattern.White);
        }

        [TestMethod]
        public void Render_RectangleCanvas_Centered()
        {
            var output = Substitute.For<IDrawTarget>();
            output.PixelWidth.Returns(150);
            output.PixelHeight.Returns(300);

            var canvasRenderer = new CanvasRenderer(output);
            var canvas = new Canvas(100, 200);

            canvasRenderer.Render(canvas);
            output.Received().FillRectangle(25, 50, canvas.PixelWidth, canvas.PixelHeight, Pattern.White);
        }
    }
}
