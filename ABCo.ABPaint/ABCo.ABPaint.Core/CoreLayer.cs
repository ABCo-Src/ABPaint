using ABCo.ABPaint.Core.Representation.Documents;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ABCo.ABPaint.Core
{
    public static class CoreLayer
    {
        /// <summary>
        /// Called by the VM layer, initializes everything the core layer needs.
        /// </summary>
        public static void Initialize(ServiceCollection serviceCollection)
        {
            // Register all services
            serviceCollection.AddSingleton<IDocumentManager, DocumentManager>();
        }
    }
}
