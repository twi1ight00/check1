using System;
using System.Collections.Generic;
using System.Data.Common.CommandTrees;
using System.Data.Metadata.Edm;

namespace Oracle.DataAccess.Client.SqlGen;

internal abstract class BasicExpressionVisitor : DbExpressionVisitor
{
	protected virtual void VisitUnaryExpression(DbUnaryExpression expression)
	{
		VisitExpression(EntityUtils.CheckArgumentNull(expression, "expression").Argument);
	}

	protected virtual void VisitBinaryExpression(DbBinaryExpression expression)
	{
		EntityUtils.CheckArgumentNull(expression, "expression");
		VisitExpression(expression.Left);
		VisitExpression(expression.Right);
	}

	protected virtual void VisitExpressionBindingPre(DbExpressionBinding binding)
	{
		EntityUtils.CheckArgumentNull(binding, "binding");
		VisitExpression(binding.Expression);
	}

	protected virtual void VisitExpressionBindingPost(DbExpressionBinding binding)
	{
	}

	protected virtual void VisitGroupExpressionBindingPre(DbGroupExpressionBinding binding)
	{
		EntityUtils.CheckArgumentNull(binding, "binding");
		VisitExpression(binding.Expression);
	}

	protected virtual void VisitGroupExpressionBindingMid(DbGroupExpressionBinding binding)
	{
	}

	protected virtual void VisitGroupExpressionBindingPost(DbGroupExpressionBinding binding)
	{
	}

	protected virtual void VisitLambdaFunctionPre(EdmFunction function, DbExpression body)
	{
		EntityUtils.CheckArgumentNull(function, "function");
		EntityUtils.CheckArgumentNull(body, "body");
	}

	protected virtual void VisitLambdaFunctionPost(EdmFunction function, DbExpression body)
	{
	}

	public virtual void VisitExpression(DbExpression expression)
	{
		EntityUtils.CheckArgumentNull(expression, "expression").Accept(this);
	}

	public virtual void VisitExpressionList(IList<DbExpression> expressionList)
	{
		EntityUtils.CheckArgumentNull(expressionList, "expressionList");
		for (int i = 0; i < expressionList.Count; i++)
		{
			VisitExpression(expressionList[i]);
		}
	}

	public virtual void VisitAggregateList(IList<DbAggregate> aggregates)
	{
		EntityUtils.CheckArgumentNull(aggregates, "aggregates");
		for (int i = 0; i < aggregates.Count; i++)
		{
			VisitAggregate(aggregates[i]);
		}
	}

	public virtual void VisitAggregate(DbAggregate aggregate)
	{
		VisitExpressionList(EntityUtils.CheckArgumentNull(aggregate, "aggregate").Arguments);
	}

	public override void Visit(DbExpression expression)
	{
		EntityUtils.CheckArgumentNull(expression, "expression");
		throw new NotSupportedException(OpoErrResManager.GetErrorMesg(ErrRes.ODP_NOT_SUPPORTED, "Oracle Data Provider for .NET", expression.GetType().FullName));
	}

	public override void Visit(DbConstantExpression expression)
	{
		EntityUtils.CheckArgumentNull(expression, "expression");
	}

	public override void Visit(DbNullExpression expression)
	{
		EntityUtils.CheckArgumentNull(expression, "expression");
	}

	public override void Visit(DbVariableReferenceExpression expression)
	{
		EntityUtils.CheckArgumentNull(expression, "expression");
	}

	public override void Visit(DbParameterReferenceExpression expression)
	{
		EntityUtils.CheckArgumentNull(expression, "expression");
	}

	public override void Visit(DbFunctionExpression expression)
	{
		EntityUtils.CheckArgumentNull(expression, "expression");
		VisitExpressionList(expression.Arguments);
	}

	public override void Visit(DbPropertyExpression expression)
	{
		EntityUtils.CheckArgumentNull(expression, "expression");
		if (expression.Instance != null)
		{
			VisitExpression(expression.Instance);
		}
	}

	public override void Visit(DbComparisonExpression expression)
	{
		VisitBinaryExpression(expression);
	}

	public override void Visit(DbLikeExpression expression)
	{
		EntityUtils.CheckArgumentNull(expression, "expression");
		VisitExpression(expression.Argument);
		VisitExpression(expression.Pattern);
		VisitExpression(expression.Escape);
	}

	public override void Visit(DbLimitExpression expression)
	{
		EntityUtils.CheckArgumentNull(expression, "expression");
		VisitExpression(expression.Argument);
		VisitExpression(expression.Limit);
	}

	public override void Visit(DbIsNullExpression expression)
	{
		VisitUnaryExpression(expression);
	}

	public override void Visit(DbArithmeticExpression expression)
	{
		VisitExpressionList(EntityUtils.CheckArgumentNull(expression, "expression").Arguments);
	}

	public override void Visit(DbAndExpression expression)
	{
		VisitBinaryExpression(expression);
	}

	public override void Visit(DbOrExpression expression)
	{
		VisitBinaryExpression(expression);
	}

	public override void Visit(DbNotExpression expression)
	{
		VisitUnaryExpression(expression);
	}

