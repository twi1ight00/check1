using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Unity.Configuration;
using Microsoft.Practices.Unity.Configuration.ConfigurationHelpers;

namespace Microsoft.Practices.Unity.InterceptionExtension.Configuration;

/// <summary>
/// Configuration element representing a call handler.
/// </summary>
public class CallHandlerElement : PolicyChildElement
{
	internal void Configure(IUnityContainer container, PolicyDefinition policyDefinition)
	{
		if (string.IsNullOrEmpty(base.TypeName))
		{
			policyDefinition.AddCallHandler(base.Name);
			return;
		}
		Type handlerType = TypeResolver.ResolveType(base.TypeName);
		IEnumerable<InjectionMember> source = base.Injection.SelectMany((InjectionMemberElement element) => element.GetInjectionMembers(container, typeof(ICallHandler), handlerType, base.Name));
		policyDefinition.AddCallHandler(handlerType, base.Lifetime.CreateLifetimeManager(), source.ToArray());
	}
}
