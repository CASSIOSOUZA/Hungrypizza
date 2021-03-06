﻿using System.ComponentModel.DataAnnotations.Schema;

namespace HungryPizza.Servico.Entities
{
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        public int IdUser { get; private set; }
        public string Name { get; private set; }
        public string Address { get; private set; }

        public Customer()
        {
        }

        public Customer(int id, int idUser, string name, string address)
        {
            Id = id;
            IdUser = idUser;
            Name = name;
            Address = address;
        }

        public void SetIdUser(int idUser)
        {
            IdUser = idUser;
        }
    }
}