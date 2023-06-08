using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Quartz.Xml.JobSchedulingData20;

/// <remarks />
[Serializable]
[DebuggerStepThrough]
[GeneratedCode("xsd", "4.0.30319.17929")]
[XmlType(Namespace = "http://quartznet.sourceforge.net/JobSchedulingData")]
[DesignerCategory("code")]
public class simpleTriggerType : abstractTriggerType
{
	private string misfireinstructionField;

	private string repeatcountField;

	private string repeatintervalField;

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
	[XmlElement("repeat-count", DataType = "integer")]
	public string repeatcount
	{
		get
		{
			return repeatcountField;
		}
		set
		{
			repeatcountField = value;
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
}
