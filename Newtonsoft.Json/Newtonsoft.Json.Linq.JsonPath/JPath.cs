using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Newtonsoft.Json.Utilities;

namespace Newtonsoft.Json.Linq.JsonPath;

internal class JPath
{
	private readonly string _expression;

	private int _currentIndex;

	public List<PathFilter> Filters { get; private set; }

	public JPath(string expression)
	{
		ValidationUtils.ArgumentNotNull(expression, "expression");
		_expression = expression;
		Filters = new List<PathFilter>();
		ParseMain();
	}

	private void ParseMain()
	{
		int currentIndex = _currentIndex;
		EatWhitespace();
		if (_expression.Length == _currentIndex)
		{
			return;
		}
		if (_expression[_currentIndex] == '$')
		{
			if (_expression.Length == 1)
			{
				return;
			}
			char c = _expression[_currentIndex + 1];
			if (c == '.' || c == '[')
			{
				_currentIndex++;
				currentIndex = _currentIndex;
			}
		}
		if (!ParsePath(Filters, currentIndex, query: false))
		{
			int currentIndex2 = _currentIndex;
			EatWhitespace();
			if (_currentIndex < _expression.Length)
			{
				throw new JsonException("Unexpected character while parsing path: " + _expression[currentIndex2]);
			}
		}
	}

	private bool ParsePath(List<PathFilter> filters, int currentPartStartIndex, bool query)
	{
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		bool flag4 = false;
		while (_currentIndex < _expression.Length && !flag4)
		{
			char c = _expression[_currentIndex];
			switch (c)
			{
			case '(':
			case '[':
				if (_currentIndex > currentPartStartIndex)
				{
					string text2 = _expression.Substring(currentPartStartIndex, _currentIndex - currentPartStartIndex);
					if (text2 == "*")
					{
						text2 = null;
					}
					PathFilter item2 = (flag ? ((PathFilter)new ScanFilter
					{
						Name = text2
					}) : ((PathFilter)new FieldFilter
					{
						Name = text2
					}));
					filters.Add(item2);
					flag = false;
				}
				filters.Add(ParseIndexer(c));
				_currentIndex++;
				currentPartStartIndex = _currentIndex;
				flag2 = true;
				flag3 = false;
				break;
			case ')':
			case ']':
				flag4 = true;
				break;
			case ' ':
				if (_currentIndex < _expression.Length)
				{
					flag4 = true;
				}
				break;
			case '.':
				if (_currentIndex > currentPartStartIndex)
				{
					string text = _expression.Substring(currentPartStartIndex, _currentIndex - currentPartStartIndex);
					if (text == "*")
					{
						text = null;
					}
					PathFilter item = (flag ? ((PathFilter)new ScanFilter
					{
						Name = text
					}) : ((PathFilter)new FieldFilter
					{
						Name = text
					}));
					filters.Add(item);
					flag = false;
				}
				if (_currentIndex + 1 < _expression.Length && _expression[_currentIndex + 1] == '.')
				{
					flag = true;
					_currentIndex++;
				}
				_currentIndex++;
				currentPartStartIndex = _currentIndex;
				flag2 = false;
				flag3 = true;
				break;
			default:
				if (query && (c == '=' || c == '<' || c == '!' || c == '>' || c == '|' || c == '&'))
				{
					flag4 = true;
					break;
				}
				if (flag2)
				{
					throw new JsonException("Unexpected character following indexer: " + c);
				}
				_currentIndex++;
				break;
			}
		}
		bool flag5 = _currentIndex == _expression.Length;
		if (_currentIndex > currentPartStartIndex)
		{
			string text3 = _expression.Substring(currentPartStartIndex, _currentIndex - currentPartStartIndex).TrimEnd();
			if (text3 == "*")
			{
				text3 = null;
			}
			PathFilter item3 = (flag ? ((PathFilter)new ScanFilter
			{
				Name = text3
			}) : ((PathFilter)new FieldFilter
			{
				Name = text3
			}));
			filters.Add(item3);
		}
		else if (flag3 && (flag5 || query))
		{
			throw new JsonException("Unexpected end while parsing path.");
		}
		return flag5;
	}

