using System;
using System.Globalization;
using System.Runtime.Serialization;

namespace Quartz;

/// <summary>
/// An exception that is thrown to indicate that an attempt to store a new
/// object (i.e. <see cref="T:Quartz.IJobDetail" />,<see cref="T:Quartz.ITrigger" />
/// or <see cref="T:Quartz.ICalendar" />) in a <see cref="T:Quartz.IScheduler" />
/// failed, because one with the same name and group already exists.
/// </summary>
/// <author>James House</author>
/// <author>Marko Lahma (.NET)</author>
[Serializable]
public class ObjectAlreadyExistsException : JobPersistenceException
{
	/// <summary> <para>
	/// Create a <see cref="T:Quartz.ObjectAlreadyExistsException" /> with the given
	/// message.
	/// </para>
	/// </summary>
	public ObjectAlreadyExistsException(string msg)
		: base(msg)
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Quartz.ObjectAlreadyExistsException" /> class.
	/// </summary>
	/// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"></see> that holds the serialized object data about the exception being thrown.</param>
	/// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"></see> that contains contextual information about the source or destination.</param>
	/// <exception cref="T:System.Runtime.Serialization.SerializationException">The class name is null or <see cref="P:System.Exception.HResult"></see> is zero (0). </exception>
	/// <exception cref="T:System.ArgumentNullException">The info parameter is null. </exception>
	protected ObjectAlreadyExistsException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}

	/// <summary> <para>
	/// Create a <see cref="T:Quartz.ObjectAlreadyExistsException" /> and auto-generate a
	/// message using the name/group from the given <see cref="T:Quartz.IJobDetail" />.
	/// </para>
	///
	/// <para>
	/// The message will read: <br />"Unable to store Job with name: '__' and
	/// group: '__', because one already exists with this identification."
	/// </para>
	/// </summary>
	public ObjectAlreadyExistsException(IJobDetail offendingJob)
		: base(string.Format(CultureInfo.InvariantCulture, "Unable to store Job: '{0}', because one already exists with this identification.", new object[1] { offendingJob.Key }))
	{
	}

	/// <summary> <para>
	/// Create a <see cref="T:Quartz.ObjectAlreadyExistsException" /> and auto-generate a
	/// message using the name/group from the given <see cref="T:Quartz.ITrigger" />.
	/// </para>
	///
	/// <para>
	/// The message will read: <br />"Unable to store Trigger with name: '__' and
	/// group: '__', because one already exists with this identification."
	/// </para>
	/// </summary>
	public ObjectAlreadyExistsException(ITrigger offendingTrigger)
		: base(string.Format(CultureInfo.InvariantCulture, "Unable to store Trigger: '{0}', because one already exists with this identification.", new object[1] { offendingTrigger.Key }))
	{
	}
}
