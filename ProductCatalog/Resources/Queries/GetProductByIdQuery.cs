using MediatR;
using ProductCatalog.Model;

namespace ProductCatalog.Resources.Queries;

public class GetProductByIdQuery : IRequest<Product>
{
    public int Id { get; set; }
}