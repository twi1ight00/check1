using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Microsoft.Practices.Unity.Configuration.ConfigurationHelpers;

internal class TypeNameParser : ParseBuilder
{
	private class ParsedUnqualifiedName
	{
		public string Namespace;

		public string Rootname;

		public GenericParameters GenericParameters;
	}

	private class GenericParameters
	{
		public bool IsOpenGeneric;

		public readonly List<TypeNameInfo> Parameters = new List<TypeNameInfo>();

		public int Count => Parameters.Count;
	}

	public static TypeNameInfo Parse(string typeName)
	{
		InputStream arg = new InputStream(typeName);
		ParseResult parseResult = ParseBuilder.Sequence(Match_TypeName, ParseBuilder.EOF)(arg);
		if (!parseResult.Matched)
		{
			return null;
		}
		ParseResult parseResult2 = new SequenceResult(parseResult)[0];
		return (TypeNameInfo)parseResult2.ResultData;
	}

	private static void InitializeTypeNameInfo(ParsedUnqualifiedName from, TypeNameInfo to)
	{
		to.Name = from.Rootname;
		to.Namespace = from.Namespace;
		to.IsGenericType = from.GenericParameters != null;
		if (!to.IsGenericType)
		{
			return;
		}
		to.IsOpenGeneric = from.GenericParameters.IsOpenGeneric;
		if (to.IsOpenGeneric)
		{
			for (int i = 0; i < from.GenericParameters.Count; i++)
			{
				to.GenericParameters.Add(null);
			}
			return;
		}
		foreach (TypeNameInfo parameter in from.GenericParameters.Parameters)
		{
			to.GenericParameters.Add(parameter);
		}
	}

	private static ParseResult Match_TypeName(InputStream input)
	{
		TypeNameInfo resultData = new TypeNameInfo();
		ParseResult parseResult = ParseBuilder.Sequence(ParseBuilder.WithAction(Match_UnqualifiedName, delegate(ParseResult r)
		{
			InitializeTypeNameInfo((ParsedUnqualifiedName)r.ResultData, resultData);
		}), ParseBuilder.ZeroOrOne(ParseBuilder.Sequence(Match_Comma, ParseBuilder.WithAction(Match_AssemblyName, delegate(ParseResult r)
		{
			resultData.AssemblyName = r.MatchedString;
		}))))(input);
		if (!parseResult.Matched)
		{
			return parseResult;
		}
		return new ParseResult(parseResult.MatchedString, resultData);
	}

	private static ParseResult Match_AssemblyName(InputStream input)
	{
		return ParseBuilder.Sequence(Match_SimpleName, ParseBuilder.ZeroOrMore(ParseBuilder.Sequence(Match_Comma, Match_AssemblyNamePart)))(input);
	}

	private static ParseResult Match_UnqualifiedName(InputStream input)
	{
		ParsedUnqualifiedName resultData = new ParsedUnqualifiedName();
		ParseResult parseResult = ParseBuilder.Sequence(ParseBuilder.WithAction(ParseBuilder.ZeroOrOne(Match_Namespace), delegate(ParseResult r)
		{
			resultData.Namespace = (string)r.ResultData;
		}), ParseBuilder.WithAction(Match_RootName, delegate(ParseResult r)
		{
			resultData.Rootname = r.MatchedString;
		}), ParseBuilder.WithAction(ParseBuilder.ZeroOrOne(Match_GenericParameters), delegate(ParseResult r)
		{
			resultData.GenericParameters = (GenericParameters)r.ResultData;
		}))(input);
		if (parseResult.Matched)
		{
			return new ParseResult(parseResult.MatchedString, resultData);
		}
		return parseResult;
	}

	private static ParseResult Match_Namespace(InputStream input)
	{
		List<string> ids = new List<string>();
		ParseResult parseResult = ParseBuilder.OneOrMore(ParseBuilder.WithAction(ParseBuilder.Sequence(Match_Id, Match_Dot), delegate(ParseResult r)
		{
			ids.Add(new SequenceResult(r)[0].MatchedString);
		}))(input);
		if (parseResult.Matched)
		{
			string resultData = string.Join(".", ids.ToArray());
			return new ParseResult(parseResult.MatchedString, resultData);
		}
		return parseResult;
	}

