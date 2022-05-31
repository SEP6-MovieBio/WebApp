﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MovieBioApp.Data.OMDbAPI;
using MovieBioApp.Models;

namespace MovieBioApp.Data.MovieService
{
    public class MovieService : IMovieService
    {
        private string uri = "https://moviebiodb.azurewebsites.net/MovieInfo/";
        //private string uri = "https://localhost:5003/MovieInfo/";

        private HttpClient client;
        //private OMDbAPIService _omDbApiObj;


        public MovieService()
        {
            client = new HttpClient();
        }
        
        //GET Movie by random character
        public async Task<Movie> GetMovieByRandChar(char randChar)
        {
            Task<string> info = client.GetStringAsync(uri + $"RandomChar?randChar={randChar}");
            string message = await info;
            Movie result = JsonSerializer.Deserialize<Movie>(message);

            return result;
        }

        //GET Movie by ID
        public async Task<Movie> GetMovieById(int id)
        {
            Task<string> info = client.GetStringAsync(uri + $"MovieID?id={id}");
            string message = await info;
            Movie result = JsonSerializer.Deserialize<Movie>(message);

            return result;        
        }
        
        //Get top200 movies
        public async Task<List<Movie>> GetTop200Movies()
        {
            Task<string> info = client.GetStringAsync(uri + "top200Movies");
            string message = await info;
            List<Movie> result = JsonSerializer.Deserialize<List<Movie>>(message);
            
            return result;  
        }

        public async Task PostMovieReview(MovieReview review)
        {

            string path = $"{uri}MovieReview";
            
            string reviewJson = JsonSerializer.Serialize(review);
            HttpContent content = new StringContent(reviewJson, Encoding.UTF8, "application/json");
            
            HttpResponseMessage responseMessage = await client.PostAsync(path, content);
            if (responseMessage.StatusCode == HttpStatusCode.Created)
            {
                Console.WriteLine("PostMovieReview succesful");
            }
            else
            {
                Console.WriteLine("PostMovieReview Not succesful");
            }
        }

        public async Task PatchMovieReview(string username, string reviewTextfield, float reviewRating, int movieID)
        {
            string path = $"{uri}UpdateMovieReview";
            MovieReview updatedInfo = new MovieReview();
            updatedInfo.ReviewUsername = username;
            updatedInfo.ReviewDescription = reviewTextfield;
            updatedInfo.ReviewRating = reviewRating;
            updatedInfo.MovieID = movieID;

            string reviewJson = JsonSerializer.Serialize(updatedInfo);
            HttpContent content = new StringContent(reviewJson, Encoding.UTF8, "application/json");
            
            HttpResponseMessage responseMessage = await client.PatchAsync(path, content);
            if (responseMessage.StatusCode == HttpStatusCode.Created)
            {
                Console.WriteLine("PatchMovieReview succesful");
            }
            else
            {
                Console.WriteLine("PatchMovieReview Not succesful");
            }        
        }
    }
}