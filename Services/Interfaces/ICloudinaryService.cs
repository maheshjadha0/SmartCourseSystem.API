namespace SmartCourseSystem.API.Services.Interfaces
{
    public interface ICloudinaryService
    {
        Task<string> UploadImageAsync(
            IFormFile file);
    }
}
