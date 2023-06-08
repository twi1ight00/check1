using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using AutoMapper.Impl;

namespace AutoMapper;

public class PropertyMap
{
	/// <summary>
	/// This expression visitor will replace an input parameter by another one
	///
	/// see http://stackoverflow.com/questions/4601844/expression-tree-copy-or-convert
	/// </summary>
	private class ConversionVisitor : ExpressionVisitor
	{
		private readonly Expression newParameter;

		private readonly ParameterExpression oldParameter;

		public ConversionVisitor(Expression newParameter, ParameterExpression oldParameter)
		{
			this.newParameter = newParameter;
			this.oldParameter = oldParameter;
		}

		protected override Expression VisitParameter(ParameterExpression node)
		{
			if ((object)node.Type != oldParameter.Type)
			{
				return node;
			}
			return newParameter;
		}

		protected override Expression VisitMember(MemberExpression node)
		{
			if (node.Expression != oldParameter)
			{
				return base.VisitMember(node);
			}
			Expression expression = Visit(node.Expression);
			MemberInfo member = newParameter.Type.GetMember(node.Member.Name).First();
			return Expression.MakeMemberAccess(expression, member);
		}
	}

	private readonly LinkedList<IValueResolver> _sourceValueResolvers = new LinkedList<IValueResolver>();

	private readonly IList<Type> _valueFormattersToSkip = new List<Type>();

	private readonly IList<IValueFormatter> _valueFormatters = new List<IValueFormatter>();

	private bool _ignored;

	private int _mappingOrder;

	private bool _hasCustomValueResolver;

	private IValueResolver _customResolver;

	private IValueResolver _customMemberResolver;

	private object _nullSubstitute;

	private bool _sealed;

	private IValueResolver[] _cachedResolvers;

	private Func<ResolutionContext, bool> _condition;

	private MemberInfo _sourceMember;

	public IMemberAccessor DestinationProperty { get; private set; }

	public Type DestinationPropertyType => DestinationProperty.MemberType;

	public LambdaExpression CustomExpression { get; private set; }

	public MemberInfo SourceMember
	{
		get
		{
			if ((object)_sourceMember == null)
			{
				return GetSourceValueResolvers().OfType<IMemberGetter>().LastOrDefault()?.MemberInfo;
			}
			return _sourceMember;
		}
		internal set
		{
			_sourceMember = value;
		}
	}

	public bool CanBeSet
	{
		get
		{
			if (DestinationProperty is PropertyAccessor)
			{
				return ((PropertyAccessor)DestinationProperty).HasSetter;
			}
			return true;
		}
	}

	public bool UseDestinationValue { get; set; }

	internal bool HasCustomValueResolver => _hasCustomValueResolver;

	public PropertyMap(IMemberAccessor destinationProperty)
	{
		UseDestinationValue = true;
		DestinationProperty = destinationProperty;
	}

	public PropertyMap(PropertyMap inheritedMappedProperty)
		: this(inheritedMappedProperty.DestinationProperty)
	{
		if (inheritedMappedProperty.IsIgnored())
		{
			Ignore();
		}
		else
		{
			foreach (IValueResolver sourceValueResolver in inheritedMappedProperty.GetSourceValueResolvers())
			{
				ChainResolver(sourceValueResolver);
			}
		}
		ApplyCondition(inheritedMappedProperty._condition);
		SetNullSubstitute(inheritedMappedProperty._nullSubstitute);
		SetMappingOrder(inheritedMappedProperty._mappingOrder);
	}

	public IEnumerable<IValueResolver> GetSourceValueResolvers()
	{
		if (_customMemberResolver != null)
		{
			yield return _customMemberResolver;
		}
		if (_customResolver != null)
		{
			yield return _customResolver;
		}
		foreach (IValueResolver sourceValueResolver in _sourceValueResolvers)
		{
			yield return sourceValueResolver;
		}
		if (_nullSubstitute != null)
		{
			yield return new NullReplacementMethod(_nullSubstitute);
		}
	}

	public void RemoveLastResolver()
	{
		_sourceValueResolvers.RemoveLast();
	}

	public ResolutionResult ResolveValue(ResolutionContext context)
	{
		Seal();
		ResolutionResult seed = new ResolutionResult(context);
		return _cachedResolvers.Aggregate(seed, (ResolutionResult current, IValueResolver resolver) => resolver.Resolve(current));
	}

	internal void Seal()
	{
		if (!_sealed)
		{
			_cachedResolvers = GetSourceValueResolvers().ToArray();
			_sealed = true;
		}
	}

	public void ChainResolver(IValueResolver IValueResolver)
	{
		_sourceValueResolvers.AddLast(IValueResolver);
	}

