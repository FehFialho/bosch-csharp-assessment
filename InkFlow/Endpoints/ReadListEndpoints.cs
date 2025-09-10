using InkFlow.UseCases.Login;
using InkFlow.UseCases.SearchReadList;
using Microsoft.AspNetCore.Mvc;

namespace InkFlow.Endpoint;
// Auth
public static class ReadListEndpoints
{
    public static void ConfigureReadListEndpoints(this WebApplication app)
    {

        app.MapGet("search-readlist", async (
            [FromServices] SearchReadListUseCase useCase,
            [FromBody] SearchReadListPayload payload) =>
        {
            var result = await useCase.Do(payload);

            if (!result.IsSuccess)
                return Results.BadRequest();
            return Results.Ok(result.Data);
        });

        // app.MapPost("add-to-readlist", async (
        //     [FromServices] AddToReadListUseCase useCase,
        //     [FromBody] AddToReadListPayload payload) =>
        // {
        //     var result = await useCase.Do(payload);

        //     if (!result.IsSuccess)
        //         return Results.BadRequest();
        //     return Results.Ok(result.Data);
        // });
    }
}