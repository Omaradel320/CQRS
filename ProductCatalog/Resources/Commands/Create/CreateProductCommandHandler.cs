using AutoMapper;
using MediatR;
using ProductCatalog.Data;
using ProductCatalog.Model;

namespace ProductCatalog.Resources.Commands.Create;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand,Product>
{
    private readonly ProductDBContext _db;
    private readonly IMapper _mapper;

    public CreateProductCommandHandler(ProductDBContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }
    public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var newProduct = _mapper.Map<Product>(request);

        _db.Products.Add(newProduct);
        await _db.SaveChangesAsync();

        return newProduct;
    }
}