using System;
using System.Linq;
using System.Text;

namespace AutoMapper;

public class AutoMapperConfigurationException : Exception
{
	public class TypeMapConfigErrors
	{
		public TypeMap TypeMap { get; private set; }

		public string[] UnmappedPropertyNames { get; private set; }

		public TypeMapConfigErrors(TypeMap typeMap, string[] unmappedPropertyNames)
		{
			TypeMap = typeMap;
			UnmappedPropertyNames = unmappedPropertyNames;
		}
	}

	public TypeMapConfigErrors[] Errors { get; private set; }

	public ResolutionContext Context { get; private set; }

	public override string Message
	{
		get
		{
			if (Context != null)
			{
				ResolutionContext resolutionContext = Context;
				string text = string.Format("The following property on {0} cannot be mapped: \n\t{2}\nAdd a custom mapping expression, ignore, add a custom resolver, or modify the destination type {1}.", new object[3]
				{
					resolutionContext.DestinationType.FullName,
					resolutionContext.DestinationType.FullName,
					resolutionContext.GetContextPropertyMap().DestinationProperty.Name
				});
				text += "\nContext:";
				while (resolutionContext != null)
				{
					text += ((resolutionContext.GetContextPropertyMap() == null) ? string.Format("\n\tMapping from type {1} to {0}", new object[2]
					{
						resolutionContext.DestinationType.FullName,
						resolutionContext.SourceType.FullName
					}) : string.Format("\n\tMapping to property {0} from {2} to {1}", new object[3]
					{
						resolutionContext.GetContextPropertyMap().DestinationProperty.Name,
						resolutionContext.DestinationType.FullName,
						resolutionContext.SourceType.FullName
					}));
					resolutionContext = resolutionContext.Parent;
				}
				return text + "\n" + base.Message;
			}
			if (Errors != null)
			{
				StringBuilder stringBuilder = new StringBuilder("\nUnmapped members were found. Review the types and members below.\nAdd a custom mapping expression, ignore, add a custom resolver, or modify the source/destination type\n");
				TypeMapConfigErrors[] errors = Errors;
				foreach (TypeMapConfigErrors typeMapConfigErrors in errors)
				{
					int count = typeMapConfigErrors.TypeMap.SourceType.FullName.Length + typeMapConfigErrors.TypeMap.DestinationType.FullName.Length + 5;
					stringBuilder.AppendLine(new string('=', count));
					stringBuilder.AppendLine(string.Concat(typeMapConfigErrors.TypeMap.SourceType.Name, " -> ", typeMapConfigErrors.TypeMap.DestinationType.Name, " (", typeMapConfigErrors.TypeMap.ConfiguredMemberList, " member list)"));
					stringBuilder.AppendLine(string.Concat(typeMapConfigErrors.TypeMap.SourceType.FullName, " -> ", typeMapConfigErrors.TypeMap.DestinationType.FullName, " (", typeMapConfigErrors.TypeMap.ConfiguredMemberList, " member list)"));
					stringBuilder.AppendLine(new string('-', count));
					string[] unmappedPropertyNames = typeMapConfigErrors.UnmappedPropertyNames;
					foreach (string value in unmappedPropertyNames)
					{
						stringBuilder.AppendLine(value);
					}
				}
				return stringBuilder.ToString();
			}
			return base.Message;
		}
	}

	public override string StackTrace
	{
		get
		{
			if (Errors != null)
			{
				return string.Join(Environment.NewLine, (from str in base.StackTrace.Split(new string[1] { Environment.NewLine }, StringSplitOptions.None)
					where !str.TrimStart(new char[0]).StartsWith("at AutoMapper.")
					select str).ToArray());
			}
			return base.StackTrace;
		}
	}

	public AutoMapperConfigurationException(string message)
		: base(message)
	{
	}

	protected AutoMapperConfigurationException(string message, Exception inner)
		: base(message, inner)
	{
	}

	public AutoMapperConfigurationException(TypeMapConfigErrors[] errors)
	{
		Errors = errors;
	}

	public AutoMapperConfigurationException(ResolutionContext context)
	{
		Context = context;
	}
}
