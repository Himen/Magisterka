using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace HR.Web_UI.Services
{
    public static class FileToByte
    {
        public static byte[] ConvertFileToByte (HttpPostedFileBase file)
        {
            byte[] data;
            using (Stream inputStream = file.InputStream)
            {
                MemoryStream memoryStream = inputStream as MemoryStream;
                if (memoryStream == null)
                {
                    memoryStream = new MemoryStream();
                    inputStream.CopyTo(memoryStream);
                }
                data = memoryStream.ToArray();
            }
            return data;
        }
    }
}