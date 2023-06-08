using System.Collections.Generic;
using System.Data.Common.CommandTrees;

namespace Oracle.DataAccess.Client;

internal class CommandTreeUtils
{
	private static readonly HashSet<DbExpressionKind> _associativeExpressionKinds = new HashSet<DbExpressionKind>(new DbExpressionKind[4]
	{
		DbExpressionKind.Or,
		DbExpressionKind.And,
		DbExpressionKind.Plus,
		DbExpressionKind.Multiply
	});

	internal static IEnumerable<DbExpression> FlattenAssociativeExpression(DbExpression expression)
	{
		return FlattenAssociativeExpression(expression.ExpressionKind, expression);
	}

	internal static IEnumerable<DbExpression> FlattenAssociativeExpression(DbExpressionKind expressionKind, params DbExpression[] arguments)
	{
		if (!_associativeExpressionKinds.Contains(expressionKind))
		{
			return arguments;
		}
		List<DbExpression> list = new List<DbExpression>();
		foreach (DbExpression expression in arguments)
		{
			ExtractAssociativeArguments(expressionKind, list, expression);
		}
		return list;
	}

	private static void ExtractAssociativeArguments(DbExpressionKind expressionKind, List<DbExpression> argumentList, DbExpression expression)
	{
		if (expression.ExpressionKind != expressionKind)
		{
			argumentList.Add(expression);
		}
		else if (expression is DbBinaryExpression dbBinaryExpression)
		{
			ExtractAssociativeArguments(expressionKind, argumentList, dbBinaryExpression.Left);
			ExtractAssociativeArguments(expressionKind, argumentList, dbBinaryExpression.Right);
		}
		else
		{
			DbArithmeticExpression dbArithmeticExpression = (DbArithmeticExpression)expression;
			ExtractAssociativeArguments(expressionKind, argumentList, dbArithmeticExpression.Arguments[0]);
			ExtractAssociativeArguments(expressionKind, argumentList, dbArithmeticExpression.Arguments[1]);
		}
	}
}
