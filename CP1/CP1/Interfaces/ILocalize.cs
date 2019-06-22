namespace CP1.Interfaces
{
    using System.Globalization;

    public interface ILocalize
    {
        CultureInfo GetCurrentCultureInfo();

        void SetLocal(CultureInfo ci);
    }
}
