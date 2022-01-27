using KALA.Models;

namespace KALA.Services;

public static class ServiciosVarios
{
    static List<Materiales> Materiales { get; }
    static int nextId = 3;
    static ServiciosVarios()
    {
        Materiales = new List<Materiales>
        {
            new Materiales { Id = 1, Name = "Taladro", BasicMaterial = false },
            new Materiales { Id = 2, Name = "Martillo", BasicMaterial = true }
        };
    }

    public static List<Materiales> GetAll() => Materiales;

    public static Materiales? Get(int id) => Materiales.FirstOrDefault(p => p.Id == id);

    public static void Add(Materiales materiales)
    {
        materiales.Id = nextId++;
        Materiales.Add(materiales);
    }

    public static void Delete(int id)
    {
        var materiales = Get(id);
        if(materiales is null)
            return;

        Materiales.Remove(materiales);
    }

    public static void Update(Materiales materiales)
    {
        var index = Materiales.FindIndex(p => p.Id == materiales.Id);
        if(index == -1)
            return;

        Materiales[index] = materiales;
    }
}