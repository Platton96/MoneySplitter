using Caliburn.Micro;
using MoneySplitter.Infrastructure;

namespace MoneySplitter.Win10.Dependecies
{
    public static class Dependecies
    {
        public static ILocalizationService LocalizationService => IoC.Get<ILocalizationService>();
    }
}
