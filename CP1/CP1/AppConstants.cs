using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CP1
{
    public class AppConstants
    {
        public static string AppId
        {
            get
            {
                switch (Device.RuntimePlatform)
                {
                    case Device.Android:
                        return "app-pub-3940256099942544~3347511713";
                    default:
                        return "app-pub-3940256099942544~3347511713";
                }
            }
        }
        public static string BannerId
        {
            get
            {
                switch (Device.RuntimePlatform)
                {
                    case Device.Android:
                        return "ca-app-pub-3940256099942544/6300978111";
                    default:
                        return "ca-app-pub-3940256099942544/6300978111";
                }
            }
        }
    }
}
