using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Model {
public class Child : Person {
    
    [JsonPropertyName("Interests")]
    public List<Interest> Interests { get; set; }
    [JsonPropertyName("Pets")]
    public List<Pet> Pets { get; set; }

    public Child()
    {
        Interests = new List<Interest>();
        Pets = new List<Pet>();
    }
}
}