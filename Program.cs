using Microsoft.AspNetCore.Mvc;
using VetClinicApp;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IMockDb, MockDb>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/api/animals", (IMockDb mockDb) => mockDb.GetAllAnimals());

app.MapGet("/api/animals/{id:int}", (IMockDb mockDb, [FromRoute] int id) =>
{
    var animal = mockDb.GetAnimalDetails(id);
    return animal is null ? Results.NotFound() : Results.Ok(animal);
});

app.MapPost("/api/animals", (IMockDb mockDb, [FromBody] Animal animal) =>
{
    mockDb.AddAnimal(animal);
    return Results.Created("", animal);
});

app.MapGet("/api/appointments", (IMockDb mockDb, [FromQuery] int animalId) =>
{
    var animalAppointments = mockDb.GetAnimalAppointments(animalId);
    return animalAppointments is null ? Results.NotFound() : Results.Ok(animalAppointments);
});

app.MapPost("/api/appointments", (IMockDb mockDb, [FromBody] Appointment appointment) =>
{
    mockDb.AddAnimalAppointment(appointment);
    return Results.Created("", appointment);
});

app.MapPut("/api/animals/{id:int}", (IMockDb mockDb, [FromRoute] int id,  [FromBody] Animal animal) =>
{
    var animalToEdit = mockDb.EditAnimal(id, animal);
    
    return animalToEdit is null ? Results.NotFound() : Results.Ok(animalToEdit);
});

app.MapDelete("/api/animals/{id:int}", (IMockDb mockDb, [FromRoute] int id) =>
{
    var animal = mockDb.RemoveAnimal(id);
    
    return animal is null? Results.Conflict() : Results.NoContent();
});

app.Run();
