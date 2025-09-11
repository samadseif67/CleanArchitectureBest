using MinimalApi_App.Enities;
using MinimalApi_App.Repositorys;

var builder = WebApplication.CreateBuilder(args);

//*******************************************************************
builder.Services.AddSingleton<IStudentRepository, StudentRepository>();



//*********************************************************************

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


//*************************************************************************************
 
app.MapGet("api/students", async (IStudentRepository studentRepository) =>
{
    var getstudents = await studentRepository.GetStudents();
    return Results.Ok(getstudents);
});

app.MapGet("api/students/{id}", async (int id, IStudentRepository studentRepository) =>
{
    var getStudent = await studentRepository.GetStudentById(id);
    return Results.Ok(getStudent);
}).WithName("GetStudentById");//یک نام برای آن لحاظ میکنیم

app.MapPost("api/student", async (Student student, IStudentRepository studentRepository) =>
{
    var insertStudent = await studentRepository.AddStudent(student);
    return  Results.CreatedAtRoute("GetStudentById", new { insertStudent.id }, student);
});

app.MapPut("api/student", async (Student student, IStudentRepository studentRepository) =>
{
    var updateStudent = await studentRepository.EditStudent(student);
    return Results.CreatedAtRoute("GetStudentById", new { id = updateStudent.id }, student);
});





//**************************************************************************************


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
