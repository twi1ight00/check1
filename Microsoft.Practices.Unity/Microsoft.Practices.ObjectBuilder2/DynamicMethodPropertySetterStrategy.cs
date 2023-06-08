using System;
using System.Globalization;
using System.Reflection;
using System.Reflection.Emit;
using Microsoft.Practices.Unity.Properties;
using Microsoft.Practices.Unity.Utility;

namespace Microsoft.Practices.ObjectBuilder2;

/// <summary>
/// A <see cref="T:Microsoft.Practices.ObjectBuilder2.BuilderStrategy" /> that generates IL to resolve properties
/// on an object being built.
/// </summary>
public class DynamicMethodPropertySetterStrategy : BuilderStrategy
{
	private static readonly MethodInfo setCurrentOperationToResolvingPropertyValue = StaticReflection.GetMethodInfo(() => SetCurrentOperationToResolvingPropertyValue(null, null));

	private static readonly MethodInfo setCurrentOperationToSettingProperty = StaticReflection.GetMethodInfo(() => SetCurrentOperationToSettingProperty(null, null));

	/// <summary>
	/// Called during the chain of responsibility for a build operation.
	/// </summary>
	/// <param name="context">The context for the operation.</param>
	public override void PreBuildUp(IBuilderContext context)
	{
		Guard.ArgumentNotNull(context, "context");
		DynamicBuildPlanGenerationContext dynamicBuildPlanGenerationContext = (DynamicBuildPlanGenerationContext)context.Existing;
		IPolicyList containingPolicyList;
		IPropertySelectorPolicy propertySelectorPolicy = context.Policies.Get<IPropertySelectorPolicy>(context.BuildKey, out containingPolicyList);
		bool flag = false;
		foreach (SelectedProperty item in propertySelectorPolicy.SelectProperties(context, containingPolicyList))
		{
			flag = true;
			dynamicBuildPlanGenerationContext.IL.Emit(OpCodes.Ldstr, item.Property.Name);
			dynamicBuildPlanGenerationContext.EmitLoadContext();
			dynamicBuildPlanGenerationContext.IL.EmitCall(OpCodes.Call, setCurrentOperationToResolvingPropertyValue, null);
			dynamicBuildPlanGenerationContext.EmitLoadExisting();
			dynamicBuildPlanGenerationContext.EmitResolveDependency(item.Property.PropertyType, item.Key);
			dynamicBuildPlanGenerationContext.IL.Emit(OpCodes.Ldstr, item.Property.Name);
			dynamicBuildPlanGenerationContext.EmitLoadContext();
			dynamicBuildPlanGenerationContext.IL.EmitCall(OpCodes.Call, setCurrentOperationToSettingProperty, null);
			dynamicBuildPlanGenerationContext.IL.EmitCall(OpCodes.Callvirt, GetValidatedPropertySetter(item.Property), null);
		}
		if (flag)
		{
			dynamicBuildPlanGenerationContext.EmitClearCurrentOperation();
		}
	}

	private static MethodInfo GetValidatedPropertySetter(PropertyInfo property)
	{
		MethodInfo setMethod = property.GetSetMethod();
		if (setMethod == null)
		{
			throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources.PropertyNotSettable, property.Name, property.DeclaringType.FullName));
		}
		return setMethod;
	}

	/// <summary>
	/// A helper method used by the generated IL to store the current operation in the build context.
	/// </summary>
	public static void SetCurrentOperationToResolvingPropertyValue(string propertyName, IBuilderContext context)
	{
		Guard.ArgumentNotNull(context, "context");
		context.CurrentOperation = new ResolvingPropertyValueOperation(context.BuildKey.Type, propertyName);
	}

	/// <summary>
	/// A helper method used by the generated IL to store the current operation in the build context.
	/// </summary>
	public static void SetCurrentOperationToSettingProperty(string propertyName, IBuilderContext context)
	{
		Guard.ArgumentNotNull(context, "context");
		context.CurrentOperation = new SettingPropertyOperation(context.BuildKey.Type, propertyName);
	}
}
