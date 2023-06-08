using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using Microsoft.Practices.Unity.InterceptionExtension.Properties;
using Microsoft.Practices.Unity.Utility;

namespace Microsoft.Practices.Unity.InterceptionExtension;

/// <summary>
/// Represents the implementation of an interface method.
/// </summary>
public class InterfaceMethodOverride
{
	private const MethodAttributes implicitImplementationAttributes = MethodAttributes.Public | MethodAttributes.Final | MethodAttributes.Virtual | MethodAttributes.HideBySig | MethodAttributes.VtableLayoutMask;

	private const MethodAttributes explicitImplementationAttributes = MethodAttributes.Private | MethodAttributes.Final | MethodAttributes.Virtual | MethodAttributes.HideBySig | MethodAttributes.VtableLayoutMask;

	private static MethodInfo BuildAdditionalInterfaceNonImplementedExceptionMethod = StaticReflection.GetMethodInfo(() => BuildAdditionalInterfaceNonImplementedException());

	private readonly TypeBuilder typeBuilder;

	private readonly MethodInfo methodToOverride;

	private readonly ParameterInfo[] methodParameters;

	private readonly FieldBuilder proxyInterceptionPipelineField;

	private readonly bool explicitImplementation;

	private readonly FieldBuilder targetField;

	private readonly Type targetInterface;

	private readonly GenericParameterMapper targetInterfaceParameterMapper;

	private readonly int overrideCount;

	private static readonly OpCode[] loadArgsOpcodes = new OpCode[3]
	{
		OpCodes.Ldarg_1,
		OpCodes.Ldarg_2,
		OpCodes.Ldarg_3
	};

	private static readonly OpCode[] loadConstOpCodes = new OpCode[9]
	{
		OpCodes.Ldc_I4_0,
		OpCodes.Ldc_I4_1,
		OpCodes.Ldc_I4_2,
		OpCodes.Ldc_I4_3,
		OpCodes.Ldc_I4_4,
		OpCodes.Ldc_I4_5,
		OpCodes.Ldc_I4_6,
		OpCodes.Ldc_I4_7,
		OpCodes.Ldc_I4_8
	};

	private bool MethodHasReturnValue => methodToOverride.ReturnType != typeof(void);

	internal InterfaceMethodOverride(TypeBuilder typeBuilder, FieldBuilder proxyInterceptionPipelineField, FieldBuilder targetField, MethodInfo methodToOverride, Type targetInterface, GenericParameterMapper targetInterfaceParameterMapper, bool explicitImplementation, int overrideCount)
	{
		this.typeBuilder = typeBuilder;
		this.proxyInterceptionPipelineField = proxyInterceptionPipelineField;
		this.explicitImplementation = explicitImplementation;
		this.targetField = targetField;
		this.methodToOverride = methodToOverride;
		this.targetInterface = targetInterface;
		this.targetInterfaceParameterMapper = targetInterfaceParameterMapper;
		methodParameters = methodToOverride.GetParameters();
		this.overrideCount = overrideCount;
	}

	internal MethodBuilder AddMethod()
	{
		MethodBuilder delegateMethod = CreateDelegateImplementation();
		return CreateMethodOverride(delegateMethod);
	}

	private string CreateMethodName(string purpose)
	{
		return "<" + methodToOverride.Name + "_" + purpose + ">__" + overrideCount.ToString(CultureInfo.InvariantCulture);
	}

	private static void EmitLoadArgument(ILGenerator il, int argumentNumber)
	{
		if (argumentNumber < loadArgsOpcodes.Length)
		{
			il.Emit(loadArgsOpcodes[argumentNumber]);
		}
		else
		{
			il.Emit(OpCodes.Ldarg, argumentNumber + 1);
		}
	}

	private static void EmitLoadConstant(ILGenerator il, int i)
	{
		if (i < loadConstOpCodes.Length)
		{
			il.Emit(loadConstOpCodes[i]);
		}
		else
		{
			il.Emit(OpCodes.Ldc_I4, i);
		}
	}

	private static void EmitBox(ILGenerator il, Type typeOnStack)
	{
		if (typeOnStack.IsValueType || typeOnStack.IsGenericParameter)
		{
			il.Emit(OpCodes.Box, typeOnStack);
		}
	}

	private static void EmitUnboxOrCast(ILGenerator il, Type targetType)
	{
		if (targetType.IsValueType || targetType.IsGenericParameter)
		{
			il.Emit(OpCodes.Unbox_Any, targetType);
		}
		else
		{
			il.Emit(OpCodes.Castclass, targetType);
		}
	}

