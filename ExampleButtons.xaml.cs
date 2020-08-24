using ACM.Presentation.Controls.Buttons;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ACM.Presentation.Views.Examples
{
    /// <summary>
    /// ExampleButtons.xaml 的交互逻辑
    /// </summary>
    public partial class ExampleButtons : UserControl
    {
        public ExampleButtons()
        {
            InitializeComponent();
        }


        private async void IndeternimateButton_Done_Click(object sender, RoutedEventArgs e)
        {
            ACMButton button = sender as ACMButton;
            button.IsProcessStart = true;

            await Task.Delay(1000 * 3);

            button.IsProcessCompleted = true;
        }

        private async void IndeternimateButton_Error_Click(object sender, RoutedEventArgs e)
        {
            ACMButton button = sender as ACMButton;
            button.IsProcessStart = true;

            await Task.Delay(1000 * 3);

            button.IsProcessCompleted = true;
        }
    }
}
