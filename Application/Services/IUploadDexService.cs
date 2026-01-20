namespace vendsys_api.Application.Services
{
    public interface IUploadDexService
    {
        Task ProcessAsync(IFormFile dexFile);
    }
}
