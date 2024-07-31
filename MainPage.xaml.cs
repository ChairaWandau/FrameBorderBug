using System.ComponentModel;
using System.Windows.Input;

namespace FrameBorderBug
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();
        }
    }

    public partial class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private GradientStopCollection _gradientStops = new GradientStopCollection();
        public GradientStopCollection GradientStops
        {
            get => _gradientStops;
            private set
            {
                _gradientStops = value;
                OnPropertyChanged(nameof(GradientStops));
            }
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public ICommand ClickCommand { get; private set; }
        public MainPageViewModel()
        {
            UpdateGradientStops();
            ClickCommand = new Command(Click);
        }

        private void Click(object obj)
        {
            UpdateGradientStops();
        }

        private void UpdateGradientStops()
        {
            GradientStops = new GradientStopCollection();
            GradientStops.Add(new GradientStop(Color.Parse("Red"), 0f));
            GradientStops.Add(new GradientStop(Color.Parse("Blue"), 1f));
        }
    }

}
