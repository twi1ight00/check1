using System.Linq.Expressions;
using System.Reflection;

namespace AutoMapper;

public class DelegateFactoryOverride : DelegateFactory
{
	public override LateBoundFieldSet CreateSet(FieldInfo field)
	{
		ParameterExpression parameterExpression = Expression.Parameter(typeof(object), "target");
		ParameterExpression parameterExpression2 = Expression.Parameter(typeof(object), "value");
		MemberExpression left = Expression.Field(Expression.Convert(parameterExpression, field.DeclaringType), field);
		BinaryExpression body = Expression.Assign(left, Expression.Convert(parameterExpression2, field.FieldType));
		Expression<LateBoundFieldSet> expression = Expression.Lambda<LateBoundFieldSet>(body, new ParameterExpression[2] { parameterExpression, parameterExpression2 });
		return expression.Compile();
	}

	public override LateBoundPropertySet CreateSet(PropertyInfo property)
	{
		ParameterExpression parameterExpression = Expression.Parameter(typeof(object), "target");
		ParameterExpression parameterExpression2 = Expression.Parameter(typeof(object), "value");
		MemberExpression left = Expression.Property(Expression.Convert(parameterExpression, property.DeclaringType), property);
		BinaryExpression body = Expression.Assign(left, Expression.Convert(parameterExpression2, property.PropertyType));
		Expression<LateBoundPropertySet> expression = Expression.Lambda<LateBoundPropertySet>(body, new ParameterExpression[2] { parameterExpression, parameterExpression2 });
		return expression.Compile();
	}
}
