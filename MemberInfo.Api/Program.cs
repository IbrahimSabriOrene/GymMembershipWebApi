using MemberInfo.Api;
using MemberInfo.Application;
using MemberInfo.Infrastructure;
var builder = WebApplication.CreateBuilder(args);

{



builder.Services.AddPresentation();
builder.Services.AddApplication()
                .AddInfrastructure(builder.Configuration);

}

var app = builder.Build();

{

app.UseExceptionHandler("/error");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();

}