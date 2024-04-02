
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Mvc;

namespace Save__plan_your_trips.Repositories
{
    public class ImageRepository : IImageRepository
    {

        private readonly IConfiguration configuration;
        private readonly Account account;

        public ImageRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            account = new Account("dbamhuz47", "495485613653551", "QxRvJNMAi87kw2jqlIZfBbp_Rh4");
        }

        [HttpPost]
        public async Task<string> UploadAsync(IFormFile file)
        {
            var client = new Cloudinary(account);

            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(file.FileName, file.OpenReadStream()),
                DisplayName = file.FileName
            };

            var uploadResult = await client.UploadAsync(uploadParams);

            if (uploadResult != null && uploadResult.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return uploadResult.SecureUri.ToString();
            }

            return null;
        }
    }

}
