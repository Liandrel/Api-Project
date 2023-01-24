using ApiProject.StartupServices;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthorization(opts => AuthServices.AddAuthorizationOptions(opts));
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(opts => AuthServices.AddJwtBearerOptions(builder, opts));

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
