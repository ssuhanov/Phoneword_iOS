using UIKit;

namespace Phoneword_iOS
{
    public static class UIViewControllerHelper
    {
        public static T StoryboardInstance<T>() where T : UIViewController
        {
            UIStoryboard storyboard = UIStoryboard.FromName(typeof(T).Name, null);
            return storyboard.InstantiateInitialViewController() as T;
        }

        public static UINavigationController NavigationStoryboardInstance<T>() where T : UIViewController
        {
            UIStoryboard storyboard = UIStoryboard.FromName(typeof(T).Name, null);
            return storyboard.InstantiateInitialViewController() as UINavigationController;
        }
    }
}
