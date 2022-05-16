using CRUD_Fornecedores.Data.DataParser.Abstract;
using CRUD_Fornecedores.Models;
using CRUD_Fornecedores.Models.ViewModels;

namespace CRUD_Fornecedores.Data.DataParser
{
    public class ProviderParser : IProviderParser
    {
        public Provider Parse(ProviderViewModel input)
        {
            return new Provider(input);
        }

        public List<Provider> Parse(List<ProviderViewModel> input)
        {
            var providers = new List<Provider>();
            input.ForEach(provider => providers.Add(Parse(provider)));
            return providers;
        }

        public ProviderViewModel Parse(Provider input)
        {
            return new ProviderViewModel()
            {
                ID = input.ID,
                Name = input.Name,
                CNPJ = $"{input.CNPJ}",
                Speciality = input.Speciality
            };
        }

        public List<ProviderViewModel> Parse(List<Provider> input)
        {
            var providers = new List<ProviderViewModel>();
            input.ForEach(provider => providers.Add(Parse(provider)));
            return providers;
        }
    }
}
