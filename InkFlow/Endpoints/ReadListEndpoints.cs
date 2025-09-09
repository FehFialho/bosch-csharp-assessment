using InkFlow.UseCases.Login;
using Microsoft.AspNetCore.Mvc;

namespace InkFlow.Endpoint;
// Auth
public static class ReadListEndpoints
{
    public static void ConfigureReadListEndpoints(this WebApplication app)
    {
        app.MapPost("auth", async (
            [FromBody] LoginPayload payload,
            [FromServices] LoginUseCase useCase) =>
        {
            var result = await useCase.Do(payload);
            if (!result.IsSuccess)
                return Results.BadRequest();
            return Results.Ok(result.Data);
        });
        
        // app.MapPost("createUser", async (
        //     [FromServices] CreateProfileUseCase useCase,
        //     [FromBody] CreateProfilePayload payload) =>
        // {
        //     var result = await useCase.Do(payload);

        //     if (!result.IsSuccess)
        //         return Results.BadRequest();
        //     return Results.Ok(result.Data);
        // }); 
    }
}