using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Net.Http.Json;

public class Animal
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Raza { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public bool Sexo { get; set; }
    public int Dueño { get; set; }
}
public class Dueño
{
    public string Dni { get; set; }
    public string Nombre { get; set; }
}
public class Atencion
{
    public int Id { get; set; }
    public string MotivoConsulta { get; set; }
    public int IdTratamiento { get; set; }
    public int IdMedicamento { get; set; }
    public DateTime FechaAtencion { get; set; }
}
public class Medicamento
{
    public int Id { get; set; }
    public string Nombre { get; set; }
}



class Program
{
    static HttpClient client = new HttpClient();

    public async Task RegistrarAnimal(Animal animalNuevo)
    {
        try
        {
            HttpResponseMessage response1 = await client.PostAsJsonAsync("api/animales", animalNuevo);
            response1.EnsureSuccessStatusCode();
        }
        catch (Exception)
        {
            throw;
        }

    }

    public async Task<string> ReturnAnimal(int idAnimalConsultar)
    {
        try
        {
            string DatosAnimal = null;
            HttpResponseMessage response2 = await client.GetAsync($"api/animales/idAnimal?idAnimal={idAnimalConsultar}");
            if (response2.IsSuccessStatusCode)
            {
                DatosAnimal = await response2.Content.ReadAsStringAsync();
            }
            return DatosAnimal;
        }
        catch (Exception)
        {
            throw;
        }

    }

    public async Task BorrarAnimal(int idAnimalEliminar)
    {
        try
        {
            HttpResponseMessage response3 = await client.DeleteAsync($"api/animales/id?idAnimal={idAnimalEliminar}");
            response3.EnsureSuccessStatusCode();
        }
        catch (Exception)
        {
            throw;
        }

    }

    public async Task RegistrarDueño(Dueño dueñoNuevo)
    {
        try
        {
            HttpResponseMessage response4 = await client.PostAsJsonAsync("api/duenos", dueñoNuevo);
            response4.EnsureSuccessStatusCode();
        }
        catch (Exception)
        {
            throw;
        }

    }

    public async Task CrearAtencion(Atencion atencionNueva)
    {
        try
        {
            HttpResponseMessage response5 = await client.PostAsJsonAsync("api/atenciones", atencionNueva);
            response5.EnsureSuccessStatusCode();
        }
        catch (Exception)
        {
            throw;
        }

    }

    public async Task<string> ReturnMedicamente(int idMedicamentoConsultar)
    {
        try
        {
            string DatosMedicamento = null;
            HttpResponseMessage response7 = await client.GetAsync($"api/medicamentos/idMedicamento?idMedicamento={idMedicamentoConsultar}");
            if (response7.IsSuccessStatusCode)
            {
                DatosMedicamento = await response7.Content.ReadAsStringAsync();
            }
            return DatosMedicamento;
        }
        catch (Exception)
        {
            throw;
        }

    }

}