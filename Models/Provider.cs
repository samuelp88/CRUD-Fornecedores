using CRUD_Fornecedores.Models.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD_Fornecedores.Models
{
    [Table("Fornecedor")]
    public class Provider
    {
        public Provider(){}
        public Provider(ProviderViewModel providerVM)
        {
            if(providerVM is null || providerVM.Name is null || providerVM.CNPJ is null || providerVM.Speciality is null) 
                throw new ArgumentNullException(nameof(providerVM));
            
            
            ID = providerVM.ID;
            Name = providerVM.Name;
            CNPJ = long.Parse(providerVM.CNPJ);
            Speciality = providerVM.Speciality;
        }

        [Key]
        public int ID { get; set; }

        [Column("Nome")]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        public long CNPJ { get; set; }

        [Column("Especialidade")]
        public string Speciality { get; set; } = string.Empty;
    }
}
