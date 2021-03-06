//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.5.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from .\BinShred.g4 by ANTLR 4.5.1

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591

using System;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.5.1")]
[System.CLSCompliant(false)]
public partial class BinShredLexer : Lexer {
	public const int
		QUOTEDVALUE=1, COMMA=2, QUOTE=3, COLON=4, SEMI=5, LPAREN=6, RPAREN=7, 
		BYTES=8, ITEMS=9, AS=10, DESCRIBED=11, BY=12, ASCII=13, UNICODE=14, UTF8=15, 
		UINT64=16, UINT32=17, UINT16=18, INT64=19, INT32=20, INT16=21, SINGLE=22, 
		FLOAT=23, DOUBLE=24, ADDITIONAL=25, PROPERTIES=26, IDENTIFIED=27, FROM=28, 
		WS=29, DOC_COMMENT=30, BLOCK_COMMENT=31, LINE_COMMENT=32, INT=33, HEXADECIMAL=34, 
		LABEL=35;
	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"QUOTEDVALUE", "COMMA", "QUOTE", "COLON", "SEMI", "LPAREN", "RPAREN", 
		"BYTES", "ITEMS", "AS", "DESCRIBED", "BY", "ASCII", "UNICODE", "UTF8", 
		"UINT64", "UINT32", "UINT16", "INT64", "INT32", "INT16", "SINGLE", "FLOAT", 
		"DOUBLE", "ADDITIONAL", "PROPERTIES", "IDENTIFIED", "FROM", "WS", "DOC_COMMENT", 
		"BLOCK_COMMENT", "LINE_COMMENT", "INT", "HEXADECIMAL", "LABEL", "A", "B", 
		"C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", 
		"Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"
	};


	public BinShredLexer(ICharStream input)
		: base(input)
	{
		Interpreter = new LexerATNSimulator(this,_ATN);
	}

	private static readonly string[] _LiteralNames = {
		null, null, "','", "'\"'", "':'", "';'", "'('", "')'"
	};
	private static readonly string[] _SymbolicNames = {
		null, "QUOTEDVALUE", "COMMA", "QUOTE", "COLON", "SEMI", "LPAREN", "RPAREN", 
		"BYTES", "ITEMS", "AS", "DESCRIBED", "BY", "ASCII", "UNICODE", "UTF8", 
		"UINT64", "UINT32", "UINT16", "INT64", "INT32", "INT16", "SINGLE", "FLOAT", 
		"DOUBLE", "ADDITIONAL", "PROPERTIES", "IDENTIFIED", "FROM", "WS", "DOC_COMMENT", 
		"BLOCK_COMMENT", "LINE_COMMENT", "INT", "HEXADECIMAL", "LABEL"
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

	public override string GrammarFileName { get { return "BinShred.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override string SerializedAtn { get { return _serializedATN; } }

	public static readonly string _serializedATN =
		"\x3\x430\xD6D1\x8206\xAD2D\x4417\xAEF1\x8D80\xAADD\x2%\x196\b\x1\x4\x2"+
		"\t\x2\x4\x3\t\x3\x4\x4\t\x4\x4\x5\t\x5\x4\x6\t\x6\x4\a\t\a\x4\b\t\b\x4"+
		"\t\t\t\x4\n\t\n\x4\v\t\v\x4\f\t\f\x4\r\t\r\x4\xE\t\xE\x4\xF\t\xF\x4\x10"+
		"\t\x10\x4\x11\t\x11\x4\x12\t\x12\x4\x13\t\x13\x4\x14\t\x14\x4\x15\t\x15"+
		"\x4\x16\t\x16\x4\x17\t\x17\x4\x18\t\x18\x4\x19\t\x19\x4\x1A\t\x1A\x4\x1B"+
		"\t\x1B\x4\x1C\t\x1C\x4\x1D\t\x1D\x4\x1E\t\x1E\x4\x1F\t\x1F\x4 \t \x4!"+
		"\t!\x4\"\t\"\x4#\t#\x4$\t$\x4%\t%\x4&\t&\x4\'\t\'\x4(\t(\x4)\t)\x4*\t"+
		"*\x4+\t+\x4,\t,\x4-\t-\x4.\t.\x4/\t/\x4\x30\t\x30\x4\x31\t\x31\x4\x32"+
		"\t\x32\x4\x33\t\x33\x4\x34\t\x34\x4\x35\t\x35\x4\x36\t\x36\x4\x37\t\x37"+
		"\x4\x38\t\x38\x4\x39\t\x39\x4:\t:\x4;\t;\x4<\t<\x4=\t=\x4>\t>\x3\x2\x3"+
		"\x2\x6\x2\x80\n\x2\r\x2\xE\x2\x81\x3\x2\x3\x2\x3\x3\x3\x3\x3\x4\x3\x4"+
		"\x3\x5\x3\x5\x3\x6\x3\x6\x3\a\x3\a\x3\b\x3\b\x3\t\x3\t\x3\t\x3\t\x3\t"+
		"\x5\t\x97\n\t\x3\n\x3\n\x3\n\x3\n\x3\n\x3\n\x3\v\x3\v\x3\v\x3\f\x3\f\x3"+
		"\f\x3\f\x3\f\x3\f\x3\f\x3\f\x3\f\x3\f\x3\r\x3\r\x3\r\x3\xE\x3\xE\x3\xE"+
		"\x3\xE\x3\xE\x3\xE\x3\xF\x3\xF\x3\xF\x3\xF\x3\xF\x3\xF\x3\xF\x3\xF\x3"+
		"\x10\x3\x10\x3\x10\x3\x10\x3\x10\x3\x11\x3\x11\x3\x11\x3\x11\x3\x11\x3"+
		"\x11\x3\x11\x3\x12\x3\x12\x3\x12\x3\x12\x3\x12\x3\x12\x3\x12\x3\x13\x3"+
		"\x13\x3\x13\x3\x13\x3\x13\x3\x13\x3\x13\x3\x14\x3\x14\x3\x14\x3\x14\x3"+
		"\x14\x3\x14\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15\x3\x16\x3\x16\x3"+
		"\x16\x3\x16\x3\x16\x3\x16\x3\x17\x3\x17\x3\x17\x3\x17\x3\x17\x3\x17\x3"+
		"\x17\x3\x18\x3\x18\x3\x18\x3\x18\x3\x18\x3\x18\x3\x19\x3\x19\x3\x19\x3"+
		"\x19\x3\x19\x3\x19\x3\x19\x3\x1A\x3\x1A\x3\x1A\x3\x1A\x3\x1A\x3\x1A\x3"+
		"\x1A\x3\x1A\x3\x1A\x3\x1A\x3\x1A\x3\x1B\x3\x1B\x3\x1B\x3\x1B\x3\x1B\x3"+
		"\x1B\x3\x1B\x3\x1B\x3\x1B\x3\x1B\x3\x1B\x3\x1C\x3\x1C\x3\x1C\x3\x1C\x3"+
		"\x1C\x3\x1C\x3\x1C\x3\x1C\x3\x1C\x3\x1C\x3\x1C\x3\x1D\x3\x1D\x3\x1D\x3"+
		"\x1D\x3\x1D\x3\x1E\x6\x1E\x124\n\x1E\r\x1E\xE\x1E\x125\x3\x1E\x3\x1E\x3"+
		"\x1F\x3\x1F\x3\x1F\x3\x1F\x3\x1F\a\x1F\x12F\n\x1F\f\x1F\xE\x1F\x132\v"+
		"\x1F\x3\x1F\x3\x1F\x3\x1F\x3 \x3 \x3 \x3 \a \x13B\n \f \xE \x13E\v \x3"+
		" \x3 \x3 \x3 \x3 \x3!\x3!\x3!\x3!\a!\x149\n!\f!\xE!\x14C\v!\x3!\x3!\x3"+
		"\"\x6\"\x151\n\"\r\"\xE\"\x152\x3#\x3#\x3#\x6#\x158\n#\r#\xE#\x159\x3"+
		"$\x3$\a$\x15E\n$\f$\xE$\x161\v$\x3%\x3%\x3&\x3&\x3\'\x3\'\x3(\x3(\x3)"+
		"\x3)\x3*\x3*\x3+\x3+\x3,\x3,\x3-\x3-\x3.\x3.\x3/\x3/\x3\x30\x3\x30\x3"+
		"\x31\x3\x31\x3\x32\x3\x32\x3\x33\x3\x33\x3\x34\x3\x34\x3\x35\x3\x35\x3"+
		"\x36\x3\x36\x3\x37\x3\x37\x3\x38\x3\x38\x3\x39\x3\x39\x3:\x3:\x3;\x3;"+
		"\x3<\x3<\x3=\x3=\x3>\x3>\x5\x81\x130\x13C\x2?\x3\x3\x5\x4\a\x5\t\x6\v"+
		"\a\r\b\xF\t\x11\n\x13\v\x15\f\x17\r\x19\xE\x1B\xF\x1D\x10\x1F\x11!\x12"+
		"#\x13%\x14\'\x15)\x16+\x17-\x18/\x19\x31\x1A\x33\x1B\x35\x1C\x37\x1D\x39"+
		"\x1E;\x1F= ?!\x41\"\x43#\x45$G%I\x2K\x2M\x2O\x2Q\x2S\x2U\x2W\x2Y\x2[\x2"+
		"]\x2_\x2\x61\x2\x63\x2\x65\x2g\x2i\x2k\x2m\x2o\x2q\x2s\x2u\x2w\x2y\x2"+
		"{\x2\x3\x2\"\x5\x2\v\f\xE\xF\"\"\x4\x2\f\f\xF\xF\x3\x2\x32;\x4\x2ZZzz"+
		"\x5\x2\x32;\x43H\x63h\x5\x2\x43\\\x61\x61\x63|\a\x2\x30\x30\x32;\x43\\"+
		"\x61\x61\x63|\x4\x2\x43\x43\x63\x63\x4\x2\x44\x44\x64\x64\x4\x2\x45\x45"+
		"\x65\x65\x4\x2\x46\x46\x66\x66\x4\x2GGgg\x4\x2HHhh\x4\x2IIii\x4\x2JJj"+
		"j\x4\x2KKkk\x4\x2LLll\x4\x2MMmm\x4\x2NNnn\x4\x2OOoo\x4\x2PPpp\x4\x2QQ"+
		"qq\x4\x2RRrr\x4\x2SSss\x4\x2TTtt\x4\x2UUuu\x4\x2VVvv\x4\x2WWww\x4\x2X"+
		"Xxx\x4\x2YYyy\x4\x2[[{{\x4\x2\\\\||\x184\x2\x3\x3\x2\x2\x2\x2\x5\x3\x2"+
		"\x2\x2\x2\a\x3\x2\x2\x2\x2\t\x3\x2\x2\x2\x2\v\x3\x2\x2\x2\x2\r\x3\x2\x2"+
		"\x2\x2\xF\x3\x2\x2\x2\x2\x11\x3\x2\x2\x2\x2\x13\x3\x2\x2\x2\x2\x15\x3"+
		"\x2\x2\x2\x2\x17\x3\x2\x2\x2\x2\x19\x3\x2\x2\x2\x2\x1B\x3\x2\x2\x2\x2"+
		"\x1D\x3\x2\x2\x2\x2\x1F\x3\x2\x2\x2\x2!\x3\x2\x2\x2\x2#\x3\x2\x2\x2\x2"+
		"%\x3\x2\x2\x2\x2\'\x3\x2\x2\x2\x2)\x3\x2\x2\x2\x2+\x3\x2\x2\x2\x2-\x3"+
		"\x2\x2\x2\x2/\x3\x2\x2\x2\x2\x31\x3\x2\x2\x2\x2\x33\x3\x2\x2\x2\x2\x35"+
		"\x3\x2\x2\x2\x2\x37\x3\x2\x2\x2\x2\x39\x3\x2\x2\x2\x2;\x3\x2\x2\x2\x2"+
		"=\x3\x2\x2\x2\x2?\x3\x2\x2\x2\x2\x41\x3\x2\x2\x2\x2\x43\x3\x2\x2\x2\x2"+
		"\x45\x3\x2\x2\x2\x2G\x3\x2\x2\x2\x3}\x3\x2\x2\x2\x5\x85\x3\x2\x2\x2\a"+
		"\x87\x3\x2\x2\x2\t\x89\x3\x2\x2\x2\v\x8B\x3\x2\x2\x2\r\x8D\x3\x2\x2\x2"+
		"\xF\x8F\x3\x2\x2\x2\x11\x91\x3\x2\x2\x2\x13\x98\x3\x2\x2\x2\x15\x9E\x3"+
		"\x2\x2\x2\x17\xA1\x3\x2\x2\x2\x19\xAB\x3\x2\x2\x2\x1B\xAE\x3\x2\x2\x2"+
		"\x1D\xB4\x3\x2\x2\x2\x1F\xBC\x3\x2\x2\x2!\xC1\x3\x2\x2\x2#\xC8\x3\x2\x2"+
		"\x2%\xCF\x3\x2\x2\x2\'\xD6\x3\x2\x2\x2)\xDC\x3\x2\x2\x2+\xE2\x3\x2\x2"+
		"\x2-\xE8\x3\x2\x2\x2/\xEF\x3\x2\x2\x2\x31\xF5\x3\x2\x2\x2\x33\xFC\x3\x2"+
		"\x2\x2\x35\x107\x3\x2\x2\x2\x37\x112\x3\x2\x2\x2\x39\x11D\x3\x2\x2\x2"+
		";\x123\x3\x2\x2\x2=\x129\x3\x2\x2\x2?\x136\x3\x2\x2\x2\x41\x144\x3\x2"+
		"\x2\x2\x43\x150\x3\x2\x2\x2\x45\x154\x3\x2\x2\x2G\x15B\x3\x2\x2\x2I\x162"+
		"\x3\x2\x2\x2K\x164\x3\x2\x2\x2M\x166\x3\x2\x2\x2O\x168\x3\x2\x2\x2Q\x16A"+
		"\x3\x2\x2\x2S\x16C\x3\x2\x2\x2U\x16E\x3\x2\x2\x2W\x170\x3\x2\x2\x2Y\x172"+
		"\x3\x2\x2\x2[\x174\x3\x2\x2\x2]\x176\x3\x2\x2\x2_\x178\x3\x2\x2\x2\x61"+
		"\x17A\x3\x2\x2\x2\x63\x17C\x3\x2\x2\x2\x65\x17E\x3\x2\x2\x2g\x180\x3\x2"+
		"\x2\x2i\x182\x3\x2\x2\x2k\x184\x3\x2\x2\x2m\x186\x3\x2\x2\x2o\x188\x3"+
		"\x2\x2\x2q\x18A\x3\x2\x2\x2s\x18C\x3\x2\x2\x2u\x18E\x3\x2\x2\x2w\x190"+
		"\x3\x2\x2\x2y\x192\x3\x2\x2\x2{\x194\x3\x2\x2\x2}\x7F\x5\a\x4\x2~\x80"+
		"\v\x2\x2\x2\x7F~\x3\x2\x2\x2\x80\x81\x3\x2\x2\x2\x81\x82\x3\x2\x2\x2\x81"+
		"\x7F\x3\x2\x2\x2\x82\x83\x3\x2\x2\x2\x83\x84\x5\a\x4\x2\x84\x4\x3\x2\x2"+
		"\x2\x85\x86\a.\x2\x2\x86\x6\x3\x2\x2\x2\x87\x88\a$\x2\x2\x88\b\x3\x2\x2"+
		"\x2\x89\x8A\a<\x2\x2\x8A\n\x3\x2\x2\x2\x8B\x8C\a=\x2\x2\x8C\f\x3\x2\x2"+
		"\x2\x8D\x8E\a*\x2\x2\x8E\xE\x3\x2\x2\x2\x8F\x90\a+\x2\x2\x90\x10\x3\x2"+
		"\x2\x2\x91\x92\x5K&\x2\x92\x93\x5y=\x2\x93\x94\x5o\x38\x2\x94\x96\x5Q"+
		")\x2\x95\x97\x5m\x37\x2\x96\x95\x3\x2\x2\x2\x96\x97\x3\x2\x2\x2\x97\x12"+
		"\x3\x2\x2\x2\x98\x99\x5Y-\x2\x99\x9A\x5o\x38\x2\x9A\x9B\x5Q)\x2\x9B\x9C"+
		"\x5\x61\x31\x2\x9C\x9D\x5m\x37\x2\x9D\x14\x3\x2\x2\x2\x9E\x9F\x5I%\x2"+
		"\x9F\xA0\x5m\x37\x2\xA0\x16\x3\x2\x2\x2\xA1\xA2\x5O(\x2\xA2\xA3\x5Q)\x2"+
		"\xA3\xA4\x5m\x37\x2\xA4\xA5\x5M\'\x2\xA5\xA6\x5k\x36\x2\xA6\xA7\x5Y-\x2"+
		"\xA7\xA8\x5K&\x2\xA8\xA9\x5Q)\x2\xA9\xAA\x5O(\x2\xAA\x18\x3\x2\x2\x2\xAB"+
		"\xAC\x5K&\x2\xAC\xAD\x5y=\x2\xAD\x1A\x3\x2\x2\x2\xAE\xAF\x5I%\x2\xAF\xB0"+
		"\x5m\x37\x2\xB0\xB1\x5M\'\x2\xB1\xB2\x5Y-\x2\xB2\xB3\x5Y-\x2\xB3\x1C\x3"+
		"\x2\x2\x2\xB4\xB5\x5q\x39\x2\xB5\xB6\x5\x63\x32\x2\xB6\xB7\x5Y-\x2\xB7"+
		"\xB8\x5M\'\x2\xB8\xB9\x5\x65\x33\x2\xB9\xBA\x5O(\x2\xBA\xBB\x5Q)\x2\xBB"+
		"\x1E\x3\x2\x2\x2\xBC\xBD\x5q\x39\x2\xBD\xBE\x5o\x38\x2\xBE\xBF\x5S*\x2"+
		"\xBF\xC0\a:\x2\x2\xC0 \x3\x2\x2\x2\xC1\xC2\x5q\x39\x2\xC2\xC3\x5Y-\x2"+
		"\xC3\xC4\x5\x63\x32\x2\xC4\xC5\x5o\x38\x2\xC5\xC6\a\x38\x2\x2\xC6\xC7"+
		"\a\x36\x2\x2\xC7\"\x3\x2\x2\x2\xC8\xC9\x5q\x39\x2\xC9\xCA\x5Y-\x2\xCA"+
		"\xCB\x5\x63\x32\x2\xCB\xCC\x5o\x38\x2\xCC\xCD\a\x35\x2\x2\xCD\xCE\a\x34"+
		"\x2\x2\xCE$\x3\x2\x2\x2\xCF\xD0\x5q\x39\x2\xD0\xD1\x5Y-\x2\xD1\xD2\x5"+
		"\x63\x32\x2\xD2\xD3\x5o\x38\x2\xD3\xD4\a\x33\x2\x2\xD4\xD5\a\x38\x2\x2"+
		"\xD5&\x3\x2\x2\x2\xD6\xD7\x5Y-\x2\xD7\xD8\x5\x63\x32\x2\xD8\xD9\x5o\x38"+
		"\x2\xD9\xDA\a\x38\x2\x2\xDA\xDB\a\x36\x2\x2\xDB(\x3\x2\x2\x2\xDC\xDD\x5"+
		"Y-\x2\xDD\xDE\x5\x63\x32\x2\xDE\xDF\x5o\x38\x2\xDF\xE0\a\x35\x2\x2\xE0"+
		"\xE1\a\x34\x2\x2\xE1*\x3\x2\x2\x2\xE2\xE3\x5Y-\x2\xE3\xE4\x5\x63\x32\x2"+
		"\xE4\xE5\x5o\x38\x2\xE5\xE6\a\x33\x2\x2\xE6\xE7\a\x38\x2\x2\xE7,\x3\x2"+
		"\x2\x2\xE8\xE9\x5m\x37\x2\xE9\xEA\x5Y-\x2\xEA\xEB\x5\x63\x32\x2\xEB\xEC"+
		"\x5U+\x2\xEC\xED\x5_\x30\x2\xED\xEE\x5Q)\x2\xEE.\x3\x2\x2\x2\xEF\xF0\x5"+
		"S*\x2\xF0\xF1\x5_\x30\x2\xF1\xF2\x5\x65\x33\x2\xF2\xF3\x5I%\x2\xF3\xF4"+
		"\x5o\x38\x2\xF4\x30\x3\x2\x2\x2\xF5\xF6\x5O(\x2\xF6\xF7\x5\x65\x33\x2"+
		"\xF7\xF8\x5q\x39\x2\xF8\xF9\x5K&\x2\xF9\xFA\x5_\x30\x2\xFA\xFB\x5Q)\x2"+
		"\xFB\x32\x3\x2\x2\x2\xFC\xFD\x5I%\x2\xFD\xFE\x5O(\x2\xFE\xFF\x5O(\x2\xFF"+
		"\x100\x5Y-\x2\x100\x101\x5o\x38\x2\x101\x102\x5Y-\x2\x102\x103\x5\x65"+
		"\x33\x2\x103\x104\x5\x63\x32\x2\x104\x105\x5I%\x2\x105\x106\x5_\x30\x2"+
		"\x106\x34\x3\x2\x2\x2\x107\x108\x5g\x34\x2\x108\x109\x5k\x36\x2\x109\x10A"+
		"\x5\x65\x33\x2\x10A\x10B\x5g\x34\x2\x10B\x10C\x5Q)\x2\x10C\x10D\x5k\x36"+
		"\x2\x10D\x10E\x5o\x38\x2\x10E\x10F\x5Y-\x2\x10F\x110\x5Q)\x2\x110\x111"+
		"\x5m\x37\x2\x111\x36\x3\x2\x2\x2\x112\x113\x5Y-\x2\x113\x114\x5O(\x2\x114"+
		"\x115\x5Q)\x2\x115\x116\x5\x63\x32\x2\x116\x117\x5o\x38\x2\x117\x118\x5"+
		"Y-\x2\x118\x119\x5S*\x2\x119\x11A\x5Y-\x2\x11A\x11B\x5Q)\x2\x11B\x11C"+
		"\x5O(\x2\x11C\x38\x3\x2\x2\x2\x11D\x11E\x5S*\x2\x11E\x11F\x5k\x36\x2\x11F"+
		"\x120\x5\x65\x33\x2\x120\x121\x5\x61\x31\x2\x121:\x3\x2\x2\x2\x122\x124"+
		"\t\x2\x2\x2\x123\x122\x3\x2\x2\x2\x124\x125\x3\x2\x2\x2\x125\x123\x3\x2"+
		"\x2\x2\x125\x126\x3\x2\x2\x2\x126\x127\x3\x2\x2\x2\x127\x128\b\x1E\x2"+
		"\x2\x128<\x3\x2\x2\x2\x129\x12A\a\x31\x2\x2\x12A\x12B\a,\x2\x2\x12B\x12C"+
		"\a,\x2\x2\x12C\x130\x3\x2\x2\x2\x12D\x12F\v\x2\x2\x2\x12E\x12D\x3\x2\x2"+
		"\x2\x12F\x132\x3\x2\x2\x2\x130\x131\x3\x2\x2\x2\x130\x12E\x3\x2\x2\x2"+
		"\x131\x133\x3\x2\x2\x2\x132\x130\x3\x2\x2\x2\x133\x134\a,\x2\x2\x134\x135"+
		"\a\x31\x2\x2\x135>\x3\x2\x2\x2\x136\x137\a\x31\x2\x2\x137\x138\a,\x2\x2"+
		"\x138\x13C\x3\x2\x2\x2\x139\x13B\v\x2\x2\x2\x13A\x139\x3\x2\x2\x2\x13B"+
		"\x13E\x3\x2\x2\x2\x13C\x13D\x3\x2\x2\x2\x13C\x13A\x3\x2\x2\x2\x13D\x13F"+
		"\x3\x2\x2\x2\x13E\x13C\x3\x2\x2\x2\x13F\x140\a,\x2\x2\x140\x141\a\x31"+
		"\x2\x2\x141\x142\x3\x2\x2\x2\x142\x143\b \x2\x2\x143@\x3\x2\x2\x2\x144"+
		"\x145\a\x31\x2\x2\x145\x146\a\x31\x2\x2\x146\x14A\x3\x2\x2\x2\x147\x149"+
		"\n\x3\x2\x2\x148\x147\x3\x2\x2\x2\x149\x14C\x3\x2\x2\x2\x14A\x148\x3\x2"+
		"\x2\x2\x14A\x14B\x3\x2\x2\x2\x14B\x14D\x3\x2\x2\x2\x14C\x14A\x3\x2\x2"+
		"\x2\x14D\x14E\b!\x2\x2\x14E\x42\x3\x2\x2\x2\x14F\x151\t\x4\x2\x2\x150"+
		"\x14F\x3\x2\x2\x2\x151\x152\x3\x2\x2\x2\x152\x150\x3\x2\x2\x2\x152\x153"+
		"\x3\x2\x2\x2\x153\x44\x3\x2\x2\x2\x154\x155\a\x32\x2\x2\x155\x157\t\x5"+
		"\x2\x2\x156\x158\t\x6\x2\x2\x157\x156\x3\x2\x2\x2\x158\x159\x3\x2\x2\x2"+
		"\x159\x157\x3\x2\x2\x2\x159\x15A\x3\x2\x2\x2\x15A\x46\x3\x2\x2\x2\x15B"+
		"\x15F\t\a\x2\x2\x15C\x15E\t\b\x2\x2\x15D\x15C\x3\x2\x2\x2\x15E\x161\x3"+
		"\x2\x2\x2\x15F\x15D\x3\x2\x2\x2\x15F\x160\x3\x2\x2\x2\x160H\x3\x2\x2\x2"+
		"\x161\x15F\x3\x2\x2\x2\x162\x163\t\t\x2\x2\x163J\x3\x2\x2\x2\x164\x165"+
		"\t\n\x2\x2\x165L\x3\x2\x2\x2\x166\x167\t\v\x2\x2\x167N\x3\x2\x2\x2\x168"+
		"\x169\t\f\x2\x2\x169P\x3\x2\x2\x2\x16A\x16B\t\r\x2\x2\x16BR\x3\x2\x2\x2"+
		"\x16C\x16D\t\xE\x2\x2\x16DT\x3\x2\x2\x2\x16E\x16F\t\xF\x2\x2\x16FV\x3"+
		"\x2\x2\x2\x170\x171\t\x10\x2\x2\x171X\x3\x2\x2\x2\x172\x173\t\x11\x2\x2"+
		"\x173Z\x3\x2\x2\x2\x174\x175\t\x12\x2\x2\x175\\\x3\x2\x2\x2\x176\x177"+
		"\t\x13\x2\x2\x177^\x3\x2\x2\x2\x178\x179\t\x14\x2\x2\x179`\x3\x2\x2\x2"+
		"\x17A\x17B\t\x15\x2\x2\x17B\x62\x3\x2\x2\x2\x17C\x17D\t\x16\x2\x2\x17D"+
		"\x64\x3\x2\x2\x2\x17E\x17F\t\x17\x2\x2\x17F\x66\x3\x2\x2\x2\x180\x181"+
		"\t\x18\x2\x2\x181h\x3\x2\x2\x2\x182\x183\t\x19\x2\x2\x183j\x3\x2\x2\x2"+
		"\x184\x185\t\x1A\x2\x2\x185l\x3\x2\x2\x2\x186\x187\t\x1B\x2\x2\x187n\x3"+
		"\x2\x2\x2\x188\x189\t\x1C\x2\x2\x189p\x3\x2\x2\x2\x18A\x18B\t\x1D\x2\x2"+
		"\x18Br\x3\x2\x2\x2\x18C\x18D\t\x1E\x2\x2\x18Dt\x3\x2\x2\x2\x18E\x18F\t"+
		"\x1F\x2\x2\x18Fv\x3\x2\x2\x2\x190\x191\t\x5\x2\x2\x191x\x3\x2\x2\x2\x192"+
		"\x193\t \x2\x2\x193z\x3\x2\x2\x2\x194\x195\t!\x2\x2\x195|\x3\x2\x2\x2"+
		"\f\x2\x81\x96\x125\x130\x13C\x14A\x152\x159\x15F\x3\x2\x3\x2";
	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN.ToCharArray());
}
