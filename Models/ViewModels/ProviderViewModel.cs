using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD_Fornecedores.Models.ViewModels
{
    public enum Specialties
    {
        Comércio,
        Serviço,
        Indústria
    }

    public class ProviderViewModel
    {
        public ProviderViewModel()
        {
            this.Specialties = new SelectList(Enum.GetNames<Specialties>());
        }

        public int ID { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(100, ErrorMessage = "Máximo de 100 caracteres")]
        [Display(Name = "Nome do fornecedor")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(14, ErrorMessage = "Máximo de 14 dígitos")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "O campo CNPJ aceita somente números.")]
        public string? CNPJ { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Especialidade")]
        public string? Speciality { get; set; }

        [NotMapped]
        public SelectList Specialties { get; set; }
    }
}
