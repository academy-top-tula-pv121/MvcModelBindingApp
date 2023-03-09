using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MvcModelBindingApp.Models
{
    public record class Employe(
        string Name, int Age, Company Company);
    public record class Company(string Title);

    public class User
    {
        public int Id { get; set; }
        
        //[BindRequired]
        public string? Name { get; set; }
        public int Age { get; set; }
        
        //[BindNever]
        public bool IsAdmin { get; set; }
    }
}
