using FriendicaMobile.Resources;
using System.Globalization;

namespace FriendicaMobile.Pages;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = LocalizationResourceManager.Instance["SettingsPageTitle"].ToString();

		SemanticScreenReader.Announce(CounterBtn.Text);
	}

    private void LanguagePicker_SelectedIndexChanged(object sender, EventArgs e)
    {
		// TODO: move this into SettingsPage
		var picker = sender as Picker;
		CultureInfo culture;
		if (picker != null)
		{
			switch (picker.SelectedItem)
			{
				case "System default language":
					culture = CultureInfo.CurrentCulture;
					// TODO: sollen wir Preferences nochmal in einen Helper kapseln? Get mit Default könnte öfters verwendet werden)
					Preferences.Set("Language", "default");
                    break;
				case "German":
					culture = new CultureInfo("de"); 
					Preferences.Set("Language", "de");
                    break;
				case "Spanish":
					culture = new CultureInfo("es");
                    Preferences.Set("Language", "es");
                    break;
                case "French":
                    culture = new CultureInfo("fr");
                    Preferences.Set("Language", "fr");
                    break;
                case "Italian":
                    culture = new CultureInfo("it");
                    Preferences.Set("Language", "it");
                    break;
                case "Portuguese":
					culture = new CultureInfo("pt");
                    Preferences.Set("Language", "pt");
                    break;
                case "English":
				default:
                    culture = new CultureInfo("en");
                    Preferences.Set("Language", "en");
                    break;
            }
			LocalizationResourceManager.Instance.SetCulture(culture);
        }
	}
}

