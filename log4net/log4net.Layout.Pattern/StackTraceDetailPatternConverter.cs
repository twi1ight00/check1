using System;
using System.Collections;
using System.Reflection;
using System.Text;
using log4net.Util;

namespace log4net.Layout.Pattern;

/// <summary>
/// Write the caller stack frames to the output
/// </summary>
/// <remarks>
/// <para>
/// Writes the <see cref="P:log4net.Core.LocationInfo.StackFrames" /> to the output writer, using format:
/// type3.MethodCall3(type param,...) &gt; type2.MethodCall2(type param,...) &gt; type1.MethodCall1(type param,...)
/// </para>
/// </remarks>
/// <author>Adam Davies</author>
internal class StackTraceDetailPatternConverter : StackTracePatternConverter
{
	/// <summary>
	/// The fully qualified type of the StackTraceDetailPatternConverter class.
	/// </summary>
	/// <remarks>
	/// Used by the internal logger to record the Type of the
	/// log message.
	/// </remarks>
	private static readonly Type declaringType = typeof(StackTracePatternConverter);

	internal override string GetMethodInformation(MethodBase method)
	{
		string result = "";
		try
		{
			string text = "";
			string[] methodParameterNames = GetMethodParameterNames(method);
			StringBuilder stringBuilder = new StringBuilder();
			if (methodParameterNames != null && methodParameterNames.GetUpperBound(0) > 0)
			{
				for (int i = 0; i <= methodParameterNames.GetUpperBound(0); i++)
				{
					stringBuilder.AppendFormat("{0}, ", methodParameterNames[i]);
				}
			}
			if (stringBuilder.Length > 0)
			{
				stringBuilder.Remove(stringBuilder.Length - 2, 2);
				text = stringBuilder.ToString();
			}
			result = base.GetMethodInformation(method) + "(" + text + ")";
		}
		catch (Exception exception)
		{
			LogLog.Error(declaringType, "An exception ocurred while retreiving method information.", exception);
		}
		return result;
	}

	private string[] GetMethodParameterNames(MethodBase methodBase)
	{
		ArrayList arrayList = new ArrayList();
		try
		{
			ParameterInfo[] parameters = methodBase.GetParameters();
			int upperBound = parameters.GetUpperBound(0);
			for (int i = 0; i <= upperBound; i++)
			{
				arrayList.Add(string.Concat(parameters[i].ParameterType, " ", parameters[i].Name));
			}
		}
		catch (Exception exception)
		{
			LogLog.Error(declaringType, "An exception ocurred while retreiving method parameters.", exception);
		}
		return (string[])arrayList.ToArray(typeof(string));
	}
}
