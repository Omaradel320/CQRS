using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Data;
using ProductCatalog.Model;

namespace ProductCatalog.Resources.Queries;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery,Product> 
{
    private readonly ProductDBContext _db;
    public GetProductByIdQueryHandler(ProductDBContext db)
    {
        _db = db;
    }

    public async Task<Product> Handle(GetProductByIdQuery Request, CancellationToken cancellationToken)
        => await _db.Products.FirstOrDefaultAsync(x => x.Id == Request.Id, cancellationToken);
}