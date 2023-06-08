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
/// Represents the implementation of a method override.
/// </summary>
public class MethodOverride
{
	private static MethodInfo BuildAbstractMethodInvokedExceptionMethod = StaticReflection.GetMethodInfo(() => BuildAbstractMethodInvokedException());

	private readonly TypeBuilder typeBuilder;

	private readonly MethodInfo methodToOverride;

	private readonly ParameterInfo[] methodParameters;

	private readonly FieldBuilder proxyInterceptionPipelineField;

	private readonly Type targetType;

	private readonly GenericParameterMapper targetTypeParameterMapper;

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

	private Type ReturnType => methodToOverride.ReturnType;

	private IEnumerable<int> OutputParameterIndices
	{
		get
		{
			for (int i = 0; i < methodParameters.Length; i++)
			{
				if (methodParameters[i].ParameterType.IsByRef)
				{
					yield return i;
				}
			}
		}
	}

	internal MethodOverride(TypeBuilder typeBuilder, FieldBuilder proxyInterceptionPipelineField, MethodInfo methodToOverride, Type targetType, GenericParameterMapper targetTypeParameterMapper, int overrideCount)
	{
		this.typeBuilder = typeBuilder;
		this.proxyInterceptionPipelineField = proxyInterceptionPipelineField;
		this.methodToOverride = methodToOverride;
		methodParameters = methodToOverride.GetParameters();
		this.targetType = targetType;
		Type declaringType = methodToOverride.DeclaringType;
		this.targetTypeParameterMapper = ((declaringType.IsGenericType && declaringType != methodToOverride.ReflectedType) ? new GenericParameterMapper(declaringType, targetTypeParameterMapper) : targetTypeParameterMapper);
		this.overrideCount = overrideCount;
	}

	internal static bool MethodCanBeIntercepted(MethodInfo method)
	{
		if (method != null && (method.IsPublic || method.IsFamily || method.IsFamilyOrAssembly) && method.IsVirtual && !method.IsFinal)
		{
			return method.DeclaringType != typeof(object);
		}
		return false;
	}

