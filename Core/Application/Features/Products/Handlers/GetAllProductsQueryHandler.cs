using AutoMapper;
using Skeleton.Application.Abstractions.Messaging;
using Skeleton.Application.Abstractions.Persistance;
using Skeleton.Application.Dtos.Products;
using Skeleton.Application.Features.Products.Queries;
using Skeleton.Domain.ReadModels;

namespace Skeleton.Application.Features.Products.Handlers
{
    public class GetAllProductsQueryHandler : IQueryHandler<GetAllProductsQuery, List<GetProductDto>>
    {
        private readonly IGenericReadRepository<ProductReadModel> _repository;
        private readonly IMapper _mapper;

        public GetAllProductsQueryHandler(IGenericReadRepository<ProductReadModel> repository,
            IMapper mapper)
        {
             _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetProductDto>> Handle(GetAllProductsQuery query, CancellationToken cancellationToken)
        {
            var products = await _repository.GetAllAsync("Products", "Skeleton");
            return _mapper.Map<List<GetProductDto>>(products);
        }
    }
}
