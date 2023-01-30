using System.ComponentModel;
using System.Globalization;

namespace FriendicaMobile.Resources
{
    public class LocalizationResourceManager : INotifyPropertyChanged
    {
        private LocalizationResourceManager()
        {
            if (Preferences.ContainsKey("Language"))
            {
                var lang = Preferences.Get("Language", "default");
                if (lang == "default")
                    AppResources.Culture = CultureInfo.CurrentCulture;
                else
                    AppResources.Culture = new CultureInfo(lang);
            }
            else
                AppResources.Culture = CultureInfo.CurrentCulture;
        }

        public static LocalizationResourceManager Instance { get; } = new();

        // non existing strings for a language will result in returning the neutral language (English)
        public object this[string resourceKey]
            => AppResources.ResourceManager.GetObject(resourceKey, AppResources.Culture) ?? Array.Empty<byte>();

        public event PropertyChangedEventHandler PropertyChanged;

        public void SetCulture(CultureInfo culture)
        {
            AppResources.Culture = culture;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }
    }
}
