using Microsoft.AspNetCore.Mvc;
using System.IO;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomerApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        string folderName = @"D:\";
        
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "file1", "file2" };
        }


        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        
        /// <summary>
        /// Post a directory name.
        /// </summary>
        [HttpPost]
        public string Post([FromForm]string dirName, IFormFile uploadFile)
        {
            folderName = folderName+dirName;
            string result = "";
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
                        result = "post success";
                    }
                }
                else
                {
                    result = "post failed";
                }

            }
            else 
            {
                result = "Folder already exists";
            }
            return result;
        }

        // PUT api/<FileController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        ///<summary>
        ///Delete Uploaded File 
        ///</summary>
        [HttpDelete]
        public string Delete(string fileName)
        {
            string result="";
            try
            {
                string filePath = folderName + fileName;
               
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);

                    if (!System.IO.File.Exists(filePath))
                    {
                        result = "file deleted successfully";
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine($"File could not be deleted:");
                result = "failed to delete file";
            }
            return result;
        }

}
}
