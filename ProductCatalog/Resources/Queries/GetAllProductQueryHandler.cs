using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Data;
using ProductCatalog.Model;

namespace ProductCatalog.Resources.Queries;

public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, IEnumerable<Product>>
{
    private readonly ProductDBContext _db;

    public GetAllProductQueryHandler(ProductDBContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Product>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        => await _db.Products.Where(p => p.Active).ToListAsync();
}