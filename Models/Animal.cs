using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VetClinicApp;

public class Animal
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public double Weight { get; set; }
    public string HairColor { get; set; }

    public Animal(int id, string name, string category, double weight, string hairColor)
    {
        Id = id;
        Name = name;
        Category = category;
        Weight = weight;
        HairColor = hairColor;
    }
}
