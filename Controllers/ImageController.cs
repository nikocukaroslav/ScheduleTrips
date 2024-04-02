﻿using Microsoft.AspNetCore.Mvc;
using Save__plan_your_trips.Repositories;
using System.Net;

namespace Save__plan_your_trips.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepository imageRepository;

        public ImagesController(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }


        [HttpPost]
        public async Task<IActionResult> UploadAsync(IFormFile file)
        {
            var imageUrl = await imageRepository.UploadAsync(file);

            if (imageUrl == null)
            {
                return Problem("Something went wrong!", null, (int)HttpStatusCode.InternalServerError);
            }

            return new JsonResult(new { link = imageUrl });
        }
    }
}