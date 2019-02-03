using System;
using Xamarin.Forms;
namespace RendererExample
{
    public interface IRendererResolver
    {
        object GetRenderer(VisualElement element);

        bool HasRenderer(VisualElement element);
    }
}
