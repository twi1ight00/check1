using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Properties;
using Microsoft.Practices.Unity.Utility;

namespace Microsoft.Practices.ObjectBuilder2;

/// <summary>
/// A <see cref="T:Microsoft.Practices.ObjectBuilder2.BuilderStrategy" /> that emits IL to call constructors
/// as part of creating a build plan.
/// </summary>
public class DynamicMethodConstructorStrategy : BuilderStrategy
{
	private static readonly MethodInfo throwForNullExistingObject = StaticReflection.GetMethodInfo(() => ThrowForNullExistingObject(null));

	private static readonly MethodInfo throwForNullExistingObjectWithInvalidConstructor = StaticReflection.GetMethodInfo(() => ThrowForNullExistingObjectWithInvalidConstructor(null, null));

	private static readonly MethodInfo throwForAttemptingToConstructInterface = StaticReflection.GetMethodInfo(() => ThrowForAttemptingToConstructInterface(null));

	private static readonly MethodInfo setCurrentOperationToResolvingParameter = StaticReflection.GetMethodInfo(() => SetCurrentOperationToResolvingParameter(null, null, null));

	private static readonly MethodInfo setCurrentOperationToInvokingConstructor = StaticReflection.GetMethodInfo(() => SetCurrentOperationToInvokingConstructor(null, null));

	private static readonly MethodInfo setExistingInContext = StaticReflection.GetPropertySetMethodInfo((IBuilderContext ctx) => ctx.Existing);

	private static readonly MethodInfo setPerBuildSingleton = StaticReflection.GetMethodInfo(() => SetPerBuildSingleton(null));

	/// <summary>
	/// Called during the chain of responsibility for a build operation.
	/// </summary>
	/// <remarks>Existing object is an instance of <see cref="T:Microsoft.Practices.ObjectBuilder2.DynamicBuildPlanGenerationContext" />.</remarks>
	/// <param name="context">The context for the operation.</param>
	public override void PreBuildUp(IBuilderContext context)
	{
		Guard.ArgumentNotNull(context, "context");
		DynamicBuildPlanGenerationContext dynamicBuildPlanGenerationContext = (DynamicBuildPlanGenerationContext)context.Existing;
		IPolicyList containingPolicyList;
		IConstructorSelectorPolicy constructorSelectorPolicy = context.Policies.Get<IConstructorSelectorPolicy>(context.BuildKey, out containingPolicyList);
		SelectedConstructor selectedConstructor = constructorSelectorPolicy.SelectConstructor(context, containingPolicyList);
		GuardTypeIsNonPrimitive(context, selectedConstructor);
		Label label = dynamicBuildPlanGenerationContext.IL.DefineLabel();
		if (!dynamicBuildPlanGenerationContext.TypeToBuild.IsValueType)
		{
			dynamicBuildPlanGenerationContext.EmitLoadExisting();
			dynamicBuildPlanGenerationContext.IL.Emit(OpCodes.Brtrue, label);
		}
		dynamicBuildPlanGenerationContext.EmitLoadContext();
		dynamicBuildPlanGenerationContext.IL.EmitCall(OpCodes.Call, throwForAttemptingToConstructInterface, null);
		if (selectedConstructor != null)
		{
			string str = CreateSignatureString(selectedConstructor.Constructor);
			ParameterInfo[] parameters = selectedConstructor.Constructor.GetParameters();
			if (!parameters.Any((ParameterInfo pi) => pi.ParameterType.IsByRef))
			{
				int num = 0;
				string[] parameterKeys = selectedConstructor.GetParameterKeys();
				foreach (string key in parameterKeys)
				{
					dynamicBuildPlanGenerationContext.IL.Emit(OpCodes.Ldstr, parameters[num].Name);
					dynamicBuildPlanGenerationContext.IL.Emit(OpCodes.Ldstr, str);
					dynamicBuildPlanGenerationContext.EmitLoadContext();
					dynamicBuildPlanGenerationContext.IL.EmitCall(OpCodes.Call, setCurrentOperationToResolvingParameter, null);
					dynamicBuildPlanGenerationContext.EmitResolveDependency(parameters[num].ParameterType, key);
					num++;
				}
				dynamicBuildPlanGenerationContext.IL.Emit(OpCodes.Ldstr, str);
				dynamicBuildPlanGenerationContext.EmitLoadContext();
				dynamicBuildPlanGenerationContext.IL.EmitCall(OpCodes.Call, setCurrentOperationToInvokingConstructor, null);
				dynamicBuildPlanGenerationContext.IL.Emit(OpCodes.Newobj, selectedConstructor.Constructor);
				dynamicBuildPlanGenerationContext.EmitStoreExisting();
				dynamicBuildPlanGenerationContext.EmitClearCurrentOperation();
				dynamicBuildPlanGenerationContext.EmitLoadContext();
				dynamicBuildPlanGenerationContext.EmitLoadExisting();
				if (dynamicBuildPlanGenerationContext.TypeToBuild.IsValueType)
				{
					dynamicBuildPlanGenerationContext.IL.Emit(OpCodes.Box, dynamicBuildPlanGenerationContext.TypeToBuild);
				}
				dynamicBuildPlanGenerationContext.IL.EmitCall(OpCodes.Callvirt, setExistingInContext, null);
				dynamicBuildPlanGenerationContext.EmitLoadContext();
				dynamicBuildPlanGenerationContext.IL.EmitCall(OpCodes.Call, setPerBuildSingleton, null);
			}
			else
			{
				dynamicBuildPlanGenerationContext.EmitLoadContext();
				dynamicBuildPlanGenerationContext.IL.Emit(OpCodes.Ldstr, str);
				dynamicBuildPlanGenerationContext.IL.EmitCall(OpCodes.Call, throwForNullExistingObjectWithInvalidConstructor, null);
			}
		}
		else
		{
			dynamicBuildPlanGenerationContext.EmitLoadContext();
			dynamicBuildPlanGenerationContext.IL.EmitCall(OpCodes.Call, throwForNullExistingObject, null);
		}
		dynamicBuildPlanGenerationContext.IL.MarkLabel(label);
	}

