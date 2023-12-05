using System.Windows;
using System.Windows.Controls;
using WpfApp.Models;

namespace WpfApp.Controls
{
    public partial class TrailerDetailsControl : UserControl
    {
        public static readonly DependencyProperty TrailerProperty = DependencyProperty.Register(
            "Trailer", typeof(Trailer), typeof(TrailerDetailsControl), new PropertyMetadata(null));

        public Trailer Trailer
        {
            get { return (Trailer)GetValue(TrailerProperty); }
            set { SetValue(TrailerProperty, value); }
        }

        public TrailerDetailsControl()
        {
            InitializeComponent();
        }
    }
}