using System;
using Xamarin.Forms;
using RendererExample.iOS;

[assembly: Dependency(typeof(IosRendererResolver))]
namespace RendererExample.iOS
{
    public class IosRendererResolver : IRendererResolver
    {
        public object GetRenderer(VisualElement element)
        {
            return Xamarin.Forms.Platform.iOS.Platform.GetRenderer(element);
        }

        public bool HasRenderer(VisualElement element)
        {
            return GetRenderer(element) != null;
        }
    }
}
