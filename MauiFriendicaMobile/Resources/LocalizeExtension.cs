namespace FriendicaMobile.Resources;

[ContentProperty(nameof(Name))]
public class LocalizeExtension : IMarkupExtension<BindingBase>
{      
    public string Name { get; set; }

    public BindingBase ProvideValue(IServiceProvider serviceProvider)
    {
        return new Binding
        {
            Mode = BindingMode.OneWay,
            Path = $"[{Name}]",
            Source = LocalizationResourceManager.Instance
        };
    }

    object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider) 
    {
        return ProvideValue(serviceProvider);
    }
}