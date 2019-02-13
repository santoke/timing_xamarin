using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

using PCLAppConfig;
using System.Reflection;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace timing
{
    public partial class App : Application
	{
        static public int ScreenWidth;
        static public readonly int GuideWidth = 360;

        public App ()
		{
			InitializeComponent();

            Assembly assembly = typeof(App).GetTypeInfo().Assembly;
            ConfigurationManager.Initialise(assembly.GetManifestResourceStream("timing.Droid.config.Secrets.xml"));

            MainPage = new MainPage();
		}

		protected override void OnStart ()
		{
#if DEBUG
#else
            AppCenter.Start($"ios=AppScrent;android={ConfigurationManager.AppSettings["AppCenterAndroid"]}",
                typeof(Analytics), typeof(Crashes));
#endif
        }

        protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
