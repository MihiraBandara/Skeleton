using AutoMapper;
using MediatR;
using Skeleton.Application.Abstractions.Messaging;
using Skeleton.Application.Abstractions.Persistance;
using Skeleton.Application.Features.Products.Commands;
using Skeleton.Application.Shared;
using Skeleton.Domain.Entities;
using Skeleton.Domain.ValueObjects;

namespace Skeleton.Application.Features.Products.Handlers
{
    public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand>
    {
        private readonly IGenericWriteRepository<Product> _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductCommandHandler(IGenericWriteRepository<Product> repository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var product = Product.Create(new ProductId(Guid.NewGuid()), command.Name, Price.Create(command.Price, command.Currency));
            var savedProduct = await _repository.Add(product);
            await _unitOfWork.SaveChangesAsync();

            if (savedProduct != null)
            {
                return Result.Success(savedProduct);
            }
            else
            {
                return Result.Failure(new Error("400","Product creation is failed"));
            }
        }
    }
}
