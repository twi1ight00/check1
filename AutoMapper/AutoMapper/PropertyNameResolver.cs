using System;
using System.Reflection;

namespace AutoMapper;

public class PropertyNameResolver : IValueResolver
{
	private readonly Type _sourceType;

	private readonly PropertyInfo _propertyInfo;

	public PropertyNameResolver(Type sourceType, string propertyName)
	{
		_sourceType = sourceType;
		_propertyInfo = sourceType.GetProperty(propertyName);
	}

	public ResolutionResult Resolve(ResolutionResult source)
	{
		if (source.Value == null)
		{
			return source;
		}
		Type type = source.Value.GetType();
		if (!_sourceType.IsAssignableFrom(type))
		{
			throw new ArgumentException(string.Concat("Expected obj to be of type ", _sourceType, " but was ", type));
		}
		object value = _propertyInfo.GetValue(source.Value, null);
		return source.New(value);
	}
}
