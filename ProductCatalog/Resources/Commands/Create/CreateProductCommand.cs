using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProductCatalog.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProductCatalog.Resources.Commands.Create;

public class CreateProductCommand : IRequest<Product>
{
    [StringLength(80), MinLength(4)]
    public string? Name { get; set; }
    [StringLength(80), MinLength(4)]
    public string? Description { get; set; }
    [StringLength(80), MinLength(4)]
    public string? Category { get; set; }
    public bool Active { get; set; } = true;
    [Column(TypeName = "decimal(10,2)")]
    public double Price { get; set; }
}