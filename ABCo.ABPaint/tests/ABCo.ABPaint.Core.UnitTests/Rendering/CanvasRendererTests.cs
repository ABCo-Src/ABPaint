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
    public class CanvasRendererTests : CanvasBaseTest
    {
        [TestMethod]
        public void Render_SquareCanvas_CenteredFill()
        {
            _canvas.PixelWidth.Returns(150);
            _canvas.PixelHeight.Returns(150);

            var canvas = new Canvas(100, 100);

            _renderer.Render(canvas, new RenderContext(_canvas));
            _canvas.Received().FillRectangle(25, 25, canvas.PixelWidth, canvas.PixelHeight, Pattern.White);
        }

        [TestMethod]
        public void Render_RectangleCanvas_CenteredFill()
        {
            _canvas.PixelWidth.Returns(150);
            _canvas.PixelHeight.Returns(300);

            var canvas = new Canvas(100, 200);

            _renderer.Render(canvas, new RenderContext(_canvas));
            _canvas.Received().FillRectangle(25, 50, canvas.PixelWidth, canvas.PixelHeight, Pattern.White);
        }

        ICanvasRenderer _renderer;

        [TestInitialize]
        public void InitRenderer() => _renderer = new CanvasRenderer(_canvas);
    }
}
