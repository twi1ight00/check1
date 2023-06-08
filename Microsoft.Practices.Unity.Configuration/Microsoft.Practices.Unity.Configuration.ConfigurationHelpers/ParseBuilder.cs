using System;
using System.Collections.Generic;

namespace Microsoft.Practices.Unity.Configuration.ConfigurationHelpers;

/// <summary>
/// A simple implementing of the rules for a Parsing Expression Grammar
/// parsing algorithm. This supplies basic methods to do the primitives
/// of the PEG, and combinators to create larger rules.
/// </summary>
internal class ParseBuilder
{
	private static readonly ParseResult matchFailed = new ParseResult(matched: false);

	/// <summary>
	/// The PEG "dot" operator that matches and consumes one character.
	/// </summary>
	/// <param name="input">Input to the parser.</param>
	/// <returns>The parse result.</returns>
	public static ParseResult Any(InputStream input)
	{
		if (input.AtEnd)
		{
			return matchFailed;
		}
		ParseResult result = new ParseResult(input.CurrentChar.ToString());
		input.Consume(1);
		return result;
	}

	/// <summary>
	/// Parse function generator that returns a method to match a single,
	/// specific character.
	/// </summary>
	/// <param name="charToMatch">Character to match.</param>
	/// <returns>The generated parsing function.</returns>
	public static Func<InputStream, ParseResult> Match(char charToMatch)
	{
		return (InputStream input) => (!input.AtEnd && input.CurrentChar == charToMatch) ? MatchAndConsumeCurrentChar(input) : matchFailed;
	}

	public static Func<InputStream, ParseResult> Match(string s)
	{
		return delegate(InputStream input)
		{
			int currentPosition = input.CurrentPosition;
			string text = s;
			foreach (char c in text)
			{
				if (input.AtEnd || input.CurrentChar != c)
				{
					input.BackupTo(currentPosition);
					return matchFailed;
				}
				input.Consume(1);
			}
			return new ParseResult(s);
		};
	}

	/// <summary>
	/// Parse function generator that checks if the current character matches
	/// the predicate supplied.
	/// </summary>
	/// <param name="predicate">Predicate used to determine if the character is in
	/// the given range.</param>
	/// <returns>The generated parsing function.</returns>
	public static Func<InputStream, ParseResult> Match(Func<char, bool> predicate)
	{
		return (InputStream input) => (!input.AtEnd && predicate(input.CurrentChar)) ? MatchAndConsumeCurrentChar(input) : matchFailed;
	}

	/// <summary>
	/// The "*" operator - match zero or more of the inner parse expressions.
	/// </summary>
	/// <param name="inner">Parse method to repeat matching.</param>
	/// <returns>The generated parsing function.</returns>
	public static Func<InputStream, ParseResult> ZeroOrMore(Func<InputStream, ParseResult> inner)
	{
		return delegate(InputStream input)
		{
			List<ParseResult> list = new List<ParseResult>();
			ParseResult parseResult = inner(input);
			if (!parseResult.Matched)
			{
				return new ParseResult(matched: true);
			}
			list.Add(parseResult);
			string text = parseResult.MatchedString;
			parseResult = inner(input);
			while (parseResult.Matched)
			{
				text += parseResult.MatchedString;
				list.Add(parseResult);
				parseResult = inner(input);
			}
			return new ParseResult(text, list);
		};
	}

	public static Func<InputStream, ParseResult> ZeroOrOne(Func<InputStream, ParseResult> expression)
	{
		return delegate(InputStream input)
		{
			ParseResult parseResult = expression(input);
			return parseResult.Matched ? parseResult : new ParseResult(matched: true);
		};
	}

	public static Func<InputStream, ParseResult> OneOrMore(Func<InputStream, ParseResult> expression)
	{
		return delegate(InputStream input)
		{
			int currentPosition = input.CurrentPosition;
			List<ParseResult> list = new List<ParseResult>();
			ParseResult parseResult = expression(input);
			if (!parseResult.Matched)
			{
				input.BackupTo(currentPosition);
				return matchFailed;
			}
			string text = "";
			while (parseResult.Matched)
			{
				list.Add(parseResult);
				text += parseResult.MatchedString;
				parseResult = expression(input);
			}
			return new ParseResult(text, list);
		};
	}

