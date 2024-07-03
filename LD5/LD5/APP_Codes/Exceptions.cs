using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LD5
{
    public class Exceptions
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

        /// <summary>
        /// Exception for wrong data line in data file
        /// </summary>
        public class WrongDataFile : Exception
        {
            public WrongDataFile(string message) : base(message)
            {
            }
        }
    }
}