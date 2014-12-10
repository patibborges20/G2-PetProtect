using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace G2_PetProtect.Models.Funcionarios
{
    public class Funcionarios
    {
        public int idFuncionario { get; set; }

        [Required(ErrorMessage = "O nome do Funcionario deve ser informado.!")]
        [StringLength(50)]
        public string nomeFuncionario { get; set; }
    }
}