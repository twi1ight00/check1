using System;

namespace Quartz;

/// <summary>
/// An attribute that marks a <see cref="T:Quartz.IJob" /> class as one that must not have multiple
/// instances executed concurrently (where instance is based-upon a <see cref="T:Quartz.IJobDetail" /> 
/// definition - or in other words based upon a <see cref="T:Quartz.JobKey" />. 
/// </summary>
/// <remarks>
/// <para>This can be used in lieu of implementing the StatefulJob marker interface that 
/// was used prior to Quartz 2.0</para>
/// </remarks>
/// <seealso cref="T:Quartz.PersistJobDataAfterExecutionAttribute" />
/// <author>James House</author>
/// <author>Marko Lahma (.NET)</author>
[AttributeUsage(AttributeTargets.Class)]
public class DisallowConcurrentExecutionAttribute : Attribute
{
}
