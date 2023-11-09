using Microsoft.AspNetCore.Http;
using RecruitmentPlatform.Domain.Entities.Assets;

namespace RecruitmentPlatform.Service.Interfaces.IAssetServices;

public interface IAssetService
{
    Task<Asset> UploadImageAsync(IFormFile file);
}
