using vendsys_api.Application.Services;

namespace vendsys_api.Api
{
    public static class UploadEndpoint
    {
        public static void MapDexEndpoints(this WebApplication app)
        {
            app.MapPost("/dex", async (
                IFormFile file,
                IUploadDexService service
            ) =>
            {
                if (file == null || file.Length == 0)
                    return Results.BadRequest("Invalid file");

                await service.ProcessAsync(file);
                return Results.Ok();
            }).DisableAntiforgery(); 
        }
    }
}
