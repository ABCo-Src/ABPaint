using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCo.ABPaint.Core.Rendering
{
    public struct RenderContext
    {
        public IDrawTarget Target { get; }

        public RenderContext(IDrawTarget target) => Target = target;
    }
}
