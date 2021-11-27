using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Model
{
    public class Job
    {
        [Key]
        [JsonPropertyName("Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public int Id {get;set;}
        [JsonPropertyName("JobTitle")]
        public string JobTitle { get; set; }
        [Range(0, int.MaxValue)]
        [JsonPropertyName("Salary")]
        public int Salary { get; set; }
    }
}