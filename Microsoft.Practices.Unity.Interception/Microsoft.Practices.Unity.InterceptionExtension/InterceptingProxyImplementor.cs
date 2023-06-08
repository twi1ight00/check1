using System.Reflection;
using System.Reflection.Emit;

namespace Microsoft.Practices.Unity.InterceptionExtension;

/// <summary>
/// This class provides the code needed to implement the <see cref="T:Microsoft.Practices.Unity.InterceptionExtension.IInterceptingProxy" />
/// interface on a class.
/// </summary>
internal static class InterceptingProxyImplementor
{
	internal static FieldBuilder ImplementIInterceptingProxy(TypeBuilder typeBuilder)
	{
		typeBuilder.AddInterfaceImplementation(typeof(IInterceptingProxy));
		FieldBuilder fieldBuilder = typeBuilder.DefineField("pipeline", typeof(InterceptionBehaviorPipeline), FieldAttributes.Private | FieldAttributes.InitOnly);
		ImplementAddInterceptionBehavior(typeBuilder, fieldBuilder);
		return fieldBuilder;
	}

	private static void ImplementAddInterceptionBehavior(TypeBuilder typeBuilder, FieldInfo proxyInterceptorPipelineField)
	{
		MethodBuilder methodBuilder = typeBuilder.DefineMethod("Microsoft.Practices.Unity.InterceptionExtension.IInterceptingProxy.AddInterceptionBehavior", MethodAttributes.Private | MethodAttributes.Final | MethodAttributes.Virtual | MethodAttributes.HideBySig | MethodAttributes.VtableLayoutMask);
		methodBuilder.SetReturnType(typeof(void));
		methodBuilder.SetParameters(typeof(IInterceptionBehavior));
		methodBuilder.DefineParameter(1, ParameterAttributes.None, "interceptor");
		ILGenerator iLGenerator = methodBuilder.GetILGenerator();
		iLGenerator.Emit(OpCodes.Ldarg_0);
		iLGenerator.Emit(OpCodes.Ldfld, proxyInterceptorPipelineField);
		iLGenerator.Emit(OpCodes.Ldarg_1);
		iLGenerator.EmitCall(OpCodes.Callvirt, InterceptionBehaviorPipelineMethods.Add, null);
		iLGenerator.Emit(OpCodes.Ret);
		typeBuilder.DefineMethodOverride(methodBuilder, IInterceptingProxyMethods.AddInterceptionBehavior);
	}
}
