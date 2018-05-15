using AsPromocoes.Domain.Entities;
using AsPromocoes.MVC.ViewModels;
using AutoMapper;

namespace AsPromocoes.MVC.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
            {
                x.CreateMap<ClienteViewModel, Cliente>();
                x.CreateMap<ProdutoViewModel, Produto>();

                //x.AddProfile<DomainToViewModelMappingProfile>();
                //x.AddProfile<ViewModelToDomainMappingProfile>();
            });
        }
    }
}