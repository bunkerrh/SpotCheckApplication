using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SpotCheckApplication
{

    public partial class App : Application
    {
        //Add a reference to any page you want to have a hamburger menu... lookk at createHamburgerIcon() for demo
        public static NavigationPage navigationPage { get; set; }
        public static double ScreenWidth { get; internal set; }
        public static double ScreenHeight { get; internal set; }

        public App()
        {
            InitializeComponent();
        }
    }
}
