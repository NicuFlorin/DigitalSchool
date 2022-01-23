using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Interfaces;
using Microsoft.AspNetCore.Http;

namespace API.DTOs
{
    public class FileDto
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public int Size { get; set; }
        public string Type { get; set; }
    }
}