	public override void Visit(DbDistinctExpression expression)
	{
		VisitUnaryExpression(expression);
	}

	public override void Visit(DbElementExpression expression)
	{
		VisitUnaryExpression(expression);
	}

	public override void Visit(DbIsEmptyExpression expression)
	{
		VisitUnaryExpression(expression);
	}

	public override void Visit(DbUnionAllExpression expression)
	{
		VisitBinaryExpression(expression);
	}

	public override void Visit(DbIntersectExpression expression)
	{
		VisitBinaryExpression(expression);
	}

	public override void Visit(DbExceptExpression expression)
	{
		VisitBinaryExpression(expression);
	}

	public override void Visit(DbOfTypeExpression expression)
	{
		VisitUnaryExpression(expression);
	}

	public override void Visit(DbTreatExpression expression)
	{
		VisitUnaryExpression(expression);
	}

	public override void Visit(DbCastExpression expression)
	{
		VisitUnaryExpression(expression);
	}

	public override void Visit(DbIsOfExpression expression)
	{
		VisitUnaryExpression(expression);
	}

	public override void Visit(DbCaseExpression expression)
	{
		EntityUtils.CheckArgumentNull(expression, "expression");
		VisitExpressionList(expression.When);
		VisitExpressionList(expression.Then);
		VisitExpression(expression.Else);
	}

	public override void Visit(DbRefExpression expression)
	{
		VisitUnaryExpression(expression);
	}

	public override void Visit(DbRelationshipNavigationExpression expression)
	{
		VisitExpression(EntityUtils.CheckArgumentNull(expression, "expression").NavigationSource);
	}

	public override void Visit(DbDerefExpression expression)
	{
		VisitUnaryExpression(expression);
	}

	public override void Visit(DbRefKeyExpression expression)
	{
		VisitUnaryExpression(expression);
	}

	public override void Visit(DbEntityRefExpression expression)
	{
		VisitUnaryExpression(expression);
	}

	public override void Visit(DbScanExpression expression)
	{
		EntityUtils.CheckArgumentNull(expression, "expression");
	}

	public override void Visit(DbFilterExpression expression)
	{
		EntityUtils.CheckArgumentNull(expression, "expression");
		VisitExpressionBindingPre(expression.Input);
		VisitExpression(expression.Predicate);
		VisitExpressionBindingPost(expression.Input);
	}

	public override void Visit(DbProjectExpression expression)
	{
		EntityUtils.CheckArgumentNull(expression, "expression");
		VisitExpressionBindingPre(expression.Input);
		VisitExpression(expression.Projection);
		VisitExpressionBindingPost(expression.Input);
	}

	public override void Visit(DbCrossJoinExpression expression)
	{
		EntityUtils.CheckArgumentNull(expression, "expression");
		foreach (DbExpressionBinding input in expression.Inputs)
		{
			VisitExpressionBindingPre(input);
		}
		foreach (DbExpressionBinding input2 in expression.Inputs)
		{
			VisitExpressionBindingPost(input2);
		}
	}

	public override void Visit(DbJoinExpression expression)
	{
		EntityUtils.CheckArgumentNull(expression, "expression");
		VisitExpressionBindingPre(expression.Left);
		VisitExpressionBindingPre(expression.Right);
		VisitExpression(expression.JoinCondition);
		VisitExpressionBindingPost(expression.Left);
		VisitExpressionBindingPost(expression.Right);
	}

	public override void Visit(DbApplyExpression expression)
	{
		EntityUtils.CheckArgumentNull(expression, "expression");
		VisitExpressionBindingPre(expression.Input);
		if (expression.Apply != null)
		{
			VisitExpression(expression.Apply.Expression);
		}
		VisitExpressionBindingPost(expression.Input);
	}

	public override void Visit(DbGroupByExpression expression)
	{
		EntityUtils.CheckArgumentNull(expression, "expression");
		VisitGroupExpressionBindingPre(expression.Input);
		VisitExpressionList(expression.Keys);
		VisitGroupExpressionBindingMid(expression.Input);
		VisitAggregateList(expression.Aggregates);
		VisitGroupExpressionBindingPost(expression.Input);
	}

	public override void Visit(DbSkipExpression expression)
	{
		EntityUtils.CheckArgumentNull(expression, "expression");
		VisitExpressionBindingPre(expression.Input);
		foreach (DbSortClause item in expression.SortOrder)
		{
			VisitExpression(item.Expression);
		}
		VisitExpressionBindingPost(expression.Input);
		VisitExpression(expression.Count);
	}

	public override void Visit(DbSortExpression expression)
	{
		EntityUtils.CheckArgumentNull(expression, "expression");
		VisitExpressionBindingPre(expression.Input);
		for (int i = 0; i < expression.SortOrder.Count; i++)
		{
			VisitExpression(expression.SortOrder[i].Expression);
		}
		VisitExpressionBindingPost(expression.Input);
	}

	public override void Visit(DbQuantifierExpression expression)
	{
		EntityUtils.CheckArgumentNull(expression, "expression");
		VisitExpressionBindingPre(expression.Input);
		VisitExpression(expression.Predicate);
		VisitExpressionBindingPost(expression.Input);
	}
}
