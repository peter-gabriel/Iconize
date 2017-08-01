
using Foundation;
using UIKit;

namespace Iconize.Sample.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication uiApplication, NSDictionary launchOptions)
        {
            global::Xamarin.Forms.Forms.Init();

            Plugin.Iconize.Iconize.Init();
           

            //var tmp = new Plugin.Iconize.IconFloatActionButtonRenderer();
            //var tmp2 = new Plugin.Iconize.IconImageRenderer();
            //var tmp3 = new Plugin.Iconize.IconLabelRenderer();
            //var tmp4 = new Plugin.Iconize.IconTabbedPageRenderer();
            //var tmp5 = new Plugin.Iconize.IconNavigationRenderer();
            //var tmp6 = new Plugin.Iconize.IconButtonRenderer();

            Plugin.Iconize.Iconize.With(new Plugin.Iconize.Fonts.EntypoPlusModule())
                                 .With(new Plugin.Iconize.Fonts.FontAwesomeModule())
                                 .With(new Plugin.Iconize.Fonts.IoniconsModule())
                                 .With(new Plugin.Iconize.Fonts.MaterialModule())
                                 .With(new Plugin.Iconize.Fonts.MeteoconsModule())
                                 .With(new Plugin.Iconize.Fonts.SimpleLineIconsModule())
                                 .With(new Plugin.Iconize.Fonts.TypiconsModule())
                                 .With(new Plugin.Iconize.Fonts.WeatherIconsModule());


            LoadApplication(new App());

            return base.FinishedLaunching(uiApplication, launchOptions);
        }
    }
}
