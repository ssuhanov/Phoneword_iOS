using System;

using UIKit;
using Foundation;
using System.Collections.Generic;

namespace Phoneword_iOS
{
	public partial class MainViewController : UIViewController
	{
		string translatedNumber = "";
		public List<string> PhoneNumbers { get; set; }

		protected MainViewController(IntPtr handle) : base(handle)
		{
			PhoneNumbers = new List<string>();
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			TranslateButton.TouchUpInside += (object sender, EventArgs e) =>
			{
				// Convert the phone number with text to a number
				// using PhoneTranslator.cs
				translatedNumber = PhoneNumberText.Text.ToPhoneNumber();

				// Dismiss the keyboard if text field was tapped
				PhoneNumberText.ResignFirstResponder();

				if (translatedNumber == "")
				{
					CallButton.SetTitle("Call", UIControlState.Normal);
					CallButton.Enabled = false;
				}
				else
				{
					CallButton.SetTitle("Call " + translatedNumber, UIControlState.Normal);
					CallButton.Enabled = true;
				}
			};

			CallButton.TouchUpInside += (object sender, EventArgs e) =>
			{
				PhoneNumbers.Add(translatedNumber);

				// Use URL handler with tel: prefix to invoke Apple's Phone app...
				var url = new NSUrl("tel:" + translatedNumber);

				// ...otherwise show an alert dialog
				if (!UIApplication.SharedApplication.OpenUrl(url))
				{
					var alert = UIAlertController.Create("Not supported", "Can't call the number: " + translatedNumber, UIAlertControllerStyle.Alert);
					alert.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
					PresentViewController(alert, true, null);
				}
			};

			CallHistoryButton.TouchUpInside += (object sender, EventArgs e) =>
			{
				CallHistoryController callHistory = UIViewControllerHelper.StoryboardInstance<CallHistoryController>();
				if (callHistory != null)
				{
					callHistory.PhoneNumbers = PhoneNumbers;
					NavigationController.PushViewController(callHistory, true);
				}
			};
		}
	}
}
