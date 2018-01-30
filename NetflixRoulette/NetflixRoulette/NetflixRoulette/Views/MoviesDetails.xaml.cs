using NetflixRoulette.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NetflixRoulette.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MoviesDetails : ContentPage
	{
        private HttpClient _client = new HttpClient();
        string movieDetails;

        public MoviesDetails(Movie movie)
		{ 
            try
            {
                BindingContext = movie;

            }
            catch (InvalidCastException e)
            {
                DisplayAlert("binding", e.Message, "sdg", "sdg");
                throw e;
            }

            InitializeComponent();
		}

        /*protected override async void OnAppearing()
        {
            var content = await _client.GetStringAsync(movieDetails);

            var movie = JsonConvert.DeserializeObject<RootObject>(content);

            Movie movieDisplay = movie.Results[0];

            //details.BindingContext = movieDisplay;          

            base.OnAppearing();
        }*/
    }
}