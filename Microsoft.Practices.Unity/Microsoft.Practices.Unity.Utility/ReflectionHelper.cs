using System;
using System.Reflection;

namespace Microsoft.Practices.Unity.Utility;

/// <summary>
/// A small helper class to encapsulate details of the
/// reflection API, particularly around generics.
/// </summary>
public class ReflectionHelper
{
	private readonly Type t;

	/// <summary>
	/// The <see cref="P:Microsoft.Practices.Unity.Utility.ReflectionHelper.Type" /> object we're reflecting over.
	/// </summary>
	public Type Type => t;

	/// <summary>
	/// Is this type generic?
	/// </summary>
	public bool IsGenericType => t.IsGenericType;

	/// <summary>
	/// Is this type an open generic (no type parameter specified)
	/// </summary>
	public bool IsOpenGeneric
	{
		get
		{
			if (t.IsGenericType)
			{
				return t.ContainsGenericParameters;
			}
			return false;
		}
	}

	/// <summary>
	/// Is this type an array type?
	/// </summary>
	public bool IsArray => t.IsArray;

	/// <summary>
	/// Is this type an array of generic elements?
	/// </summary>
	public bool IsGenericArray
	{
		get
		{
			if (IsArray)
			{
				return ArrayElementType.IsGenericParameter;
			}
			return false;
		}
	}

	/// <summary>
	/// The type of the elements in this type (if it's an array).
	/// </summary>
	public Type ArrayElementType => t.GetElementType();

	/// <summary>
	/// Create a new <see cref="T:Microsoft.Practices.Unity.Utility.ReflectionHelper" /> instance that
	/// lets you look at information about the given type.
	/// </summary>
	/// <param name="typeToReflect">Type to do reflection on.</param>
	public ReflectionHelper(Type typeToReflect)
	{
		t = typeToReflect;
	}

	/// <summary>
	/// Test the given <see cref="T:System.Reflection.MethodBase" /> object, looking at
	/// the parameters. Determine if any of the parameters are
	/// open generic types that need type attributes filled in.
	/// </summary>
	/// <param name="method">The method to check.</param>
	/// <returns>True if any of the parameters are open generics. False if not.</returns>
	public static bool MethodHasOpenGenericParameters(MethodBase method)
	{
		Guard.ArgumentNotNull(method, "method");
		ParameterInfo[] parameters = method.GetParameters();
		foreach (ParameterInfo parameterInfo in parameters)
		{
			ReflectionHelper reflectionHelper = new ReflectionHelper(parameterInfo.ParameterType);
			if (reflectionHelper.IsOpenGeneric)
			{
				return true;
			}
		}
		return false;
	}

	/// <summary>
	/// If this type is an open generic, use the
	/// given <paramref name="genericArguments" /> array to
	/// determine what the required closed type is and return that.
	/// </summary>
	/// <remarks>If the parameter is not an open type, just
	/// return this parameter's type.</remarks>
	/// <param name="genericArguments">Type arguments to substitute in for
	/// the open type parameters.</param>
	/// <returns>Corresponding closed type of this parameter.</returns>
	public Type GetClosedParameterType(Type[] genericArguments)
	{
		Guard.ArgumentNotNull(genericArguments, "genericArguments");
		if (IsOpenGeneric)
		{
			Type[] genericArguments2 = Type.GetGenericArguments();
			for (int i = 0; i < genericArguments2.Length; i++)
			{
				genericArguments2[i] = genericArguments[genericArguments2[i].GenericParameterPosition];
			}
			return Type.GetGenericTypeDefinition().MakeGenericType(genericArguments2);
		}
		if (Type.IsGenericParameter)
		{
			return genericArguments[Type.GenericParameterPosition];
		}
		if (IsArray && ArrayElementType.IsGenericParameter)
		{
			int arrayRank;
			if ((arrayRank = Type.GetArrayRank()) == 1)
			{
				return genericArguments[Type.GetElementType().GenericParameterPosition].MakeArrayType();
			}
			return genericArguments[Type.GetElementType().GenericParameterPosition].MakeArrayType(arrayRank);
		}
		return Type;
	}

	/// <summary>
	/// Given a generic argument name, return the corresponding type for this
	/// closed type. For example, if the current type is SomeType&lt;User&gt;, and the
	/// corresponding definition was SomeType&lt;TSomething&gt;, calling this method
	/// and passing "TSomething" will return typeof(User).
	/// </summary>
	/// <param name="parameterName">Name of the generic parameter.</param>
	/// <returns>Type of the corresponding generic parameter, or null if there
	/// is no matching name.</returns>
	public Type GetNamedGenericParameter(string parameterName)
	{
		Type genericTypeDefinition = Type.GetGenericTypeDefinition();
		Type result = null;
		int num = -1;
		Type[] genericArguments = genericTypeDefinition.GetGenericArguments();
		foreach (Type type in genericArguments)
		{
			if (type.Name == parameterName)
			{
				num = type.GenericParameterPosition;
				break;
			}
		}
		if (num != -1)
		{
			result = Type.GetGenericArguments()[num];
		}
		return result;
	}
}
