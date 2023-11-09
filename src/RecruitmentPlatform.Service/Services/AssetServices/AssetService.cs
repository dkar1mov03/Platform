using Microsoft.AspNetCore.Http;
using RecruitmentPlatform.Data.IRepositories;
using RecruitmentPlatform.Domain.Entities.Assets;
using RecruitmentPlatform.Service.Helpers;
using RecruitmentPlatform.Service.Interfaces.IAssetServices;

namespace RecruitmentPlatform.Service.Services.AssetServices;

public class AssetService : IAssetService
{
    IRepository<Asset> _assetRepository;

    public AssetService(IRepository<Asset> assetRepository)
    {
        this._assetRepository = assetRepository;
    }
    public async Task<Asset> UploadImageAsync(IFormFile file)
    {
        var rootPath = Path.Combine(WebEnvironmentHost.WebRootPath + "assets");
        var fileName = Guid.NewGuid().ToString("N") + Path.GetExtension(file.FileName);
        var path = Path.Combine(rootPath, fileName);

        if(!File.Exists(path))
            File.Create(path);
        using(var stream = File.OpenWrite(path))
        {
            await file.CopyToAsync(stream);
        }
        var asset = new Asset()
        {
            CreatedAt = DateTime.UtcNow,
            Path = Path.Combine("assets", fileName)
        };

        await this._assetRepository.InsertAsync(asset);
        //await this._assetRepository.SaveChangeAsync();
        return asset;
    }
}
