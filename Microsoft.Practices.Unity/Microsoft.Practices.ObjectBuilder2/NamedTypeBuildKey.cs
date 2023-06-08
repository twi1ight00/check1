using System;
using System.Globalization;

namespace Microsoft.Practices.ObjectBuilder2;

/// <summary>
/// Build key used to combine a type object with a string name. Used by
/// ObjectBuilder to indicate exactly what is being built.
/// </summary>
public class NamedTypeBuildKey
{
	private readonly Type type;

	private readonly string name;

	/// <summary>
	/// Return the <see cref="P:Microsoft.Practices.ObjectBuilder2.NamedTypeBuildKey.Type" /> stored in this build key.
	/// </summary>
	/// <value>The type to build.</value>
	public Type Type => type;

	/// <summary>
	/// Returns the name stored in this build key.
	/// </summary>
	/// <remarks>The name to use when building.</remarks>
	public string Name => name;

	/// <summary>
	/// Create a new <see cref="T:Microsoft.Practices.ObjectBuilder2.NamedTypeBuildKey" /> instance with the given
	/// type and name.
	/// </summary>
	/// <param name="type"><see cref="P:Microsoft.Practices.ObjectBuilder2.NamedTypeBuildKey.Type" /> to build.</param>
	/// <param name="name">Key to use to look up type mappings and singletons.</param>
	public NamedTypeBuildKey(Type type, string name)
	{
		this.type = type;
		this.name = ((!string.IsNullOrEmpty(name)) ? name : null);
	}

	/// <summary>
	/// Create a new <see cref="T:Microsoft.Practices.ObjectBuilder2.NamedTypeBuildKey" /> instance for the default
	/// buildup of the given type.
	/// </summary>
	/// <param name="type"><see cref="P:Microsoft.Practices.ObjectBuilder2.NamedTypeBuildKey.Type" /> to build.</param>
	public NamedTypeBuildKey(Type type)
		: this(type, null)
	{
	}

	/// <summary>
	/// This helper method creates a new <see cref="T:Microsoft.Practices.ObjectBuilder2.NamedTypeBuildKey" /> instance. It is
	/// initialized for the default key for the given type.
	/// </summary>
	/// <typeparam name="T">Type to build.</typeparam>
	/// <returns>A new <see cref="T:Microsoft.Practices.ObjectBuilder2.NamedTypeBuildKey" /> instance.</returns>
	public static NamedTypeBuildKey Make<T>()
	{
		return new NamedTypeBuildKey(typeof(T));
	}

	/// <summary>
	/// This helper method creates a new <see cref="T:Microsoft.Practices.ObjectBuilder2.NamedTypeBuildKey" /> instance for
	/// the given type and key.
	/// </summary>
	/// <typeparam name="T">Type to build</typeparam>
	/// <param name="name">Key to use to look up type mappings and singletons.</param>
	/// <returns>A new <see cref="T:Microsoft.Practices.ObjectBuilder2.NamedTypeBuildKey" /> instance initialized with the given type and name.</returns>
	public static NamedTypeBuildKey Make<T>(string name)
	{
		return new NamedTypeBuildKey(typeof(T), name);
	}

	/// <summary>
	/// Compare two <see cref="T:Microsoft.Practices.ObjectBuilder2.NamedTypeBuildKey" /> instances.
	/// </summary>
	/// <remarks>Two <see cref="T:Microsoft.Practices.ObjectBuilder2.NamedTypeBuildKey" /> instances compare equal
	/// if they contain the same name and the same type. Also, comparing
	/// against a different type will also return false.</remarks>
	/// <param name="obj">Object to compare to.</param>
	/// <returns>True if the two keys are equal, false if not.</returns>
	public override bool Equals(object obj)
	{
		NamedTypeBuildKey namedTypeBuildKey = obj as NamedTypeBuildKey;
		if (namedTypeBuildKey == null)
		{
			return false;
		}
		return this == namedTypeBuildKey;
	}

	/// <summary>
	/// Calculate a hash code for this instance.
	/// </summary>
	/// <returns>A hash code.</returns>
	public override int GetHashCode()
	{
		int num = ((type != null) ? type.GetHashCode() : 0);
		int num2 = ((name != null) ? name.GetHashCode() : 0);
		return (num + 37) ^ (num2 + 17);
	}

	/// <summary>
	/// Compare two <see cref="T:Microsoft.Practices.ObjectBuilder2.NamedTypeBuildKey" /> instances for equality.
	/// </summary>
	/// <remarks>Two <see cref="T:Microsoft.Practices.ObjectBuilder2.NamedTypeBuildKey" /> instances compare equal
	/// if they contain the same name and the same type.</remarks>
	/// <param name="left">First of the two keys to compare.</param>
	/// <param name="right">Second of the two keys to compare.</param>
	/// <returns>True if the values of the keys are the same, else false.</returns>
	public static bool operator ==(NamedTypeBuildKey left, NamedTypeBuildKey right)
	{
		bool flag = object.ReferenceEquals(left, null);
		bool flag2 = object.ReferenceEquals(right, null);
		if (flag && flag2)
		{
			return true;
		}
		if (flag || flag2)
		{
			return false;
		}
		if (left.type == right.type)
		{
			return string.Compare(left.name, right.name, StringComparison.Ordinal) == 0;
		}
		return false;
	}

	/// <summary>
	/// Compare two <see cref="T:Microsoft.Practices.ObjectBuilder2.NamedTypeBuildKey" /> instances for inequality.
	/// </summary>
	/// <remarks>Two <see cref="T:Microsoft.Practices.ObjectBuilder2.NamedTypeBuildKey" /> instances compare equal
	/// if they contain the same name and the same type. If either field differs
	/// the keys are not equal.</remarks>
	/// <param name="left">First of the two keys to compare.</param>
	/// <param name="right">Second of the two keys to compare.</param>
	/// <returns>false if the values of the keys are the same, else true.</returns>
	public static bool operator !=(NamedTypeBuildKey left, NamedTypeBuildKey right)
	{
		return !(left == right);
	}

	/// <summary>
	/// Formats the build key as a string (primarily for debugging).
	/// </summary>
	/// <returns>A readable string representation of the build key.</returns>
	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "Build Key[{0}, {1}]", type, name ?? "null");
	}
}
/// <summary>
/// A generic version of <see cref="T:Microsoft.Practices.ObjectBuilder2.NamedTypeBuildKey" /> so that
/// you can new up a key using generic syntax.
/// </summary>
/// <typeparam name="T">Type for the key.</typeparam>
public class NamedTypeBuildKey<T> : NamedTypeBuildKey
{
	/// <summary>
	/// Construct a new <see cref="T:Microsoft.Practices.ObjectBuilder2.NamedTypeBuildKey`1" /> that
	/// specifies the given type.
	/// </summary>
	public NamedTypeBuildKey()
		: base(typeof(T), null)
	{
	}

	/// <summary>
	/// Construct a new <see cref="T:Microsoft.Practices.ObjectBuilder2.NamedTypeBuildKey`1" /> that
	/// specifies the given type and name.
	/// </summary>
	/// <param name="name">Name for the key.</param>
	public NamedTypeBuildKey(string name)
		: base(typeof(T), name)
	{
	}
}