	private PathFilter ParseIndexer(char indexerOpenChar)
	{
		_currentIndex++;
		char indexerCloseChar = ((indexerOpenChar == '[') ? ']' : ')');
		EnsureLength("Path ended with open indexer.");
		EatWhitespace();
		if (_expression[_currentIndex] == '\'')
		{
			return ParseQuotedField(indexerCloseChar);
		}
		if (_expression[_currentIndex] == '?')
		{
			return ParseQuery(indexerCloseChar);
		}
		return ParseArrayIndexer(indexerCloseChar);
	}

	private PathFilter ParseArrayIndexer(char indexerCloseChar)
	{
		int currentIndex = _currentIndex;
		int? num = null;
		List<int> list = null;
		int num2 = 0;
		int? start = null;
		int? end = null;
		int? step = null;
		while (_currentIndex < _expression.Length)
		{
			char c = _expression[_currentIndex];
			if (c == ' ')
			{
				num = _currentIndex;
				EatWhitespace();
				continue;
			}
			if (c == indexerCloseChar)
			{
				int num3 = (num ?? _currentIndex) - currentIndex;
				if (list != null)
				{
					if (num3 == 0)
					{
						throw new JsonException("Array index expected.");
					}
					int item = Convert.ToInt32(_expression.Substring(currentIndex, num3), CultureInfo.InvariantCulture);
					list.Add(item);
					return new ArrayMultipleIndexFilter
					{
						Indexes = list
					};
				}
				if (num2 > 0)
				{
					if (num3 > 0)
					{
						int value = Convert.ToInt32(_expression.Substring(currentIndex, num3), CultureInfo.InvariantCulture);
						if (num2 == 1)
						{
							end = value;
						}
						else
						{
							step = value;
						}
					}
					return new ArraySliceFilter
					{
						Start = start,
						End = end,
						Step = step
					};
				}
				if (num3 == 0)
				{
					throw new JsonException("Array index expected.");
				}
				int value2 = Convert.ToInt32(_expression.Substring(currentIndex, num3), CultureInfo.InvariantCulture);
				return new ArrayIndexFilter
				{
					Index = value2
				};
			}
			switch (c)
			{
			case ',':
			{
				int num5 = (num ?? _currentIndex) - currentIndex;
				if (num5 == 0)
				{
					throw new JsonException("Array index expected.");
				}
				if (list == null)
				{
					list = new List<int>();
				}
				string value4 = _expression.Substring(currentIndex, num5);
				list.Add(Convert.ToInt32(value4, CultureInfo.InvariantCulture));
				_currentIndex++;
				EatWhitespace();
				currentIndex = _currentIndex;
				num = null;
				break;
			}
			case '*':
				_currentIndex++;
				EnsureLength("Path ended with open indexer.");
				EatWhitespace();
				if (_expression[_currentIndex] != indexerCloseChar)
				{
					throw new JsonException("Unexpected character while parsing path indexer: " + c);
				}
				return new ArrayIndexFilter();
			case ':':
			{
				int num4 = (num ?? _currentIndex) - currentIndex;
				if (num4 > 0)
				{
					int value3 = Convert.ToInt32(_expression.Substring(currentIndex, num4), CultureInfo.InvariantCulture);
					switch (num2)
					{
					case 0:
						start = value3;
						break;
					case 1:
						end = value3;
						break;
					default:
						step = value3;
						break;
					}
				}
				num2++;
				_currentIndex++;
				EatWhitespace();
				currentIndex = _currentIndex;
				num = null;
				break;
			}
			default:
				if (!char.IsDigit(c) && c != '-')
				{
					throw new JsonException("Unexpected character while parsing path indexer: " + c);
				}
				if (num.HasValue)
				{
					throw new JsonException("Unexpected character while parsing path indexer: " + c);
				}
				_currentIndex++;
				break;
			}
		}
		throw new JsonException("Path ended with open indexer.");
	}

	private void EatWhitespace()
	{
		while (_currentIndex < _expression.Length && _expression[_currentIndex] == ' ')
		{
			_currentIndex++;
		}
	}