	private MethodBuilder CreateDelegateImplementation()
	{
		string name = CreateMethodName("DelegateImplementation");
		MethodBuilder methodBuilder = typeBuilder.DefineMethod(name, MethodAttributes.Private | MethodAttributes.HideBySig);
		List<LocalBuilder> list = new List<LocalBuilder>();
		MethodOverrideParameterMapper methodOverrideParameterMapper = new MethodOverrideParameterMapper(methodToOverride);
		methodOverrideParameterMapper.SetupParameters(methodBuilder, targetInterfaceParameterMapper);
		methodBuilder.SetReturnType(typeof(IMethodReturn));
		methodBuilder.SetParameters(typeof(IMethodInvocation), typeof(GetNextInterceptionBehaviorDelegate));
		methodBuilder.DefineParameter(1, ParameterAttributes.None, "inputs");
		methodBuilder.DefineParameter(2, ParameterAttributes.None, "getNext");
		methodBuilder.SetCustomAttribute(new CustomAttributeBuilder(CompilerGeneratedAttributeMethods.CompilerGeneratedAttribute, new object[0]));
		ILGenerator iLGenerator = methodBuilder.GetILGenerator();
		if (targetField != null)
		{
			Label loc = iLGenerator.DefineLabel();
			LocalBuilder local = iLGenerator.DeclareLocal(typeof(Exception));
			LocalBuilder local2 = null;
			LocalBuilder local3 = null;
			if (MethodHasReturnValue)
			{
				local2 = iLGenerator.DeclareLocal(methodOverrideParameterMapper.GetReturnType());
			}
			LocalBuilder local4 = iLGenerator.DeclareLocal(typeof(IMethodReturn));
			iLGenerator.BeginExceptionBlock();
			iLGenerator.Emit(OpCodes.Ldarg_0);
			iLGenerator.Emit(OpCodes.Ldfld, targetField);
			if (methodParameters.Length > 0)
			{
				local3 = iLGenerator.DeclareLocal(typeof(IParameterCollection));
				iLGenerator.Emit(OpCodes.Ldarg_1);
				iLGenerator.EmitCall(OpCodes.Callvirt, IMethodInvocationMethods.GetArguments, null);
				iLGenerator.Emit(OpCodes.Stloc, local3);
				for (int i = 0; i < methodParameters.Length; i++)
				{
					iLGenerator.Emit(OpCodes.Ldloc, local3);
					EmitLoadConstant(iLGenerator, i);
					iLGenerator.EmitCall(OpCodes.Callvirt, IListMethods.GetItem, null);
					Type parameterType = methodOverrideParameterMapper.GetParameterType(methodParameters[i].ParameterType);
					if (parameterType.IsByRef)
					{
						Type elementType = parameterType.GetElementType();
						LocalBuilder localBuilder = iLGenerator.DeclareLocal(elementType);
						list.Add(localBuilder);
						EmitUnboxOrCast(iLGenerator, elementType);
						iLGenerator.Emit(OpCodes.Stloc, localBuilder);
						iLGenerator.Emit(OpCodes.Ldloca, localBuilder);
					}
					else
					{
						EmitUnboxOrCast(iLGenerator, parameterType);
					}
				}
			}
			MethodInfo methodInfo = methodToOverride;
			if (methodInfo.IsGenericMethod)
			{
				methodInfo = methodToOverride.MakeGenericMethod(methodOverrideParameterMapper.GenericMethodParameters);
			}
			iLGenerator.Emit(OpCodes.Callvirt, methodInfo);
			if (MethodHasReturnValue)
			{
				iLGenerator.Emit(OpCodes.Stloc, local2);
			}
			iLGenerator.Emit(OpCodes.Ldarg_1);
			if (MethodHasReturnValue)
			{
				iLGenerator.Emit(OpCodes.Ldloc, local2);
				EmitBox(iLGenerator, methodOverrideParameterMapper.GetReturnType());
			}
			else
			{
				iLGenerator.Emit(OpCodes.Ldnull);
			}
			EmitLoadConstant(iLGenerator, methodParameters.Length);
			iLGenerator.Emit(OpCodes.Newarr, typeof(object));
			if (methodParameters.Length > 0)
			{
				LocalBuilder local5 = iLGenerator.DeclareLocal(typeof(object[]));
				iLGenerator.Emit(OpCodes.Stloc, local5);
				int num = 0;
				for (int j = 0; j < methodParameters.Length; j++)
				{
					iLGenerator.Emit(OpCodes.Ldloc, local5);
					EmitLoadConstant(iLGenerator, j);
					Type parameterType2 = methodOverrideParameterMapper.GetParameterType(methodParameters[j].ParameterType);
					if (parameterType2.IsByRef)
					{
						parameterType2 = parameterType2.GetElementType();
						iLGenerator.Emit(OpCodes.Ldloc, list[num++]);
						EmitBox(iLGenerator, parameterType2);
					}
					else
					{
						iLGenerator.Emit(OpCodes.Ldloc, local3);
						EmitLoadConstant(iLGenerator, j);
						iLGenerator.Emit(OpCodes.Callvirt, IListMethods.GetItem);
					}
					iLGenerator.Emit(OpCodes.Stelem_Ref);
				}
				iLGenerator.Emit(OpCodes.Ldloc, local5);
			}
			iLGenerator.Emit(OpCodes.Callvirt, IMethodInvocationMethods.CreateReturn);
			iLGenerator.Emit(OpCodes.Stloc, local4);
			iLGenerator.BeginCatchBlock(typeof(Exception));
			iLGenerator.Emit(OpCodes.Stloc, local);
			iLGenerator.Emit(OpCodes.Ldarg_1);
			iLGenerator.Emit(OpCodes.Ldloc, local);
			iLGenerator.EmitCall(OpCodes.Callvirt, IMethodInvocationMethods.CreateExceptionMethodReturn, null);
			iLGenerator.Emit(OpCodes.Stloc, local4);
			iLGenerator.EndExceptionBlock();
			iLGenerator.MarkLabel(loc);
			iLGenerator.Emit(OpCodes.Ldloc, local4);
			iLGenerator.Emit(OpCodes.Ret);
		}
		else
		{
			iLGenerator.Emit(OpCodes.Ldarg_1);
			iLGenerator.EmitCall(OpCodes.Call, BuildAdditionalInterfaceNonImplementedExceptionMethod, null);
			iLGenerator.EmitCall(OpCodes.Callvirt, IMethodInvocationMethods.CreateExceptionMethodReturn, null);
			iLGenerator.Emit(OpCodes.Ret);
		}
		return methodBuilder;
	}

