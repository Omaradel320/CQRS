using MediatR;
using ProductCatalog.Model;

namespace ProductCatalog.Resources.Queries;

public class GetAllProductQuery : IRequest<IEnumerable<Product>>
{
}
