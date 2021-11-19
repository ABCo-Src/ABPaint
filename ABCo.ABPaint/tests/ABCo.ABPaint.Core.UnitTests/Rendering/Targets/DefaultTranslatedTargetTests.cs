using ABCo.ABPaint.Core.Rendering;
using ABCo.ABPaint.Core.Rendering.Targets;
using ABCo.ABPaint.Core.Representation.Patterns;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCo.ABPaint.Core.UnitTests.Rendering.Targets
{
    [TestClass]
    public class DefaultTranslatedTargetTests : CanvasBaseTest
    {
        [TestMethod]
        public void Start_ThrowsException() => Assert.ThrowsException<Exception>(() => new DefaultTranslatedTarget(0, 0, _canvas).Start());

        [TestMethod]
        public void Finish_ThrowsException() => Assert.ThrowsException<Exception>(() => new DefaultTranslatedTarget(0, 0, _canvas).Finish());

        [TestMethod]
        public void DrawRectangle_CallsTransformed()
        {
            var target = new DefaultTranslatedTarget(20, 25, _canvas);
            target.DrawRectangle(50, 70, 20, 30, Pattern.White);
            _canvas.Received().DrawRectangle(70, 95, 20, 30, Pattern.White);
        }

        [TestMethod]
        public void DrawAndFillRectangle_CallsTransformed()
        {
            var target = new DefaultTranslatedTarget(5, 10, _canvas);
            target.DrawAndFillRectangle(90, 110, 20, 30, Pattern.White);
            _canvas.Received().DrawAndFillRectangle(95, 120, 20, 30, Pattern.White);
        }

        [TestMethod]
        public void FillRectangle_CallsTransformed()
        {
            var target = new DefaultTranslatedTarget(15, 25, _canvas);
            target.FillRectangle(50, 70, 20, 30, Pattern.White);
            _canvas.Received().FillRectangle(65, 95, 20, 30, Pattern.White);
        }
    }
}
