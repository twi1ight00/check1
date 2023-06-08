using System;
using System.Globalization;
using Microsoft.Practices.Unity.Properties;

namespace Microsoft.Practices.Unity.Utility;

/// <summary>
/// A static helper class that includes various parameter checking routines.
/// </summary>
public static class Guard
{
	/// <summary>
	/// Throws <see cref="T:System.ArgumentNullException" /> if the given argument is null.
	/// </summary>
	/// <exception cref="T:System.ArgumentNullException"> if tested value if null.</exception>
	/// <param name="argumentValue">Argument value to test.</param>
	/// <param name="argumentName">Name of the argument being tested.</param>
	public static void ArgumentNotNull(object argumentValue, string argumentName)
	{
		if (argumentValue == null)
		{
			throw new ArgumentNullException(argumentName);
		}
	}

	/// <summary>
	/// Throws an exception if the tested string argument is null or the empty string.
	/// </summary>
	/// <exception cref="T:System.ArgumentNullException">Thrown if string value is null.</exception>
	/// <exception cref="T:System.ArgumentException">Thrown if the string is empty</exception>
	/// <param name="argumentValue">Argument value to check.</param>
	/// <param name="argumentName">Name of argument being checked.</param>
	public static void ArgumentNotNullOrEmpty(string argumentValue, string argumentName)
	{
		if (argumentValue == null)
		{
			throw new ArgumentNullException(argumentName);
		}
		if (argumentValue.Length == 0)
		{
			throw new ArgumentException(Resources.ArgumentMustNotBeEmpty, argumentName);
		}
	}

	/// <summary>
	/// Verifies that an argument type is assignable from the provided type (meaning
	/// interfaces are implemented, or classes exist in the base class hierarchy).
	/// </summary>
	/// <param name="assignmentTargetType">The argument type that will be assigned to.</param>
	/// <param name="assignmentValueType">The type of the value being assigned.</param>
	/// <param name="argumentName">Argument name.</param>
	public static void TypeIsAssignable(Type assignmentTargetType, Type assignmentValueType, string argumentName)
	{
		if (assignmentTargetType == null)
		{
			throw new ArgumentNullException("assignmentTargetType");
		}
		if (assignmentValueType == null)
		{
			throw new ArgumentNullException("assignmentValueType");
		}
		if (!assignmentTargetType.IsAssignableFrom(assignmentValueType))
		{
			throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.TypesAreNotAssignable, assignmentTargetType, assignmentValueType), argumentName);
		}
	}

	/// <summary>
	/// Verifies that an argument instance is assignable from the provided type (meaning
	/// interfaces are implemented, or classes exist in the base class hierarchy, or instance can be 
	/// assigned through a runtime wrapper, as is the case for COM Objects).
	/// </summary>
	/// <param name="assignmentTargetType">The argument type that will be assigned to.</param>
	/// <param name="assignmentInstance">The instance that will be assigned.</param>
	/// <param name="argumentName">Argument name.</param>
	public static void InstanceIsAssignable(Type assignmentTargetType, object assignmentInstance, string argumentName)
	{
		if (assignmentTargetType == null)
		{
			throw new ArgumentNullException("assignmentTargetType");
		}
		if (assignmentInstance == null)
		{
			throw new ArgumentNullException("assignmentInstance");
		}
		if (!assignmentTargetType.IsInstanceOfType(assignmentInstance))
		{
			throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.TypesAreNotAssignable, assignmentTargetType, GetTypeName(assignmentInstance)), argumentName);
		}
	}

	private static string GetTypeName(object assignmentInstance)
	{
		try
		{
			return assignmentInstance.GetType().FullName;
		}
		catch (Exception)
		{
			return Resources.UnknownType;
		}
	}
}
