using ABCo.ABPaint.Core.Representation.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCo.ABPaint.Core.Rendering
{
    public interface IDrawTarget
    {
        public int PixelWidth { get; }
        public int PixelHeight { get; }

        public void Start();
        public void Finish();
        public void DrawRectangle(int x, int y, int width, int height, Pattern pattern);
        public void FillRectangle(int x, int y, int width, int height, Pattern pattern);
        public void DrawAndFillRectangle(int x, int y, int width, int height, Pattern pattern);
    }
}
