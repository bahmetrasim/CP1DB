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
                        return "ca-app-pub-9496442035641158~4557840655";
                    default:
                        return "ca-app-pub-9496442035641158~4557840655";
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
                        return "ca-app-pub-9496442035641158/7670378711";
                    default:
                        return "ca-app-pub-9496442035641158/7670378711";
                }
            }
        }
    }
}