	/// <summary>
	/// A helper method used by the generated IL to throw an exception if
	/// a dependency cannot be resolved.
	/// </summary>
	/// <param name="context">The <see cref="T:Microsoft.Practices.ObjectBuilder2.IBuilderContext" /> currently being
	/// used for the build of this object.</param>
	public static void ThrowForNullExistingObject(IBuilderContext context)
	{
		Guard.ArgumentNotNull(context, "context");
		throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources.NoConstructorFound, context.BuildKey.Type.Name));
	}

	/// <summary>
	/// A helper method used by the generated IL to throw an exception if
	/// a dependency cannot be resolved because of an invalid constructor.
	/// </summary>
	/// <param name="context">The <see cref="T:Microsoft.Practices.ObjectBuilder2.IBuilderContext" /> currently being
	/// used for the build of this object.</param>
	/// <param name="signature">The signature of the invalid constructor.</param>
	public static void ThrowForNullExistingObjectWithInvalidConstructor(IBuilderContext context, string signature)
	{
		Guard.ArgumentNotNull(context, "context");
		throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources.SelectedConstructorHasRefParameters, context.BuildKey.Type.Name, signature));
	}

	/// <summary>
	/// A helper method used by the generated IL to throw an exception if
	/// no existing object is present, but the user is attempting to build
	/// an interface (usually due to the lack of a type mapping).
	/// </summary>
	/// <param name="context">The <see cref="T:Microsoft.Practices.ObjectBuilder2.IBuilderContext" /> currently being
	/// used for the build of this object.</param>
	public static void ThrowForAttemptingToConstructInterface(IBuilderContext context)
	{
		Guard.ArgumentNotNull(context, "context");
		if (context.BuildKey.Type.IsInterface)
		{
			throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources.CannotConstructInterface, context.BuildKey.Type, context.BuildKey));
		}
	}

	/// <summary>
	/// A helper method used by the generated IL to store the current operation in the build context.
	/// </summary>
	public static void SetCurrentOperationToResolvingParameter(string parameterName, string constructorSignature, IBuilderContext context)
	{
		Guard.ArgumentNotNull(context, "context");
		context.CurrentOperation = new ConstructorArgumentResolveOperation(context.BuildKey.Type, constructorSignature, parameterName);
	}

	/// <summary>
	/// A helper method used by the generated IL to store the current operation in the build context.
	/// </summary>
	public static void SetCurrentOperationToInvokingConstructor(string constructorSignature, IBuilderContext context)
	{
		Guard.ArgumentNotNull(context, "context");
		context.CurrentOperation = new InvokingConstructorOperation(context.BuildKey.Type, constructorSignature);
	}

	/// <summary>
	/// A helper method used by the generated IL to set up a PerResolveLifetimeManager lifetime manager
	/// if the current object is such.
	/// </summary>
	/// <param name="context">Current build context.</param>
	public static void SetPerBuildSingleton(IBuilderContext context)
	{
		Guard.ArgumentNotNull(context, "context");
		ILifetimePolicy lifetimePolicy = context.Policies.Get<ILifetimePolicy>(context.BuildKey);
		if (lifetimePolicy is PerResolveLifetimeManager)
		{
			PerResolveLifetimeManager policy = new PerResolveLifetimeManager(context.Existing);
			context.Policies.Set((ILifetimePolicy)policy, (object)context.BuildKey);
		}
	}

	private static string CreateSignatureString(ConstructorInfo ctor)
	{
		string fullName = ctor.DeclaringType.FullName;
		ParameterInfo[] parameters = ctor.GetParameters();
		string[] array = new string[parameters.Length];
		for (int i = 0; i < parameters.Length; i++)
		{
			array[i] = string.Format(CultureInfo.CurrentCulture, "{0} {1}", parameters[i].ParameterType.FullName, parameters[i].Name);
		}
		return string.Format(CultureInfo.CurrentCulture, "{0}({1})", fullName, string.Join(", ", array));
	}

	private static void GuardTypeIsNonPrimitive(IBuilderContext context, SelectedConstructor selectedConstructor)
	{
		Type type = context.BuildKey.Type;
		if (!type.IsInterface && type == typeof(string))
		{
			throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources.TypeIsNotConstructable, type.Name));
		}
	}
}
