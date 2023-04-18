using Microsoft.EntityFrameworkCore;
using ApiWithEntityFramework.Data;
using ApiWithEntityFramework.Models;
namespace ApiWithEntityFramework.Controllers;

public static class StudentEndpoints
{
    public static void MapStudentModelEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/StudentModel", async (ApplicationDbContext db) =>
        {
            return await db.StudentDetails.ToListAsync();
        })
        .WithName("GetAllStudentModels")
        .Produces<List<StudentModel>>(StatusCodes.Status200OK);

        routes.MapGet("/api/StudentModel/{id}", async (int StudentId, ApplicationDbContext db) =>
        {
            return await db.StudentDetails.FindAsync(StudentId)
                is StudentModel model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithName("GetStudentModelById")
        .Produces<StudentModel>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        routes.MapPut("/api/StudentModel/{id}", async (int StudentId, StudentModel studentModel, ApplicationDbContext db) =>
        {
            var foundModel = await db.StudentDetails.FindAsync(StudentId);

            if (foundModel is null)
            {
                return Results.NotFound();
            }

            db.Update(studentModel);

            await db.SaveChangesAsync();

            return Results.NoContent();
        })
        .WithName("UpdateStudentModel")
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent);

        routes.MapPost("/api/StudentModel/", async (StudentModel studentModel, ApplicationDbContext db) =>
        {
            db.StudentDetails.Add(studentModel);
            await db.SaveChangesAsync();
            return Results.Created($"/StudentModels/{studentModel.StudentId}", studentModel);
        })
        .WithName("CreateStudentModel")
        .Produces<StudentModel>(StatusCodes.Status201Created);

        routes.MapDelete("/api/StudentModel/{id}", async (int StudentId, ApplicationDbContext db) =>
        {
            if (await db.StudentDetails.FindAsync(StudentId) is StudentModel studentModel)
            {
                db.StudentDetails.Remove(studentModel);
                await db.SaveChangesAsync();
                return Results.Ok(studentModel);
            }

            return Results.NotFound();
        })
        .WithName("DeleteStudentModel")
        .Produces<StudentModel>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}
