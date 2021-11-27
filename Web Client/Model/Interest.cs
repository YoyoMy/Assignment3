using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Model
{
    public class Interest
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("Type")]
        public string Type { get; set; }
        [JsonPropertyName("Description")]
        public string Description { get; set; }

        public int ChildId {get;set;}

    }
}