using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace Microsoft.Practices.Unity.InterceptionExtension;

internal class InterfaceImplementation
{
	private readonly TypeBuilder typeBuilder;

	private readonly Type @interface;

	private readonly Type targetInterface;

	private readonly GenericParameterMapper genericParameterMapper;

	private readonly FieldBuilder proxyInterceptionPipelineField;

	private readonly bool explicitImplementation;

	private readonly FieldBuilder targetField;

	public InterfaceImplementation(TypeBuilder typeBuilder, Type @interface, FieldBuilder proxyInterceptionPipelineField, bool explicitImplementation)
		: this(typeBuilder, @interface, proxyInterceptionPipelineField, explicitImplementation, null)
	{
	}

	public InterfaceImplementation(TypeBuilder typeBuilder, Type @interface, FieldBuilder proxyInterceptionPipelineField, bool explicitImplementation, FieldBuilder targetField)
		: this(typeBuilder, @interface, GenericParameterMapper.DefaultMapper, proxyInterceptionPipelineField, explicitImplementation, targetField)
	{
	}

	public InterfaceImplementation(TypeBuilder typeBuilder, Type @interface, GenericParameterMapper genericParameterMapper, FieldBuilder proxyInterceptionPipelineField, bool explicitImplementation, FieldBuilder targetField)
	{
		this.typeBuilder = typeBuilder;
		this.@interface = @interface;
		this.genericParameterMapper = genericParameterMapper;
		this.proxyInterceptionPipelineField = proxyInterceptionPipelineField;
		this.explicitImplementation = explicitImplementation;
		this.targetField = targetField;
		if (@interface.IsGenericType)
		{
			Type genericTypeDefinition = @interface.GetGenericTypeDefinition();
			Type[] typeArguments = (from t in genericTypeDefinition.GetGenericArguments()
				select genericParameterMapper.Map(t)).ToArray();
			targetInterface = genericTypeDefinition.MakeGenericType(typeArguments);
		}
		else
		{
			targetInterface = @interface;
		}
	}

	public int Implement(HashSet<Type> implementedInterfaces, int memberCount)
	{
		if (implementedInterfaces.Contains(@interface))
		{
			return memberCount;
		}
		implementedInterfaces.Add(@interface);
		typeBuilder.AddInterfaceImplementation(@interface);
		foreach (MethodInfo item in MethodsToIntercept())
		{
			OverrideMethod(item, memberCount++);
		}
		foreach (PropertyInfo item2 in PropertiesToIntercept())
		{
			OverrideProperty(item2, memberCount++);
		}
		foreach (EventInfo item3 in EventsToIntercept())
		{
			OverrideEvent(item3, memberCount++);
		}
		Type[] interfaces = @interface.GetInterfaces();
		foreach (Type type in interfaces)
		{
			memberCount = new InterfaceImplementation(typeBuilder, type, new GenericParameterMapper(type, genericParameterMapper), proxyInterceptionPipelineField, explicitImplementation, targetField).Implement(implementedInterfaces, memberCount);
		}
		return memberCount;
	}

	private IEnumerable<MethodInfo> MethodsToIntercept()
	{
		try
		{
			MethodInfo[] methods = @interface.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			foreach (MethodInfo method in methods)
			{
				if (!method.IsSpecialName)
				{
					yield return method;
				}
			}
		}
		finally
		{
		}
	}

	private void OverrideMethod(MethodInfo method, int methodNum)
	{
		new InterfaceMethodOverride(typeBuilder, proxyInterceptionPipelineField, targetField, method, targetInterface, genericParameterMapper, explicitImplementation, methodNum).AddMethod();
	}

	private IEnumerable<PropertyInfo> PropertiesToIntercept()
	{
		return @interface.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
	}

	private void OverrideProperty(PropertyInfo property, int count)
	{
		MethodBuilder getMethod = OverridePropertyMethod(property.GetGetMethod(), count);
		MethodBuilder setMethod = OverridePropertyMethod(property.GetSetMethod(), count);
		AddPropertyDefinition(property, getMethod, setMethod);
	}

	private void AddPropertyDefinition(PropertyInfo property, MethodBuilder getMethod, MethodBuilder setMethod)
	{
		PropertyBuilder propertyBuilder = typeBuilder.DefineProperty(property.Name, property.Attributes, property.PropertyType, (from param in property.GetIndexParameters()
			select param.ParameterType).ToArray());
		if (getMethod != null)
		{
			propertyBuilder.SetGetMethod(getMethod);
		}
		if (setMethod != null)
		{
			propertyBuilder.SetSetMethod(setMethod);
		}
	}

	private MethodBuilder OverridePropertyMethod(MethodInfo method, int count)
	{
		if (method != null)
		{
			return new InterfaceMethodOverride(typeBuilder, proxyInterceptionPipelineField, targetField, method, targetInterface, genericParameterMapper, explicitImplementation, count).AddMethod();
		}
		return null;
	}

	private IEnumerable<EventInfo> EventsToIntercept()
	{
		return @interface.GetEvents(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
	}

	private void OverrideEvent(EventInfo @event, int count)
	{
		MethodBuilder addMethod = OverrideEventMethod(@event.GetAddMethod(), count);
		MethodBuilder removeMethod = OverrideEventMethod(@event.GetRemoveMethod(), count);
		AddEventDefinition(@event, addMethod, removeMethod);
	}

	private void AddEventDefinition(EventInfo @event, MethodBuilder addMethod, MethodBuilder removeMethod)
	{
		EventBuilder eventBuilder = typeBuilder.DefineEvent(@event.Name, @event.Attributes, @event.EventHandlerType);
		if (addMethod != null)
		{
			eventBuilder.SetAddOnMethod(addMethod);
		}
		if (removeMethod != null)
		{
			eventBuilder.SetRemoveOnMethod(removeMethod);
		}
	}

	private MethodBuilder OverrideEventMethod(MethodInfo method, int count)
	{
		if (method != null)
		{
			return new InterfaceMethodOverride(typeBuilder, proxyInterceptionPipelineField, targetField, method, targetInterface, genericParameterMapper, explicitImplementation, count).AddMethod();
		}
		return null;
	}
}
