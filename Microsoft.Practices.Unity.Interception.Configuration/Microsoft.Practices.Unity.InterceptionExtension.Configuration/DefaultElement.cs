namespace Microsoft.Practices.Unity.InterceptionExtension.Configuration;

/// <summary>
/// The &lt;default&gt; element that appears inside an &lt;interceptor&gt; element.
/// </summary>
public class DefaultElement : InterceptorRegistrationElement
{
	internal override string Key => "default:" + base.TypeName;

	internal override string ElementName => "default";

	/// <summary>
	/// Actually register the interceptor against this type.
	/// </summary>
	/// <param name="container">Container to configure.</param>
	/// <param name="interceptor">interceptor to register.</param>
	internal override void RegisterInterceptor(IUnityContainer container, IInterceptor interceptor)
	{
		if (interceptor is ITypeInterceptor interceptor2)
		{
			container.Configure<Interception>().SetDefaultInterceptorFor(base.ResolvedType, interceptor2);
		}
		else
		{
			container.Configure<Interception>().SetDefaultInterceptorFor(base.ResolvedType, (IInstanceInterceptor)interceptor);
		}
	}
}
