using InkFlow.UseCases.CreateStory;
using InkFlow.UseCases.DeleteStory;
using InkFlow.UseCases.EditStory;
using Microsoft.AspNetCore.Mvc;

namespace InkFlow.Endpoint;
// Auth
public static class StoryEndpoints
{
    public static void ConfigureStoryEndpoints(this WebApplication app)
    {
        app.MapPost("create-story", async (
            [FromServices] CreateStoryUseCase useCase,
            [FromBody] CreateStoryPayload payload) =>
        {
            var result = await useCase.Do(payload);

            if (!result.IsSuccess)
                return Results.BadRequest();
            return Results.Ok(result.Data);
        });

        app.MapDelete("delete-story", async (
            [FromServices] DeleteStoryUseCase useCase,
            [FromBody] DeleteStoryPayload payload) =>
        {
            var result = await useCase.Do(payload);

            if (!result.IsSuccess)
                return Results.BadRequest();
            return Results.Ok(result.Data);
        }); 

        app.MapPut("edit-story", async (
            [FromServices] EditStoryUseCase useCase,
            [FromBody] EditStoryPayload payload) =>
        {
            var result = await useCase.Do(payload);

            if (!result.IsSuccess)
                return Results.BadRequest();
            return Results.Ok(result.Data);
        }); 
    }
}