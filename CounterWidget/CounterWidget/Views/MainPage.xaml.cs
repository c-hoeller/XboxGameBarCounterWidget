using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.Foundation;
using Windows.Storage;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CounterWidget.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        private string _counterName;
        private int _counterValue;
        ApplicationDataContainer _localSettings = ApplicationData.Current.LocalSettings;

        public MainPage()
        {
            this.InitializeComponent();
            DataContext = this;
            ApplicationView.PreferredLaunchViewSize = new Size(440, 260);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
        }

        public string CounterName
        {
            get => _counterName;
            set
            {
                _counterName = value;
                this.OnPropertyChanged(nameof(CounterName));
                _localSettings.Values["counter name"] = CounterName;
            }
        }

        public int CounterValue
        {
            get => _counterValue;
            set
            {
                _counterValue = value;
                this.OnPropertyChanged(nameof(CounterValue));
                _localSettings.Values["counter value"] = CounterValue;
            }
        }


        private void DecrementCounterButtonClick(object sender, RoutedEventArgs e) => CounterValue--;

        private void IncrementCounterButtonClick(object sender, RoutedEventArgs e) => CounterValue++;

        private void ResetCounterButtonClick(object sender, RoutedEventArgs e) => CounterValue = 0;
    
        

        private void LoadState(object sender, RoutedEventArgs e)
        {
            var counterName = _localSettings.Values["counter name"] as string;
            var counterValue = _localSettings.Values["counter value"];
            if (counterName != null)
                CounterName = counterName;
            if (counterValue != null)
                CounterValue = (int)counterValue;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
