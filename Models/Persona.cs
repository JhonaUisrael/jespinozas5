using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jespinozaS5.Models
{
    [Table("Persona")]
    public class Persona
    {
        [AutoIncrement,PrimaryKey]
        public int Id { get; set; }

        [Required(ErrorMessage="El {0} es obligatorio"),System.ComponentModel.DataAnnotations.MaxLength(25)]

        public string Name { get; set; }

        public Persona(string name)
        {
            Name = name;
        }

    }
}