	private MethodBuilder CreateMethodOverride(MethodBuilder delegateMethod)
	{
		string name = (explicitImplementation ? (methodToOverride.DeclaringType.Name + "." + methodToOverride.Name) : methodToOverride.Name);
		MethodBuilder methodBuilder = typeBuilder.DefineMethod(name, explicitImplementation ? (MethodAttributes.Private | MethodAttributes.Final | MethodAttributes.Virtual | MethodAttributes.HideBySig | MethodAttributes.VtableLayoutMask) : (MethodAttributes.Public | MethodAttributes.Final | MethodAttributes.Virtual | MethodAttributes.HideBySig | MethodAttributes.VtableLayoutMask));
		MethodOverrideParameterMapper paramMapper = new MethodOverrideParameterMapper(methodToOverride);
		paramMapper.SetupParameters(methodBuilder, targetInterfaceParameterMapper);
		methodBuilder.SetReturnType(paramMapper.GetReturnType());
		methodBuilder.SetParameters(methodParameters.Select((ParameterInfo pi) => paramMapper.GetParameterType(pi.ParameterType)).ToArray());
		if (explicitImplementation)
		{
			typeBuilder.DefineMethodOverride(methodBuilder, methodToOverride);
		}
		int num = 1;
		ParameterInfo[] array = methodParameters;
		foreach (ParameterInfo parameterInfo in array)
		{
			methodBuilder.DefineParameter(num++, parameterInfo.Attributes, parameterInfo.Name);
		}
		ILGenerator iLGenerator = methodBuilder.GetILGenerator();
		LocalBuilder local = iLGenerator.DeclareLocal(typeof(IMethodReturn));
		LocalBuilder local2 = iLGenerator.DeclareLocal(typeof(Exception));
		LocalBuilder local3 = iLGenerator.DeclareLocal(typeof(object[]));
		LocalBuilder local4 = iLGenerator.DeclareLocal(typeof(VirtualMethodInvocation));
		iLGenerator.Emit(OpCodes.Ldarg_0);
		if (targetField != null)
		{
			iLGenerator.Emit(OpCodes.Ldfld, targetField);
		}
		iLGenerator.Emit(OpCodes.Ldtoken, methodToOverride.IsGenericMethodDefinition ? methodToOverride.MakeGenericMethod(paramMapper.GenericMethodParameters) : methodToOverride);
		if (methodToOverride.DeclaringType.IsGenericType)
		{
			iLGenerator.Emit(OpCodes.Ldtoken, targetInterface);
			iLGenerator.Emit(OpCodes.Call, MethodBaseMethods.GetMethodForGenericFromHandle);
		}
		else
		{
			iLGenerator.Emit(OpCodes.Call, MethodBaseMethods.GetMethodFromHandle);
		}
		EmitLoadConstant(iLGenerator, methodParameters.Length);
		iLGenerator.Emit(OpCodes.Newarr, typeof(object));
		if (methodParameters.Length > 0)
		{
			iLGenerator.Emit(OpCodes.Stloc, local3);
			for (int j = 0; j < methodParameters.Length; j++)
			{
				iLGenerator.Emit(OpCodes.Ldloc, local3);
				EmitLoadConstant(iLGenerator, j);
				EmitLoadArgument(iLGenerator, j);
				Type type = paramMapper.GetParameterType(methodParameters[j].ParameterType);
				if (type.IsByRef)
				{
					type = paramMapper.GetElementType(methodParameters[j].ParameterType);
					iLGenerator.Emit(OpCodes.Ldobj, type);
				}
				EmitBox(iLGenerator, type);
				iLGenerator.Emit(OpCodes.Stelem_Ref);
			}
			iLGenerator.Emit(OpCodes.Ldloc, local3);
		}
		iLGenerator.Emit(OpCodes.Newobj, VirtualMethodInvocationMethods.VirtualMethodInvocation);
		iLGenerator.Emit(OpCodes.Stloc, local4);
		iLGenerator.Emit(OpCodes.Ldarg_0);
		iLGenerator.Emit(OpCodes.Ldfld, proxyInterceptionPipelineField);
		iLGenerator.Emit(OpCodes.Ldloc, local4);
		iLGenerator.Emit(OpCodes.Ldarg_0);
		MethodInfo methodInfo = delegateMethod;
		if (methodInfo.IsGenericMethod)
		{
			methodInfo = delegateMethod.MakeGenericMethod(paramMapper.GenericMethodParameters);
		}
		iLGenerator.Emit(OpCodes.Ldftn, methodInfo);
		iLGenerator.Emit(OpCodes.Newobj, InvokeInterceptionBehaviorDelegateMethods.InvokeInterceptionBehaviorDelegate);
		iLGenerator.Emit(OpCodes.Call, InterceptionBehaviorPipelineMethods.Invoke);
		iLGenerator.Emit(OpCodes.Stloc, local);
		Label label = iLGenerator.DefineLabel();
		iLGenerator.Emit(OpCodes.Ldloc, local);
		iLGenerator.EmitCall(OpCodes.Callvirt, IMethodReturnMethods.GetException, null);
		iLGenerator.Emit(OpCodes.Stloc, local2);
		iLGenerator.Emit(OpCodes.Ldloc, local2);
		iLGenerator.Emit(OpCodes.Ldnull);
		iLGenerator.Emit(OpCodes.Ceq);
		iLGenerator.Emit(OpCodes.Brtrue_S, label);
		iLGenerator.Emit(OpCodes.Ldloc, local2);
		iLGenerator.Emit(OpCodes.Throw);
		iLGenerator.MarkLabel(label);
		if (methodParameters.Length > 0)
		{
			int num2 = 0;
			for (num = 0; num < methodParameters.Length; num++)
			{
				ParameterInfo parameterInfo2 = methodParameters[num];
				if (parameterInfo2.ParameterType.IsByRef)
				{
					EmitLoadArgument(iLGenerator, num);
					iLGenerator.Emit(OpCodes.Ldloc, local);
					iLGenerator.Emit(OpCodes.Callvirt, IMethodReturnMethods.GetOutputs);
					EmitLoadConstant(iLGenerator, num2++);
					iLGenerator.Emit(OpCodes.Callvirt, IListMethods.GetItem);
					EmitUnboxOrCast(iLGenerator, paramMapper.GetElementType(parameterInfo2.ParameterType));
					iLGenerator.Emit(OpCodes.Stobj, paramMapper.GetElementType(parameterInfo2.ParameterType));
				}
			}
		}
		if (MethodHasReturnValue)
		{
			iLGenerator.Emit(OpCodes.Ldloc, local);
			iLGenerator.EmitCall(OpCodes.Callvirt, IMethodReturnMethods.GetReturnValue, null);
			EmitUnboxOrCast(iLGenerator, paramMapper.GetReturnType());
		}
		iLGenerator.Emit(OpCodes.Ret);
		return methodBuilder;
	}

	/// <summary>
	/// Used to throw an <see cref="T:System.NotImplementedException" /> for non-implemented methods on the
	/// additional interfaces.
	/// </summary>
	public static Exception BuildAdditionalInterfaceNonImplementedException()
	{
		return new NotImplementedException(Resources.ExceptionAdditionalInterfaceNotImplemented);
	}
}
