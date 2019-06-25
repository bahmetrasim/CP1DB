namespace CP1.Helpers
{
    using Xamarin.Forms;
    using Interfaces;
    using CP1.Resources;

    public static class Languages
    {
        static Languages()
        {
            var ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
            Resource.Culture = ci;
            DependencyService.Get<ILocalize>().SetLocal(ci);
        }

        public static string PG1L1
        {
            get { return Resource.PG1L1; }
        }

    }
}