	private static ParseResult Match_RootName(InputStream input)
	{
		return ParseBuilder.Sequence(Match_Id, ParseBuilder.ZeroOrMore(Match_NestedName))(input);
	}

	private static ParseResult Match_NestedName(InputStream input)
	{
		return ParseBuilder.Sequence(Match_Plus, Match_Id)(input);
	}

	private static ParseResult Match_GenericParameters(InputStream input)
	{
		return ParseBuilder.FirstOf(Match_ClosedGeneric, Match_OpenGeneric)(input);
	}

	private static ParseResult Match_OpenGeneric(InputStream input)
	{
		return ParseBuilder.FirstOf(Match_CLRSyntax, Match_EmptyBrackets)(input);
	}

	private static ParseResult Match_CLRSyntax(InputStream input)
	{
		GenericParameters resultData = new GenericParameters();
		ParseResult parseResult = ParseBuilder.Sequence(Match_Backquote, ParseBuilder.WithAction(ParseBuilder.OneOrMore(Match_Digit), delegate(ParseResult r)
		{
			resultData.IsOpenGeneric = true;
			int num = int.Parse(r.MatchedString, CultureInfo.InvariantCulture);
			for (int i = 0; i < num; i++)
			{
				resultData.Parameters.Add(null);
			}
		}))(input);
		if (parseResult.Matched)
		{
			return new ParseResult(parseResult.MatchedString, resultData);
		}
		return parseResult;
	}

	private static ParseResult Match_EmptyBrackets(InputStream input)
	{
		GenericParameters resultData = new GenericParameters();
		ParseResult parseResult = ParseBuilder.Sequence(Match_LeftBracket, ParseBuilder.WithAction(ParseBuilder.ZeroOrMore(Match_Comma), delegate(ParseResult r)
		{
			int num = r.MatchedString.Length + 1;
			resultData.IsOpenGeneric = true;
			for (int i = 0; i < num; i++)
			{
				resultData.Parameters.Add(null);
			}
		}), Match_RightBracket)(input);
		if (parseResult.Matched)
		{
			return new ParseResult(parseResult.MatchedString, resultData);
		}
		return parseResult;
	}

	private static ParseResult Match_ClosedGeneric(InputStream input)
	{
		ParseResult parseResult = ParseBuilder.Sequence(ParseBuilder.ZeroOrOne(Match_CLRSyntax), Match_TypeParameters)(input);
		if (parseResult.Matched)
		{
			GenericParameters genericParameters = new GenericParameters();
			genericParameters.IsOpenGeneric = false;
			genericParameters.Parameters.AddRange((List<TypeNameInfo>)new SequenceResult(parseResult)[1].ResultData);
			return new ParseResult(parseResult.MatchedString, genericParameters);
		}
		return parseResult;
	}

	private static ParseResult Match_TypeParameters(InputStream input)
	{
		List<TypeNameInfo> list = new List<TypeNameInfo>();
		ParseResult parseResult = ParseBuilder.Sequence(Match_LeftBracket, ParseBuilder.WithAction(Match_GenericTypeParameter, StoreTypeParameter(list)), ParseBuilder.ZeroOrMore(ParseBuilder.Sequence(Match_Comma, ParseBuilder.WithAction(Match_GenericTypeParameter, StoreTypeParameter(list)))), Match_RightBracket)(input);
		if (parseResult.Matched)
		{
			return new ParseResult(parseResult.MatchedString, list);
		}
		return parseResult;
	}

	private static Action<ParseResult> StoreTypeParameter(ICollection<TypeNameInfo> l)
	{
		return delegate(ParseResult r)
		{
			l.Add((TypeNameInfo)r.ResultData);
		};
	}

