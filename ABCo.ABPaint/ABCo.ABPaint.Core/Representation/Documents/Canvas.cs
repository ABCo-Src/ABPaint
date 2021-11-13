using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCo.ABPaint.Core.Representation.Documents
{
    public class Canvas
    {
        public int PixelWidth { get; set; }
        public int PixelHeight { get; set; }

        public Canvas(int pixelWidth, int pixelHeight) => (PixelWidth, PixelHeight) = (pixelWidth, pixelHeight);
    }
}
