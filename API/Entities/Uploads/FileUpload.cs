using System.Collections.Generic;

namespace API.Entities.Uploads
{
    public class FileUpload
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string Url { get; set; }
        public Folder Folder { get; set; }
        public int? FolderId { get; set; }
        public Upload Upload { get; set; }
        public int? UploadId { get; set; }
        public Question Question { get; set; }
        public AssignmentSubmit AssignmentSubmit { get; set; }
        public string Type { get; set; }



    }
}