using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Model
{
    public class User
    {
        [Required]
        [MinLength(4)]
        [JsonPropertyName("Username")]
        public string Username { get; set; }
        [Required]
        [MinLength(4)]
        [JsonPropertyName("Password")]
        public string Password { get; set; }
        [Required]
        [MinLength(2)]
        [JsonPropertyName("FirstName")]
        public string FirstName { get; set; }
        [Required]
        [MinLength(2)]
        [JsonPropertyName("LastName")]
        public string LastName { get; set; }
        [JsonPropertyName("Role")]
        public string Role { get; set; }
    }
}