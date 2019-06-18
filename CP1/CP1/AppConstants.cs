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
                        return "ca-app-pub-3815590831760195~5715526881";
                    default:
                        return "ca-app-pub-3815590831760195~5715526881";
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
                        return "ca-app-pub-3815590831760195/4215754711";
                    default:
                        return "ca-app-pub-3815590831760195/4215754711";
                }
            }
        }
    }
}
