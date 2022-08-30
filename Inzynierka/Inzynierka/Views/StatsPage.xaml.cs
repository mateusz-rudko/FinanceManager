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
using Inzynierka.Models;

namespace Inzynierka.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StatsPage : ContentPage
    {
        private async void DrawChartForIncome(string firstDate, string secondDate)
        {
            var entries = new List<Entry>();
            firstDate = datePickerStart.ToString();
            secondDate = datePickerEnd.ToString();
            var transactions = await App.Database.GetAllTransactionsAsync();
            var filtered = transactions.Where(t => t.IsIncome == true && t.Date >= datePickerStart.Date && t.Date <= datePickerEnd.Date)
                        .GroupBy(g => g.Category)
                        .Select(p => new Transaction
                        { 
                            Category = p.Key,
                            Price = p.Sum(pp=>pp.Price) 
                        }).ToList();
            if(filtered.Count() == 0)
            {
                isIncomeLabel.IsVisible = true;
            }
            else
            {
                
                foreach(var fil in filtered)
                {
                    entries.Add(new Entry(fil.Price)
                    {
                        Color = SKColor.Parse("#FF1943"),
                        Label = fil.Category,
                        ValueLabel = fil.Price.ToString()
                    });
                }
                chartViewLineForIncomes.Chart = new BarChart
                {
                    Entries = entries,
                    LabelColor = SKColor.Parse("#C0C0C0"),

                };
            }    
        }
        private async void DrawChartForExpense(string firstDate, string secondDate)
        {
            var entries = new List<Entry>();
            firstDate = datePickerStart.ToString();
            secondDate = datePickerEnd.ToString();
            var transactions = await App.Database.GetAllTransactionsAsync();
            var filtered = transactions.Where(t => t.IsIncome == false && t.Date >= datePickerStart.Date && t.Date <= datePickerEnd.Date)
                        .GroupBy(g => g.Category)
                        .Select(p => new Transaction
                        {
                            Category = p.Key,
                            Price = p.Sum(pp => pp.Price)
                        }).ToList();
            if (filtered.Count() == 0)
            {
               isExpenseLabel.IsVisible = true;
            }
            else
            {

                foreach (var fil in filtered)
                {
                    entries.Add(new Entry(fil.Price)
                    {
                        Color = SKColor.Parse("#FF1943"),
                        Label = fil.Category,
                        ValueLabel = fil.Price.ToString()
                    });
                }
                chartViewLineForExpenses.Chart = new BarChart
                {
                    Entries = entries,
                    LabelColor = SKColor.Parse("#C0C0C0"),

                };
            }
        }
        private void filterButtonClicked(object sender, EventArgs e)
        {
            string firstDate = datePickerStart.Date.ToString();
            string secondDate = datePickerEnd.Date.ToString();
            DrawChartForIncome(firstDate,secondDate);
            DrawChartForExpense(firstDate,secondDate);
        }
        //List<Entry> entries = new List<Entry>
        //{
        //    new Entry(200)
        //    {
        //        Color=SKColor.Parse("#FF1943"),
        //        Label ="January",
        //        ValueLabel = "200"
        //    },
        //    new Entry(400)
        //    {
        //        Color = SKColor.Parse("00BFFF"),
        //        Label = "March",
        //        ValueLabel = "400"
        //    },
        //    new Entry(-100)
        //    {
        //        Color =  SKColor.Parse("#00CED1"),
        //        Label = "Octobar",
        //        ValueLabel = "-100"
        //    },
        //};

        public StatsPage()
        {

            InitializeComponent();
            isIncomeLabel.IsVisible = false;
            isExpenseLabel.IsVisible = false;
            DrawChartForIncome(datePickerStart.Date.ToString(),datePickerEnd.ToString());
            DrawChartForExpense(datePickerStart.Date.ToString(), datePickerEnd.ToString());
            //Chart1.Chart = new RadialGaugeChart() { Entries = DrawChartForIncome() };
            //Chart2.Chart = new RadialGaugeChart() { Entries = entries, };
            //Chart3.Chart = new DonutChart() { Entries = entries };
            //Chart4.Chart = new BarChart() { Entries = entries };
            //Chart5.Chart = new PointChart() { Entries = entries };
        }
    }
}