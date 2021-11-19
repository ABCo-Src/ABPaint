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
        public void FillRectangle_CallsTransformed()
        {
            var baseTarget = Substitute.For<IDrawTarget>();
            var target = new DefaultTranslatedTarget(15, 25, baseTarget);

            target.FillRectangle(50, 70, 20, 30, Pattern.White);

            baseTarget.Received().FillRectangle(65, 95, 20, 30, Pattern.White);
        }
    }
}
