﻿// ---------------------------------------
// Email: quickapp@ebenmonney.com
// Templates: www.ebenmonney.com/templates
// (c) 2024 www.ebenmonney.com/mit-license
// ---------------------------------------

namespace QuickApp.Core.Services.Shop
{
   
    public class CompteurException : Exception
    {
        /// <summary>Initializes a new instance of the <see cref="CompteurException" /> class.</summary>
        public CompteurException() : base("")
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CompteurException" /> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public CompteurException(string? message) : base(message)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CompteurException" /> class with a specified error message
        /// and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">
        /// The exception that is the cause of the current exception, or a null reference (<see langword="Nothing" /> 
        /// in Visual Basic) if no inner exception is specified.
        /// </param>
        public CompteurException(string? message, Exception? innerException) : base(message, innerException)
        {

        }
    }
}
