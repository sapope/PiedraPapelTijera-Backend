using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Entities.DTO
{
    public class PlayersDTO
    {
        public PlayersDTO() {
            Name = string.Empty;
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(100, ErrorMessage = "La longitud del nombre no debe ser mayor a 100 caracteres")]
        [MinLength(3, ErrorMessage = "La longitud del nombre debe ser al menos 3 caracteres")]
        [RegularExpression("^[a-zA-Z0-9 ]+$", ErrorMessage = "El nombre solo debe contener letras, números o espacios entre las palabras")]
        public string Name { get; set; }
    }
}
