namespace Microsoft.Practices.ObjectBuilder2;

/// <summary>
/// A delegate type that defines the signature of the
/// dynamic method created by the build plans.
/// </summary>
/// <param name="context"><see cref="T:Microsoft.Practices.ObjectBuilder2.IBuilderContext" /> used to build up the object.</param>
internal delegate void DynamicBuildPlanMethod(IBuilderContext context);
