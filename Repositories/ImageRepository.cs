
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.EntityFrameworkCore;
using Save__plan_your_trips.Data;
using Save__plan_your_trips.Models.Domain;

namespace Save__plan_your_trips.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly ScheduleTripsDbContext scheduleTripsDbContext;

        private readonly IConfiguration configuration;
        private readonly Account account;

        public ImageRepository(IConfiguration configuration, ScheduleTripsDbContext scheduleTripsDbContext)
        {
            this.scheduleTripsDbContext = scheduleTripsDbContext;
            this.configuration = configuration;
            account = new Account(
                configuration.GetSection("Cloudinary")["dbamhuz47"],
                configuration.GetSection("Cloudinary")["571855712285968"],
                configuration.GetSection("Cloudinary")["-l4RZATS8RNz4R2tyyAN2jDR580"]);
        }

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
        public async Task<IEnumerable<Album>> GetAll()
        {
            return await scheduleTripsDbContext.Album.ToListAsync();
        }
    }

}
