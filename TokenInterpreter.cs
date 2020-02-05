using System;
using System.Collections.Generic;

namespace OCRNamespace
{
    /// <summary>
    /// Abstract base class to interpret single tokens
    /// takes dictionary of child classes to translate token to string
    /// </summary>
    public abstract class TokenInterpreter
    {
        protected abstract Dictionary<Token, string> TokenAlphabet { get; }

        /// <summary>
        /// translates single token to string
        /// </summary>
        /// <param name="token">single token</param>
        /// <returns>translated token</returns>
        public string TranslateFrom(Token token)
        {
            if (isValidToken(token))
                return TokenAlphabet[token];
            else
                throw new ArgumentException("Token argument not in dictionary", $"{nameof(token)}");
        }

        /// <summary>
        /// checks if token is valid/in dictionary
        /// </summary>
        /// <param name="token">single token</param>
        /// <returns>true if token in dictionary</returns>
        public bool isValidToken(Token token)
        {
            return TokenAlphabet.ContainsKey(token);
        }
    }

    /// <summary>
    /// Implementation of token interpreter with realized dictionary
    /// that maps Tokens to strings
    /// </summary>
    public class TokenInterpreterOCR : TokenInterpreter
    {
        protected override Dictionary<Token, string> TokenAlphabet => new Dictionary<Token, string>
        {
            { new Token(
                " _ " +
                "| |" +
                "|_|"), "0" },
            { new Token(
                "   " +
                "  |" +
                "  |"), "1" },
            { new Token(
                " _ " +
                " _|" +
                "|_ "), "2" },
            { new Token(
                " _ " +
                " _|" +
                " _|"), "3" },
            { new Token(
                "   " +
                "|_|" +
                "  |"), "4" },
            { new Token(
                " _ " +
                "|_ " +
                " _|"), "5" },
            { new Token(
                " _ " +
                "|_ " +
                "|_|"), "6" },
            { new Token(
                " _ " +
                "  |" +
                "  |"), "7" },
            { new Token(
                " _ " +
                "|_|" +
                "|_|"), "8" },
            { new Token(
                " _ " +
                "|_|" +
                " _|"), "9" },
        };
    }
}