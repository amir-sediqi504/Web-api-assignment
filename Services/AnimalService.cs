using Animals.Models;

namespace Animals.Services;

public static class AnimalService
{
    static List<Animal> Animals { get; }
    static int nextId = 3;
    static AnimalService()
    {
        Animals = new List<Animal>
        {
            new Animal { Id = 1, type = "räv", name = "Lukas" },
            new Animal { Id = 2, type = "Varulv", name = "David" }
        };
    }

    public static List<Animal> GetAll() => Animals;

    public static Animal? Get(int id) => Animals.FirstOrDefault(p => p.Id == id);

    public static void Add(Animal animal)
    {
        animal.Id = nextId++;
        Animals.Add(animal);
    }

    public static void Delete(int id)
    {
        var pizza = Get(id);
        if(pizza is null)
            return;

        Animals.Remove(pizza);
    }

    public static void Update(Animal animal)
    {
        var index = Animals.FindIndex(p => p.Id == animal.Id);
        if(index == -1)
            return;

        Animals[index] = animal;
    }
}