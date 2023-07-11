using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace restaurant.Models
{
    public class UploadImgModel
    {
        public IFormFile imgSubida {set;get;}
    }
}