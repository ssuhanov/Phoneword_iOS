using System;

using UIKit;
using Foundation;

namespace Phoneword_iOS
{
    public partial class MainViewController : UIViewController, IMainView
    {
        MainPresenter presenter;

		#region IMainView

		public void HideKeyboard()
		{
			PhoneNumberText.ResignFirstResponder();
		}

		public void UpdateButtonTitle(string title, bool enabled)
		{
			CallButton.SetTitle(title, UIControlState.Normal);
			CallButton.Enabled = enabled;
		}

		public void OpenUrl(NSUrl url, string phoneNumber)
		{
			if (!UIApplication.SharedApplication.OpenUrl(url))
			{
                ShowError(phoneNumber);
			}
		}

		public void PushViewController(UIViewController viewController)
		{
			NavigationController.PushViewController(viewController, true);
		}

		#endregion

		public MainViewController(IntPtr handle) : base(handle)
        {
			presenter = new MainPresenter();
		}

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            TranslateButton.TouchUpInside += (object sender, EventArgs e) =>
            {
                presenter.TranslateToPhoneNumber(this, PhoneNumberText.Text);
            };

            CallButton.TouchUpInside += (object sender, EventArgs e) =>
            {
                presenter.CallToPhoneNumber(this);
            };

            CallHistoryButton.TouchUpInside += (object sender, EventArgs e) =>
            {
                presenter.ShowCallHistory(this);
            };
        }

		void ShowError(string phoneNumber)
		{
			var alert = UIAlertController.Create("Not supported", "Can't call the number: " + phoneNumber, UIAlertControllerStyle.Alert);
			alert.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
			PresentViewController(alert, true, null);
		}
	}
}
