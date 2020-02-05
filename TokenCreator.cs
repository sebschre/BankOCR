using System;
using System.Text;
using System.Collections.Generic;

namespace OCRNamespace
{
    /// <summary>
    /// Interface to create Tokens from single TokenLine
    /// </summary>
    public interface ITokenCreator
    {
        /// <summary>
        /// Interface method that creates Tokens from single TokenLine
        /// </summary>
        /// <param name="tokenLine">unparsed tokenline</param>
        /// <returns>unparsed tokens</returns>
        public IEnumerable<Token> TokenizeFrom(TokenLine tokenLine);
    }

    /// <summary>
    /// Implementation of the ITokenCreator interface
    /// </summary>
    public class TokenCreatorOCR : ITokenCreator
    {
        /// <summary>
        /// Implementation of interface method
        /// builds string to pass to Token constructor and yield returns Token
        /// </summary>
        /// <param name="tokenLine">unparsed tokenline</param>
        /// <returns>unparsed tokens</returns>
        public IEnumerable<Token> TokenizeFrom(TokenLine tokenLine)
        {
            if (tokenLine.Line1.Length != tokenLine.Line2.Length ||
                tokenLine.Line2.Length != tokenLine.Line3.Length)
                throw new ArgumentException("Lines in TokenLine must be of same length", $"{nameof(tokenLine)}");
            var sb = new StringBuilder();
            for (int i = 0; i < tokenLine.Line1.Length; i += 3)
            {
                sb.Clear();
                sb.Append(tokenLine.Line1.Substring(i, 3));
                sb.Append(tokenLine.Line2.Substring(i, 3));
                sb.Append(tokenLine.Line3.Substring(i, 3));
                string tokenString = sb.ToString();
                yield return new Token(tokenString);
            }
        }
    }
}