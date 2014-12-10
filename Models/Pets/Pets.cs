using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace G2_PetProtect.Models.Pets
{
    public class Pets
    {
        public int idPet { get; set; }

        [Required(ErrorMessage = "O nome do contato deve ser informado.!")]
        [StringLength(50)]
        public string nomeDono { get; set; }
       
        [Required(ErrorMessage = "O telefone deve ser informado.!")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Forneça o número do telefone no formato (000) 000-0000")]
        [DisplayName("Número do Telefone")]
        public string telefoneDono { get; set; }

        [Required(ErrorMessage = "O nome do Pet deve ser informado.!")]
        [StringLength(50)]
        public string nomePet { get; set; }
    }
}