using System.Text.Json;
var url = "https://jsonplaceholder.typicode.com/users";
HttpClient client = new HttpClient();
HttpResponseMessage respuesta = await client.GetAsync(url);
respuesta.EnsureSuccessStatusCode();
string respuestaTexto = await respuesta.Content.ReadAsStringAsync();
List<Usuario> usuarios = JsonSerializer.Deserialize<List<Usuario>>(respuestaTexto);

if(usuarios == null)
{
    System.Console.WriteLine("Fallo al obtener usuarios. ");
    return;
}

int contador = 0;

foreach(var usuario in usuarios)
{
    if(contador < 5)
    {
        System.Console.WriteLine("Nombre: " + usuario.name + " // " + " Email: " + usuario.email + " Domicilio: " + usuario.address.street + " " + usuario.address.suite + ", " + usuario.address.city + ", " + usuario.address.zipcode + ". \n");
    }
    else
    {
        break;
    }
contador++;
}

string jsonString = JsonSerializer.Serialize(usuarios);
File.WriteAllText("Usuarios.json", jsonString);
System.Console.WriteLine("Archivo Json creado exitosamente. ");

public class Usuario
{
    public int id {get; set;}
    public string name {get; set;}
    public string username {get; set;}
    public string email {get; set;}
    public Address address {get; set;} = new Address();
    public string phone {get; set;}
    public string website {get; set;}
    public Company company {get; set;} = new Company();
    
}

public class Address
{
    public string street {get; set;}
    public string suite {get; set;}
    public string city {get; set;}
    public string zipcode {get; set;}
    public Geo geo {get; set;} = new Geo();
}

public class Geo
{
    public string lat {get; set;}
    public string lng {get; set;}
}

public class Company
{
    public string name {get; set;}
    public string catchPhrase {get; set;}
    public string bs {get; set;}
}