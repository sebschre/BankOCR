using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace OCRNamespace
{
    /// <summary>
    /// Takes list of lines from text file to
    /// 1.) create list of tokenlines
    /// 2.) create List of tokens from tokenlines
    /// 3.) interpret tokens to strings
    /// </summary>
    public class OCRInterpreter
    {
        private ITokenLineCreator _tokenLineCreator;
        private ITokenCreator _tokenCreator;
        private TokenInterpreter _tokenInterpreter;
        private const string _errorMessage = "Fehlerhafte Zeile";

        public OCRInterpreter(ITokenLineCreator tokenLineCreator, ITokenCreator tokenCreator, TokenInterpreter tokenInterpreter)
        {
            _tokenLineCreator = tokenLineCreator;
            _tokenCreator = tokenCreator;
            _tokenInterpreter = tokenInterpreter;
        }

        /// <summary>
        /// Takes list of lines from text file to
        /// 1.) create list of tokenlines
        /// 2.) create List of tokens from tokenlines
        /// 3.) interpret tokens to strings
        /// </summary>
        /// <param name="textFileLines">list of lines from text file</param>
        /// <returns>interpreted tokens as strings</returns>
        public List<string> Parse(List<string> textFileLines)
        {
            var allParsedValues = new List<string>();
            var tokenLineList = _tokenLineCreator.GetTokenLineListFromSingleLines(textFileLines);
            foreach (var tokenLine in tokenLineList)
            {
                IEnumerable<Token> tokenList = Enumerable.Empty<Token>();
                try
                {
                    tokenList = _tokenCreator.TokenizeFrom(tokenLine);
                }
                catch (ArgumentException)
                {
                    allParsedValues.Add(_errorMessage);
                }

                var parsedLineBuilder = new StringBuilder();
                foreach (var token in tokenList)
                {
                    try
                    {
                        parsedLineBuilder.Append(_tokenInterpreter.TranslateFrom(token));
                    }
                    catch (ArgumentException)
                    {
                        parsedLineBuilder.Clear();
                        parsedLineBuilder.Append(_errorMessage);
                        break;
                    }
                }
                allParsedValues.Add(parsedLineBuilder.ToString());
            }
            return allParsedValues;
        }
    }
}