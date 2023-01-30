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

		// TODO: replace the following by a setting in the SettingsPage
		var switchToCulture = new CultureInfo("es");
        if (AppResources.Culture.TwoLetterISOLanguageName.Equals("es", StringComparison.InvariantCultureIgnoreCase))
			switchToCulture = new CultureInfo("en");
		else if (AppResources.Culture.TwoLetterISOLanguageName.Equals("en", StringComparison.InvariantCultureIgnoreCase))
			switchToCulture = new CultureInfo("de");
		LocalizationResourceManager.Instance.SetCulture(switchToCulture);

		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = LocalizationResourceManager.Instance["SettingsPageTitle"].ToString();

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}

