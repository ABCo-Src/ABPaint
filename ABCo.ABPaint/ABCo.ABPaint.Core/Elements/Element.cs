using ABCo.ABPaint.Core.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCo.ABPaint.Core.Elements
{
    public abstract class Element
    {
        public abstract void Render(RenderContext ctx);
    }
}
