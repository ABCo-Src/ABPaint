using ABCo.ABPaint.Core.Representation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCo.ABPaint.Core.Rendering.Core
{
    public class DocumentRenderer : IDocumentRenderer
    {
        readonly IUIDrawableBitmap _output;

        public DocumentRenderer(IUIDrawableBitmap output) => _output = output;

        public void Render(Document doc)
        {
            _output.Start();

            for (int i = 0; i < doc.Elements.Length; i++)
            {
                doc.Elements[i].Render(_output);
            }

            _output.Finish();
        }
    }
}
