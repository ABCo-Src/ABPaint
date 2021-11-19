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
    public class DefaultTranslatedTargetTests
    {
        [TestMethod]
        public void Start_ThrowsException() => Assert.ThrowsException<Exception>(() => new DefaultTranslatedTarget(0, 0, Substitute.For<IDrawTarget>()).Start());

        [TestMethod]
        public void Finish_ThrowsException() => Assert.ThrowsException<Exception>(() => new DefaultTranslatedTarget(0, 0, Substitute.For<IDrawTarget>()).Finish());

        [TestMethod]
        public void DrawRectangle_CallsTransformed()
        {
            var baseTarget = Substitute.For<IDrawTarget>();
            var target = new DefaultTranslatedTarget(20, 25, baseTarget);

            target.DrawRectangle(50, 70, 20, 30, Pattern.White);

            baseTarget.Received().DrawRectangle(70, 95, 20, 30, Pattern.White);
        }

        [TestMethod]
        public void DrawAndFillRectangle_CallsTransformed()
        {
            var baseTarget = Substitute.For<IDrawTarget>();
            var target = new DefaultTranslatedTarget(5, 10, baseTarget);

            target.DrawAndFillRectangle(90, 110, 20, 30, Pattern.White);

            baseTarget.Received().DrawAndFillRectangle(95, 120, 20, 30, Pattern.White);
        }

        [TestMethod]
        public void FillRectangle_CallsTransformed()
        {
            var baseTarget = Substitute.For<IDrawTarget>();
            var target = new DefaultTranslatedTarget(15, 25, baseTarget);

            target.FillRectangle(50, 70, 20, 30, Pattern.White);

            baseTarget.Received().FillRectangle(65, 95, 20, 30, Pattern.White);
        }
    }
}
