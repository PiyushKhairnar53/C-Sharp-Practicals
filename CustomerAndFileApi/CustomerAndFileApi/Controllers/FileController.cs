using CustomerAndFileApi.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.IO;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomerApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        string folderName = @"D:\";

        /// <summary>
        /// Post a directory name.
        /// </summary>
        ///<param name="dirName">Enter Name of Directory to create</param>
        [HttpPost]
        [SwaggerResponse(StatusCodes.Status200OK, "Folder created successfully.")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "FileNotFound")]
        public IActionResult PostFolderFile(string dirName, IFormFile uploadFile)
        {
            folderName = folderName+dirName;
            // If directory does not exist, create it
            if (!Directory.Exists(folderName))
            {
                Directory.CreateDirectory(folderName);
                int TenMegaBytes = 10 * 1024 * 1024;


                if (uploadFile.Length >= TenMegaBytes)
                {
                    using (FileStream fileStream = System.IO.File.Create(Path.Combine(folderName, uploadFile.FileName)))
                    {
                        uploadFile.CopyTo(fileStream);
                        return Ok("File Added successfuly");
                    }
                }
                
            }
            else 
            {
                return BadRequest("Folder already exists");
            }

            return NoContent();
        }

        ///<summary>
        ///Delete Uploaded File 
        ///</summary>
        ///<param name="fileName">Enter Full path of File to delete</param>
        [HttpDelete]
        [SwaggerResponse(StatusCodes.Status200OK, "File deleted successfully")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "FileNotFound")]

        public IActionResult DeleteFile(string fileName)
        {
            string filePath = fileName;

            try
            {
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);

                    if (!System.IO.File.Exists(filePath))
                    {
                        return Ok("File deleted successfully");
                    }
                    else {
                        return NotFound();
                    }
                }
            }
            catch (IOException exception)
            {
               return BadRequest(exception.Message);    
            }

            return NoContent();
        }

}
}
