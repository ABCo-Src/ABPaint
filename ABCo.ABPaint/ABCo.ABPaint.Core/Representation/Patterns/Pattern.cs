﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCo.ABPaint.Core.Representation.Patterns
{
    public class Pattern
    {
        public static Pattern White { get; } = new SolidColor(0xFFFFFF00);
    }
}