	private PathFilter ParseQuery(char indexerCloseChar)
	{
		_currentIndex++;
		EnsureLength("Path ended with open indexer.");
		if (_expression[_currentIndex] != '(')
		{
			throw new JsonException("Unexpected character while parsing path indexer: " + _expression[_currentIndex]);
		}
		_currentIndex++;
		QueryExpression expression = ParseExpression();
		_currentIndex++;
		EnsureLength("Path ended with open indexer.");
		EatWhitespace();
		if (_expression[_currentIndex] != indexerCloseChar)
		{
			throw new JsonException("Unexpected character while parsing path indexer: " + _expression[_currentIndex]);
		}
		return new QueryFilter
		{
			Expression = expression
		};
	}

	private QueryExpression ParseExpression()
	{
		QueryExpression queryExpression = null;
		CompositeExpression compositeExpression = null;
		while (_currentIndex < _expression.Length)
		{
			EatWhitespace();
			if (_expression[_currentIndex] != '@')
			{
				throw new JsonException("Unexpected character while parsing path query: " + _expression[_currentIndex]);
			}
			_currentIndex++;
			List<PathFilter> list = new List<PathFilter>();
			if (ParsePath(list, _currentIndex, query: true))
			{
				throw new JsonException("Path ended with open query.");
			}
			EatWhitespace();
			EnsureLength("Path ended with open query.");
			object value = null;
			QueryOperator queryOperator;
			if (_expression[_currentIndex] == ')' || _expression[_currentIndex] == '|' || _expression[_currentIndex] == '&')
			{
				queryOperator = QueryOperator.Exists;
			}
			else
			{
				queryOperator = ParseOperator();
				EatWhitespace();
				EnsureLength("Path ended with open query.");
				value = ParseValue();
				EatWhitespace();
				EnsureLength("Path ended with open query.");
			}
			BooleanQueryExpression booleanQueryExpression = new BooleanQueryExpression
			{
				Path = list,
				Operator = queryOperator,
				Value = ((queryOperator != QueryOperator.Exists) ? new JValue(value) : null)
			};
			if (_expression[_currentIndex] == ')')
			{
				if (compositeExpression != null)
				{
					compositeExpression.Expressions.Add(booleanQueryExpression);
					return queryExpression;
				}
				return booleanQueryExpression;
			}
			if (_expression[_currentIndex] == '&' && Match("&&"))
			{
				if (compositeExpression == null || compositeExpression.Operator != QueryOperator.And)
				{
					CompositeExpression compositeExpression2 = new CompositeExpression
					{
						Operator = QueryOperator.And
					};
					compositeExpression?.Expressions.Add(compositeExpression2);
					compositeExpression = compositeExpression2;
					if (queryExpression == null)
					{
						queryExpression = compositeExpression;
					}
				}
				compositeExpression.Expressions.Add(booleanQueryExpression);
			}
			if (_expression[_currentIndex] != '|' || !Match("||"))
			{
				continue;
			}
			if (compositeExpression == null || compositeExpression.Operator != QueryOperator.Or)
			{
				CompositeExpression compositeExpression3 = new CompositeExpression
				{
					Operator = QueryOperator.Or
				};
				compositeExpression?.Expressions.Add(compositeExpression3);
				compositeExpression = compositeExpression3;
				if (queryExpression == null)
				{
					queryExpression = compositeExpression;
				}
			}
			compositeExpression.Expressions.Add(booleanQueryExpression);
		}
		throw new JsonException("Path ended with open query.");
	}

