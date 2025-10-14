using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;
using System.Reflection;
using System.Runtime.InteropServices;
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
        [DllImport("User32.dll")]
        private static extern uint GetDpiForWindow(IntPtr hWnd);
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
            const int logicalWidth = 430;
            const int logicalHeight = 730;

            var hwnd = WindowNative.GetWindowHandle(window);
            var windowId = Win32Interop.GetWindowIdFromWindow(hwnd);
            var appWindow = AppWindow.GetFromWindowId(windowId);

            if (appWindow.Presenter is OverlappedPresenter presenter)
            {
                presenter.IsResizable = false;
                presenter.IsMaximizable = false;
                presenter.IsMinimizable = true;
            }

            // Get DPI for the window
            uint dpi = GetDpiForWindow(hwnd);
            float scalingFactor = dpi / 96f;

            int scaledWidth = (int)(logicalWidth * scalingFactor);
            int scaledHeight = (int)(logicalHeight * scalingFactor);

            appWindow.Resize(new SizeInt32(scaledWidth, scaledHeight));
        });
    });
#endif
            });

            return builder.Build();
        }
    }
}
