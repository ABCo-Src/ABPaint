using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCo.ABPaint.Core.Representation.Patterns
{
    internal class SolidColor : Pattern
    {
        // RRGGBBXX
        public uint ColorValue { get; }

        public SolidColor(uint colorValue) => ColorValue = colorValue;
    }
}
