

namespace EarTrumpet.UI.ViewModels
{
    public class EarTrumpetExtraSettingsPageViewModel : SettingsPageViewModel
    {
        public bool UseGlobalMouseWheelHook
        {
            get => _settings.UseGlobalMouseWheelHook;
            set => _settings.UseGlobalMouseWheelHook = value;
        }

        private readonly AppSettings _settings;

        public EarTrumpetExtraSettingsPageViewModel(AppSettings settings) : base(null)
        {
            _settings = settings;
            Title = Properties.Resources.ExtraSettingsPageText;
            Glyph = "\xE74C";
        }
    }
}