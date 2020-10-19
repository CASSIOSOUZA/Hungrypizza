using System.Collections.Generic;

namespace HungryPizza.Compartilhado.Models
{
    public class AppSettings
    {
        public ConnectionStrings ConnectionStrings { get; set; }
        public Dictionary<string, string> Errors { get; set; }
    }
}