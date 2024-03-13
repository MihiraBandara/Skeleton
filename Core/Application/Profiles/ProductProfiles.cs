using AutoMapper;
using Skeleton.Application.Dtos.Products;
using Skeleton.Application.Features.Products.Commands;
using Skeleton.Domain.Entities;
using Skeleton.Domain.ReadModels;
using Skeleton.Domain.ValueObjects;

namespace Skeleton.Application.Profiles
{
    public class ProductProfiles : Profile
    {
        public ProductProfiles()
        {
            CreateMap<ProductReadModel, GetProductDto>();
        }
    }
}
