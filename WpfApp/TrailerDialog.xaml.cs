using System;
using System.Windows;

namespace WpfApp.Views; 

public partial class TrailerDialog : Window {
    public int TruckId { get; set; }
    
    public TrailerDialog() {
        InitializeComponent();
    }
    
    private void OkButton_Click(object sender, RoutedEventArgs e)
    {
        TruckId = Convert.ToInt32(TruckIdTextBox.Text);
        this.DialogResult = true;
    }
}