	private static ParseResult Match_GenericTypeParameter(InputStream input)
	{
		return ParseBuilder.FirstOf(ParseBuilder.WithAction(Match_UnqualifiedName, delegate(ParseResult r)
		{
			TypeNameInfo typeNameInfo = new TypeNameInfo();
			InitializeTypeNameInfo((ParsedUnqualifiedName)r.ResultData, typeNameInfo);
			return new ParseResult(r.MatchedString, typeNameInfo);
		}), ParseBuilder.WithAction(ParseBuilder.Sequence(Match_LeftBracket, Match_TypeName, Match_RightBracket), (ParseResult r) => new SequenceResult(r)[1]))(input);
	}

	private static ParseResult Match_SimpleName(InputStream input)
	{
		return ParseBuilder.Sequence(Match_AssemblyNameStart, ParseBuilder.ZeroOrMore(Match_AssemblyNameContinuation), Match_Spacing)(input);
	}

	private static ParseResult Match_AssemblyNamePart(InputStream input)
	{
		return ParseBuilder.FirstOf(Match_Culture, Match_Version, Match_PublicKey, Match_PublicKeyToken)(input);
	}

	private static ParseResult Match_Culture(InputStream input)
	{
		return ParseBuilder.Sequence(ParseBuilder.Match("Culture"), Match_Spacing, Match_Equals, Match_LanguageTag)(input);
	}

	private static ParseResult Match_LanguageTag(InputStream input)
	{
		return ParseBuilder.Sequence(Match_LangTagPart, ParseBuilder.ZeroOrOne(ParseBuilder.Sequence(ParseBuilder.Match('-'), Match_LangTagPart)), Match_Spacing)(input);
	}

	private static ParseResult Match_LangTagPart(InputStream input)
	{
		Func<InputStream, ParseResult> func = ParseBuilder.Match((char ch) => "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".Contains(ch));
		Func<InputStream, ParseResult> func2 = ParseBuilder.ZeroOrOne(func);
		return ParseBuilder.Sequence(func, func2, func2, func2, func2, func2, func2, func2, func2, func2, func2, func2, func2, func2, func2, func2)(input);
	}

	private static ParseResult Match_Version(InputStream input)
	{
		return ParseBuilder.Sequence(ParseBuilder.Match("Version"), Match_Spacing, Match_Equals, Match_VersionNumber, Match_Spacing)(input);
	}

	private static ParseResult Match_VersionNumber(InputStream input)
	{
		return ParseBuilder.Sequence(Match_Int, Match_Dot, Match_Int, Match_Dot, Match_Int, Match_Dot, Match_Int)(input);
	}

	private static ParseResult Match_PublicKey(InputStream input)
	{
		return ParseBuilder.Sequence(ParseBuilder.Match("PublicKey"), Match_Spacing, Match_Equals, ParseBuilder.OneOrMore(Match_HexDigit), Match_Spacing)(input);
	}

	private static ParseResult Match_PublicKeyToken(InputStream input)
	{
		return ParseBuilder.Sequence(ParseBuilder.Match("PublicKeyToken"), Match_Spacing, Match_Equals, Match_PublicKeyValue)(input);
	}

	private static ParseResult Match_PublicKeyValue(InputStream input)
	{
		IEnumerable<Func<InputStream, ParseResult>> source = Enumerable.Repeat<Func<InputStream, ParseResult>>(Match_HexDigit, 16).Concat(new Func<InputStream, ParseResult>[1] { Match_Spacing });
		return ParseBuilder.Sequence(source.ToArray())(input);
	}

	private static ParseResult Match_AssemblyNameStart(InputStream input)
	{
		return ParseBuilder.Sequence(ParseBuilder.Not(Match_Dot), Match_AssemblyNameChar)(input);
	}

	private static ParseResult Match_AssemblyNameContinuation(InputStream input)
	{
		return Match_AssemblyNameChar(input);
	}

	private static ParseResult Match_AssemblyNameChar(InputStream input)
	{
		return ParseBuilder.FirstOf(Match_QuotedChar, ParseBuilder.Match((char ch) => !"^/\\:?\"<>|,[]".Contains(ch)))(input);
	}

