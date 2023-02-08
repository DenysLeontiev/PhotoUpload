using CloudinaryDotNet.Actions;

namespace PhotoUpload.Inrefaces
{
    public interface IPhotoService
    {
        Task<ImageUploadResult> UploadAsync(IFormFile file);
        Task<DeletionResult> DeleteAsync(string publicId);
    }
}
