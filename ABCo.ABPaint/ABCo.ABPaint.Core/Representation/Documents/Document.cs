using ABCo.ABPaint.Core.Elements;
using ABCo.ABPaint.Core.Representation.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCo.ABPaint.Core.Representation
{
    public class Document
    {
        public Canvas Canvas { get; set; }
        public Element[] Elements { get; set; }
    }
}
