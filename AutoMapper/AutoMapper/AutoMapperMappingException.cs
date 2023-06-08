using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoMapper;

public class AutoMapperMappingException : Exception
{
	private string _message;

	public ResolutionContext Context { get; private set; }

	public override string Message
	{
		get
		{
			string text = null;
			string newLine = Environment.NewLine;
			if (Context != null)
			{
				text = _message + newLine + newLine + "Mapping types:";
				text = text + newLine + string.Format("{0} -> {1}", new object[2]
				{
					Context.SourceType.Name,
					Context.DestinationType.Name
				});
				text = text + newLine + string.Format("{0} -> {1}", new object[2]
				{
					Context.SourceType.FullName,
					Context.DestinationType.FullName
				});
				string destPath = GetDestPath(Context);
				string text2 = text;
				text = text2 + newLine + newLine + "Destination path:" + newLine + destPath;
				object obj = text;
				return string.Concat(obj, newLine, newLine, "Source value:", newLine, Context.SourceValue ?? "(null)");
			}
			if (_message != null)
			{
				text = _message;
			}
			return ((text == null) ? null : (text + newLine)) + base.Message;
		}
	}

	public override string StackTrace => string.Join(Environment.NewLine, from str in base.StackTrace.Split(new string[1] { Environment.NewLine }, StringSplitOptions.None)
		where !str.TrimStart(new char[0]).StartsWith("at AutoMapper.")
		select str);

	public AutoMapperMappingException()
	{
	}

	public AutoMapperMappingException(string message)
		: base(message)
	{
		_message = message;
	}

	public AutoMapperMappingException(string message, Exception inner)
		: base(null, inner)
	{
		_message = message;
	}

	public AutoMapperMappingException(ResolutionContext context)
	{
		Context = context;
	}

	public AutoMapperMappingException(ResolutionContext context, Exception inner)
		: base(null, inner)
	{
		Context = context;
	}

	public AutoMapperMappingException(ResolutionContext context, string message)
		: this(context)
	{
		_message = message;
	}

	private string GetDestPath(ResolutionContext context)
	{
		IEnumerable<ResolutionContext> enumerable = GetContexts(context).Reverse();
		StringBuilder stringBuilder = new StringBuilder(enumerable.First().DestinationType.Name);
		foreach (ResolutionContext item in enumerable)
		{
			if (!string.IsNullOrEmpty(item.MemberName))
			{
				stringBuilder.Append(".");
				stringBuilder.Append(item.MemberName);
			}
			if (item.ArrayIndex.HasValue)
			{
				stringBuilder.AppendFormat("[{0}]", new object[1] { item.ArrayIndex });
			}
		}
		return stringBuilder.ToString();
	}

	private static IEnumerable<ResolutionContext> GetContexts(ResolutionContext context)
	{
		while (context.Parent != null)
		{
			yield return context;
			context = context.Parent;
		}
		yield return context;
	}
}
