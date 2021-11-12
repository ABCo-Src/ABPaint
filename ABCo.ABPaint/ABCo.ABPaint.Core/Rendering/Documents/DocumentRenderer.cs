using ABCo.ABPaint.Core.Representation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCo.ABPaint.Core.Rendering.Documents
{
    public class DocumentRenderer : IDocumentRenderer
    {
        IUIRenderCanvas _canvas;

        public DocumentRenderer(IUIRenderCanvas canvas) => _canvas = canvas;

        public void Render(Document doc)
        {
            _canvas.Start();

            for (int i = 0; i < doc.Elements.Length; i++)
            {
                doc.Elements[i].Render(_canvas);
            }

            _canvas.Finish();
        }
    }
}
