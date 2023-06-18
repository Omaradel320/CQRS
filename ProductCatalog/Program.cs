    using AutoMapper;
    using MediatR;
    using ProductCatalog;
    using ProductCatalog.Data;
    using ProductCatalog.Model;
    using ProductCatalog.Resources.Commands.Create;
    using ProductCatalog.Resources.Commands.Delete;
    using ProductCatalog.Resources.Commands.Update;
    using ProductCatalog.Resources.Queries;
    using System.Reflection;

    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddDbContext<ProductDBContext>();
    builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
    builder.Services.AddAutoMapper(typeof(MappingProfile));

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    //Calling EndPoints
    app.MapGet("Product/get-all", async (IMediator _mediator) =>
    {
        try
        {
            var response = await _mediator.Send(new GetAllProductQuery());

            return response is not null ? Results.Ok(response) : Results.Ok("No Products Found");
        }
        catch (Exception ex)
        {
            return Results.BadRequest(ex.Message);
        }
    });

    app.MapGet("Product/get-by-id", async (IMediator _mediator, int Id) =>
    {
        try
        {
            var response = await _mediator.Send(new GetProductByIdQuery { Id = Id });

            return response is not null ? Results.Ok(response) : Results.Ok("This product is not found");
        }
        catch (Exception ex)
        {
            return Results.BadRequest(ex.Message);
        }
    });

    app.MapPost("Product/Create", async (IMediator _mediator, CreateProductCommand product) =>
    {
        try
        {
            var response = _mediator.Send(product);

            return response is not null ? Results.Ok(response) : Results.NotFound();

        }
        catch (Exception ex)
        {

            return Results.BadRequest(ex.Message);
        }
    });

    app.MapPost("Product/Update", async (IMediator _mediator, Product product) =>
    {
        try
        {
            var request = new UpdateProductCommand()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Category = product.Category,
                Active = product.Active,
                Price = product.Price
            };

            var response = _mediator.Send(request);

            return response.Result is not null ? Results.Ok(response) : Results.NotFound("Product Not Found");
        }
        catch (Exception ex)
        {
            return Results.BadRequest(ex.Message);
        }
    });

    app.MapPost("Product/Delete", async (IMediator _mediator, int Id) =>
    {
        try
        {
            var response = _mediator.Send(new DeleteProductCommand { Id = Id });

            return response.Result is not null ? Results.Ok(response) : Results.NotFound("Product Not Found");
        }
        catch (Exception ex)
        {
            return Results.BadRequest(ex.Message);
        }
    });

    app.UseHttpsRedirection();
    app.Run();