using System;
using UIKit;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using CoreGraphics;
using System.ComponentModel;
using Plugin.Iconize;
using Xamarin.Forms.Internals;

[assembly: ExportRenderer(typeof(IconFloatActionButton), typeof(IconFloatActionButtonRenderer))]

namespace Plugin.Iconize
{
    [Preserve]
    public class IconFloatActionButtonRenderer: ButtonRenderer
    {
        /// <summary>
        /// Raises the <see cref="E:ElementChanged" /> event.
        /// </summary>
        /// <param name="e">
        /// The <see cref="ElementChangedEventArgs{Button}" /> instance containing the event data.
        /// </param>
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            if (Control == null || Element == null)
                return;

            Element.WidthRequest = 50;
            Element.HeightRequest = 50;
            Element.BorderRadius = 25;
            Element.BorderWidth = 0;

            // set background
            Control.BackgroundColor = ((IconFloatActionButton)Element).ButtonColor.ToUIColor();

            UpdateText();
        }

        /// <summary>
        /// Called when [element property changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">
        /// The <see cref="PropertyChangedEventArgs" /> instance containing the event data.
        /// </param>
        protected override void OnElementPropertyChanged(Object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (Control == null || Element == null)
                return;

            switch (e.PropertyName)
            {
                case nameof(IconFloatActionButton.FontSize):
                case nameof(IconFloatActionButton.Text):
                case nameof(IconFloatActionButton.TextColor):
                    UpdateText();
                    break;
                case nameof(IconFloatActionButton.ButtonColor):
                    Control.BackgroundColor = ((IconFloatActionButton)Element).ButtonColor.ToUIColor();
                    break;
            }
        }

        public override void Draw(CGRect rect)
        {
            base.Draw(rect);
            // add shadow
            Layer.ShadowRadius = 2.0f;
            Layer.ShadowColor = UIColor.Black.CGColor;
            Layer.ShadowOffset = new CGSize(1, 1);
            Layer.ShadowOpacity = 0.80f;
            Layer.ShadowPath = UIBezierPath.FromOval(Layer.Bounds).CGPath;
            Layer.MasksToBounds = false;

        }

        /// <summary>
        /// Updates the text.
        /// </summary>
        private void UpdateText()
        {
            var icon = Iconize.FindIconForKey(Element.Text);
            if (icon != null)
            {
                var font = Iconize.FindModuleOf(icon)?.ToUIFont((nfloat)Element.FontSize);
                if (font != null)
                {
                    Control.SetTitle($"{icon.Character}", UIControlState.Normal);
                    Control.Font = font;
                }
            }
        }
    }
}