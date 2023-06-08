using System;
using System.ComponentModel;
using System.Reflection;
using System.Reflection.Emit;

namespace AutoMapper.Impl;

public class PropertyEmitter
{
	private static readonly MethodInfo proxyBase_NotifyPropertyChanged = typeof(ProxyBase).GetMethod("NotifyPropertyChanged", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[2]
	{
		typeof(PropertyChangedEventHandler),
		typeof(string)
	}, null);

	private readonly FieldBuilder fieldBuilder;

	private readonly MethodBuilder getterBuilder;

	private readonly TypeBuilder owner;

	private readonly PropertyBuilder propertyBuilder;

	private readonly FieldBuilder propertyChangedField;

	private readonly MethodBuilder setterBuilder;

	public Type PropertyType => propertyBuilder.PropertyType;

	public PropertyEmitter(TypeBuilder owner, string name, Type propertyType, FieldBuilder propertyChangedField)
	{
		this.owner = owner;
		this.propertyChangedField = propertyChangedField;
		fieldBuilder = owner.DefineField($"<{name}>", propertyType, FieldAttributes.Private);
		getterBuilder = owner.DefineMethod($"get_{name}", MethodAttributes.Public | MethodAttributes.Virtual | MethodAttributes.HideBySig | MethodAttributes.SpecialName, propertyType, Type.EmptyTypes);
		ILGenerator iLGenerator = getterBuilder.GetILGenerator();
		iLGenerator.Emit(OpCodes.Ldarg_0);
		iLGenerator.Emit(OpCodes.Ldfld, fieldBuilder);
		iLGenerator.Emit(OpCodes.Ret);
		setterBuilder = owner.DefineMethod($"set_{name}", MethodAttributes.Public | MethodAttributes.Virtual | MethodAttributes.HideBySig | MethodAttributes.SpecialName, typeof(void), new Type[1] { propertyType });
		ILGenerator iLGenerator2 = setterBuilder.GetILGenerator();
		iLGenerator2.Emit(OpCodes.Ldarg_0);
		iLGenerator2.Emit(OpCodes.Ldarg_1);
		iLGenerator2.Emit(OpCodes.Stfld, fieldBuilder);
		if (propertyChangedField != null)
		{
			iLGenerator2.Emit(OpCodes.Ldarg_0);
			iLGenerator2.Emit(OpCodes.Dup);
			iLGenerator2.Emit(OpCodes.Ldfld, propertyChangedField);
			iLGenerator2.Emit(OpCodes.Ldstr, name);
			iLGenerator2.Emit(OpCodes.Call, proxyBase_NotifyPropertyChanged);
		}
		iLGenerator2.Emit(OpCodes.Ret);
		propertyBuilder = owner.DefineProperty(name, PropertyAttributes.None, propertyType, null);
		propertyBuilder.SetGetMethod(getterBuilder);
		propertyBuilder.SetSetMethod(setterBuilder);
	}

	public MethodBuilder GetGetter(Type requiredType)
	{
		if (!requiredType.IsAssignableFrom(PropertyType))
		{
			throw new InvalidOperationException("Types are not compatible");
		}
		return getterBuilder;
	}

	public MethodBuilder GetSetter(Type requiredType)
	{
		if (!PropertyType.IsAssignableFrom(requiredType))
		{
			throw new InvalidOperationException("Types are not compatible");
		}
		return setterBuilder;
	}
}
