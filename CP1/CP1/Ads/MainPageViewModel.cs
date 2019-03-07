using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CP1.Ads
{
    public class MainPageViewModel : BindableObject
    {

        public string AdUnitId { get; set; } = "ca-app-pub-9496442035641158/7670378711";

        //public void Test()
        //{
        //    if (Device.RuntimePlatform == Device.iOS)
        //        AdUnitId = "iOS Key";
        //    else if (Device.RuntimePlatform == Device.Android)
        //        AdUnitId = "ca-app-pub-9496442035641158/7670378711";
        //}
    }
}
