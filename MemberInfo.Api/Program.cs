using Customer.Api;
using Customer.Application;
using Customer.Infrastructure;
var builder = WebApplication.CreateBuilder(args);

{



    builder.Services.AddPresentation();
    builder.Services.AddApplication()
                    .AddInfrastructure(builder.Configuration);

}

var app = builder.Build();

{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
   {
       c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
   });
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();

    app.Run();

}