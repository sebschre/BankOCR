using System;
using System.Linq;
using System.Collections.Generic;

namespace OCRNamespace
{
    /// <summary>
    /// Interface to create TokenLines from lines in 
    /// </summary>
    public interface ITokenLineCreator
    {
        /// <summary>
        /// Interface method that creates TokenLines from lines in textfile
        /// </summary>
        /// <param name="lines">line from text file</param>
        /// <returns>TokenLines</returns>
        public IEnumerable<TokenLine> GetTokenLineListFromSingleLines(IEnumerable<string> lines);
    }

    /// <summary>
    /// Implementation of interface ITokenLineCreator
    /// </summary>
    public class TokenLineCreatorOCR : ITokenLineCreator
    {
        /// <summary>
        /// Implementation of interface method
        /// Assumes: - TokenLine in the first line of the text file
        ///          - One empty line after every TokenLine
        /// TODO: performance (ELementAt)
        /// </summary>
        /// <param name="lines">lines from text file</param>
        /// <returns>TokenLines</returns>
        public IEnumerable<TokenLine> GetTokenLineListFromSingleLines(IEnumerable<string> lines)
        {
            if (lines == null)
                throw new ArgumentNullException("Argument must not be null", $"{nameof(lines)}");
            if (lines.Count() < 3)
                throw new ArgumentException("Argument must contain at least three lines", $"{nameof(lines)}");
            for (int i = 2; i < lines.Count(); i += 4)
            {
                yield return new TokenLine(
                    lines.ElementAt(i - 2),
                    lines.ElementAt(i - 1),
                    lines.ElementAt(i)
                );
            }
        }
    }
}