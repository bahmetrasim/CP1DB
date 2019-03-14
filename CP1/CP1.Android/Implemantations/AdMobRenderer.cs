using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.Gms.Ads;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CP1.Controls;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using CP1.Droid.Implemantations;
using Android.Content.Res;

[assembly: ExportRenderer(typeof(AdMobControl), typeof(AdMobRenderer))]
namespace CP1.Droid.Implemantations
{
    public class AdMobRenderer : ViewRenderer<AdMobControl, AdView>
    {
        public AdMobRenderer(Context context) : base(context) { }

        private int SmartBannerDpHeight()
        {

            var dpHeight = Resources.DisplayMetrics.HeightPixels / Resources.DisplayMetrics.Density;

            if (dpHeight <= 400)
            {
                return 40;
            }
            if (dpHeight <= 720)
            {
                return 62;
            }
            return 102;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<AdMobControl> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                var adView = new AdView(Context)
                {
                    AdSize = AdSize.SmartBanner,
                    AdUnitId = Element.AdUnitId
                };

                var requestbuilder = new AdRequest.Builder();

                adView.LoadAd(requestbuilder.Build());
                e.NewElement.HeightRequest = SmartBannerDpHeight();

                SetNativeControl(adView);
            }
        }
    }
}