using System.Text.Json;

HttpClient Cliente = new HttpClient();
string url = "https://jsonplaceholder.typicode.com/todos/";

HttpResponseMessage respuesta = await Cliente.GetAsync(url);
respuesta.EnsureSuccessStatusCode();

string Json = await respuesta.Content.ReadAsStringAsync();

List<Tarea> listTarea = JsonSerializer.Deserialize<List<Tarea>>(Json);

foreach (var tarea in listTarea){
    Console.WriteLine("UserID: " + tarea.userId + " ID: " + tarea.id + " Titulo: " + tarea.title + " Completado: " + tarea.completed);
}

Console.WriteLine("/// Tareas Completadas ///");

foreach(var tareaComp in listTarea)
{
    if(tareaComp.completed == true)
    {
        {
            Console.WriteLine("UserID: " + tareaComp.userId + " ID: " + tareaComp.id + " Titulo: " + tareaComp.title + " Completado: " + tareaComp.completed);
        }
    }
}

System.Console.WriteLine("/// Tareas Pendientes ///");

foreach(var tareaPend in listTarea)
{
    if(tareaPend.completed == false)
    {
        {
            Console.WriteLine("UserID: " + tareaPend.userId + " ID: " + tareaPend.id + " Titulo: " + tareaPend.title + " Completado: " + tareaPend.completed);
        }
    }
}

string jsonString = JsonSerializer.Serialize(listTarea);
File.WriteAllText("tareas.json", jsonString);
System.Console.WriteLine("Archivo Json creado exitosamente.");



public class Tarea
{
    public int userId { get; set; }
    public int id { get; set; }
    public string title { get; set; }
    public bool completed { get; set; }

}