using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Data;
using ProductCatalog.Model;

namespace ProductCatalog.Resources.Commands.Delete;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Product>
{
    private readonly ProductDBContext _db;

    public DeleteProductCommandHandler(ProductDBContext db)
    {
        _db = db;
    }

    public async Task<Product> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _db.Products.FirstOrDefaultAsync(p => p.Id == request.Id);

        if (product is null)
            return null;

        product.Active = !product.Active;

        await _db.SaveChangesAsync();

        return product;
    }
}
