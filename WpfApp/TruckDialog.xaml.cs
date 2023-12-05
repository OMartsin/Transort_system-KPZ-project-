using System;
using System.Windows;

namespace WpfApp; 

public partial class TruckDialog : Window {
    
    public int TruckId { get; set; }
    
    public TruckDialog() {
        InitializeComponent();
    }
    
    private void OkButton_Click(object sender, RoutedEventArgs e)
    {
        TruckId = Convert.ToInt32(TruckIdTextBox.Text);
        this.DialogResult = true;
    }
}