using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace timing
{
    public partial class MainPage : ContentPage
    {
        public string DebugText { get; } = "This is Sparta";

        public MainPage()
        {
            InitializeComponent();

            //BindingContext = this;
            //DebugText = Application.Current.MainPage.Width.ToString() + ":" + Application.Current.MainPage.Height.ToString();
        }
    }
}
