using System;
using System.Globalization;
using System.Runtime.Serialization;

namespace Quartz;

/// <summary> 
/// Base class for exceptions thrown by the Quartz <see cref="T:Quartz.IScheduler" />.
/// </summary>
/// <remarks>
/// SchedulerExceptions may contain a reference to another
/// <see cref="T:System.Exception" />, which was the underlying cause of the SchedulerException.
/// </remarks>
/// <author>James House</author>
/// <author>Marko Lahma (.NET)</author>
[Serializable]
public class SchedulerException : Exception
{
	/// <summary>
	/// Initializes a new instance of the <see cref="T:Quartz.SchedulerException" /> class.
	/// </summary>
	public SchedulerException()
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Quartz.SchedulerException" /> class.
	/// </summary>
	/// <param name="msg">The MSG.</param>
	public SchedulerException(string msg)
		: base(msg)
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Quartz.SchedulerException" /> class.
	/// </summary>
	/// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"></see> that holds the serialized object data about the exception being thrown.</param>
	/// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"></see> that contains contextual information about the source or destination.</param>
	/// <exception cref="T:System.Runtime.Serialization.SerializationException">The class name is null or <see cref="P:System.Exception.HResult"></see> is zero (0). </exception>
	/// <exception cref="T:System.ArgumentNullException">The info parameter is null. </exception>
	protected SchedulerException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Quartz.SchedulerException" /> class.
	/// </summary>
	/// <param name="cause">The cause.</param>
	public SchedulerException(Exception cause)
		: base(cause.ToString(), cause)
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Quartz.SchedulerException" /> class.
	/// </summary>
	/// <param name="msg">The MSG.</param>
	/// <param name="cause">The cause.</param>
	public SchedulerException(string msg, Exception cause)
		: base(msg, cause)
	{
	}

	/// <summary>
	/// Creates and returns a string representation of the current exception.
	/// </summary>
	/// <returns>
	/// A string representation of the current exception.
	/// </returns>
	/// <PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" PathDiscovery="*AllFiles*" /></PermissionSet>
	public override string ToString()
	{
		if (base.InnerException == null)
		{
			return base.ToString();
		}
		return string.Format(CultureInfo.InvariantCulture, "{0} [See nested exception: {1}]", new object[2]
		{
			base.ToString(),
			base.InnerException
		});
	}
}
