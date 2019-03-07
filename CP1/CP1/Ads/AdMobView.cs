using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CP1.Ads
{
    public class AdMobView : View
    {
        public static readonly BindableProperty AdUnitIdProperty = BindableProperty.Create(
                   nameof(AdUnitId),
                   typeof(string),
                   typeof(AdMobView),
                   string.Empty);

        public string AdUnitId
        {
            get => (string)GetValue(AdUnitIdProperty);
            set => SetValue(AdUnitIdProperty, value);
        }
    }
}
