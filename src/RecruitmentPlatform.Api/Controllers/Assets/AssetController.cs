using Microsoft.AspNetCore.Mvc;
using RecruitmentPlatform.Api.Models;
using RecruitmentPlatform.Service.Interfaces.IAssetServices;

namespace RecruitmentPlatform.Api.Controllers.Assets;

public class AssetController : BaseController
{
    IAssetService assetService;

    public AssetController(IAssetService assetService)
    {
        this.assetService = assetService;
    }
    [HttpPost]
    public async Task<IActionResult> PostImageAsync(IFormFile file)
    {
        var asset = await this.assetService.UploadImageAsync(file);
        return this.Ok(new Response()
            {
                StatusCode = 200,
                Message = "Succes",
                Data = asset
            });
    }
}
