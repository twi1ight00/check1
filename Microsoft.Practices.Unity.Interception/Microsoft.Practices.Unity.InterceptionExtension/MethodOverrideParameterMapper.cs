using System;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace Microsoft.Practices.Unity.InterceptionExtension;

/// <summary>
/// This class handles parameter type mapping. When we generate
/// a generic method, we need to make sure our parameter type
/// objects line up with the generic parameters on the generated
/// method, not on the one we're overriding. 
/// </summary>
internal class MethodOverrideParameterMapper
{
	private readonly MethodInfo methodToOverride;

	private GenericParameterMapper genericParameterMapper;

	public Type[] GenericMethodParameters => genericParameterMapper.GetGeneratedParameters();

	public MethodOverrideParameterMapper(MethodInfo methodToOverride)
	{
		this.methodToOverride = methodToOverride;
	}

	public void SetupParameters(MethodBuilder methodBuilder, GenericParameterMapper parentMapper)
	{
		if (methodToOverride.IsGenericMethod)
		{
			Type[] genericArguments = methodToOverride.GetGenericArguments();
			string[] names = genericArguments.Select((Type t) => t.Name).ToArray();
			GenericTypeParameterBuilder[] array = methodBuilder.DefineGenericParameters(names);
			for (int i = 0; i < genericArguments.Length; i++)
			{
				array[i].SetGenericParameterAttributes(genericArguments[i].GenericParameterAttributes);
				Type[] source = (from ct in genericArguments[i].GetGenericParameterConstraints()
					select parentMapper.Map(ct)).ToArray();
				Type[] array2 = source.Where((Type t) => t.IsInterface).ToArray();
				Type type = source.Where((Type t) => !t.IsInterface).FirstOrDefault();
				if (type != null)
				{
					array[i].SetBaseTypeConstraint(type);
				}
				if (array2.Length > 0)
				{
					array[i].SetInterfaceConstraints(array2);
				}
			}
			genericParameterMapper = new GenericParameterMapper(genericArguments, array.Cast<Type>().ToArray(), parentMapper);
		}
		else
		{
			genericParameterMapper = parentMapper;
		}
	}

	public Type GetParameterType(Type originalParameterType)
	{
		return genericParameterMapper.Map(originalParameterType);
	}

	public Type GetElementType(Type originalParameterType)
	{
		return GetParameterType(originalParameterType).GetElementType();
	}

	public Type GetReturnType()
	{
		return GetParameterType(methodToOverride.ReturnType);
	}
}