	private static ParseResult Match_Id(InputStream input)
	{
		return ParseBuilder.Sequence(Match_IdStart, ParseBuilder.ZeroOrMore(Match_IdContinuation))(input);
	}

	private static ParseResult Match_IdStart(InputStream input)
	{
		return ParseBuilder.FirstOf(Match_IdNonAlpha, Match_IdAlpha)(input);
	}

	private static ParseResult Match_IdContinuation(InputStream input)
	{
		return ParseBuilder.FirstOf(Match_IdNonAlpha, Match_IdAlphanumeric)(input);
	}

	private static ParseResult Match_IdAlpha(InputStream input)
	{
		return ParseBuilder.FirstOf(Match_QuotedChar, ParseBuilder.Match((char ch) => char.IsLetter(ch)))(input);
	}

	private static ParseResult Match_IdAlphanumeric(InputStream input)
	{
		return ParseBuilder.FirstOf(Match_QuotedChar, ParseBuilder.Match((char ch) => char.IsLetterOrDigit(ch)))(input);
	}

	private static ParseResult Match_QuotedChar(InputStream input)
	{
		return ParseBuilder.WithAction(ParseBuilder.Sequence(Match_Backslash, ParseBuilder.Any), delegate(ParseResult result)
		{
			string matchedString = new SequenceResult(result)[1].MatchedString;
			return new ParseResult(matchedString);
		})(input);
	}

	private static ParseResult Match_IdNonAlpha(InputStream input)
	{
		return ParseBuilder.Match((char ch) => "_$@?".Contains(ch))(input);
	}

	private static ParseResult Match_Digit(InputStream input)
	{
		return ParseBuilder.Match((char ch) => char.IsDigit(ch))(input);
	}

	private static ParseResult Match_HexDigit(InputStream input)
	{
		return ParseBuilder.Match((char ch) => "0123456789ABCDEFabcdef".Contains(ch))(input);
	}

	private static ParseResult Match_Int(InputStream input)
	{
		return ParseBuilder.WithAction(ParseBuilder.Sequence(Match_Digit, ParseBuilder.ZeroOrMore(Match_Digit)), (ParseResult r) => new ParseResult(r.MatchedString, int.Parse(r.MatchedString, CultureInfo.InvariantCulture)))(input);
	}

	private static ParseResult Match_LeftBracket(InputStream input)
	{
		return ParseBuilder.Sequence(ParseBuilder.Match('['), Match_Spacing)(input);
	}

	private static ParseResult Match_RightBracket(InputStream input)
	{
		return ParseBuilder.Sequence(ParseBuilder.Match(']'), Match_Spacing)(input);
	}

	private static ParseResult Match_Dot(InputStream input)
	{
		return ParseBuilder.Match('.')(input);
	}

	private static ParseResult Match_Backquote(InputStream input)
	{
		return ParseBuilder.Match('`')(input);
	}

	private static ParseResult Match_Plus(InputStream input)
	{
		return ParseBuilder.Match('+')(input);
	}

	private static ParseResult Match_Comma(InputStream input)
	{
		return ParseBuilder.Sequence(ParseBuilder.Match(','), Match_Spacing)(input);
	}

	private static ParseResult Match_Backslash(InputStream input)
	{
		return ParseBuilder.Match('\\')(input);
	}

	private static ParseResult Match_Equals(InputStream input)
	{
		return ParseBuilder.Sequence(ParseBuilder.Match('='), Match_Spacing)(input);
	}

	private static ParseResult Match_Spacing(InputStream input)
	{
		return ParseBuilder.ZeroOrOne(Match_Space)(input);
	}

	private static ParseResult Match_Space(InputStream input)
	{
		return ParseBuilder.FirstOf(ParseBuilder.Match(' '), ParseBuilder.Match('\t'), Match_Eol)(input);
	}

	private static ParseResult Match_Eol(InputStream input)
	{
		return ParseBuilder.FirstOf(ParseBuilder.Match("\r\n"), ParseBuilder.Match('\r'), ParseBuilder.Match('\n'))(input);
	}
}
