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
					break;
				case "German":
					culture = new CultureInfo("de");
					break;
				case "Spanish":
					culture = new CultureInfo("es");
					break;
                case "French":
                    culture = new CultureInfo("fr");
                    break;
                case "Italian":
                    culture = new CultureInfo("it");
                    break;
                case "Portuguese":
					culture = new CultureInfo("pt");
					break;
                case "English":
				default:
                    culture = new CultureInfo("en");
                    break;
            }
			LocalizationResourceManager.Instance.SetCulture(culture);
        }
	}
}

