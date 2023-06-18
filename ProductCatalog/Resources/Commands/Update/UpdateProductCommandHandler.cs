using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Data;
using ProductCatalog.Model;

namespace ProductCatalog.Resources.Commands.Update;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Product>
{
    private readonly ProductDBContext _db;
    private readonly IMapper _mapper;

    public UpdateProductCommandHandler(ProductDBContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }
    public async Task<Product> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _db.Products.FirstOrDefaultAsync(p => p.Id == request.Id);

        if (product is null)
            return default;

        var updateProduct = _mapper.Map<Product>(product);
        await _db.SaveChangesAsync();

        return updateProduct;
    }
}