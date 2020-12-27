using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Text.RegularExpressions;

namespace Polyland
{
    /// <summary>
    /// @author John Ellis
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ConfigurationData _data;
        public MainWindow()
        {
            InitializeComponent();
            _data = new ConfigurationData();
            this.DataContext = _data;  
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int value = _data.LargestPolygonSize;
            if (value>=3 && value<=ConfigurationData.LargestPossiblePolygonSize)
            {
                CalculateAync();
            }
            else
            {
                MessageBox.Show(string.Format("{0} is not between 3 & {1}", value, ConfigurationData.LargestPossiblePolygonSize));
            }
        }

        public async void CalculateAync()
        {
            LargestPolygonTextBox.IsEnabled = false;
            StartButton.IsEnabled = false;
            await Task.Run(() => _data.CheckPolygons());
            MessageBox.Show(string.Format("Found {0} polygons with metalllic ratios", _data.MetallicPolygons.Count));
            StartButton.IsEnabled = true;
            LargestPolygonTextBox.IsEnabled = true;
        }


    }
}