	private object ParseValue()
	{
		char c = _expression[_currentIndex];
		if (c == '\'')
		{
			return ReadQuotedString();
		}
		if (char.IsDigit(c) || c == '-')
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(c);
			_currentIndex++;
			while (_currentIndex < _expression.Length)
			{
				c = _expression[_currentIndex];
				if (c == ' ' || c == ')')
				{
					string text = stringBuilder.ToString();
					if (text.IndexOfAny(new char[3] { '.', 'E', 'e' }) != -1)
					{
						if (double.TryParse(text, NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out var result))
						{
							return result;
						}
						throw new JsonException("Could not read query value.");
					}
					if (long.TryParse(text, NumberStyles.Integer, CultureInfo.InvariantCulture, out var result2))
					{
						return result2;
					}
					throw new JsonException("Could not read query value.");
				}
				stringBuilder.Append(c);
				_currentIndex++;
			}
		}
		else
		{
			switch (c)
			{
			case 't':
				if (Match("true"))
				{
					return true;
				}
				break;
			case 'f':
				if (Match("false"))
				{
					return false;
				}
				break;
			case 'n':
				if (Match("null"))
				{
					return null;
				}
				break;
			}
		}
		throw new JsonException("Could not read query value.");
	}

	private string ReadQuotedString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		_currentIndex++;
		while (_currentIndex < _expression.Length)
		{
			char c = _expression[_currentIndex];
			if (c == '\\' && _currentIndex + 1 < _expression.Length)
			{
				_currentIndex++;
				if (_expression[_currentIndex] == '\'')
				{
					stringBuilder.Append('\'');
				}
				else
				{
					if (_expression[_currentIndex] != '\\')
					{
						throw new JsonException("Unknown escape chracter: \\" + _expression[_currentIndex]);
					}
					stringBuilder.Append('\\');
				}
				_currentIndex++;
			}
			else
			{
				if (c == '\'')
				{
					_currentIndex++;
					return stringBuilder.ToString();
				}
				_currentIndex++;
				stringBuilder.Append(c);
			}
		}
		throw new JsonException("Path ended with an open string.");
	}

	private bool Match(string s)
	{
		int num = _currentIndex;
		foreach (char c in s)
		{
			if (num < _expression.Length && _expression[num] == c)
			{
				num++;
				continue;
			}
			return false;
		}
		_currentIndex = num;
		return true;
	}

	private QueryOperator ParseOperator()
	{
		if (_currentIndex + 1 >= _expression.Length)
		{
			throw new JsonException("Path ended with open query.");
		}
		if (Match("=="))
		{
			return QueryOperator.Equals;
		}
		if (Match("!=") || Match("<>"))
		{
			return QueryOperator.NotEquals;
		}
		if (Match("<="))
		{
			return QueryOperator.LessThanOrEquals;
		}
		if (Match("<"))
		{
			return QueryOperator.LessThan;
		}
		if (Match(">="))
		{
			return QueryOperator.GreaterThanOrEquals;
		}
		if (Match(">"))
		{
			return QueryOperator.GreaterThan;
		}
		throw new JsonException("Could not read query operator.");
	}

	private PathFilter ParseQuotedField(char indexerCloseChar)
	{
		List<string> list = null;
		while (_currentIndex < _expression.Length)
		{
			string text = ReadQuotedString();
			EatWhitespace();
			EnsureLength("Path ended with open indexer.");
			if (_expression[_currentIndex] == indexerCloseChar)
			{
				if (list != null)
				{
					list.Add(text);
					return new FieldMultipleFilter
					{
						Names = list
					};
				}
				return new FieldFilter
				{
					Name = text
				};
			}
			if (_expression[_currentIndex] == ',')
			{
				_currentIndex++;
				EatWhitespace();
				if (list == null)
				{
					list = new List<string>();
				}
				list.Add(text);
				continue;
			}
			throw new JsonException("Unexpected character while parsing path indexer: " + _expression[_currentIndex]);
		}
		throw new JsonException("Path ended with open indexer.");
	}

	private void EnsureLength(string message)
	{
		if (_currentIndex >= _expression.Length)
		{
			throw new JsonException(message);
		}
	}

	internal IEnumerable<JToken> Evaluate(JToken t, bool errorWhenNoMatch)
	{
		return Evaluate(Filters, t, errorWhenNoMatch);
	}

	internal static IEnumerable<JToken> Evaluate(List<PathFilter> filters, JToken t, bool errorWhenNoMatch)
	{
		IEnumerable<JToken> enumerable = new JToken[1] { t };
		foreach (PathFilter filter in filters)
		{
			enumerable = filter.ExecuteFilter(enumerable, errorWhenNoMatch);
		}
		return enumerable;
	}
}
