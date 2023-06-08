using System;

namespace Quartz;

/// <summary>
/// An attribute that marks a <see cref="T:Quartz.IJob" /> class as one that makes updates to its
/// <see cref="T:Quartz.JobDataMap" /> during execution, and wishes the scheduler to re-store the
/// <see cref="T:Quartz.JobDataMap" /> when execution completes. 
/// </summary>
/// <remarks>
/// <para>
/// Jobs that are marked with this annotation should also seriously consider
/// using the <see cref="T:Quartz.DisallowConcurrentExecutionAttribute" /> attribute, to avoid data
/// storage race conditions with concurrently executing job instances.
/// </para>
/// <para>
/// This can be used in lieu of implementing the StatefulJob marker interface that 
/// was used prior to Quartz 2.0
/// </para>
///             </remarks>
/// <seealso cref="T:Quartz.DisallowConcurrentExecutionAttribute" />
/// <author>James House</author>
/// <author>Marko Lahma (.NET)</author>
[AttributeUsage(AttributeTargets.Class)]
public class PersistJobDataAfterExecutionAttribute : Attribute
{
}
