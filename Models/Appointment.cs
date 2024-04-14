namespace VetClinicApp;

public class Appointment
{
    public DateTime DateOfVisit { get; }
    public Animal Animal { get; }
    public string Description { get; }
    public double Price { get; }

    public Appointment(DateTime dateOfVisit, Animal animal, string description, double price)
    {
        DateOfVisit = dateOfVisit;
        Animal = animal;
        Description = description;
        Price = price;
    }
}