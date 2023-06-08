using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Quartz.Xml.JobSchedulingData20;

/// <remarks />
[Serializable]
[XmlType(Namespace = "http://quartznet.sourceforge.net/JobSchedulingData")]
[GeneratedCode("xsd", "4.0.30319.17929")]
[DebuggerStepThrough]
[DesignerCategory("code")]
public class cronTriggerType : abstractTriggerType
{
	private string misfireinstructionField;

	private string cronexpressionField;

	private string timezoneField;

	/// <remarks />
	[XmlElement("misfire-instruction")]
	public string misfireinstruction
	{
		get
		{
			return misfireinstructionField;
		}
		set
		{
			misfireinstructionField = value;
		}
	}

	/// <remarks />
	[XmlElement("cron-expression")]
	public string cronexpression
	{
		get
		{
			return cronexpressionField;
		}
		set
		{
			cronexpressionField = value;
		}
	}

	/// <remarks />
	[XmlElement("time-zone")]
	public string timezone
	{
		get
		{
			return timezoneField;
		}
		set
		{
			timezoneField = value;
		}
	}
}
