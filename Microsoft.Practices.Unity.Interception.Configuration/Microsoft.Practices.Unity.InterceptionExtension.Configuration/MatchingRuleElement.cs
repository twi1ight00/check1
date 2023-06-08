using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Unity.Configuration;
using Microsoft.Practices.Unity.Configuration.ConfigurationHelpers;

namespace Microsoft.Practices.Unity.InterceptionExtension.Configuration;

/// <summary>
/// A configuration element representing a matching rule.
/// </summary>
public class MatchingRuleElement : PolicyChildElement
{
	internal void Configure(IUnityContainer container, PolicyDefinition policyDefinition)
	{
		if (string.IsNullOrEmpty(base.TypeName))
		{
			policyDefinition.AddMatchingRule(base.Name);
			return;
		}
		Type matchingRuleType = TypeResolver.ResolveType(base.TypeName);
		LifetimeManager lifetimeManager = base.Lifetime.CreateLifetimeManager();
		IEnumerable<InjectionMember> source = base.Injection.SelectMany((InjectionMemberElement element) => element.GetInjectionMembers(container, typeof(IMatchingRule), matchingRuleType, base.Name));
		policyDefinition.AddMatchingRule(matchingRuleType, lifetimeManager, source.ToArray());
	}
}
