using System;

using UIKit;

namespace FlyMe.iOS
{
    public partial class LauncherViewController : UIViewController
    {
        public LauncherViewController() : base("LauncherViewController", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

