using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RocklandServiceApp.Models
{
    public class FileModel
    {
        public int FileId { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string Type { get; set; }
        public List<FileModel> Files { get; set; }
    }
}
