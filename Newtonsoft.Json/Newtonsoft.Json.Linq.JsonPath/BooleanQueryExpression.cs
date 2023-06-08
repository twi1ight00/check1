using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Newtonsoft.Json.Utilities;

namespace Newtonsoft.Json.Linq.JsonPath;

internal class BooleanQueryExpression : QueryExpression
{
	public List<PathFilter> Path { get; set; }

	public JValue Value { get; set; }

	public override bool IsMatch(JToken t)
	{
		foreach (JToken item in JPath.Evaluate(Path, t, errorWhenNoMatch: false))
		{
			if (item is JValue jValue)
			{
				switch (base.Operator)
				{
				case QueryOperator.Equals:
					if (EqualsWithStringCoercion(jValue, Value))
					{
						return true;
					}
					break;
				case QueryOperator.NotEquals:
					if (!EqualsWithStringCoercion(jValue, Value))
					{
						return true;
					}
					break;
				case QueryOperator.GreaterThan:
					if (jValue.CompareTo(Value) > 0)
					{
						return true;
					}
					break;
				case QueryOperator.GreaterThanOrEquals:
					if (jValue.CompareTo(Value) >= 0)
					{
						return true;
					}
					break;
				case QueryOperator.LessThan:
					if (jValue.CompareTo(Value) < 0)
					{
						return true;
					}
					break;
				case QueryOperator.LessThanOrEquals:
					if (jValue.CompareTo(Value) <= 0)
					{
						return true;
					}
					break;
				case QueryOperator.Exists:
					return true;
				}
			}
			else
			{
				QueryOperator @operator = base.Operator;
				if (@operator == QueryOperator.NotEquals || @operator == QueryOperator.Exists)
				{
					return true;
				}
			}
		}
		return false;
	}

	private bool EqualsWithStringCoercion(JValue value, JValue queryValue)
	{
		if (value.Equals(queryValue))
		{
			return true;
		}
		if (queryValue.Type != JTokenType.String)
		{
			return false;
		}
		string b = (string)queryValue.Value;
		string a;
		switch (value.Type)
		{
		case JTokenType.Date:
		{
			using (StringWriter stringWriter = StringUtils.CreateStringWriter(64))
			{
				if (value.Value is DateTimeOffset)
				{
					DateTimeUtils.WriteDateTimeOffsetString(stringWriter, (DateTimeOffset)value.Value, DateFormatHandling.IsoDateFormat, null, CultureInfo.InvariantCulture);
				}
				else
				{
					DateTimeUtils.WriteDateTimeString(stringWriter, (DateTime)value.Value, DateFormatHandling.IsoDateFormat, null, CultureInfo.InvariantCulture);
				}
				a = stringWriter.ToString();
			}
			break;
		}
		case JTokenType.Bytes:
			a = Convert.ToBase64String((byte[])value.Value);
			break;
		case JTokenType.Guid:
		case JTokenType.TimeSpan:
			a = value.Value.ToString();
			break;
		case JTokenType.Uri:
			a = ((Uri)value.Value).OriginalString;
			break;
		default:
			return false;
		}
		return string.Equals(a, b, StringComparison.Ordinal);
	}
}
