using ABCo.ABPaint.Core.Representation.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCo.ABPaint.Core.Rendering
{
    public interface ICanvasRenderer
    {
        public void Render(Canvas canvas, RenderContext ctx);
    }
}
