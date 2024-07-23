using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.ModelBuilder;
using ODataComplexType;
using ODataComplexType.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ODataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Database"));
});

var modelBuilder = new ODataConventionModelBuilder();

modelBuilder.ComplexType<Money>();

var transactionEntity = modelBuilder.EntitySet<Transaction>("Transactions").EntityType;
transactionEntity.HasKey(p => p.Id);
transactionEntity.ComplexProperty(p => p.Price);

builder.Services.AddControllers()
    .AddOData(
        options =>
        {
            options
                .Select()
                .Filter()
                .OrderBy()
                .Expand()
                .Count()
                .SetMaxTop(1000)
                .SkipToken()
                .AddRouteComponents("odata", modelBuilder.GetEdmModel());
        });

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
