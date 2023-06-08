using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text.RegularExpressions;
using AutoMapper.Internal;

namespace AutoMapper.Impl;

public class ProxyGenerator : IProxyGenerator
{
	private static readonly byte[] privateKey = StringToByteArray("002400000480000094000000060200000024000052534131000400000100010079dfef85ed6ba841717e154f13182c0a6029a40794a6ecd2886c7dc38825f6a4c05b0622723a01cd080f9879126708eef58f134accdc99627947425960ac2397162067507e3c627992aa6b92656ad3380999b30b5d5645ba46cc3fcc6a1de5de7afebcf896c65fb4f9547a6c0c6433045fceccb1fa15e960d519d0cd694b29a4");

	private static readonly byte[] privateKeyToken = StringToByteArray("be96cd2c38ef1005");

	private static readonly MethodInfo delegate_Combine = typeof(Delegate).GetMethod("Combine", BindingFlags.Static | BindingFlags.Public, null, new Type[2]
	{
		typeof(Delegate),
		typeof(Delegate)
	}, null);

	private static readonly MethodInfo delegate_Remove = typeof(Delegate).GetMethod("Remove", BindingFlags.Static | BindingFlags.Public, null, new Type[2]
	{
		typeof(Delegate),
		typeof(Delegate)
	}, null);

	private static readonly EventInfo iNotifyPropertyChanged_PropertyChanged = typeof(INotifyPropertyChanged).GetEvent("PropertyChanged", BindingFlags.Instance | BindingFlags.Public);

