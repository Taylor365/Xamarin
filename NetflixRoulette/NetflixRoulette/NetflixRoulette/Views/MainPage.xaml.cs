using NetflixRoulette.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NetflixRoulette.Views
{
    public class RootObject
    {
        [JsonProperty("results")]
        public List<Movie> Results { get; set; }
    }

    public partial class MainPage : ContentPage
	{
        private const string Url = "https://api.themoviedb.org/3/search/movie?query=";
        private string apiKey = "&api_key=3990f9970c66e2dfcc045102f39cfdc8";
        private string title;
        private HttpClient _client = new HttpClient();
        private ObservableCollection<Movie> _movies;

        public MainPage()
		{
			InitializeComponent();
		}

        async void Handle_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue.Length >= 4)
            {
                title = e.NewTextValue;

                var content = await _client.GetStringAsync(Url + title + apiKey);

                var movies = JsonConvert.DeserializeObject<RootObject>(content);

                _movies = new ObservableCollection<Movie>(movies.Results);

                if (movies.Results.Count < 1)
                {
                    postsListView.ItemsSource = "No Movies Found";
                }
                else
                    postsListView.ItemsSource = _movies;
            }
        }

        async void Handle_Selection(object sender, SelectedItemChangedEventArgs e)
        {
            Movie movie = e.SelectedItem as Movie;

            await Navigation.PushAsync(new MoviesDetails(movie));                
        }
    }
}
