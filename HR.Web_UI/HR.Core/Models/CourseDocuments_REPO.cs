﻿using System;

namespace HR.Core.Models
{
    public class CourseDocuments_REPO
    {
        public Guid Guid { get; set; }
        public byte[] Content { get; set; }//dooooooooooooookument itd
        public string FileName { get; set; }
        public string FileType { get; set; }
        public long CourseMaterialId { get; set; }

        public virtual CourseMaterial CourseMaterial { get; set; }

        //dokonczyc
    }
}