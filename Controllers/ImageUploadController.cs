using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace QuizWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageUploadController : ControllerBase
    {
        public static IWebHostEnvironment _environment;
        public ImageUploadController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        public class FileUploadAPI
        {
            public IFormFile file { get; set; }
        }

        [HttpPost]
        public string Post([FromForm] FileUploadAPI objFile)
        {
            try
            {
                if (objFile.file.Length > 0)
                {
                    if (!Directory.Exists(_environment.WebRootPath + "\\Upload\\"))
                    {
                        Directory.CreateDirectory(_environment.WebRootPath + "\\Upload\\");
                    }
                    int lastDot = objFile.file.FileName.LastIndexOf('.');
                    string now = DateTime.Now.ToString("yyMMddHHmmss");
                    string fileName = $"{objFile.file.FileName.Substring(0, lastDot)}_{now}.{objFile.file.FileName.Substring(lastDot + 1)}";
                    using (FileStream fileStream = System.IO.File.Create(_environment.WebRootPath + "\\Upload\\" + fileName))
                    {
                        objFile.file.CopyTo(fileStream);
                        fileStream.Flush();
                        return "/Upload/" + fileName;
                    }
                }
                else
                {
                    return "Failed";
                }
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
    }
}
