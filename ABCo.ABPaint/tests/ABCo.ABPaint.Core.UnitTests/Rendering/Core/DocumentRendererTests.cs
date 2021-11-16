using ABCo.ABPaint.Core.Elements;
using ABCo.ABPaint.Core.Rendering;
using ABCo.ABPaint.Core.Rendering.Core;
using ABCo.ABPaint.Core.Representation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCo.ABPaint.Core.UnitTests.Rendering.Core
{
    [TestClass]
    public class DocumentRendererTests
    {
        [TestMethod]
        public void Render_StartAndFinish()
        {
            var doc = new Document() { Elements = Array.Empty<Element>() };

            _renderer.Render(doc);

            _canvas.Received().Start();
            _canvas.Received().Finish();
        }

        [TestMethod]
        public void Render_MultipleElements_CallsRenderOnAll()
        {
            Element[] arr = new Element[3];
            for (int i = 0; i < arr.Length; i++)
                arr[i] = Substitute.For<Element>();

            var doc = new Document() { Elements = arr };

            _renderer.Render(doc);

            for (int i = 0; i < arr.Length; i++)
                arr[i].Received().Render(_canvas);
        }

        IDrawTarget _canvas;
        DocumentRenderer _renderer;

        [TestInitialize]
        public void Init()
        {
            _canvas = Substitute.For<IDrawTarget>();
            _renderer = new DocumentRenderer(_canvas);
        }
    }
}
