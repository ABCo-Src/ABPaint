using ABCo.ABPaint.Core.Representation.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCo.ABPaint.Core.Rendering.Targets
{
    public class DefaultTranslatedTarget : IDrawTarget
    {
        IDrawTarget _base;

        int _translateX;
        int _translateY;

        public int PixelWidth => _base.PixelWidth;
        public int PixelHeight => _base.PixelWidth;

        public DefaultTranslatedTarget(int translateX, int translateY, IDrawTarget @base) => (_translateX, _translateY, _base) = (translateX, translateY, @base);

        public void FillRectangle(int x, int y, int width, int height, Pattern pattern)
        {
            _base.FillRectangle(x + _translateX, y + _translateY, width, height, pattern);
        }

        // TODO: Better exception objects?
        public void Start() => throw new Exception("Cannot start a 'DefaultTranslatedTarget'");
        public void Finish() => throw new Exception("Cannot start a 'DefaultTranslatedTarget'");
    }
}
