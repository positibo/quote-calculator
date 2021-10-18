using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QuoteCalculator.Entities;
using QuoteCalculator.Source.Domain.BusinessRules;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace QuoteCalculator.Source.Domain.UseCases.GetAllProducts
{
    public class GetAllProductsQuery : IRequest<List<GetAllProductsResult>>
    {
        private class GetAllBookingsQueryHandler : IRequestHandler<GetAllProductsQuery, List<GetAllProductsResult>>
        {
            private DataContext context;
            private readonly IMapper mapper;

            public GetAllBookingsQueryHandler(DataContext context, IMapper mapper)
            {
                this.context = context;
                this.mapper = mapper;
            }

            public async Task<List<GetAllProductsResult>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
            {
                var products = await context.Products.ToListAsync();
                if (products == null)
                {
                    throw new NotFoundException();
                }

                return mapper.Map<List<GetAllProductsResult>>(products);
            }
        }
    }
}
