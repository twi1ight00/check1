using System;
using System.Globalization;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity.Properties;
using Microsoft.Practices.Unity.Utility;

namespace Microsoft.Practices.Unity;

/// <summary>
/// The exception thrown by the Unity container when
/// an attempt to resolve a dependency fails.
/// </summary>
/// <summary>
/// The exception thrown by the Unity container when
/// an attempt to resolve a dependency fails.
/// </summary>
[Serializable]
public class ResolutionFailedException : Exception
{
	private readonly string typeRequested;

	private readonly string nameRequested;

	/// <summary>
	/// The type that was being requested from the container at the time of failure.
	/// </summary>
	public string TypeRequested => typeRequested;

	/// <summary>
	/// The name that was being requested from the container at the time of failure.
	/// </summary>
	public string NameRequested => nameRequested;

	/// <summary>
	/// Constructor to create a <see cref="T:Microsoft.Practices.Unity.ResolutionFailedException" /> from serialized state.
	/// </summary>
	/// <param name="info">Serialization info</param>
	/// <param name="context">Serialization context</param>
	protected ResolutionFailedException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		typeRequested = info.GetString("typeRequested");
		nameRequested = info.GetString("nameRequested");
	}

	/// <summary>
	/// Serialize this object into the given context.
	/// </summary>
	/// <param name="info">Serialization info</param>
	/// <param name="context">Streaming context</param>
	[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		Guard.ArgumentNotNull(info, "info");
		base.GetObjectData(info, context);
		info.AddValue("typeRequested", typeRequested, typeof(string));
		info.AddValue("nameRequested", nameRequested, typeof(string));
	}

	/// <summary>
	/// Create a new <see cref="T:Microsoft.Practices.Unity.ResolutionFailedException" /> that records
	/// the exception for the given type and name.
	/// </summary>
	/// <param name="typeRequested">Type requested from the container.</param>
	/// <param name="nameRequested">Name requested from the container.</param>
	/// <param name="innerException">The actual exception that caused the failure of the build.</param>
	/// <param name="context">The build context representing the failed operation.</param>
	public ResolutionFailedException(Type typeRequested, string nameRequested, Exception innerException, IBuilderContext context)
		: base(CreateMessage(typeRequested, nameRequested, innerException, context), innerException)
	{
		Guard.ArgumentNotNull(typeRequested, "typeRequested");
		if (typeRequested != null)
		{
			this.typeRequested = typeRequested.Name;
		}
		this.nameRequested = nameRequested;
	}

	private static string CreateMessage(Type typeRequested, string nameRequested, Exception innerException, IBuilderContext context)
	{
		Guard.ArgumentNotNull(typeRequested, "typeRequested");
		Guard.ArgumentNotNull(context, "context");
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendFormat(CultureInfo.CurrentCulture, Resources.ResolutionFailed, typeRequested, FormatName(nameRequested), ExceptionReason(context), (innerException != null) ? innerException.GetType().Name : "ResolutionFailedException", innerException?.Message);
		stringBuilder.AppendLine();
		AddContextDetails(stringBuilder, context, 1);
		return stringBuilder.ToString();
	}

	private static void AddContextDetails(StringBuilder builder, IBuilderContext context, int depth)
	{
		if (context != null)
		{
			string value = new string(' ', depth * 2);
			NamedTypeBuildKey buildKey = context.BuildKey;
			NamedTypeBuildKey originalBuildKey = context.OriginalBuildKey;
			builder.Append(value);
			if (buildKey == originalBuildKey)
			{
				builder.AppendFormat(CultureInfo.CurrentCulture, Resources.ResolutionTraceDetail, buildKey.Type, FormatName(buildKey.Name));
			}
			else
			{
				builder.AppendFormat(CultureInfo.CurrentCulture, Resources.ResolutionWithMappingTraceDetail, buildKey.Type, FormatName(buildKey.Name), originalBuildKey.Type, FormatName(originalBuildKey.Name));
			}
			builder.AppendLine();
			if (context.CurrentOperation != null)
			{
				builder.Append(value);
				builder.AppendFormat(CultureInfo.CurrentCulture, context.CurrentOperation.ToString());
				builder.AppendLine();
			}
			AddContextDetails(builder, context.ChildContext, depth + 1);
		}
	}

	private static string FormatName(string name)
	{
		if (!string.IsNullOrEmpty(name))
		{
			return name;
		}
		return "(none)";
	}

	private static string ExceptionReason(IBuilderContext context)
	{
		IBuilderContext builderContext = context;
		while (builderContext.ChildContext != null)
		{
			builderContext = builderContext.ChildContext;
		}
		if (builderContext.CurrentOperation != null)
		{
			return builderContext.CurrentOperation.ToString();
		}
		return Resources.NoOperationExceptionReason;
	}
}
