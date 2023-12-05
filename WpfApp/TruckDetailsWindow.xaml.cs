using System.Windows;
using WpfApp.Models;

namespace WpfApp; 

public partial class TruckDetailsWindow : Window {
    public Truck Truck { get; set; }

    public TruckDetailsWindow(Truck truck = null) {
        InitializeComponent();

        if (truck != null) {
            Truck = truck;
            NumberPlateTextBox.Text = truck.TruckNumberPlate;
            FuelTypeTextBox.Text = truck.TruckFuelType;
            VendorTextBox.Text = truck.TruckVendor;
            ModelTextBox.Text = truck.TruckModel;
            EcoStandartEuroTextBox.Text = truck.TruckEcoStandartEuro.ToString();
            WeightTextBox.Text = truck.TruckWeight.ToString();
            FrontTyresTypeTextBox.Text = truck.TruckFrontTyresType;
            RearTyresTypeTextBox.Text = truck.TruckRearTyresType;
        }
    }
    
    private void SaveButton_Click(object sender, RoutedEventArgs e)
    {
        Truck = Truck ?? new Truck();
        Truck.TruckNumberPlate = NumberPlateTextBox.Text;
        Truck.TruckFuelType = FuelTypeTextBox.Text;
        Truck.TruckVendor = VendorTextBox.Text;
        Truck.TruckModel = ModelTextBox.Text;

        // Validate and parse Eco Standard EURO
        if (int.TryParse(EcoStandartEuroTextBox.Text, out int ecoStandard))
        {
            Truck.TruckEcoStandartEuro = ecoStandard;
        }
        else
        {
            MessageBox.Show("Invalid Eco Standard EURO value.");
            return; // Stop further execution
        }

        // Validate and parse Weight
        if (int.TryParse(WeightTextBox.Text, out int weight))
        {
            Truck.TruckWeight = weight;
        }
        else
        {
            MessageBox.Show("Invalid Weight value.");
            return; // Stop further execution
        }

        Truck.TruckFrontTyresType = FrontTyresTypeTextBox.Text;
        Truck.TruckRearTyresType = RearTyresTypeTextBox.Text;

        this.DialogResult = true;
        this.Close();
    }
    
    private void CancelButton_Click(object sender, RoutedEventArgs e)
    {
        this.DialogResult = false;
        this.Close();
    }
}