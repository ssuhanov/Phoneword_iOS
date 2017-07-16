using Foundation;
using System;
using UIKit;

namespace Phoneword_iOS
{
    public partial class StartViewController : UIViewController
    {
        public StartViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            UINavigationController mainView = UIViewControllerHelper.NavigationStoryboardInstance<MainViewController>();
            if (mainView != null)
            {
                PresentViewController(mainView, true, null);
            }
		}
    }
}