using ABCo.ABPaint.Core.Rendering;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCo.ABPaint.Core.UnitTests
{
    public abstract class CanvasBaseTest
    {
        protected IDrawTarget _canvas;

        [TestInitialize]
        public void Init()
        {
            _canvas = Substitute.For<IDrawTarget>();
        }
    }
}
