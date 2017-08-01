using Xamarin.Forms;

namespace Plugin.Iconize
{
    public class IconFloatActionButton: Button
    {
        public static BindableProperty ButtonColorProperty = BindableProperty.Create(nameof(ButtonColor), typeof(Color), typeof(IconFloatActionButton), Color.Accent);
        public Color ButtonColor
        {
            get
            {
                return (Color)GetValue(ButtonColorProperty);
            }
            set
            {
                SetValue(ButtonColorProperty, value);
            }
        }
    }
}
