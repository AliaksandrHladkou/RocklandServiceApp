using BlazorInputFile;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RocklandServiceApp.Service
{
    /// <summary>
    /// Class for uploading an image.
    /// </summary>
    public class FileUpload:IFileUpload 
    {
        private readonly IWebHostEnvironment _environment;
        public FileUpload(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        /// <summary>
        /// Uploading a file to the server. Currently, removes all files in folder before new upload.
        /// Currently, it is limimted to load into wwwroot folder so it can be accessed to display as pdf.
        /// </summary>
        /// <param name="fileEntry">A file entry that is uploaded by a user.</param>
        /// <returns></returns>
        public async Task UploadAsync(IFileListEntry fileEntry)
        {
            DirectoryInfo directory = new DirectoryInfo(Path.Combine(_environment.WebRootPath, "files"));
            foreach (FileInfo file in directory.GetFiles())
            {
                file.Delete();
            }
            var path = Path.Combine(_environment.WebRootPath, "files", fileEntry.Name);
            var memoryStream = new MemoryStream();
            await fileEntry.Data.CopyToAsync(memoryStream);
            using (FileStream file = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                memoryStream.WriteTo(file);
            }
        }
    }
}
