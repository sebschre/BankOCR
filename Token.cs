using System;

namespace OCRNamespace
{
    /// <summary>
    /// Stores single OCR Token
    /// </summary>
    public struct Token
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="text">string of flattened character token matrix of length 9</param>
        public Token(string text)
        {
            if (text.Length != 9)
                throw new ArgumentException("Wrong length of string argument", "text");
            State = text;
        }

        public string State { get; }
    }
}