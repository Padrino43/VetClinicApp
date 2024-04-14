namespace VetClinicApp;

public interface IMockDb
{
    public ICollection<Animal> GetAllAnimals();
    public Animal? GetAnimalDetails(int id);
    public bool AddAnimal(Animal animal);
    public List<Appointment>? GetAnimalAppointments(int id);
    public bool AddAnimalAppointment(Appointment appointment);
    public Animal? EditAnimal(int id, Animal animal);
    public Animal? RemoveAnimal(int id);
}

public class MockDb : IMockDb
{
    private static List<Animal> _animals = new List<Animal>()
    {
        new (0, "Madża", "Pig", 120000.2, "White"),
        new (1, "Franek", "Whale", 200000000.2, "None")
    };
    private static List<Appointment> _appointments = new List<Appointment>()
    {
        new (DateTime.Now, _animals[0], "Medicover", 120000.2),
        new (DateTime.MaxValue, _animals[1], "NFZ", 200000000.2)
    };
    

    public ICollection<Animal> GetAllAnimals()
    {
        return _animals;
    }

    public Animal? GetAnimalDetails(int id)
    {
        return _animals.FirstOrDefault(animal => animal.Id == id);
    }

    public bool AddAnimal(Animal animal)
    {
        _animals.Add(animal);
        return true;
    }

    public List<Appointment>? GetAnimalAppointments(int id)
    {
        var animal = _animals.FirstOrDefault(animal => animal.Id == id);
        return animal is null ? null : _appointments.FindAll(e=> e.Animal == animal);
    }

    public bool AddAnimalAppointment(Appointment appointment)
    {
        _appointments.Add(appointment);
        return true;
    }

    public Animal? EditAnimal(int id, Animal edited)
    {
        var animalToEdit = _animals.FirstOrDefault(animal => animal.Id == id);
        if (animalToEdit is null) 
            return null;

        animalToEdit.Name = edited.Name;
        animalToEdit.Category = edited.Category;
        animalToEdit.Weight = edited.Weight;
        animalToEdit.HairColor = edited.HairColor;

        return edited;
    }

    public Animal? RemoveAnimal(int id)
    {
        var animalToDelete = _animals.FirstOrDefault(animal => animal.Id == id);
        if (animalToDelete is null) return null;
        
        _animals.Remove(animalToDelete);
        return animalToDelete;
    }
}