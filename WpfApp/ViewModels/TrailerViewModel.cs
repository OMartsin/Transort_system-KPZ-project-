using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using WpfApp.Models;
using WpfApp.Views;

namespace WpfApp.ViewModels; 

    public class TrailerViewModel
    {
        public ObservableCollection<Trailer>? Trailers { get; set; }
        public int SelectedTrailerId { get; set; }
        public RelayCommand GetCommand { get; set; }

        public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://localhost:7209/Trailer";

        public TrailerViewModel()
        {
            _httpClient = new HttpClient();
            Trailers = new ObservableCollection<Trailer>();
            GetCommand = new RelayCommand(GetTrailers);
            AddCommand = new RelayCommand(AddTrailer);
            DeleteCommand = new RelayCommand(DeleteTrailer);
            UpdateCommand = new RelayCommand(UpdateTrailer);
        }

        public async void GetTrailers()
        {
            var response = await _httpClient.GetAsync(BaseUrl);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var trailers = JsonConvert.DeserializeObject<IEnumerable<Trailer>>(content);
                Trailers.Clear();
                foreach (var trailer in trailers)
                {
                    Trailers.Add(trailer);
                }
            }
        }

        private async void AddTrailer()
        {
            var detailsWindow = new TrailerDetailsWindow { Trailer = new Trailer() };
            if (detailsWindow.ShowDialog() == true)
            {
                var trailer = detailsWindow.Trailer;
                var json = JsonConvert.SerializeObject(trailer);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(BaseUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    var addedTrailer = JsonConvert.DeserializeObject<Trailer>(await response.Content.ReadAsStringAsync());
                    Trailers.Add(addedTrailer);
                }
            }
        }

        private async void DeleteTrailer()
        {
            if (SelectedTrailerId <= 0) return;

            var response = await _httpClient.DeleteAsync($"{BaseUrl}?id={SelectedTrailerId}");
            if (response.IsSuccessStatusCode)
            {
                var trailerToDelete = Trailers.FirstOrDefault(t => t.TrailerId == SelectedTrailerId);
                if (trailerToDelete != null)
                {
                    Trailers.Remove(trailerToDelete);
                }
            }
        }

        private async void UpdateTrailer() {
            var selectedTrailer = Trailers.FirstOrDefault(t => t.TrailerId == SelectedTrailerId);
            if (selectedTrailer != null) {
                var detailsWindow = new TrailerDetailsWindow { Trailer = selectedTrailer };
                if (detailsWindow.ShowDialog() == true) {
                    var updatedTrailer = detailsWindow.Trailer;
                    var json = JsonConvert.SerializeObject(updatedTrailer);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await _httpClient.PutAsync(BaseUrl, content);

                    if (response.IsSuccessStatusCode) {
                        Trailers.Remove(selectedTrailer);
                        var trailerFromResponse =
                            JsonConvert.DeserializeObject<Trailer>(await response.Content.ReadAsStringAsync());
                        Trailers.Add(trailerFromResponse);
                    }
                }
            }
        }
    }