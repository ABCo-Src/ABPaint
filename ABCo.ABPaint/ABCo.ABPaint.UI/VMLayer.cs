using ABCo.ABPaint.Core;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ABCo.ABPaint.UI
{
    public static class VMLayer
    {
        /// <summary>
        /// Called by the view, initializes everything the UI (view-model) layer of the app needs initialized. This includes initializing the core layer too.
        /// </summary>
        public static void Initialize(ServiceCollection serviceCollection)
        {
            // Setup the core layer
            CoreLayer.Initialize(serviceCollection);
        }
    }
}
