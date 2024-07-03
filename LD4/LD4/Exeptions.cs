using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LD4
{
    /// <summary>
    /// Exception for empty list
    /// </summary>
    public class ListIsEmptyException : Exception
    {
        public ListIsEmptyException(string message) : base(message)
        {
        }
    }

    /// <summary>
    /// Exception for files not being found
    /// </summary>
    public class FilesNotFound : Exception
    {
        public FilesNotFound(string message) : base(message)
        {
        }
    }
}