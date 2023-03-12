using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Collections.Specialized.BitVector32;

namespace APOD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string? Date { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();
        }

        private async void StartDate_CalendarClosed(object sender, RoutedEventArgs e)
        {
            Date = StartDatePicker.SelectedDate.Value.ToString("yyyy-MM-dd");

            try
            {
                var Info = await SelectedDateProcessor.LoadImage();

                var uriSource = new Uri(Info.Hdurl, UriKind.Absolute);
                NASAImage.Source = new BitmapImage(uriSource);

                DescriptionTextBox.Text = Info.Explanation;

            }
            catch (Exception ex)
            {
                string message = "No data found";
                MessageBox.Show(message);
            }

        }
    }
}
