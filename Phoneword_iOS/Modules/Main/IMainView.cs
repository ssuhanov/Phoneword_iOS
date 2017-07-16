using Foundation;
using UIKit;

namespace Phoneword_iOS
{
    public interface IMainView
    {
        void HideKeyboard();
        void UpdateButtonTitle(string title, bool enabled);
        void OpenUrl(NSUrl url, string phoneNumber);
        void PushViewController(UIViewController viewController);
    }
}
