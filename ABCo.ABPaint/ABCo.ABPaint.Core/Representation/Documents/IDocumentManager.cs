using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCo.ABPaint.Core.Representation.Documents
{
    /// <summary>
    /// A service that manages the retrieval of the current document, and the possibility of multiple documents etc.
    /// </summary>
    public interface IDocumentManager
    {
        Document GetCurrentDocument();
    }
}
