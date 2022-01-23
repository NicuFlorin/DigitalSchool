using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities.Uploads
{
    public class Folder : Upload
    {
       
        public IEnumerable<Folder> Folders { get; set; }
        public Folder Parent { get; set; }
        public int? ParentId { get; set; }
    }
}