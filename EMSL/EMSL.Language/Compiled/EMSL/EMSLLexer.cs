//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.13.2
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from F:/DevFile/EMSL/EMSL/EMSL.Language/EMSL.g4 by ANTLR 4.13.2

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace EMSL {
using System;
using System.IO;
using System.Text;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.13.2")]
[System.CLSCompliant(false)]
public partial class EMSLLexer : Lexer {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		NAME=1, SOURCE=2, TARGET=3, WITH=4, HOSTNAME=5, PORT=6, RESOURCE=7, OF=8, 
		TYPE=9, RESOURCE_TYPE=10, FROM=11, TO=12, REQUIRES=13, AND=14, INT_LITERAL=15, 
		STRING_LITERAL=16, LINE_ENDINGS=17;
	public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"NAME", "SOURCE", "TARGET", "WITH", "HOSTNAME", "PORT", "RESOURCE", "OF", 
		"TYPE", "RESOURCE_TYPE", "FROM", "TO", "REQUIRES", "AND", "INT_LITERAL", 
		"STRING_LITERAL", "LINE_ENDINGS"
	};


	public EMSLLexer(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public EMSLLexer(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	private static readonly string[] _LiteralNames = {
		null, "'NAME '", "'SOURCE'", "'TARGET'", "'WITH'", "'HOSTNAME'", "'PORT'", 
		"'RESOURCE'", "'OF'", "'TYPE'", null, "'FROM'", "'TO'", "'REQUIRES'", 
		"'AND'"
	};
	private static readonly string[] _SymbolicNames = {
		null, "NAME", "SOURCE", "TARGET", "WITH", "HOSTNAME", "PORT", "RESOURCE", 
		"OF", "TYPE", "RESOURCE_TYPE", "FROM", "TO", "REQUIRES", "AND", "INT_LITERAL", 
		"STRING_LITERAL", "LINE_ENDINGS"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "EMSL.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ChannelNames { get { return channelNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override int[] SerializedAtn { get { return _serializedATN; } }

	static EMSLLexer() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}
	private static int[] _serializedATN = {
		4,0,17,147,6,-1,2,0,7,0,2,1,7,1,2,2,7,2,2,3,7,3,2,4,7,4,2,5,7,5,2,6,7,
		6,2,7,7,7,2,8,7,8,2,9,7,9,2,10,7,10,2,11,7,11,2,12,7,12,2,13,7,13,2,14,
		7,14,2,15,7,15,2,16,7,16,1,0,1,0,1,0,1,0,1,0,1,0,1,1,1,1,1,1,1,1,1,1,1,
		1,1,1,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,3,1,3,1,3,1,3,1,3,1,4,1,4,1,4,1,4,
		1,4,1,4,1,4,1,4,1,4,1,5,1,5,1,5,1,5,1,5,1,6,1,6,1,6,1,6,1,6,1,6,1,6,1,
		6,1,6,1,7,1,7,1,7,1,8,1,8,1,8,1,8,1,8,1,9,1,9,1,9,1,9,1,9,3,9,97,8,9,1,
		10,1,10,1,10,1,10,1,10,1,11,1,11,1,11,1,12,1,12,1,12,1,12,1,12,1,12,1,
		12,1,12,1,12,1,13,1,13,1,13,1,13,1,14,3,14,121,8,14,1,14,1,14,3,14,125,
		8,14,1,14,1,14,5,14,129,8,14,10,14,12,14,132,9,14,3,14,134,8,14,1,15,4,
		15,137,8,15,11,15,12,15,138,1,16,4,16,142,8,16,11,16,12,16,143,1,16,1,
		16,0,0,17,1,1,3,2,5,3,7,4,9,5,11,6,13,7,15,8,17,9,19,10,21,11,23,12,25,
		13,27,14,29,15,31,16,33,17,1,0,4,1,0,48,57,1,0,49,57,4,0,45,58,65,90,95,
		95,97,122,3,0,9,10,13,13,32,32,153,0,1,1,0,0,0,0,3,1,0,0,0,0,5,1,0,0,0,
		0,7,1,0,0,0,0,9,1,0,0,0,0,11,1,0,0,0,0,13,1,0,0,0,0,15,1,0,0,0,0,17,1,
		0,0,0,0,19,1,0,0,0,0,21,1,0,0,0,0,23,1,0,0,0,0,25,1,0,0,0,0,27,1,0,0,0,
		0,29,1,0,0,0,0,31,1,0,0,0,0,33,1,0,0,0,1,35,1,0,0,0,3,41,1,0,0,0,5,48,
		1,0,0,0,7,55,1,0,0,0,9,60,1,0,0,0,11,69,1,0,0,0,13,74,1,0,0,0,15,83,1,
		0,0,0,17,86,1,0,0,0,19,96,1,0,0,0,21,98,1,0,0,0,23,103,1,0,0,0,25,106,
		1,0,0,0,27,115,1,0,0,0,29,133,1,0,0,0,31,136,1,0,0,0,33,141,1,0,0,0,35,
		36,5,78,0,0,36,37,5,65,0,0,37,38,5,77,0,0,38,39,5,69,0,0,39,40,5,32,0,
		0,40,2,1,0,0,0,41,42,5,83,0,0,42,43,5,79,0,0,43,44,5,85,0,0,44,45,5,82,
		0,0,45,46,5,67,0,0,46,47,5,69,0,0,47,4,1,0,0,0,48,49,5,84,0,0,49,50,5,
		65,0,0,50,51,5,82,0,0,51,52,5,71,0,0,52,53,5,69,0,0,53,54,5,84,0,0,54,
		6,1,0,0,0,55,56,5,87,0,0,56,57,5,73,0,0,57,58,5,84,0,0,58,59,5,72,0,0,
		59,8,1,0,0,0,60,61,5,72,0,0,61,62,5,79,0,0,62,63,5,83,0,0,63,64,5,84,0,
		0,64,65,5,78,0,0,65,66,5,65,0,0,66,67,5,77,0,0,67,68,5,69,0,0,68,10,1,
		0,0,0,69,70,5,80,0,0,70,71,5,79,0,0,71,72,5,82,0,0,72,73,5,84,0,0,73,12,
		1,0,0,0,74,75,5,82,0,0,75,76,5,69,0,0,76,77,5,83,0,0,77,78,5,79,0,0,78,
		79,5,85,0,0,79,80,5,82,0,0,80,81,5,67,0,0,81,82,5,69,0,0,82,14,1,0,0,0,
		83,84,5,79,0,0,84,85,5,70,0,0,85,16,1,0,0,0,86,87,5,84,0,0,87,88,5,89,
		0,0,88,89,5,80,0,0,89,90,5,69,0,0,90,18,1,0,0,0,91,92,5,75,0,0,92,93,5,
		56,0,0,93,97,5,83,0,0,94,95,5,86,0,0,95,97,5,77,0,0,96,91,1,0,0,0,96,94,
		1,0,0,0,97,20,1,0,0,0,98,99,5,70,0,0,99,100,5,82,0,0,100,101,5,79,0,0,
		101,102,5,77,0,0,102,22,1,0,0,0,103,104,5,84,0,0,104,105,5,79,0,0,105,
		24,1,0,0,0,106,107,5,82,0,0,107,108,5,69,0,0,108,109,5,81,0,0,109,110,
		5,85,0,0,110,111,5,73,0,0,111,112,5,82,0,0,112,113,5,69,0,0,113,114,5,
		83,0,0,114,26,1,0,0,0,115,116,5,65,0,0,116,117,5,78,0,0,117,118,5,68,0,
		0,118,28,1,0,0,0,119,121,5,45,0,0,120,119,1,0,0,0,120,121,1,0,0,0,121,
		122,1,0,0,0,122,134,7,0,0,0,123,125,5,45,0,0,124,123,1,0,0,0,124,125,1,
		0,0,0,125,126,1,0,0,0,126,130,7,1,0,0,127,129,7,0,0,0,128,127,1,0,0,0,
		129,132,1,0,0,0,130,128,1,0,0,0,130,131,1,0,0,0,131,134,1,0,0,0,132,130,
		1,0,0,0,133,120,1,0,0,0,133,124,1,0,0,0,134,30,1,0,0,0,135,137,7,2,0,0,
		136,135,1,0,0,0,137,138,1,0,0,0,138,136,1,0,0,0,138,139,1,0,0,0,139,32,
		1,0,0,0,140,142,7,3,0,0,141,140,1,0,0,0,142,143,1,0,0,0,143,141,1,0,0,
		0,143,144,1,0,0,0,144,145,1,0,0,0,145,146,6,16,0,0,146,34,1,0,0,0,8,0,
		96,120,124,130,133,138,143,1,6,0,0
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
} // namespace EMSL