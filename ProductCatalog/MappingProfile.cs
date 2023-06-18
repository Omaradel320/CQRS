using AutoMapper;
using ProductCatalog.Model;
using ProductCatalog.Resources.Commands.Create;
using ProductCatalog.Resources.Commands.Update;

namespace ProductCatalog;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateProductCommand,Product>().ReverseMap();
        CreateMap<UpdateProductCommand,Product>().ReverseMap();
    }
}