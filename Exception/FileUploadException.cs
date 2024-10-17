
using System;

namespace CareerHub.exception
{
    public class FileUploadException : Exception
    {
        public FileUploadException(string message) : base(message)
        {
        }
    }
}
