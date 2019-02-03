using System;
using Xamarin.Forms;
using RendererExample.Droid;

[assembly: Dependency(typeof(AndroidRendererResolver))]
namespace RendererExample.Droid
{
    public class AndroidRendererResolver : IRendererResolver
    {
        public object GetRenderer(VisualElement element)
        {
            return Xamarin.Forms.Platform.Android.Platform.GetRenderer(element);
        }

        public bool HasRenderer(VisualElement element)
        {
            return GetRenderer(element) != null;
        }
    }
}
