using Microsoft.AspNetCore.Hosting;
using RocklandServiceApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RocklandServiceApp.Service
{
    /// <summary>
    /// Class to retrieve pdf files found in the folder. 
    /// </summary>
    public class FileService: IFileService
    {
        IHostingEnvironment _hostingEnvironment = null;

        public FileService(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        /// <summary>
        /// Retrieves all .pdf files found in the directory.
        /// </summary>
        /// <returns>A list of PDF files of FileModel type.</returns>
        public List<FileModel> GetAll()
        {
            List<FileModel> files = new List<FileModel>();
            string path = $"{_hostingEnvironment.WebRootPath}\\files\\";
            int fileCounter = 1;

            foreach(string filePath in Directory.EnumerateFiles(path, "*.pdf"))
            {
                files.Add(new FileModel() { 
                    FileId = fileCounter++,
                    Name = Path.GetFileName(filePath),
                    Path = filePath,
                    Type = Path.GetExtension(filePath)
                });
            }
            return files;
        }
    }
}
