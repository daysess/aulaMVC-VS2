using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BDProjeto.Dominio
{
    public class Usuario
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cargo { get; set; }

        [DisplayName("Data de cadastro")]
        [Required(ErrorMessage = "Preencha a data de cadastro")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        //[DataType(DataType.Date)]
        public DateTime Data { get; set; }

    }
}
