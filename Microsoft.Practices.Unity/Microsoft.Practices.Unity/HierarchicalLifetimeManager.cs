namespace Microsoft.Practices.Unity;

/// <summary>
/// A special lifetime manager which works like <see cref="T:Microsoft.Practices.Unity.ContainerControlledLifetimeManager" />,
/// except that in the presence of child containers, each child gets it's own instance
/// of the object, instead of sharing one in the common parent.
/// </summary>
public class HierarchicalLifetimeManager : ContainerControlledLifetimeManager
{
}
