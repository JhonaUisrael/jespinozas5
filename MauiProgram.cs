using jespinozaS5.Helpers;
using jespinozaS5.Repository;
using Microsoft.Extensions.Logging;

namespace jespinozaS5
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

            string path = FileAccessHelper.GetLocalPath("dbPersona.db3");
            builder.Services.AddSingleton<PersonaRepository>(s=>ActivatorUtilities.CreateInstance<PersonaRepository>(s,path));

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
