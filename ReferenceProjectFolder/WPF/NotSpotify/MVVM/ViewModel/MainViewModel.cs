using Newtonsoft.Json;
using NotSpotify.MVVM.Model;
using RestSharp;
using System.Collections.ObjectModel;

#pragma warning disable S1133

namespace NotSpotify.MVVM.ViewModel
{
    internal class MainViewModel
    {
        public ObservableCollection<Item> Songs { get; set; }

        [System.Obsolete]
        public MainViewModel()
        {
            Songs = new ObservableCollection<Item>();
            PopulateCollection();
        }

        //[Obsolete]
        // ReSharper disable once UnusedMember.Local
        [System.Obsolete]
        private void PopulateCollection()
        {
            RestClient client = new()
            {
                //Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator("BQA1ZTB7VWvIbjv6IIyIrm7nEQoZjo4gH17RGi04y6d8FN7w4hutNYS6XxNlLfvloBdsYcr8aNHUtH0BBUc", "Bearer")
            };

            RestRequest request = new("https://api.spotify.com/v1/browse/new-releases", Method.Get);
            _ = request.AddHeader("Accept", "application/json");
            _ = request.AddHeader("Content-Type", "application/json");

            RestResponse response = client.GetAsync(request).GetAwaiter().GetResult();
            if (response.Content != null)
            {
                TrackModel? data = JsonConvert.DeserializeObject<TrackModel>(response.Content);

                for (int i = 0; i < data.Albums.Limit; i++)
                {
                    Item track = data.Albums.Items[i];
                    track.Duration = "2:32";
                    Songs.Add(track);
                }
            }

            /// <summary>
            /// curl command - k
            /// </summary>
            //curl - X "GET"  "https://api.spotify.com/v1/browse/new-releases?country=SE&limit=10&offset=5" - H "Accept: application/json" - H "Content-Type: application/json" - H "Authorization: Bearer BQA1ZTB7VWvIbjv6IIyIrm7nEQoZjo4gH17RGi04y6d8FN7w4hutNYS6XxNlLfvloBdsYcr8aNHUtH0BBUc-h_ZN8K0A6wI8Fh63vXpk2sUs2jEnoBmdv_jNHm0McVtmQ-7s8DoUxJCVkX6-yKCpMUhxy6szrRp0LFr4_NekVMyBJ0Ii0Y7c9vTOy_A2hDHASe8_"
        }
    }
}