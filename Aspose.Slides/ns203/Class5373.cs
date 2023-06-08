using System;
using System.Collections;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading;

namespace ns203;

internal class Class5373
{
	private const string string_0 = "Proxy";

	private const string string_1 = "ProxyAssembly";

	private const string string_2 = "ProxyModule";

	private const string string_3 = "handler";

	private static Class5373 class5373_0;

	private static object object_0;

	private Hashtable hashtable_0 = Hashtable.Synchronized(new Hashtable());

	private static readonly Hashtable hashtable_1;

	static Class5373()
	{
		object_0 = new object();
		hashtable_1 = new Hashtable();
		hashtable_1.Add(typeof(bool), OpCodes.Ldind_I1);
		hashtable_1.Add(typeof(short), OpCodes.Ldind_I2);
		hashtable_1.Add(typeof(int), OpCodes.Ldind_I4);
		hashtable_1.Add(typeof(long), OpCodes.Ldind_I8);
		hashtable_1.Add(typeof(double), OpCodes.Ldind_R8);
		hashtable_1.Add(typeof(float), OpCodes.Ldind_R4);
		hashtable_1.Add(typeof(ushort), OpCodes.Ldind_U2);
		hashtable_1.Add(typeof(uint), OpCodes.Ldind_U4);
	}

	private Class5373()
	{
	}

	public static Class5373 smethod_0()
	{
		if (class5373_0 == null)
		{
			smethod_1();
		}
		return class5373_0;
	}

	private static void smethod_1()
	{
		lock (object_0)
		{
			if (class5373_0 == null)
			{
				class5373_0 = new Class5373();
			}
		}
	}

	public object method_0(Interface178 handler, Type objType, bool isObjInterface)
	{
		string text = objType.FullName + "Proxy";
		Type type = (Type)hashtable_0[text];
		if (type == null)
		{
			type = ((!isObjInterface) ? method_2(handler, objType.GetInterfaces(), text) : method_2(handler, new Type[1] { objType }, text));
			hashtable_0.Add(text, type);
		}
		return Activator.CreateInstance(type, handler);
	}

	public object method_1(Interface178 handler, Type objType)
	{
		return method_0(handler, objType, isObjInterface: false);
	}