	internal MethodBuilder AddMethod()
	{
		MethodBuilder delegateMethod = CreateDelegateImplementation(methodToOverride);
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

	private static void EmitUnboxOrCast(ILGenerator il, Type typeOnStack)
	{
		if (typeOnStack.IsValueType || typeOnStack.IsGenericParameter)
		{
			il.Emit(OpCodes.Unbox_Any, typeOnStack);
		}
		else
		{
			il.Emit(OpCodes.Castclass, typeOnStack);
		}
	}

	private MethodBuilder CreateDelegateImplementation(MethodInfo callBaseMethod)
	{
		string name = CreateMethodName("DelegateImplementation");
		MethodBuilder methodBuilder = typeBuilder.DefineMethod(name, MethodAttributes.Private | MethodAttributes.HideBySig);
		List<LocalBuilder> list = new List<LocalBuilder>();
		MethodOverrideParameterMapper methodOverrideParameterMapper = new MethodOverrideParameterMapper(methodToOverride);
		methodOverrideParameterMapper.SetupParameters(methodBuilder, targetTypeParameterMapper);
		methodBuilder.SetReturnType(typeof(IMethodReturn));
		methodBuilder.SetParameters(typeof(IMethodInvocation), typeof(GetNextInterceptionBehaviorDelegate));
		methodBuilder.DefineParameter(1, ParameterAttributes.None, "inputs");
		methodBuilder.DefineParameter(2, ParameterAttributes.None, "getNext");
		methodBuilder.SetCustomAttribute(new CustomAttributeBuilder(CompilerGeneratedAttributeMethods.CompilerGeneratedAttribute, new object[0]));
		ILGenerator iLGenerator = methodBuilder.GetILGenerator();
		if (!methodToOverride.IsAbstract)
		{
			Label loc = iLGenerator.DefineLabel();
			LocalBuilder local = iLGenerator.DeclareLocal(typeof(Exception));
			LocalBuilder local2 = null;
			LocalBuilder local3 = null;
			if (MethodHasReturnValue)
			{
				local2 = iLGenerator.DeclareLocal(methodOverrideParameterMapper.GetParameterType(methodToOverride.ReturnType));
			}
			LocalBuilder local4 = iLGenerator.DeclareLocal(typeof(IMethodReturn));
			iLGenerator.BeginExceptionBlock();
			iLGenerator.Emit(OpCodes.Ldarg_0);
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
					if (methodParameters[i].ParameterType.IsByRef)
					{
						Type elementType = methodOverrideParameterMapper.GetElementType(methodParameters[i].ParameterType);
						LocalBuilder localBuilder = iLGenerator.DeclareLocal(elementType);
						list.Add(localBuilder);
						EmitUnboxOrCast(iLGenerator, elementType);
						iLGenerator.Emit(OpCodes.Stloc, localBuilder);
						iLGenerator.Emit(OpCodes.Ldloca, localBuilder);
					}
					else
					{
						EmitUnboxOrCast(iLGenerator, methodOverrideParameterMapper.GetParameterType(methodParameters[i].ParameterType));
					}
				}
			}
			MethodInfo methodInfo = callBaseMethod;
			if (methodInfo.IsGenericMethod)
			{
				methodInfo = callBaseMethod.MakeGenericMethod(methodOverrideParameterMapper.GenericMethodParameters);
			}
			iLGenerator.Emit(OpCodes.Call, methodInfo);
			if (MethodHasReturnValue)
			{
				iLGenerator.Emit(OpCodes.Stloc, local2);
			}
			iLGenerator.Emit(OpCodes.Ldarg_1);
			if (MethodHasReturnValue)
			{
				iLGenerator.Emit(OpCodes.Ldloc, local2);
				if (ReturnType.IsValueType || ReturnType.IsGenericParameter)
				{
					iLGenerator.Emit(OpCodes.Box, methodOverrideParameterMapper.GetReturnType());
				}
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
					if (methodParameters[j].ParameterType.IsByRef)
					{
						iLGenerator.Emit(OpCodes.Ldloc, list[num]);
						EmitBox(iLGenerator, list[num].LocalType);
						num++;
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
			iLGenerator.EmitCall(OpCodes.Call, BuildAbstractMethodInvokedExceptionMethod, null);
			iLGenerator.EmitCall(OpCodes.Callvirt, IMethodInvocationMethods.CreateExceptionMethodReturn, null);
			iLGenerator.Emit(OpCodes.Ret);
		}
		return methodBuilder;
	}

	private MethodBuilder CreateMethodOverride(MethodBuilder delegateMethod)
	{
		MethodAttributes attributes = methodToOverride.Attributes & ~MethodAttributes.VtableLayoutMask & ~MethodAttributes.Abstract;
		MethodBuilder methodBuilder = typeBuilder.DefineMethod(methodToOverride.Name, attributes);
		MethodOverrideParameterMapper paramMapper = new MethodOverrideParameterMapper(methodToOverride);
		paramMapper.SetupParameters(methodBuilder, targetTypeParameterMapper);
		methodBuilder.SetReturnType(paramMapper.GetParameterType(methodToOverride.ReturnType));
		methodBuilder.SetParameters(methodParameters.Select((ParameterInfo pi) => paramMapper.GetParameterType(pi.ParameterType)).ToArray());
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
		iLGenerator.Emit(OpCodes.Ldtoken, methodToOverride.IsGenericMethodDefinition ? methodToOverride.MakeGenericMethod(paramMapper.GenericMethodParameters) : methodToOverride);
		if (methodToOverride.DeclaringType.IsGenericType)
		{
			iLGenerator.Emit(OpCodes.Ldtoken, targetType);
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
				if (methodParameters[j].ParameterType.IsValueType || methodParameters[j].ParameterType.IsGenericParameter)
				{
					iLGenerator.Emit(OpCodes.Box, paramMapper.GetParameterType(methodParameters[j].ParameterType));
				}
				else if (methodParameters[j].ParameterType.IsByRef)
				{
					Type elementType = paramMapper.GetElementType(methodParameters[j].ParameterType);
					iLGenerator.Emit(OpCodes.Ldobj, elementType);
					if (elementType.IsValueType || elementType.IsGenericParameter)
					{
						iLGenerator.Emit(OpCodes.Box, elementType);
					}
				}
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
		MethodInfo meth = delegateMethod;
		if (delegateMethod.IsGenericMethod)
		{
			meth = delegateMethod.MakeGenericMethod(paramMapper.GenericMethodParameters);
		}
		iLGenerator.Emit(OpCodes.Ldftn, meth);
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
		if (MethodHasReturnValue)
		{
			iLGenerator.Emit(OpCodes.Ldloc, local);
			iLGenerator.EmitCall(OpCodes.Callvirt, IMethodReturnMethods.GetReturnValue, null);
			if (ReturnType.IsValueType || ReturnType.IsGenericParameter)
			{
				iLGenerator.Emit(OpCodes.Unbox_Any, paramMapper.GetReturnType());
			}
			else
			{
				iLGenerator.Emit(OpCodes.Castclass, paramMapper.GetReturnType());
			}
		}
		if (methodParameters.Length > 0)
		{
			int num2 = 0;
			foreach (int outputParameterIndex in OutputParameterIndices)
			{
				Type elementType2 = paramMapper.GetElementType(methodParameters[outputParameterIndex].ParameterType);
				EmitLoadArgument(iLGenerator, outputParameterIndex);
				iLGenerator.Emit(OpCodes.Ldloc, local);
				iLGenerator.Emit(OpCodes.Callvirt, IMethodReturnMethods.GetOutputs);
				EmitLoadConstant(iLGenerator, num2);
				iLGenerator.Emit(OpCodes.Callvirt, IListMethods.GetItem);
				EmitUnboxOrCast(iLGenerator, elementType2);
				iLGenerator.Emit(OpCodes.Stobj, elementType2);
				num2++;
			}
		}
		iLGenerator.Emit(OpCodes.Ret);
		return methodBuilder;
	}

	/// <summary>
	/// Used to throw an <see cref="T:System.NotImplementedException" /> for overrides on abstract methods.
	/// </summary>
	public static Exception BuildAbstractMethodInvokedException()
	{
		return new NotImplementedException(Resources.ExceptionAbstractMethodNotImplemented);
	}
}
