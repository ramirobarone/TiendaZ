using Android.Content;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace AppTiendaZ.Droid.CustomRenders
{
    public class MyPickerRenderer : PickerRenderer
    {
        public MyPickerRenderer(Context context) : base(context)
        {

        }
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.SetBackgroundColor(global::Android.Graphics.Color.Transparent);
            }
        }
    }
}