	private Type method_2(Interface178 handler, Type[] interfaces, string dynamicTypeName)
	{
		Type result = null;
		if (handler != null && interfaces != null)
		{
			Type typeFromHandle = typeof(object);
			Type typeFromHandle2 = typeof(Interface178);
			AppDomain domain = Thread.GetDomain();
			AssemblyName assemblyName = new AssemblyName();
			assemblyName.Name = "ProxyAssembly";
			assemblyName.Version = new Version(1, 0, 0, 0);
			AssemblyBuilder assemblyBuilder = domain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
			ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("ProxyModule");
			TypeBuilder typeBuilder = moduleBuilder.DefineType(dynamicTypeName, TypeAttributes.Public | TypeAttributes.Sealed, typeFromHandle, interfaces);
			FieldBuilder fieldBuilder = typeBuilder.DefineField("handler", typeFromHandle2, FieldAttributes.Private);
			ConstructorInfo constructor = typeFromHandle.GetConstructor(new Type[0]);
			ConstructorBuilder constructorBuilder = typeBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, new Type[1] { typeFromHandle2 });
			ILGenerator iLGenerator = constructorBuilder.GetILGenerator();
			iLGenerator.Emit(OpCodes.Ldarg_0);
			iLGenerator.Emit(OpCodes.Ldarg_1);
			iLGenerator.Emit(OpCodes.Stfld, fieldBuilder);
			iLGenerator.Emit(OpCodes.Ldarg_0);
			iLGenerator.Emit(OpCodes.Call, constructor);
			iLGenerator.Emit(OpCodes.Ret);
			foreach (Type interfaceType in interfaces)
			{
				method_3(interfaceType, fieldBuilder, typeBuilder);
			}
			result = typeBuilder.CreateType();
		}
		return result;
	}

	private void method_3(Type interfaceType, FieldBuilder handlerField, TypeBuilder typeBuilder)
	{
		Class5372.Add(interfaceType);
		MethodInfo[] methods = interfaceType.GetMethods();
		if (methods != null)
		{
			for (int i = 0; i < methods.Length; i++)
			{
				MethodInfo methodInfo = methods[i];
				ParameterInfo[] parameters = methodInfo.GetParameters();
				int num = parameters.Length;
				Type[] array = new Type[num];
				for (int j = 0; j < num; j++)
				{
					array[j] = parameters[j].ParameterType;
				}
				MethodBuilder methodBuilder = typeBuilder.DefineMethod(methodInfo.Name, MethodAttributes.Public | MethodAttributes.Virtual, CallingConventions.Standard, methodInfo.ReturnType, array);
				ILGenerator iLGenerator = methodBuilder.GetILGenerator();
				if (!methodInfo.ReturnType.Equals(typeof(void)))
				{
					iLGenerator.DeclareLocal(methodInfo.ReturnType);
					if (methodInfo.ReturnType.IsValueType && !methodInfo.ReturnType.IsPrimitive)
					{
						iLGenerator.DeclareLocal(methodInfo.ReturnType);
					}
				}
				if (num > 0)
				{
					iLGenerator.DeclareLocal(typeof(object[]));
				}
				Label label = iLGenerator.DefineLabel();
				Label label2 = iLGenerator.DefineLabel();
				iLGenerator.Emit(OpCodes.Ldarg_0);
				iLGenerator.Emit(OpCodes.Ldfld, handlerField);
				iLGenerator.Emit(OpCodes.Brtrue_S, label);
				if (!methodInfo.ReturnType.Equals(typeof(void)))
				{
					if (methodInfo.ReturnType.IsValueType && !methodInfo.ReturnType.IsPrimitive && !methodInfo.ReturnType.IsEnum)
					{
						iLGenerator.Emit(OpCodes.Ldloc_1);
					}
					else
					{
						iLGenerator.Emit(OpCodes.Ldnull);
					}
					iLGenerator.Emit(OpCodes.Stloc_0);
					iLGenerator.Emit(OpCodes.Br_S, label2);
				}
				iLGenerator.MarkLabel(label);
				iLGenerator.Emit(OpCodes.Ldarg_0);
				iLGenerator.Emit(OpCodes.Ldfld, handlerField);
				iLGenerator.Emit(OpCodes.Ldarg_0);
				iLGenerator.Emit(OpCodes.Ldstr, interfaceType.FullName);
				iLGenerator.Emit(OpCodes.Ldc_I4, i);
				iLGenerator.Emit(OpCodes.Call, typeof(Class5372).GetMethod("GetMethod", new Type[2]
				{
					typeof(string),
					typeof(int)
				}));
				iLGenerator.Emit(OpCodes.Ldc_I4, num);
				iLGenerator.Emit(OpCodes.Newarr, typeof(object));
				if (num > 0)
				{
					iLGenerator.Emit(OpCodes.Stloc_1);
					for (int k = 0; k < num; k++)
					{
						iLGenerator.Emit(OpCodes.Ldloc_1);
						iLGenerator.Emit(OpCodes.Ldc_I4, k);
						iLGenerator.Emit(OpCodes.Ldarg, k + 1);
						if (array[k].IsValueType)
						{
							iLGenerator.Emit(OpCodes.Box, array[k]);
						}
						iLGenerator.Emit(OpCodes.Stelem_Ref);
					}
					iLGenerator.Emit(OpCodes.Ldloc_1);
				}
				iLGenerator.Emit(OpCodes.Callvirt, typeof(Interface178).GetMethod("Invoke"));
				if (!methodInfo.ReturnType.Equals(typeof(void)))
				{
					if (methodInfo.ReturnType.IsValueType)
					{
						iLGenerator.Emit(OpCodes.Unbox, methodInfo.ReturnType);
						if (methodInfo.ReturnType.IsEnum)
						{
							iLGenerator.Emit(OpCodes.Ldind_I4);
						}
						else if (!methodInfo.ReturnType.IsPrimitive)
						{
							iLGenerator.Emit(OpCodes.Ldobj, methodInfo.ReturnType);
						}
						else
						{
							iLGenerator.Emit((OpCode)hashtable_1[methodInfo.ReturnType]);
						}
					}
					iLGenerator.Emit(OpCodes.Stloc_0);
					iLGenerator.Emit(OpCodes.Br_S, label2);
					iLGenerator.MarkLabel(label2);
					iLGenerator.Emit(OpCodes.Ldloc_0);
				}
				else
				{
					iLGenerator.Emit(OpCodes.Pop);
					iLGenerator.MarkLabel(label2);
				}
				iLGenerator.Emit(OpCodes.Ret);
			}
		}
		Type[] interfaces = interfaceType.GetInterfaces();
		foreach (Type interfaceType2 in interfaces)
		{
			method_3(interfaceType2, handlerField, typeBuilder);
		}
	}
}
