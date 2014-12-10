using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using G2_PetProtect.Models.Servicos;
using G2_PetProtect.Models;
using System.ComponentModel.DataAnnotations;


namespace G2_PetProtect.Models.Agenda
{
    public class Agenda
    {
        public int idAgenda { get; set; }

        [Required(ErrorMessage = "Campo data obrigatorio.")]
        [DataType(DataType.Date)]
        public DateTime data { get; set; }
        public Servicos.Servicos servico { get; set; }
        public Funcionarios.Funcionarios funcionario { get; set; }
        public Horarios.Horarios horario { get; set; }
        public Pets.Pets pets { get; set; }
    }
}