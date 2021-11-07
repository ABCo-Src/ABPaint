using ABCo.ABPaint.UI.Desktop.Views;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;

namespace ABCo.ABPaint.UI.Desktop
{
    public class App : Application
    {
        public ServiceProvider Services = null!;

        public override void Initialize()
        {
            var serviceCollection = new ServiceCollection();
            VMLayer.Initialize(serviceCollection);
            Services = serviceCollection.BuildServiceProvider();

            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow
                {
                    DataContext = new MainViewModel(),
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
