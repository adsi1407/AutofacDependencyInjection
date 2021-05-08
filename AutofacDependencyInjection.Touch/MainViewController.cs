using UIKit;

namespace AutofacDependencyInjection.Touch
{
    public partial class MainViewController : UIViewController
    {
        private readonly SecondViewController secondViewController;

        public MainViewController(SecondViewController secondViewController)
        {
            this.secondViewController = secondViewController;
        }

        partial void BtnSecondView_Click(Foundation.NSObject sender)
        {
            PresentViewController(secondViewController, true, null);
        }
    }
}
