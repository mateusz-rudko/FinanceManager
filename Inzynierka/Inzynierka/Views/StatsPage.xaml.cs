using Microcharts;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entry = Microcharts.ChartEntry;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Inzynierka.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StatsPage : ContentPage
    {
        List<Entry> entries = new List<Entry>
        {
            new Entry(200)
            {
                Color=SKColor.Parse("#FF1943"),
                Label ="January",
                ValueLabel = "200"
            },
            new Entry(400)
            {
                Color = SKColor.Parse("00BFFF"),
                Label = "March",
                ValueLabel = "400"
            },
            new Entry(-100)
            {
                Color =  SKColor.Parse("#00CED1"),
                Label = "Octobar",
                ValueLabel = "-100"
            },
        };

        public StatsPage()
        {
           
            InitializeComponent();
             //Chart1.Chart = new RadialGaugeChart() { Entries = entries };
            Chart1.Chart = new RadialGaugeChart() { Entries = entries, };
            //Chart3.Chart = new DonutChart() { Entries = entries };
            //Chart4.Chart = new BarChart() { Entries = entries };
            //Chart5.Chart = new PointChart() { Entries = entries };
        }
    }
}