using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Security;

namespace Microsoft.Practices.Unity.InterceptionExtension;

/// <summary>
/// Class that handles generating the dynamic types used for interception.
/// </summary>
public class InterceptingClassGenerator
{
	private readonly Type typeToIntercept;

	private Type targetType;

	private GenericParameterMapper mainTypeMapper;

	private readonly IEnumerable<Type> additionalInterfaces;

	private static readonly AssemblyBuilder assemblyBuilder;

	private FieldBuilder proxyInterceptionPipelineField;

	private TypeBuilder typeBuilder;

	private static ModuleBuilder GetModuleBuilder()
	{
		string name = Guid.NewGuid().ToString("N");
		return assemblyBuilder.DefineDynamicModule(name);
	}

	[SecurityCritical]
	static InterceptingClassGenerator()
	{
		assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(new AssemblyName("Unity_ILEmit_DynamicClasses"), AssemblyBuilderAccess.Run);
	}

	/// <summary>
	/// Create a new <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.InterceptingClassGenerator" /> that will generate a
	/// wrapper class for the requested <paramref name="typeToIntercept" />.
	/// </summary>
	/// <param name="typeToIntercept">Type to generate the wrapper for.</param>
	/// <param name="additionalInterfaces">Additional interfaces the proxy must implement.</param>
	public InterceptingClassGenerator(Type typeToIntercept, params Type[] additionalInterfaces)
	{
		this.typeToIntercept = typeToIntercept;
		this.additionalInterfaces = additionalInterfaces;
		CreateTypeBuilder();
	}

	/// <summary>
	/// Create the wrapper class for the given type.
	/// </summary>
	/// <returns>Wrapper type.</returns>
	public Type GenerateType()
	{
		AddMethods();
		AddProperties();
		AddEvents();
		AddConstructors();
		int memberCount = 0;
		HashSet<Type> implementedInterfacesSet = GetImplementedInterfacesSet();
		foreach (Type additionalInterface in additionalInterfaces)
		{
			memberCount = new InterfaceImplementation(typeBuilder, additionalInterface, proxyInterceptionPipelineField, explicitImplementation: true).Implement(implementedInterfacesSet, memberCount);
		}
		return typeBuilder.CreateType();
	}

	private void AddMethods()
	{
		int num = 0;
		foreach (MethodInfo item in GetMethodsToIntercept())
		{
			new MethodOverride(typeBuilder, proxyInterceptionPipelineField, item, targetType, mainTypeMapper, num++).AddMethod();
		}
	}

	private IEnumerable<MethodInfo> GetMethodsToIntercept()
	{
		List<MethodInfo> methodsToIntercept = new List<MethodInfo>();
		MethodInfo[] methods = typeToIntercept.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		foreach (MethodInfo methodInfo in methods)
		{
			if (!methodInfo.IsSpecialName && MethodOverride.MethodCanBeIntercepted(methodInfo))
			{
				methodsToIntercept.Add(methodInfo);
			}
		}
		MethodSorter sorter = new MethodSorter(typeToIntercept, methodsToIntercept);
		foreach (MethodInfo item in sorter)
		{
			yield return item;
		}
	}

	private void AddProperties()
	{
		int num = 0;
		PropertyInfo[] properties = typeToIntercept.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		foreach (PropertyInfo propertyInfo in properties)
		{
			OverridePropertyMethod(propertyInfo.GetGetMethod(nonPublic: true), num);
			OverridePropertyMethod(propertyInfo.GetSetMethod(nonPublic: true), num);
			num++;
		}
	}

	private void OverridePropertyMethod(MethodInfo method, int count)
	{
		if (method != null && MethodOverride.MethodCanBeIntercepted(method))
		{
			new MethodOverride(typeBuilder, proxyInterceptionPipelineField, method, targetType, mainTypeMapper, count).AddMethod();
		}
	}

