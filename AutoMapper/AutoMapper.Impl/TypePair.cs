using System;

namespace AutoMapper.Impl;

public struct TypePair : IEquatable<TypePair>
{
	private readonly Type _destinationType;

	private readonly int _hashcode;

	private readonly Type _sourceType;

	public Type SourceType => _sourceType;

	public Type DestinationType => _destinationType;

	public TypePair(Type sourceType, Type destinationType)
	{
		this = default(TypePair);
		_sourceType = sourceType;
		_destinationType = destinationType;
		_hashcode = (_sourceType.GetHashCode() * 397) ^ _destinationType.GetHashCode();
	}

	public bool Equals(TypePair other)
	{
		if (object.Equals(other._sourceType, _sourceType))
		{
			return object.Equals(other._destinationType, _destinationType);
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (object.ReferenceEquals(null, obj))
		{
			return false;
		}
		if ((object)obj.GetType() != typeof(TypePair))
		{
			return false;
		}
		return Equals((TypePair)obj);
	}

	public override int GetHashCode()
	{
		return _hashcode;
	}
}
