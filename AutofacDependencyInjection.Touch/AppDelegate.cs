using Autofac;
using AutofacDependencyInjection.Domain;
using Foundation;
using UIKit;

namespace AutofacDependencyInjection.Touch
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : UIResponder, IUIApplicationDelegate
    {

        [Export("window")]
        public UIWindow Window { get; set; }

        public static IContainer Container { get; private set; }

        [Export("application:didFinishLaunchingWithOptions:")]
        public bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            // Override point for customization after application launch.
            // If not required for your application you can safely delete this method

            InitializeAutofac();
            return true;
        }

        // UISceneSession Lifecycle

        [Export("application:configurationForConnectingSceneSession:options:")]
        public UISceneConfiguration GetConfiguration(UIApplication application, UISceneSession connectingSceneSession, UISceneConnectionOptions options)
        {
            // Called when a new scene session is being created.
            // Use this method to select a configuration to create the new scene with.
            return UISceneConfiguration.Create("Default Configuration", connectingSceneSession.Role);
        }

        private static void InitializeAutofac()
        {
            ContainerBuilder containerBuilder = new();

            containerBuilder.RegisterType<MessageRepository>().As<IMessageRepository>();
            containerBuilder.RegisterType<MessageService>();
            containerBuilder.RegisterType<MainViewController>();
            containerBuilder.RegisterType<SecondViewController>();
            Container = containerBuilder.Build();
        }
    }
}

