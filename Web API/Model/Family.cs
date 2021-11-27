using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Model {
public class Family {
    
    [JsonPropertyName("Id")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    [MinLength(2)]
    [JsonPropertyName("StreetName")]
    public string StreetName { get; set; }
    [Required]
    [JsonPropertyName("HouseNumber")]
    public int HouseNumber{ get; set; }
    [JsonPropertyName("Adults")]
    public ICollection<Adult> Adults { get; set; }
    [JsonPropertyName("Children")]
    public ICollection<Child> Children{ get; set; }
    [JsonPropertyName("Pets")]
    public ICollection<Pet> Pets{ get; set; }

    public Family() {
        Adults = new List<Adult>(); 
        Children = new List<Child>();
        Pets = new List<Pet>();    
    }
}


}