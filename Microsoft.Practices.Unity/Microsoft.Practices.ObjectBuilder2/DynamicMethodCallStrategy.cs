using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using Microsoft.Practices.Unity.Properties;
using Microsoft.Practices.Unity.Utility;

namespace Microsoft.Practices.ObjectBuilder2;

/// <summary>
/// A <see cref="T:Microsoft.Practices.ObjectBuilder2.BuilderStrategy" /> that generates IL to call
/// chosen methods (as specified by the current <see cref="T:Microsoft.Practices.ObjectBuilder2.IMethodSelectorPolicy" />)
/// as part of object build up.
/// </summary>
public class DynamicMethodCallStrategy : BuilderStrategy
{
	private static readonly MethodInfo setCurrentOperationToResolvingParameter = StaticReflection.GetMethodInfo(() => SetCurrentOperationToResolvingParameter(null, null, null));

	private static readonly MethodInfo setCurrentOperationToInvokingMethod = StaticReflection.GetMethodInfo(() => SetCurrentOperationToInvokingMethod(null, null));

	/// <summary>
	/// Called during the chain of responsibility for a build operation. The
	/// PreBuildUp method is called when the chain is being executed in the
	/// forward direction.
	/// </summary>
	/// <param name="context">Context of the build operation.</param>
	public override void PreBuildUp(IBuilderContext context)
	{
		DynamicBuildPlanGenerationContext dynamicBuildPlanGenerationContext = (DynamicBuildPlanGenerationContext)context.Existing;
		IPolicyList containingPolicyList;
		IMethodSelectorPolicy methodSelectorPolicy = context.Policies.Get<IMethodSelectorPolicy>(context.BuildKey, out containingPolicyList);
		bool flag = false;
		foreach (SelectedMethod item in methodSelectorPolicy.SelectMethods(context, containingPolicyList))
		{
			flag = true;
			string methodSignature = GetMethodSignature(item.Method);
			GuardMethodIsNotOpenGeneric(item.Method);
			GuardMethodHasNoOutParams(item.Method);
			GuardMethodHasNoRefParams(item.Method);
			ParameterInfo[] parameters = item.Method.GetParameters();
			dynamicBuildPlanGenerationContext.EmitLoadExisting();
			int num = 0;
			string[] parameterKeys = item.GetParameterKeys();
			foreach (string key in parameterKeys)
			{
				dynamicBuildPlanGenerationContext.IL.Emit(OpCodes.Ldstr, parameters[num].Name);
				dynamicBuildPlanGenerationContext.IL.Emit(OpCodes.Ldstr, methodSignature);
				dynamicBuildPlanGenerationContext.EmitLoadContext();
				dynamicBuildPlanGenerationContext.IL.EmitCall(OpCodes.Call, setCurrentOperationToResolvingParameter, null);
				dynamicBuildPlanGenerationContext.EmitResolveDependency(parameters[num].ParameterType, key);
				num++;
			}
			dynamicBuildPlanGenerationContext.IL.Emit(OpCodes.Ldstr, methodSignature);
			dynamicBuildPlanGenerationContext.EmitLoadContext();
			dynamicBuildPlanGenerationContext.IL.EmitCall(OpCodes.Call, setCurrentOperationToInvokingMethod, null);
			dynamicBuildPlanGenerationContext.IL.EmitCall(OpCodes.Callvirt, item.Method, null);
			if (item.Method.ReturnType != typeof(void))
			{
				dynamicBuildPlanGenerationContext.IL.Emit(OpCodes.Pop);
			}
		}
		if (flag)
		{
			dynamicBuildPlanGenerationContext.EmitClearCurrentOperation();
		}
	}

	private static void GuardMethodIsNotOpenGeneric(MethodInfo method)
	{
		if (method.IsGenericMethodDefinition)
		{
			ThrowIllegalInjectionMethod(Resources.CannotInjectOpenGenericMethod, method);
		}
	}

	private static void GuardMethodHasNoOutParams(MethodInfo method)
	{
		if (method.GetParameters().Any((ParameterInfo param) => param.IsOut))
		{
			ThrowIllegalInjectionMethod(Resources.CannotInjectMethodWithOutParam, method);
		}
	}

	private static void GuardMethodHasNoRefParams(MethodInfo method)
	{
		if (method.GetParameters().Any((ParameterInfo param) => param.ParameterType.IsByRef))
		{
			ThrowIllegalInjectionMethod(Resources.CannotInjectMethodWithOutParam, method);
		}
	}

	private static void ThrowIllegalInjectionMethod(string format, MethodInfo method)
	{
		throw new IllegalInjectionMethodException(string.Format(CultureInfo.CurrentCulture, format, method.DeclaringType.Name, method.Name));
	}

	/// <summary>
	/// A helper method used by the generated IL to store the current operation in the build context.
	/// </summary>
	public static void SetCurrentOperationToResolvingParameter(string parameterName, string methodSignature, IBuilderContext context)
	{
		Guard.ArgumentNotNull(context, "context");
		context.CurrentOperation = new MethodArgumentResolveOperation(context.BuildKey.Type, methodSignature, parameterName);
	}

	/// <summary>
	/// A helper method used by the generated IL to store the current operation in the build context.
	/// </summary>
	public static void SetCurrentOperationToInvokingMethod(string methodSignature, IBuilderContext context)
	{
		Guard.ArgumentNotNull(context, "context");
		context.CurrentOperation = new InvokingMethodOperation(context.BuildKey.Type, methodSignature);
	}

	private static string GetMethodSignature(MethodBase method)
	{
		string name = method.Name;
		ParameterInfo[] parameters = method.GetParameters();
		string[] array = new string[parameters.Length];
		for (int i = 0; i < parameters.Length; i++)
		{
			array[i] = parameters[i].ParameterType.FullName + " " + parameters[i].Name;
		}
		return string.Format(CultureInfo.CurrentCulture, "{0}({1})", name, string.Join(", ", array));
	}
}
