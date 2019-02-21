using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAuthentication.Models.Video
{
    public class FileModel
    {
        public int invoke { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContentType { get; set; }
        public byte[] Data { get; set; }
    }
}