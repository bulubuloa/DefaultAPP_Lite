﻿
using Android.App;
using Android.Content.PM;
using Android.OS;
using SupportUIXF.Droid;
using SupportXFLite.Droid;

namespace DefaultAPP.Droid
{
    [Activity(Label = "DefaultAPP", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            SupportXFLiteSetup.Initialize(this, savedInstanceState);
            SupportUIXFSetup.Initialize(this,savedInstanceState);
            LoadApplication(new App());
        }
    }
}