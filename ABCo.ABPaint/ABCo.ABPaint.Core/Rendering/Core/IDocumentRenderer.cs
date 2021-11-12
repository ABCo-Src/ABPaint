using ABCo.ABPaint.Core.Representation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCo.ABPaint.Core.Rendering.Core
{
    public interface IDocumentRenderer
    {
        public void Render(Document document);
    }
}
