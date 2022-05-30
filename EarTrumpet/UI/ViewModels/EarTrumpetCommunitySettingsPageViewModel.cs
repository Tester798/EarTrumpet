﻿namespace EarTrumpet.UI.ViewModels
{
    public class EarTrumpetCommunitySettingsPageViewModel : SettingsPageViewModel
    {
        private readonly AppSettings _settings;
        public bool UseLogarithmicVolume
        {
            get => _settings.UseLogarithmicVolume;
            set => _settings.UseLogarithmicVolume = value;
        }
        
        public bool MoveVolumeInTrayTooltipToRight
        {
            get => _settings.MoveVolumeInTrayTooltipToRight;
            set => _settings.MoveVolumeInTrayTooltipToRight = value;
        }
        
        public bool SkipAddingEarTrumpetToTrayTooltip
        {
            get => _settings.SkipAddingEarTrumpetToTrayTooltip;
            set => _settings.SkipAddingEarTrumpetToTrayTooltip = value;
        }
        
        public EarTrumpetCommunitySettingsPageViewModel(AppSettings settings) : base(null)
        {
            _settings = settings;
            Title = Properties.Resources.CommunitySettingsPageText;
            Glyph = "\xE902";
        }
    }
}