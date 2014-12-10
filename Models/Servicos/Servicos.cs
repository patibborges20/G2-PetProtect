using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace G2_PetProtect.Models.Servicos
{
    public class Servicos
    {
        public int idServico { get; set; }
        [Required(ErrorMessage = "O nome do serviço deve ser informado.!")]
        [StringLength(50)]
        public string nomeServico { get; set; }
        public string precoP { get; set; }
        public string precoM { get; set; }
        public string precoG { get; set; }
    }
}