	/// <summary>
	/// Parsing combinator that matches all of the given expressions in
	/// order, or matches none of them.
	/// </summary>
	/// <param name="expressions">Expressions that form the sequence to match.</param>
	/// <returns>The combined sequence.</returns>
	public static Func<InputStream, ParseResult> Sequence(params Func<InputStream, ParseResult>[] expressions)
	{
		return delegate(InputStream input)
		{
			int currentPosition = input.CurrentPosition;
			List<ParseResult> list = new List<ParseResult>(expressions.Length);
			string text = "";
			Func<InputStream, ParseResult>[] array = expressions;
			foreach (Func<InputStream, ParseResult> func in array)
			{
				ParseResult parseResult = func(input);
				if (!parseResult.Matched)
				{
					input.BackupTo(currentPosition);
					return matchFailed;
				}
				list.Add(parseResult);
				text += parseResult.MatchedString;
			}
			return new ParseResult(text, list);
		};
	}

	/// <summary>
	/// Parsing combinator that implements the PEG prioritized choice operator. Basically,
	/// try each of the expressions in order, and match if any of them match, stopping on the
	/// first match.
	/// </summary>
	/// <param name="expressions">Expressions that form the set of alternatives.</param>
	/// <returns>The combined parsing method.</returns>
	public static Func<InputStream, ParseResult> FirstOf(params Func<InputStream, ParseResult>[] expressions)
	{
		return delegate(InputStream input)
		{
			Func<InputStream, ParseResult>[] array = expressions;
			foreach (Func<InputStream, ParseResult> func in array)
			{
				ParseResult parseResult = func(input);
				if (parseResult.Matched)
				{
					return parseResult;
				}
			}
			return matchFailed;
		};
	}

	/// <summary>
	/// Parsing combinator implementing the "not" predicate. This wraps
	/// the given <paramref name="expression" /> parsing method with a check
	/// to see if it matched. If it matched, then the Not fails, and vice
	/// versa. The result consumes no input.
	/// </summary>
	/// <param name="expression">The parse method to wrap.</param>
	/// <returns>The generated parsing function.</returns>
	public static Func<InputStream, ParseResult> Not(Func<InputStream, ParseResult> expression)
	{
		return delegate(InputStream input)
		{
			int currentPosition = input.CurrentPosition;
			ParseResult parseResult = expression(input);
			input.BackupTo(currentPosition);
			return new ParseResult(!parseResult.Matched);
		};
	}

	/// <summary>
	/// Parsing expression that matches End of input.
	/// </summary>
	/// <param name="input">Parser input.</param>
	/// <returns>Parse result</returns>
	public static ParseResult EOF(InputStream input)
	{
		return new ParseResult(input.AtEnd);
	}

	/// <summary>
	/// Combinator that executes an action if the given expression matched.
	/// </summary>
	/// <param name="expression">Parsing expression to match.</param>
	/// <param name="onMatched">Action to execute if <paramref name="expression" />
	/// matched. Input is the matched text from <paramref name="expression" />.</param>
	/// <returns>The result of <paramref name="expression" />.</returns>
	public static Func<InputStream, ParseResult> WithAction(Func<InputStream, ParseResult> expression, Action<ParseResult> onMatched)
	{
		return delegate(InputStream input)
		{
			ParseResult parseResult = expression(input);
			if (parseResult.Matched)
			{
				onMatched(parseResult);
			}
			return parseResult;
		};
	}

	/// <summary>
	/// Combinator that executes an action if the given expression matched.
	/// </summary>
	/// <param name="expression">parsing expression to match.</param>
	/// <param name="onMatched">Method to execute if a match happens. This method returns
	/// the <see cref="T:Microsoft.Practices.Unity.Configuration.ConfigurationHelpers.ParseResult" /> that will be returned from the combined expression.</param>
	/// <returns>The result of <paramref name="onMatched" /> if expression matched, else
	/// whatever <paramref name="expression" /> returned.</returns>
	public static Func<InputStream, ParseResult> WithAction(Func<InputStream, ParseResult> expression, Func<ParseResult, ParseResult> onMatched)
	{
		return delegate(InputStream input)
		{
			ParseResult parseResult = expression(input);
			return parseResult.Matched ? onMatched(parseResult) : parseResult;
		};
	}

	private static ParseResult MatchAndConsumeCurrentChar(InputStream input)
	{
		ParseResult result = new ParseResult(input.CurrentChar.ToString());
		input.Consume(1);
		return result;
	}
}
