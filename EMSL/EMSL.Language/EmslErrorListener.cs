using System.Collections.Generic;
using System.IO;
using Antlr4.Runtime;
using EMSL.Language.Models;

namespace EMSL.Language;

public class EmslErrorListener : BaseErrorListener
{
    private bool _hasErrors;
    private readonly List<string> _errorMessages = [];

    public override void SyntaxError(TextWriter output, IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine,
        string msg, RecognitionException e)
    {
        _hasErrors = true;
        _errorMessages.Add(msg);
    }

    public void ThrowIfSyntaxError()
    {
        if (_hasErrors)
        {
            throw new EmslSyntaxException(string.Join('\n', _errorMessages));
        }
    }
}