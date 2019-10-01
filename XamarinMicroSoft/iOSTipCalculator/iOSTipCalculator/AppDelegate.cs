﻿using Foundation;
using UIKit;

namespace iOSTipCalculator
{
  // The UIApplicationDelegate for the application. This class is responsible for launching the
  // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
  [Register("AppDelegate")]
  public class AppDelegate : UIApplicationDelegate
  {
    // class-level declarations

    public override UIWindow Window
    {
      get;
      set;
    }

    public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
    {
      Window = new UIWindow(UIScreen.MainScreen.Bounds);

      Window.RootViewController = new MyViewController();

      Window.MakeKeyAndVisible();

      return true;
    }
  }
}

