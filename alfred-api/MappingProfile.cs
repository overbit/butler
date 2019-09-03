using System.Linq;
using alfred_api.Model.Contracts.Search.Request;
using alfred_api.Model.Contracts.Search.Response;
using alfred_api.Model.Dtos.Search.Request;
using alfred_api.Model.Dtos.Search.Response;
using AutoMapper;

namespace alfred_api
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SearchQueryDto, SearchQuery>()
                .ForMember(dto => dto.TargetName, opt => opt.MapFrom(model => model.Facets.TargetName))
                .ForMember(dto => dto.Application, opt => opt.MapFrom(model => model.Facets.Application))
                .ForMember(dto => dto.Reactivity, opt => opt.MapFrom(model => model.Facets.Reactivity))
                .ForMember(dto => dto.HostSpecies, opt => opt.MapFrom(model => model.Facets.HostSpecies));

            CreateMap<SearchResultPocModel, ProductsDto>()
                .ForMember(dto => dto.Products, opt => opt.MapFrom(model => model.Products))
                .ForMember(dto => dto.TotalItems, opt => opt.MapFrom(model => model.TotalItems));

            CreateMap<Product, ProductsDto.ProductDto>();
            CreateMap<FacetCategory, FacetCategoryDto>()
                .ForMember(dto => dto.Name, opt => opt.MapFrom(category => category.Facet.Name))
                .ForMember(dto => dto.Facets,
                    opt => opt.MapFrom(category => category.FacetInfos.Select(info => new FacetInfoDto
                        {Name = info.Name, Count = info.Count, Position = info.Position})))
                ;
            CreateMap<FacetInfo, FacetInfoDto>();
            CreateMap<Product.Productindexmodel, ProductsDto.ProductDto.Productindexmodel>();
            CreateMap<Product.Linksviewmodel, ProductsDto.ProductDto.Linksviewmodel>();
            CreateMap<Product.Visibleproperty, ProductsDto.ProductDto.Visibleproperty>();
        }
    }
}