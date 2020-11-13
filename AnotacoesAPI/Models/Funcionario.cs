using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AnotacoesAPI.Models
{
    public class Funcionario
    {
        public Guid Id { get; set; }
        
        [Required]
        public string Nome { get; set; }

        [Required]
        public string Cidade { get; set; }

        [Required]
        public string Estado { get; set; }

        [Required]
        public string Departamento { get; set; }

        [Required]
        public double Salario { get; set; }

        [Required]
        public string Sexo { get; set; }
    }
}
