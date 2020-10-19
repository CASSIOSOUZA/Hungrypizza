using System.ComponentModel.DataAnnotations.Schema;

namespace HungryPizza.Servico.Entities
{
    public class Pizza
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public bool Active { get; private set; }

        public Pizza(int id, string name, decimal price, bool active)
        {
            Id = id;
            Name = name;
            Price = price;
            Active = active;
        }
    }
}