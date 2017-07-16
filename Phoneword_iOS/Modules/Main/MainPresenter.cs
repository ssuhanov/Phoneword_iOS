using Foundation;
using System.Collections.Generic;

namespace Phoneword_iOS
{
    public class MainPresenter
    {
		string translatedNumber = "";
        readonly List<string> phoneNumber;

		public MainPresenter()
        {
            phoneNumber = new List<string>();
        }

        public void TranslateToPhoneNumber(IMainView view, string phoneNumberText)
        {
            translatedNumber = phoneNumberText.ToPhoneNumber();
            view.HideKeyboard();

			if (translatedNumber == "")
			{
				view.UpdateButtonTitle("Call", false);
			}
			else
			{
				view.UpdateButtonTitle("Call " + translatedNumber, true);
			}
		}

        public void CallToPhoneNumber(IMainView view)
        {
			phoneNumber.Add(translatedNumber);
			var url = new NSUrl("tel:" + translatedNumber);
            view.OpenUrl(url, translatedNumber);
		}

        public void ShowCallHistory(IMainView view)
        {
            CallHistoryController callHistoryView = UIViewControllerHelper.StoryboardInstance<CallHistoryController>();
			if (callHistoryView != null)
			{
				callHistoryView.PhoneNumbers = phoneNumber;
                view.PushViewController(callHistoryView);
			}
		}
    }
}
