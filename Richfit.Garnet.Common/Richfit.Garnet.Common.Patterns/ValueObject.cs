using System;
using System.Linq;
using System.Reflection;

namespace Richfit.Garnet.Common.Patterns;

/// <summary>
/// 值对象比较的基类
/// </summary>
/// <typeparam name="T">值对象类型</typeparam>
public class ValueObject<T> : IEquatable<T> where T : ValueObject<T>
{
	/// <summary>
	/// <see cref="M:System.object.IEquatable{T}" />
	/// </summary>
	/// <param name="other"><see cref="M:System.object.IEquatable{T}" /></param>
	/// <returns><see cref="M:System.object.IEquatable{T}" /></returns>
	public bool Equals(T other)
	{
		if (other == null)
		{
			return false;
		}
		if (object.ReferenceEquals(this, other))
		{
			return true;
		}
		PropertyInfo[] publicProperties = GetType().GetProperties();
		if (publicProperties != null && publicProperties.Any())
		{
			return publicProperties.All(delegate(PropertyInfo p)
			{
				object value = p.GetValue(this, null);
				object value2 = p.GetValue(other, null);
				return typeof(T).IsAssignableFrom(value.GetType()) ? object.ReferenceEquals(value, value2) : value.Equals(value2);
			});
		}
		return true;
	}

	/// <summary>
	/// <see cref="M:System.object.Equals" />
	/// </summary>
	/// <param name="obj"><see cref="M:System.object.Equals" /></param>
	/// <returns><see cref="M:System.object.Equals" /></returns>
	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (object.ReferenceEquals(this, obj))
		{
			return true;
		}
		if (obj is ValueObject<T> item)
		{
			return Equals((T)item);
		}
		return false;
	}

	/// <summary>
	/// <see cref="M:System.object.GetHashCode" />
	/// </summary>
	/// <returns><see cref="M:System.object.GetHashCode" /></returns>
	public override int GetHashCode()
	{
		int hashCode = 31;
		bool changeMultiplier = false;
		int index = 1;
		PropertyInfo[] publicProperties = GetType().GetProperties();
		if (publicProperties != null && publicProperties.Any())
		{
			PropertyInfo[] array = publicProperties;
			foreach (PropertyInfo item in array)
			{
				object value = item.GetValue(this, null);
				if (value != null)
				{
					hashCode = hashCode * (changeMultiplier ? 59 : 114) + value.GetHashCode();
					changeMultiplier = !changeMultiplier;
				}
				else
				{
					hashCode ^= index * 13;
				}
			}
		}
		return hashCode;
	}

	/// <summary>
	/// 重写等于运算符
	/// </summary>
	/// <param name="left"></param>
	/// <param name="right"></param>
	/// <returns></returns>
	public static bool operator ==(ValueObject<T> left, ValueObject<T> right)
	{
		if (object.Equals(left, null))
		{
			return object.Equals(right, null) ? true : false;
		}
		return left.Equals(right);
	}

	/// <summary>
	/// 重写不等于运算符
	/// </summary>
	/// <param name="left"></param>
	/// <param name="right"></param>
	/// <returns></returns>
	public static bool operator !=(ValueObject<T> left, ValueObject<T> right)
	{
		return !(left == right);
	}
}
