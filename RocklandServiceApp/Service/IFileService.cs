using RocklandServiceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RocklandServiceApp.Service
{
    public interface IFileService
    {
        List<FileModel> GetAll();
    }
}
