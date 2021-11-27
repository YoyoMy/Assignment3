using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Model
{
    public class Job
    {
        [JsonPropertyName("JobTitle")]
        public string JobTitle { get; set; }
        [Range(0, int.MaxValue)]
        [JsonPropertyName("Salary")]
        public int Salary { get; set; }
    }
}