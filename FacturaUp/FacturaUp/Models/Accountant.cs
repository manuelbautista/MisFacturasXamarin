using System;
using System.Collections.Generic;
using System.Text;

namespace FacturaUp.Models
{
    public class Accountant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public IEnumerable<Accountant> GetAccountants(string emailLoggedUser)
        {
            var list = new List<Accountant>();
            Accountant accountant = new Accountant
            {
                Id = 4,
                Name = "Mary Gil",
                Email = "mary@gmail.com"
            };

            list.Add(accountant);

            return list;
        }
    }
}
