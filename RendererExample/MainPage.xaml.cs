using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Globalization;

namespace RendererExample
{
    public partial class MainPage : ContentPage
    {
        static int _pageCount = 0;

        DateTime _onAttached, _onDisappearing;
    
        public MainPage()
        {
            InitializeComponent();

            this.Title = $"Page {++_pageCount}";
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var now = DateTime.Now;
            System.Diagnostics.Debug.WriteLine($"OnAppearing: {this.Title} at {now} - {(now - _onAttached).TotalMilliseconds}ms later");
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            _onDisappearing = DateTime.Now;
            System.Diagnostics.Debug.WriteLine($"OnDisappearing: {this.Title} at {DateTime.Now}");
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            
            if(propertyName.Equals("Renderer", StringComparison.OrdinalIgnoreCase))
            {
                var now = DateTime.Now;

                var rr = DependencyService.Get<IRendererResolver>();
                
                if(rr.HasRenderer(this))
                {
                    //do setup work
                
                    System.Diagnostics.Debug.WriteLine($"Renderer Attached: {this.Title} at {now}");
                    _onAttached = DateTime.Now;
                }
                else
                { 
                    // do shutdown work
                    System.Diagnostics.Debug.WriteLine($"Renderer Detatched: {this.Title} at {now} - {(now - _onDisappearing).TotalMilliseconds}ms later");
                }
            }
        }


        void Handle_Clicked(object sender, System.EventArgs e)
        {
            var nextPage = new MainPage { };

            this.Navigation.PushAsync(nextPage);
        }
    }
}
