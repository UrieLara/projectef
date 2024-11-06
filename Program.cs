using System.IO.Compression;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projectef;
using projectef.Models;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<iTaskContext>(p => p.UseInMemoryDatabase("TasksDB"));
builder.Services.AddSqlServer<iTaskContext>(builder.Configuration.GetConnectionString("cnTasks"));
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconnection", async ([FromServices] iTaskContext dbContext) => 
{
    dbContext.Database.EnsureCreated();
    return Results.Ok($"Data base in memory: {dbContext.Database.IsInMemory()}");
});

app.MapGet("/api/tasks", async ([FromServices] iTaskContext dbContext) => {

return Results.Ok(dbContext.iTasks.Include(p => p.Category));
} );

//Para agregar datos se usa POST*/

app.MapPost("/api/tasks", async ([FromServices] iTaskContext dbContext, [FromBody] iTask task) => {

task.iTaskId = Guid.NewGuid();
task.CreationDate = DateTime.Now;
await dbContext.AddAsync(task);
//await dbContext.iTaks.AddAsync(task); <- Otra manera

await dbContext.SaveChangesAsync(); 

return Results.Ok();

} );


app.MapPut("/api/tasks/{id}", async ([FromServices] iTaskContext dbContext, [FromBody] iTask task, [FromRoute] Guid id) => {

var actualTask = dbContext.iTasks.Find(id);

if(actualTask!=null) {
    actualTask.CategoryId = task.CategoryId;
    actualTask.Title = task.Title;
    actualTask.iTaskPriority = task.iTaskPriority;
    actualTask.Description = task.Description;

    await dbContext.SaveChangesAsync(); 

    return Results.Ok();
}

return Results.NotFound();

} );


app.MapPut("/api/categories/{categoryId}", async ([FromServices] iTaskContext dbContext, [FromBody] Category category, [FromRoute] Guid categoryId) => {

var actualCategory = dbContext.Categories.Find(categoryId);

if(actualCategory!=null) {
    actualCategory.Name = category.Name;
    actualCategory.Description = category.Description;
    actualCategory.Weight = category.Weight;

    await dbContext.SaveChangesAsync(); 

    return Results.Ok();
}

return Results.NotFound();

} );


app.MapDelete("/api/tasks/{id}", async ([FromServices] iTaskContext dbContext, [FromRoute] Guid id) => {

var actualTask = dbContext.iTasks.Find(id);

if(actualTask!=null) {
    dbContext.Remove(actualTask);

    await dbContext.SaveChangesAsync();

    return Results.Ok();
}

return Results.NotFound();

} );

app.Run();
