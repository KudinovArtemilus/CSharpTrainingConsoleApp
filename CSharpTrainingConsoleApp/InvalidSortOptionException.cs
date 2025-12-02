using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpTrainingConsoleApp
{
    internal class InvalidSortOptionException : Exception
    {
        public InvalidSortOptionException() { }

        public InvalidSortOptionException(string message) : base(message) { }

        public InvalidSortOptionException(string message, Exception inner)
            : base(message, inner) { }

    }
}
