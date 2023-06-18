using MediatR;
using ProductCatalog.Model;

namespace ProductCatalog.Resources.Commands.Delete;

public class DeleteProductCommand : IRequest<Product>
{
    public int Id { get; set; }
}