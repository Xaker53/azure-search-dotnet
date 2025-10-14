using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;
using System.Reflection;
using UserLoginIn.Interface;
using UserLoginIn.Requests;
using UserLoginIn.Tools;
#if WINDOWS
using Microsoft.UI;
using Microsoft.UI.Windowing;
using Windows.Graphics;
using WinRT.Interop;
#endif

namespace UserLoginIn
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            using var stream = FileSystem.OpenAppPackageFileAsync("appsettings.json").Result;
            builder.Configuration.AddJsonStream(stream);

            builder.Services.Configure<ApiSettings>(builder.Configuration.GetSection(nameof(ApiSettings)));
            builder.Services.AddSingleton<IJsonconver, ConvertToJson>();
            builder.Services.AddScoped<ILoginRequests, LoginRequests>();

            builder.Services.AddSingleton<ITryCatchRequest, TryCatchRequest>();

            


            builder.Services.AddScoped<IRegistrationRequests, RegistrationRequests>();
            builder.Services.AddTransient<RegistrationsPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

  
            builder.ConfigureLifecycleEvents(events =>
            {
#if WINDOWS
                events.AddWindows(windows =>
                {
                    windows.OnWindowCreated(window =>
                    {
                        const int width = 430;
                        const int height = 730;

                        var hwnd = WindowNative.GetWindowHandle(window);
                        var windowId = Win32Interop.GetWindowIdFromWindow(hwnd);
                        var appWindow = AppWindow.GetFromWindowId(windowId);

                        if (appWindow.Presenter is OverlappedPresenter presenter)
                        {
                            presenter.IsResizable = false;  
                            presenter.IsMaximizable = false;
                            presenter.IsMinimizable = true;

                            // presenter.SetBorderAndTitleBar(false, false);
                        }

                        appWindow.Resize(new SizeInt32(width, height));
                    });
                });
#endif
            });

            return builder.Build();
        }
    }
}