	private void AddEvents()
	{
		int num = 0;
		EventInfo[] events = typeToIntercept.GetEvents(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		foreach (EventInfo eventInfo in events)
		{
			OverrideEventMethod(eventInfo.GetAddMethod(), num);
			OverrideEventMethod(eventInfo.GetRemoveMethod(), num);
			num++;
		}
	}

	private void OverrideEventMethod(MethodInfo method, int count)
	{
		if (method != null && MethodOverride.MethodCanBeIntercepted(method))
		{
			new MethodOverride(typeBuilder, proxyInterceptionPipelineField, method, targetType, mainTypeMapper, count).AddMethod();
		}
	}

	private void AddConstructors()
	{
		BindingFlags bindingAttr = (typeToIntercept.IsAbstract ? (BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic) : (BindingFlags.Instance | BindingFlags.Public));
		ConstructorInfo[] constructors = typeToIntercept.GetConstructors(bindingAttr);
		foreach (ConstructorInfo ctor in constructors)
		{
			AddConstructor(ctor);
		}
	}

	private void AddConstructor(ConstructorInfo ctor)
	{
		if (ctor.IsPublic || ctor.IsFamily || ctor.IsFamilyOrAssembly)
		{
			MethodAttributes attributes = (ctor.Attributes & ~MethodAttributes.ReservedMask & ~MethodAttributes.MemberAccessMask) | MethodAttributes.Public;
			ParameterInfo[] parameters = ctor.GetParameters();
			Type[] array = parameters.Select((ParameterInfo item) => item.ParameterType).ToArray();
			ConstructorBuilder constructorBuilder = typeBuilder.DefineConstructor(attributes, ctor.CallingConvention, array);
			for (int i = 0; i < parameters.Length; i++)
			{
				constructorBuilder.DefineParameter(i + 1, parameters[i].Attributes, parameters[i].Name);
			}
			ILGenerator iLGenerator = constructorBuilder.GetILGenerator();
			iLGenerator.Emit(OpCodes.Ldarg_0);
			iLGenerator.Emit(OpCodes.Newobj, InterceptionBehaviorPipelineMethods.Constructor);
			iLGenerator.Emit(OpCodes.Stfld, proxyInterceptionPipelineField);
			iLGenerator.Emit(OpCodes.Ldarg_0);
			for (int j = 0; j < array.Length; j++)
			{
				iLGenerator.Emit(OpCodes.Ldarg, j + 1);
			}
			iLGenerator.Emit(OpCodes.Call, ctor);
			iLGenerator.Emit(OpCodes.Ret);
		}
	}

	private void CreateTypeBuilder()
	{
		TypeAttributes attributes = typeToIntercept.Attributes;
		attributes = FilterTypeAttributes(attributes);
		Type genericType = GetGenericType(typeToIntercept);
		ModuleBuilder moduleBuilder = GetModuleBuilder();
		typeBuilder = moduleBuilder.DefineType("DynamicModule.ns.Wrapped_" + typeToIntercept.Name + "_" + Guid.NewGuid().ToString("N"), attributes, genericType);
		mainTypeMapper = DefineGenericArguments(typeBuilder, genericType);
		if (typeToIntercept.IsGenericType)
		{
			Type genericTypeDefinition = typeToIntercept.GetGenericTypeDefinition();
			Type[] typeArguments = (from t in genericTypeDefinition.GetGenericArguments()
				select mainTypeMapper.Map(t)).ToArray();
			targetType = genericTypeDefinition.MakeGenericType(typeArguments);
		}
		else
		{
			targetType = typeToIntercept;
		}
		proxyInterceptionPipelineField = InterceptingProxyImplementor.ImplementIInterceptingProxy(typeBuilder);
	}

	private static Type GetGenericType(Type typeToIntercept)
	{
		if (typeToIntercept.IsGenericType)
		{
			return typeToIntercept.GetGenericTypeDefinition();
		}
		return typeToIntercept;
	}

	private static GenericParameterMapper DefineGenericArguments(TypeBuilder typeBuilder, Type baseClass)
	{
		if (!baseClass.IsGenericType)
		{
			return GenericParameterMapper.DefaultMapper;
		}
		Type[] genericArguments = baseClass.GetGenericArguments();
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

	private static TypeAttributes FilterTypeAttributes(TypeAttributes attributes)
	{
		if ((attributes & TypeAttributes.NestedPublic) != 0)
		{
			attributes &= ~TypeAttributes.NestedPublic;
			attributes |= TypeAttributes.Public;
		}
		attributes &= ~TypeAttributes.ReservedMask;
		attributes &= ~TypeAttributes.Abstract;
		return attributes;
	}

	private HashSet<Type> GetImplementedInterfacesSet()
	{
		HashSet<Type> hashSet = new HashSet<Type>();
		AddToImplementedInterfaces(typeToIntercept, hashSet);
		return hashSet;
	}

	private static void AddToImplementedInterfaces(Type type, HashSet<Type> implementedInterfaces)
	{
		if (!implementedInterfaces.Contains(type))
		{
			if (type.IsInterface)
			{
				implementedInterfaces.Add(type);
			}
			Type[] interfaces = type.GetInterfaces();
			foreach (Type type2 in interfaces)
			{
				AddToImplementedInterfaces(type2, implementedInterfaces);
			}
		}
	}
}
