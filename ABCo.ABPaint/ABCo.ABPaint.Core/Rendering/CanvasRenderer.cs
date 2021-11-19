using ABCo.ABPaint.Core.Representation.Documents;
using ABCo.ABPaint.Core.Representation.Patterns;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCo.ABPaint.Core.Rendering
{
    public class CanvasRenderer : ICanvasRenderer
    {
        IDrawTarget _output;

        public CanvasRenderer(IDrawTarget output) => _output = output;

        public void Render(Canvas canvas, RenderContext ctx)
        {
#if DEBUG
            Debug.Assert(canvas.PixelWidth < _output.PixelWidth);
            Debug.Assert(canvas.PixelHeight < _output.PixelHeight);
#endif

            // Fill a white rectangle in the center
            int xPos = (_output.PixelWidth / 2) - (canvas.PixelWidth / 2);
            int yPos = (_output.PixelHeight / 2) - (canvas.PixelHeight / 2);

            _output.FillRectangle(xPos, yPos, canvas.PixelWidth, canvas.PixelHeight, Pattern.White);
        }
    }
}
