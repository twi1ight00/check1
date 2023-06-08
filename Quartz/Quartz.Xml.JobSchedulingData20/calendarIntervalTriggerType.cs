using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Quartz.Xml.JobSchedulingData20;

/// <remarks />
[Serializable]
[XmlType(Namespace = "http://quartznet.sourceforge.net/JobSchedulingData")]
[DesignerCategory("code")]
[GeneratedCode("xsd", "4.0.30319.17929")]
[DebuggerStepThrough]
public class calendarIntervalTriggerType : abstractTriggerType
{
	private string misfireinstructionField;

	private string repeatintervalField;

	private string repeatintervalunitField;

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
	[XmlElement("repeat-interval", DataType = "nonNegativeInteger")]
	public string repeatinterval
	{
		get
		{
			return repeatintervalField;
		}
		set
		{
			repeatintervalField = value;
		}
	}

	/// <remarks />
	[XmlElement("repeat-interval-unit")]
	public string repeatintervalunit
	{
		get
		{
			return repeatintervalunitField;
		}
		set
		{
			repeatintervalunitField = value;
		}
	}
}
