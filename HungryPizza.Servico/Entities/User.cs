using System.ComponentModel.DataAnnotations.Schema;

namespace HungryPizza.Servico.Entities
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        public string Email { get; private set; }
        public string Password { get; private set; }
        public bool Active { get; private set; }

        public User()
        {
        }

        public User(int id, string email, string password, bool active)
        {
            Id = id;
            Email = email;
            Password = password;
            Active = active;
        }

        public void SetId(int id)
        {
            Id = id;
        }
    }
}