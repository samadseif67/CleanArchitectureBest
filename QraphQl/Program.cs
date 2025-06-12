using QraphQl_App.GQl;
using QraphQl_App.GQl.Mutations;
using QraphQl_App.GQl.Queries;

var builder = WebApplication.CreateBuilder(args);

//******************************************************************************


builder.Services.AddScoped<AppMutations>();
builder.Services.AddScoped<AppQueries>();
builder.Services.AddScoped<AppSchema>();


//*******************************************************************************


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//***************************************************************************

app.UseGraphQL<AppSchema>();
app.UseGraphQLGraphiQL("ui/graphql");

 

//************************************************************************
app.UseAuthorization();

app.MapControllers();

app.Run();