	private static readonly ConstructorInfo proxyBase_ctor = typeof(ProxyBase).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Type.EmptyTypes, null);

	private static readonly ModuleBuilder proxyModule = CreateProxyModule();

	private static readonly Dictionary<Type, Type> proxyTypes = new Dictionary<Type, Type>();

	private static ModuleBuilder CreateProxyModule()
	{
		AssemblyName assemblyName = new AssemblyName("AutoMapper.Proxies");
		assemblyName.SetPublicKey(privateKey);
		assemblyName.SetPublicKeyToken(privateKeyToken);
		AssemblyBuilder assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
		return assemblyBuilder.DefineDynamicModule("AutoMapper.Proxies.emit");
	}

	private static Type CreateProxyType(Type interfaceType)
	{
		if (!interfaceType.IsInterface)
		{
			throw new ArgumentException("Only interfaces can be proxied", "interfaceType");
		}
		string name = string.Format("Proxy<{0}>", Regex.Replace(interfaceType.AssemblyQualifiedName ?? interfaceType.FullName ?? interfaceType.Name, "[\\s,]+", "_"));
		List<Type> list = new List<Type>();
		list.Add(interfaceType);
		List<Type> list2 = list;
		list2.AddRange(interfaceType.GetInterfaces());
		TypeBuilder typeBuilder = proxyModule.DefineType(name, TypeAttributes.Public | TypeAttributes.Sealed, typeof(ProxyBase), list2.ToArray());
		ConstructorBuilder constructorBuilder = typeBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, Type.EmptyTypes);
		ILGenerator iLGenerator = constructorBuilder.GetILGenerator();
		iLGenerator.Emit(OpCodes.Ldarg_0);
		iLGenerator.Emit(OpCodes.Call, proxyBase_ctor);
		iLGenerator.Emit(OpCodes.Ret);
		FieldBuilder fieldBuilder = null;
		if (typeof(INotifyPropertyChanged).IsAssignableFrom(interfaceType))
		{
			fieldBuilder = typeBuilder.DefineField("PropertyChanged", typeof(PropertyChangedEventHandler), FieldAttributes.Private);
			MethodBuilder methodBuilder = typeBuilder.DefineMethod("add_PropertyChanged", MethodAttributes.Public | MethodAttributes.Virtual | MethodAttributes.HideBySig | MethodAttributes.VtableLayoutMask | MethodAttributes.SpecialName, typeof(void), new Type[1] { typeof(PropertyChangedEventHandler) });
			ILGenerator iLGenerator2 = methodBuilder.GetILGenerator();
			iLGenerator2.Emit(OpCodes.Ldarg_0);
			iLGenerator2.Emit(OpCodes.Dup);
			iLGenerator2.Emit(OpCodes.Ldfld, fieldBuilder);
			iLGenerator2.Emit(OpCodes.Ldarg_1);
			iLGenerator2.Emit(OpCodes.Call, delegate_Combine);
			iLGenerator2.Emit(OpCodes.Castclass, typeof(PropertyChangedEventHandler));
			iLGenerator2.Emit(OpCodes.Stfld, fieldBuilder);
			iLGenerator2.Emit(OpCodes.Ret);
			MethodBuilder methodBuilder2 = typeBuilder.DefineMethod("remove_PropertyChanged", MethodAttributes.Public | MethodAttributes.Virtual | MethodAttributes.HideBySig | MethodAttributes.VtableLayoutMask | MethodAttributes.SpecialName, typeof(void), new Type[1] { typeof(PropertyChangedEventHandler) });
			ILGenerator iLGenerator3 = methodBuilder2.GetILGenerator();
			iLGenerator3.Emit(OpCodes.Ldarg_0);
			iLGenerator3.Emit(OpCodes.Dup);
			iLGenerator3.Emit(OpCodes.Ldfld, fieldBuilder);
			iLGenerator3.Emit(OpCodes.Ldarg_1);
			iLGenerator3.Emit(OpCodes.Call, delegate_Remove);
			iLGenerator3.Emit(OpCodes.Castclass, typeof(PropertyChangedEventHandler));
			iLGenerator3.Emit(OpCodes.Stfld, fieldBuilder);
			iLGenerator3.Emit(OpCodes.Ret);
			typeBuilder.DefineMethodOverride(methodBuilder, iNotifyPropertyChanged_PropertyChanged.GetAddMethod());
			typeBuilder.DefineMethodOverride(methodBuilder2, iNotifyPropertyChanged_PropertyChanged.GetRemoveMethod());
		}
		List<PropertyInfo> list3 = new List<PropertyInfo>();
		foreach (PropertyInfo item in list2.Where((Type intf) => intf != typeof(INotifyPropertyChanged)).SelectMany((Type intf) => intf.GetProperties()))
		{
			if (item.CanWrite)
			{
				list3.Insert(0, item);
			}
			else
			{
				list3.Add(item);
			}
		}
		Dictionary<string, PropertyEmitter> dictionary = new Dictionary<string, PropertyEmitter>();
		foreach (PropertyInfo item2 in list3)
		{
			if (dictionary.TryGetValue(item2.Name, out var value))
			{
				if (value.PropertyType != item2.PropertyType && (item2.CanWrite || !item2.PropertyType.IsAssignableFrom(value.PropertyType)))
				{
					throw new ArgumentException($"The interface has a conflicting property {item2.Name}", "interfaceType");
				}
			}
			else
			{
				dictionary.Add(item2.Name, value = new PropertyEmitter(typeBuilder, item2.Name, item2.PropertyType, fieldBuilder));
			}
			if (item2.CanRead)
			{
				typeBuilder.DefineMethodOverride(value.GetGetter(item2.PropertyType), item2.GetGetMethod());
			}
			if (item2.CanWrite)
			{
				typeBuilder.DefineMethodOverride(value.GetSetter(item2.PropertyType), item2.GetSetMethod());
			}
		}
		return typeBuilder.CreateType();
	}

	public Type GetProxyType(Type interfaceType)
	{
		if (interfaceType == null)
		{
			throw new ArgumentNullException("interfaceType");
		}
		lock (proxyTypes)
		{
			if (!proxyTypes.TryGetValue(interfaceType, out var value))
			{
				proxyTypes.Add(interfaceType, value = CreateProxyType(interfaceType));
			}
			return value;
		}
	}

	private static byte[] StringToByteArray(string hex)
	{
		int length = hex.Length;
		byte[] array = new byte[length / 2];
		for (int i = 0; i < length; i += 2)
		{
			array[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
		}
		return array;
	}
}
