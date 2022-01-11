using FreeCourse.Services.PhotoStock.Dtos;
using FreeCourse.Shared.ControllerBases;
using FreeCourse.Shared.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FreeCourse.Services.PhotoStock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosController : CustomBaseController
    {
        /// <summary>
        /// 
        /// </summary>
        public async Task<IActionResult> PhotoSave(IFormFile photo, CancellationToken cancellationToken) //this token triggers when user cancel the operation such as closing the browser and cancelling event 
        {
            if (photo != null && photo.Length > 0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/photos", photo.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await photo.CopyToAsync(stream, cancellationToken);
                }
                var returnPath = "photos/" + photo.FileName;// http://www.photostock.api.com/photos/blablabla.jpeg
                PhotoDto photoDto = new() { Url = returnPath };
                return CreateActionResultInstance(Response<PhotoDto>.Success(200));
            }
            return CreateActionResultInstance(Response<PhotoDto>.Fail("empty content", 400));
        }
    }
}
