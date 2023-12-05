using System.Windows;
using WpfApp.Models;

namespace WpfApp
{
    public partial class TrailerDetailsWindow : Window
    {
        public static readonly DependencyProperty TrailerProperty = DependencyProperty.Register(
            "Trailer", typeof(Trailer), typeof(TrailerDetailsWindow), new PropertyMetadata(null));

        public Trailer Trailer
        {
            get { return (Trailer)GetValue(TrailerProperty); }
            set { SetValue(TrailerProperty, value); }
        }

        public TrailerDetailsWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}