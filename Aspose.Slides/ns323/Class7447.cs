using System.Collections;
using System.Collections.Generic;
using ns322;

namespace ns323;

internal class Class7447 : Interface395
{
	private List<string> list_0 = new List<string>();

	public Class7447(List<string> definedFunctions)
	{
		list_0 = definedFunctions;
	}

	public void imethod_0(Class7380 expression)
	{
	}

	public void imethod_1(Class7363 expression)
	{
		expression.Left.vmethod_0(this);
		expression.Right.vmethod_0(this);
	}

	public void imethod_2(Class7379 expression)
	{
		foreach (Class7675 item in (IEnumerable)expression.Statements)
		{
			Class7360 class2 = (Class7360)item.Data;
			class2.vmethod_0(this);
		}
	}

	public void imethod_3(Class7381 expression)
	{
	}

	public void imethod_4(Class7382 expression)
	{
	}

	public void imethod_5(Class7383 expression)
	{
		expression.Statement.vmethod_0(this);
	}

	public void imethod_6(Class7384 expression)
	{
	}

	public void imethod_7(Class7385 expression)
	{
		expression.Expression.vmethod_0(this);
	}

	public void imethod_8(Class7386 expression)
	{
		expression.InitialisationStatement.vmethod_0(this);
		expression.Expression.vmethod_0(this);
		expression.Statement.vmethod_0(this);
	}

	public void imethod_9(Class7387 expression)
	{
		expression.InitialisationStatement.vmethod_0(this);
		expression.ConditionExpression.vmethod_0(this);
		expression.IncrementExpression.vmethod_0(this);
		expression.Statement.vmethod_0(this);
	}

	public void imethod_10(Class7388 expression)
	{
		expression.Statement.vmethod_0(this);
	}

	public void imethod_11(Class7389 expression)
	{
		expression.Expression.vmethod_0(this);
		expression.Then.vmethod_0(this);
		if (expression.Else != null)
		{
			expression.Else.vmethod_0(this);
		}
	}

	public void imethod_12(Class7390 expression)
	{
		expression.Expression.vmethod_0(this);
	}

	public void imethod_13(Class7391 expression)
	{
		expression.Expression.vmethod_0(this);
		if (expression.DefaultStatement != null)
		{
			expression.DefaultStatement.vmethod_0(this);
		}
		if (expression.CaseClauses == null)
		{
			return;
		}
		foreach (Class7444 caseClause in expression.CaseClauses)
		{
			caseClause.Statement.vmethod_0(this);
			caseClause.Expression.vmethod_0(this);
		}
	}

	public void imethod_14(Class7396 expression)
	{
		expression.Expression.vmethod_0(this);
		expression.Statement.vmethod_0(this);
	}

	public void imethod_15(Class7392 expression)
	{
		expression.Expression.vmethod_0(this);
	}

	public void imethod_16(Class7393 expression)
	{
		expression.Statement.vmethod_0(this);
		if (expression.Catch != null)
		{
			expression.Catch.Statement.vmethod_0(this);
		}
		if (expression.Finally != null)
		{
			expression.Finally.Statement.vmethod_0(this);
		}
	}

	public void imethod_17(Class7394 expression)
	{
		if (expression.Expression != null)
		{
			expression.Expression.vmethod_0(this);
		}
	}

	public void imethod_18(Class7395 expression)
	{
		expression.Condition.vmethod_0(this);
		if (expression.Statement != null)
		{
			expression.Statement.vmethod_0(this);
		}
	}

	public void imethod_19(Class7362 expression)
	{
		for (int i = 0; i < expression.Parameters.Count; i++)
		{
			((Class7360)expression.Parameters[i]).vmethod_0(this);
		}
	}

	public void imethod_20(Class7365 expression)
	{
		foreach (Class7360 statement in expression.Statements)
		{
			statement.vmethod_0(this);
		}
	}

	public void imethod_21(Class7366 expression)
	{
		expression.Statement.vmethod_0(this);
	}

	public void imethod_22(Class7371 expression)
	{
		if (expression.Previous != null)
		{
			expression.Previous.vmethod_0(this);
		}
		if (expression.Member is Class7372 && expression.Previous is Class7367)
		{
			Class7367 @class = (Class7367)expression.Previous;
			if (list_0.Contains(@class.Text))
			{
				expression.Previous = new Class7371(new Class7368(@class.Text), new Class7367("this"));
			}
		}
		expression.Member.vmethod_0(this);
	}

	public void imethod_23(Class7372 expression)
	{
		for (int i = 0; i < expression.Arguments.Count; i++)
		{
			((Class7361)expression.Arguments[i]).vmethod_0(this);
		}
	}

	public void imethod_24(Class7369 expression)
	{
		expression.Index.vmethod_0(this);
	}

	public void imethod_25(Class7368 expression)
	{
	}

	public void imethod_26(Class7374 expression)
	{
		expression.Expression.vmethod_0(this);
		if (expression.GetExpression != null)
		{
			expression.GetExpression.vmethod_0(this);
		}
		if (expression.SetExpression != null)
		{
			expression.SetExpression.vmethod_0(this);
		}
	}

	public void imethod_27(Class7367 expression)
	{
	}

	public void imethod_28(Class7370 expression)
	{
		foreach (DictionaryEntry value in expression.Values)
		{
			((Class7361)value.Value).vmethod_0(this);
		}
	}

	public void imethod_29(Class7373 expression)
	{
		expression.Expression.vmethod_0(this);
		for (int i = 0; i < expression.Arguments.Count; i++)
		{
			((Class7361)expression.Arguments[i]).vmethod_0(this);
		}
	}

	public void imethod_30(Class7364 expression)
	{
		expression.LeftExpression.vmethod_0(this);
		expression.RightExpression.vmethod_0(this);
	}

	public void imethod_31(Class7376 expression)
	{
		expression.LeftExpression.vmethod_0(this);
		expression.MiddleExpression.vmethod_0(this);
		expression.RightExpression.vmethod_0(this);
	}

	public void imethod_32(Class7377 expression)
	{
		expression.Expression.vmethod_0(this);
	}

	public void imethod_33(Class7378 expression)
	{
	}

	public void imethod_34(Class7375 expression)
	{
	}

	public void imethod_35(Class7360 expression)
	{
	}
}
