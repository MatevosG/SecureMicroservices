using IdentityModel.Client;
using Movies.Client.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Movies.Client.ApiServices
{
    public class MovieApiService : IMovieApiService
    {
        public async Task<IEnumerable<Movie>> GetMovies()
        {
            var applicationCredentials = new ClientCredentialsTokenRequest
            {
                Address = "https://localhost:6005/connect/token",
                ClientId = "movieClient",
                ClientSecret = "secret",
                Scope = "movieAPI"
            };

            var client = new HttpClient();

            var disco = await client.GetDiscoveryDocumentAsync("https://localhost:6005");
            if (disco.IsError)
            {
                return null;
            }

            var tokenResponse = await client.RequestClientCredentialsTokenAsync(applicationCredentials);
            if (tokenResponse.IsError)
            {
                return null;
            }

            var apiClient = new HttpClient();

            apiClient.SetBearerToken(tokenResponse.AccessToken);

            var response = await apiClient.GetAsync("https://localhost:6001/api/movies");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            var movieList = JsonConvert.DeserializeObject<List<Movie>>(content);

            return movieList;
            //var movieList = new List<Movie>();
            //movieList.Add(
            //    new Movie
            //    {
            //        Id = 1,
            //        Genre = "Comics",
            //        Title = "asd",
            //        Rating = "9.2",
            //        ImageUrl = "images/src",
            //        ReleaseData = System.DateTime.Now,
            //        Owner = "swn"
            //    }
            //    );
            //return await Task.FromResult(movieList);
        }
        public Task<Movie> CreateMovie(Movie movie)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteMovie(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Movie> GetMovie(string id)
        {
            throw new System.NotImplementedException();
        }

       

        public Task<Movie> UpdateMovie(Movie movie)
        {
            throw new System.NotImplementedException();
        }
    }
}
