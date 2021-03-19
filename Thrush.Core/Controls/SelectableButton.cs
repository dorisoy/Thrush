using Thrush.Core.Effects;
using Xamarin.Forms;

namespace Thrush.Core.Controls
{
    public class SelectableButton : ImageButton
    {
        public SelectableButton()
        {
            Effects.Add(new TransparentSelectableEffect());
        }
    }
}
