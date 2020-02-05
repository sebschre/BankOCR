
namespace OCRNamespace
{
    /// <summary>
    /// Stores 3 lines as strings
    /// </summary>
    public struct TokenLine
    {
        public string Line1 { get; }
        public string Line2 { get; }
        public string Line3 { get; }

        public TokenLine(string line1, string line2, string line3)
        {
            Line1 = line1;
            Line2 = line2;
            Line3 = line3;
        }
    }
}