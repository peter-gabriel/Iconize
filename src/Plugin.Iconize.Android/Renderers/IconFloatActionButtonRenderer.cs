using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using FAB = Android.Support.Design.Widget.FloatingActionButton;
using Plugin.Iconize;
using Plugin.Iconize.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(IconFloatActionButton), typeof(IconFloatActionButtonRenderer))]

namespace Plugin.Iconize.Renderers
{

   public class IconFloatActionButtonRenderer : Xamarin.Forms.Platform.Android.AppCompat.ViewRenderer<IconFloatActionButton, FAB>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<IconFloatActionButton> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement == null)
                return;


            var fab = new FAB(Context)
            {
                BackgroundTintList = ColorStateList.ValueOf(Element.ButtonColor.ToAndroid()),
            };


            var bmp = UpdateTextBitmap(e.NewElement.Text);
            if (bmp != null)
                fab.SetImageDrawable(bmp);
            
            fab.Click += Fab_Click;
            
            fab.UseCompatPadding = true;
            
            SetNativeControl(fab);

        }
        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            base.OnLayout(changed, l, t, r, b);
            Control.BringToFront();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var fab = (FAB)Control;
            if (e.PropertyName == nameof(Element.ButtonColor))
            {
                fab.BackgroundTintList = ColorStateList.ValueOf(Element.ButtonColor.ToAndroid());
            }
            if (e.PropertyName == nameof(Element.Text))
            {
                var bmp = UpdateTextBitmap(Element.Text);
                if (bmp != null)
                    fab.SetImageDrawable(bmp);
                fab.Elevation = 16;
            }
            base.OnElementPropertyChanged(sender, e);
        }

        private Drawable UpdateTextBitmap(string Text)
        {
            Drawable bitmap = null;
            var icon = Iconize.FindIconForKey(Text);
            if (icon != null)
                bitmap = new IconDrawable(Context, icon);

            return bitmap;
        }
        private void Fab_Click(object sender, EventArgs e)
        {
            // proxy the click to the element
            ((IButtonController)Element).SendClicked();
        }
    }
}