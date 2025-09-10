using InkFlow.UseCases.CreateProfile;
using InkFlow.UseCases.Login;
using Microsoft.AspNetCore.Mvc;

namespace InkFlow.Endpoint;
// Auth
public static class UserEndpoint
{
    public static void ConfigureUserEndpoints(this WebApplication app)
    {
        app.MapPost("auth", async (
            [FromServices] LoginUseCase useCase,
            [FromBody] LoginPayload payload) =>
        {
            var result = await useCase.Do(payload);

            if (!result.IsSuccess)
                return Results.BadRequest();
            return Results.Ok(result.Data);

        });
        
        app.MapPost("createUser", async (
            [FromServices] CreateProfileUseCase useCase,
            [FromBody] CreateProfilePayload payload) =>
        {
            var result = await useCase.Do(payload);

            if (!result.IsSuccess)
                return Results.BadRequest();
            return Results.Ok(result.Data);
        }); 
    }
}