using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace ColorBinding.ViewModels
{
    class MainViewModel : INotifyPropertyChanged
    {
        private Color _color;
        private SolidColorBrush _selectedColor;


        public int Red
        {
            get => _color.R;
            set
            {
                _color.R = (byte)value;
                SelectedColor = new SolidColorBrush(_color);
                NotifyPropertyChanged();
                NotifyPropertyChanged("MergedDecimal");
                NotifyPropertyChanged("Hexadecimal");

            }
        }
        public double Green
        {
            get => _color.G;
            set
            {
                _color.G = (byte)value;
                SelectedColor = new SolidColorBrush(_color);
                NotifyPropertyChanged();
                NotifyPropertyChanged("MergedDecimal");
                NotifyPropertyChanged("Hexadecimal");
            }
        }
        public double Blue
        {
            get => _color.B;
            set
            {
                _color.B = (byte)value;
                SelectedColor = new SolidColorBrush(_color);
                NotifyPropertyChanged();
                NotifyPropertyChanged("MergedDecimal");
                NotifyPropertyChanged("Hexadecimal");
            }
        }
        public SolidColorBrush SelectedColor
        {
            get => _selectedColor;
            set
            {
                _selectedColor = value;
                NotifyPropertyChanged();
            }
        }
        public string MergeDecimal
        {
            get => String.Format("{0},{1},{2}", Red, Green, Blue);
        }
        public string Hexadecimal
        {
            get
            {
                string r = Red.ToString("X");
                string g = Green.ToString("X");
                string b = Blue.ToString("X");
                return "#" + r.PadLeft(2, '0') + g.PadLeft(2, '0') + b.PadLeft(2, '0');
            }
        }
        public MainViewModel()
        {
            _color = new Color();
            _color.A = 255;
            Red = 100;
            Green = 200;
            Blue = 50;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
