using System.Windows;
using TransportSystem.Models;
using WpfApp.ViewModels;
using WpfApp.Views;

namespace WpfApp {
    public partial class MainWindow : Window
    {
        private TruckViewModel _truckViewModel;
        private TrailerViewModel _trailerViewModel;

        public MainWindow()
        {
            InitializeComponent();
            _truckViewModel = new TruckViewModel();
            _trailerViewModel = new TrailerViewModel();
            TrucksDataGrid.ItemsSource = _truckViewModel.Trucks;
            _truckViewModel.GetCommand.Execute(null);
            _trailerViewModel.GetCommand.Execute(null);
            TrailersDataGrid.ItemsSource = _trailerViewModel.Trailers;
            
        }

        private void AddTruckButton_Click(object sender, RoutedEventArgs e)
        {
            _truckViewModel.AddCommand.Execute(null);
        }

        private void DeleteTruckButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new TruckDialog();
            if (dialog.ShowDialog() == true)
            {
                _truckViewModel.SelectedTruckId = dialog.TruckId;
                _truckViewModel.DeleteCommand.Execute(null);
            }
        }

        private void UpdateTruckButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new TruckDialog();
            if (dialog.ShowDialog() == true)
            {
                _truckViewModel.SelectedTruckId = dialog.TruckId;
                _truckViewModel.UpdateCommand.Execute(null);
            }
        }
        
        private void AddTrailerButton_Click(object sender, RoutedEventArgs e)
        {
            _trailerViewModel.AddCommand.Execute(null);
        }
        
        private void DeleteTrailerButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new TrailerDialog();
            if (dialog.ShowDialog() == true)
            {
                _trailerViewModel.SelectedTrailerId = dialog.TruckId;
                _trailerViewModel.DeleteCommand.Execute(null);
            }
        }
        
        private void UpdateTrailerButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new TrailerDialog();
            if (dialog.ShowDialog() == true)
            {
                _trailerViewModel.SelectedTrailerId = dialog.TruckId;
                _trailerViewModel.UpdateCommand.Execute(null);
            }
        }
        
        
    }
}