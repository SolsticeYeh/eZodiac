using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using static eZodiac.Infor;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace eZodiac
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class InformationPage : Page
    {
        public InformationPage()
        {
            this.InitializeComponent();
            this.ari = new Ari();
            this.tau = new Tau();
            this.gem = new Gem();
            this.can = new Can();
            this.leo = new Leo();
            this.vir = new Vir();
            this.lib = new Lib();
            this.sco = new Sco();
            this.sag = new Sag();
            this.cap = new Cap();
            this.aqu = new Aqu();
            this.pis = new Pis();
        }
        public Ari ari { get; set; }
        public Tau tau { get; set; }
        public Gem gem { get; set; }
        public Can can {get;set;}
        public Leo leo {get;set;}
        public Vir vir {get;set;}
        public Lib lib {get;set;}
        public Sco sco {get;set;}
        public Sag sag {get;set;}
        public Cap cap {get;set;}
        public Aqu aqu {get;set;}
        public Pis pis {get;set;}
    }
}
