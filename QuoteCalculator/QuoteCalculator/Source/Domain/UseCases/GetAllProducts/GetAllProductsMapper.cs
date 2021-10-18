using AutoMapper;
using QuoteCalculator.Entities;

namespace QuoteCalculator.Source.Domain.UseCases.GetAllProducts
{
    public class GetAllProductsMapper : Profile
    {
        public GetAllProductsMapper()
        {
            CreateMap<Product, GetAllProductsResult>();
            CreateMap<GetAllProductsResult, Product>();
        }
    }
}
