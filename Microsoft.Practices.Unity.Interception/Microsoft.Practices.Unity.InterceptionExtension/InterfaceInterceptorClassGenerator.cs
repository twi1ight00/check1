using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Security;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity.InterceptionExtension.Properties;

namespace Microsoft.Practices.Unity.InterceptionExtension;

/// <summary>
/// A class used to generate proxy classes for doing interception on
/// interfaces.
/// </summary>
public class InterfaceInterceptorClassGenerator
{
	private readonly Type typeToIntercept;

	private GenericParameterMapper mainInterfaceMapper;

	private readonly IEnumerable<Type> additionalInterfaces;

	private static readonly AssemblyBuilder assemblyBuilder;

	private FieldBuilder proxyInterceptionPipelineField;

	private FieldBuilder targetField;

	private FieldBuilder typeToProxyField;

	private TypeBuilder typeBuilder;

	[SecurityCritical]
	static InterfaceInterceptorClassGenerator()
	{
		assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(new AssemblyName("Unity_ILEmit_InterfaceProxies"), AssemblyBuilderAccess.Run);
	}

	/// <summary>
	/// Create an instance of <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.InterfaceInterceptorClassGenerator" /> that
	/// can construct an intercepting proxy for the given interface.
	/// </summary>
	/// <param name="typeToIntercept">Type of the interface to intercept.</param>
	/// <param name="additionalInterfaces">Additional interfaces the proxy must implement.</param>
	public InterfaceInterceptorClassGenerator(Type typeToIntercept, IEnumerable<Type> additionalInterfaces)
	{
		CheckAdditionalInterfaces(additionalInterfaces);
		this.typeToIntercept = typeToIntercept;
		this.additionalInterfaces = additionalInterfaces;
		CreateTypeBuilder();
	}

	private static void CheckAdditionalInterfaces(IEnumerable<Type> additionalInterfaces)
	{
		if (additionalInterfaces == null)
		{
			throw new ArgumentNullException("additionalInterfaces");
		}
		foreach (Type additionalInterface in additionalInterfaces)
		{
			if (additionalInterface == null)
			{
				throw new ArgumentException(Resources.ExceptionContainsNullElement, "additionalInterfaces");
			}
			if (!additionalInterface.IsInterface)
			{
				throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.ExceptionTypeIsNotInterface, additionalInterface.Name), "additionalInterfaces");
			}
			if (additionalInterface.IsGenericTypeDefinition)
			{
				throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.ExceptionTypeIsOpenGeneric, additionalInterface.Name), "additionalInterfaces");
			}
		}
	}

	/// <summary>
	/// Create the type to proxy the requested interface
	/// </summary>
	/// <returns></returns>
	public Type CreateProxyType()
	{
		HashSet<Type> implementedInterfaces = new HashSet<Type>();
		int memberCount = new InterfaceImplementation(typeBuilder, typeToIntercept, mainInterfaceMapper, proxyInterceptionPipelineField, explicitImplementation: false, targetField).Implement(implementedInterfaces, 0);
		foreach (Type additionalInterface in additionalInterfaces)
		{
			memberCount = new InterfaceImplementation(typeBuilder, additionalInterface, proxyInterceptionPipelineField, explicitImplementation: true).Implement(implementedInterfaces, memberCount);
		}
		AddConstructor();
		return typeBuilder.CreateType();
	}

	private void AddConstructor()
	{
		Type[] parameterTypes = Sequence.Collect<Type>(typeToIntercept, typeof(Type)).ToArray();
		ConstructorBuilder constructorBuilder = typeBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.HasThis, parameterTypes);
		constructorBuilder.DefineParameter(1, ParameterAttributes.None, "target");
		constructorBuilder.DefineParameter(2, ParameterAttributes.None, "typeToProxy");
		ILGenerator iLGenerator = constructorBuilder.GetILGenerator();
		iLGenerator.Emit(OpCodes.Ldarg_0);
		iLGenerator.Emit(OpCodes.Call, ObjectMethods.Constructor);
		iLGenerator.Emit(OpCodes.Ldarg_0);
		iLGenerator.Emit(OpCodes.Newobj, InterceptionBehaviorPipelineMethods.Constructor);
		iLGenerator.Emit(OpCodes.Stfld, proxyInterceptionPipelineField);
		iLGenerator.Emit(OpCodes.Ldarg_0);
		iLGenerator.Emit(OpCodes.Ldarg_1);
		iLGenerator.Emit(OpCodes.Stfld, targetField);
		iLGenerator.Emit(OpCodes.Ldarg_0);
		iLGenerator.Emit(OpCodes.Ldarg_2);
		iLGenerator.Emit(OpCodes.Stfld, typeToProxyField);
		iLGenerator.Emit(OpCodes.Ret);
	}

	private void CreateTypeBuilder()
	{
		TypeAttributes attr = TypeAttributes.Public;
		ModuleBuilder moduleBuilder = GetModuleBuilder();
		typeBuilder = moduleBuilder.DefineType(CreateTypeName(), attr);
		mainInterfaceMapper = DefineGenericArguments();
		proxyInterceptionPipelineField = InterceptingProxyImplementor.ImplementIInterceptingProxy(typeBuilder);
		targetField = typeBuilder.DefineField("target", typeToIntercept, FieldAttributes.Private);
		typeToProxyField = typeBuilder.DefineField("typeToProxy", typeof(Type), FieldAttributes.Private);
	}

	private string CreateTypeName()
	{
		return "DynamicModule.ns.Wrapped_" + typeToIntercept.Name + "_" + Guid.NewGuid().ToString("N");
	}

	private GenericParameterMapper DefineGenericArguments()
	{
		if (!typeToIntercept.IsGenericType)
		{
			return GenericParameterMapper.DefaultMapper;
		}
		Type[] genericArguments = typeToIntercept.GetGenericArguments();
		GenericTypeParameterBuilder[] array = typeBuilder.DefineGenericParameters(genericArguments.Select((Type t) => t.Name).ToArray());
		for (int i = 0; i < genericArguments.Length; i++)
		{
			array[i].SetGenericParameterAttributes(genericArguments[i].GenericParameterAttributes);
			List<Type> list = new List<Type>();
			Type[] genericParameterConstraints = genericArguments[i].GetGenericParameterConstraints();
			foreach (Type type in genericParameterConstraints)
			{
				if (type.IsClass)
				{
					array[i].SetBaseTypeConstraint(type);
				}
				else
				{
					list.Add(type);
				}
			}
			if (list.Count > 0)
			{
				array[i].SetInterfaceConstraints(list.ToArray());
			}
		}
		return new GenericParameterMapper(genericArguments, array.Cast<Type>().ToArray());
	}

	private static ModuleBuilder GetModuleBuilder()
	{
		string name = Guid.NewGuid().ToString("N");
		return assemblyBuilder.DefineDynamicModule(name);
	}
}
