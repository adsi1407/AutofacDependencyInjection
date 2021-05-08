using Autofac;
using AutofacDependencyInjection.Touch;
using Foundation;
using UIKit;

namespace NewSingleViewTemplate
{
    [Register("SceneDelegate")]
    public class SceneDelegate : UIResponder, IUIWindowSceneDelegate
    {

        [Export("window")]
        public UIWindow Window { get; set; }

        [Export("scene:willConnectToSession:options:")]
        public void WillConnect(UIScene scene, UISceneSession session, UISceneConnectionOptions connectionOptions)
        {
            // Use this method to optionally configure and attach the UIWindow `window` to the provided UIWindowScene `scene`.
            // If using a storyboard, the `window` property will automatically be initialized and attached to the scene.
            // This delegate does not imply the connecting scene or session are new (see UIApplicationDelegate `GetConfiguration` instead).
            UIWindowScene windowScene = new(session, connectionOptions);
            Window = new UIWindow(windowScene)
            {
                RootViewController = AppDelegate.Container.Resolve<MainViewController>()
            };

            Window.MakeKeyAndVisible();
        }
    }
}
