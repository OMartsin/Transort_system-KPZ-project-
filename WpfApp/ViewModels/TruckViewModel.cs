using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using WpfApp.Models;

namespace WpfApp.ViewModels; 

public class TruckViewModel {
    public ObservableCollection<Truck>? Trucks { get; set; }
    public int SelectedTruckId { get; set; }
    public RelayCommand GetCommand { get; set; }

    public ICommand AddCommand { get; set; }
    public ICommand DeleteCommand { get; set; }
    public ICommand UpdateCommand { get; set; }
    private readonly HttpClient _httpClient;
    private const string BaseUrl = "https://localhost:7209/";
    
    public TruckViewModel() {
        _httpClient = new HttpClient();
        Trucks = new ObservableCollection<Truck>();
        GetCommand = new RelayCommand(GetTrucks);
        AddCommand = new RelayCommand(AddTruck);
        DeleteCommand = new RelayCommand(DeleteTruck);
        UpdateCommand = new RelayCommand(UpdateTruck);

    }
    public async void GetTrucks() {
        var response = await _httpClient.GetAsync(BaseUrl + "Truck");
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var trucks = JsonConvert.DeserializeObject<IEnumerable<Truck>>(content);
            Trucks.Clear();
            foreach (var truck in trucks)
            {
                Trucks.Add(truck);
            }
        }
    }
    
    private async void AddTruck()
    {
        var detailsWindow = new TruckDetailsWindow();
        if (detailsWindow.ShowDialog() == true)
        {
            var truck = detailsWindow.Truck;
            var json = JsonConvert.SerializeObject(truck);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(BaseUrl + "Truck", content);

            if (response.IsSuccessStatusCode)
            {
                var addedTruck = JsonConvert.DeserializeObject<Truck>(await response.Content.ReadAsStringAsync());
                Trucks.Add(addedTruck);
            }
        }
    }
    private async void DeleteTruck()
    {
        if (SelectedTruckId <= 0) return;

        var response = await _httpClient.DeleteAsync(BaseUrl + $"Truck?id={SelectedTruckId}");
        if (response.IsSuccessStatusCode)
        {
            var truckToDelete = Trucks.FirstOrDefault(t => t.TruckId == SelectedTruckId);
            if (truckToDelete != null)
            {
                Trucks.Remove(truckToDelete);
            }
        }
    }
    
    private async void UpdateTruck()
    {
        var selectedTruck = Trucks.FirstOrDefault(t => t.TruckId == SelectedTruckId);
        var detailsWindow = new TruckDetailsWindow(selectedTruck);
        if (detailsWindow.ShowDialog() == true)
        {
            var updatedTruck = detailsWindow.Truck;
            var json = JsonConvert.SerializeObject(updatedTruck);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(BaseUrl + $"Truck", content);

            if (response.IsSuccessStatusCode)
            {
                Trucks.Remove(selectedTruck);
                var truckFromResponse = JsonConvert.DeserializeObject<Truck>(await response.Content.ReadAsStringAsync());
                Trucks.Add(truckFromResponse);
            }
        }
    }
     
}