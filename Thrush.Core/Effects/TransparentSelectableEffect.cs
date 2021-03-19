using Xamarin.Forms;

namespace Thrush.Core.Effects
{
    public class TransparentSelectableEffect : RoutingEffect
    {
        public TransparentSelectableEffect() : base("Thrush.TransparentSelectableEffect")
        {
        }

        public bool Borderless { get; set; } = true;
    }
}
