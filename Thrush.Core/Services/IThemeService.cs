using Thrush.Core.Models;
using Xamarin.Forms;

namespace Thrush.Core.Helpers
{
    public interface IThemeService
    {
        ResourceDictionary CustomColors { get; set; }
        ThemeMode AppTheme { get; set; }
        void UpdateTheme(ThemeMode themeMode = ThemeMode.Auto);
    }
}
