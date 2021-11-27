using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace Model {
public class Person {

    [JsonPropertyName("Id")] 
    [Key]   
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [JsonIgnore]
    public int FamilyId {get;set;}
    [Required]
    [MinLength(2)]
    [JsonPropertyName("FirstName")]   
    public string FirstName { get; set; }
    [Required]
    [MinLength(2)]
    [JsonPropertyName("LastName")] 
    public string LastName { get; set; }
    [Required]
    [MinLength(4)]
    [JsonPropertyName("HairColor")] 
    public string HairColor { get; set; }
    [Required]
    [MinLength(4)]
    [JsonPropertyName("EyeColor")] 
    public string EyeColor { get; set; }
    [Required]
    [Range(0,200)]
    [JsonPropertyName("Age")] 
    public int Age { get; set; }
    [Range(0,900)]
    [JsonPropertyName("Weight")] 
    public float Weight { get; set; }
    [Range(30,300)]
    [JsonPropertyName("Height")] 
    public int Height { get; set; }
    [RegularExpression("F|M|O", ErrorMessage = "Gender must be either 'M', 'F' or 'O'.")]
    [JsonPropertyName("Sex")] 
    public string Sex { get; set; }
}


}