	public void AddFormatterToSkip<TValueFormatter>() where TValueFormatter : IValueFormatter
	{
		_valueFormattersToSkip.Add(typeof(TValueFormatter));
	}

	public bool FormattersToSkipContains(Type valueFormatterType)
	{
		return _valueFormattersToSkip.Contains(valueFormatterType);
	}

	public void AddFormatter(IValueFormatter valueFormatter)
	{
		_valueFormatters.Add(valueFormatter);
	}

	public IValueFormatter[] GetFormatters()
	{
		return _valueFormatters.ToArray();
	}

	public void AssignCustomValueResolver(IValueResolver valueResolver)
	{
		_ignored = false;
		_customResolver = valueResolver;
		ResetSourceMemberChain();
		_hasCustomValueResolver = true;
	}

	public void ChainTypeMemberForResolver(IValueResolver valueResolver)
	{
		ResetSourceMemberChain();
		_customMemberResolver = valueResolver;
	}

	public void ChainConstructorForResolver(IValueResolver valueResolver)
	{
		_customResolver = valueResolver;
	}

	public void Ignore()
	{
		_ignored = true;
	}

	public bool IsIgnored()
	{
		return _ignored;
	}

	public void SetMappingOrder(int mappingOrder)
	{
		_mappingOrder = mappingOrder;
	}

	public int GetMappingOrder()
	{
		return _mappingOrder;
	}

	public bool IsMapped()
	{
		if (_sourceValueResolvers.Count <= 0 && !_hasCustomValueResolver)
		{
			return _ignored;
		}
		return true;
	}

	public bool CanResolveValue()
	{
		if (_sourceValueResolvers.Count > 0 || _hasCustomValueResolver || UseDestinationValue)
		{
			return !_ignored;
		}
		return false;
	}

	public void RemoveLastFormatter()
	{
		_valueFormatters.RemoveAt(_valueFormatters.Count - 1);
	}

	public void SetNullSubstitute(object nullSubstitute)
	{
		_nullSubstitute = nullSubstitute;
	}

	private void ResetSourceMemberChain()
	{
		_sourceValueResolvers.Clear();
	}

	public bool Equals(PropertyMap other)
	{
		if (object.ReferenceEquals(null, other))
		{
			return false;
		}
		if (object.ReferenceEquals(this, other))
		{
			return true;
		}
		return object.Equals(other.DestinationProperty, DestinationProperty);
	}

	public override bool Equals(object obj)
	{
		if (object.ReferenceEquals(null, obj))
		{
			return false;
		}
		if (object.ReferenceEquals(this, obj))
		{
			return true;
		}
		if ((object)obj.GetType() != typeof(PropertyMap))
		{
			return false;
		}
		return Equals((PropertyMap)obj);
	}

	public override int GetHashCode()
	{
		return DestinationProperty.GetHashCode();
	}

	public void ApplyCondition(Func<ResolutionContext, bool> condition)
	{
		_condition = condition;
	}

	public bool ShouldAssignValue(ResolutionContext context)
	{
		if (_condition != null)
		{
			return _condition(context);
		}
		return true;
	}

	public void SetCustomValueResolverExpression<TSource, TMember>(Expression<Func<TSource, TMember>> sourceMember)
	{
		if (sourceMember.Body is MemberExpression)
		{
			SourceMember = ((MemberExpression)sourceMember.Body).Member;
		}
		CustomExpression = sourceMember;
		AssignCustomValueResolver(new NullReferenceExceptionSwallowingResolver(new DelegateBasedResolver<TSource, TMember>(sourceMember.Compile())));
	}

	public object GetDestinationValue(object mappedObject)
	{
		if (!UseDestinationValue)
		{
			return null;
		}
		return DestinationProperty.GetValue(mappedObject);
	}

	public ExpressionResolutionResult ResolveExpression(Type currentType, Expression instanceParameter)
	{
		Expression expression = instanceParameter;
		Type type = currentType;
		foreach (IValueResolver sourceValueResolver in GetSourceValueResolvers())
		{
			if (sourceValueResolver is IMemberGetter memberGetter)
			{
				MemberInfo memberInfo = memberGetter.MemberInfo;
				if (!(memberInfo is PropertyInfo propertyInfo))
				{
					throw new NotImplementedException("Expressions mapping from methods not supported yet.");
				}
				expression = Expression.Property(expression, propertyInfo);
				type = propertyInfo.PropertyType;
			}
			else
			{
				ParameterExpression oldParameter = CustomExpression.Parameters.Single();
				ConversionVisitor conversionVisitor = new ConversionVisitor(instanceParameter, oldParameter);
				expression = conversionVisitor.Visit(CustomExpression.Body);
				type = expression.Type;
			}
		}
		return new ExpressionResolutionResult(expression, type);
	}
}
