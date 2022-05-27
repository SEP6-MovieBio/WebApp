using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MovieBioApp.Models.ClassesToReadJson
{
    public class Result
    {
        [JsonPropertyName("results")]
        public List<People> results { get; set; }
        
        public Result()
        {
            results = new List<People>();
        }
        
        
    }
}