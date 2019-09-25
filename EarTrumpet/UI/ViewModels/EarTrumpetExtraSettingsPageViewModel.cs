

namespace EarTrumpet.UI.ViewModels
{
    public class EarTrumpetExtraSettingsPageViewModel : SettingsPageViewModel
    {
        private readonly AppSettings _settings;

        public EarTrumpetExtraSettingsPageViewModel(AppSettings settings) : base(null)
        {
            _settings = settings;
            Title = Properties.Resources.ExtraSettingsPageText;
            Glyph = "\xE74C";
        }
    }
}