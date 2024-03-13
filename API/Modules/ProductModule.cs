using MediatR;
using Microsoft.AspNetCore.Mvc;
using Skeleton.Api.Interfaces;
using Skeleton.Application.Features.Products.Commands;
using Skeleton.Application.Features.Products.Queries;

namespace Skeleton.Api.Modules
{
    public class ProductModule : IApiModule
    {
        void IApiModule.MapEndpoint(WebApplication app)
        {
            app.MapGet("/products", async ([FromServices] IMediator _mediator) =>
            {
                return Results.Ok(await _mediator.Send(new GetAllProductsQuery()));
            });

            app.MapPost("/products", async (CreateProductCommand command, [FromServices] IMediator _mediator) =>
            {
                return Results.Ok(await _mediator.Send(command));
            });
        }
    }
}
