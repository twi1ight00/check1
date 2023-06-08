using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Quartz.Xml.JobSchedulingData20;

/// <remarks />
[Serializable]
[DebuggerStepThrough]
[XmlType(AnonymousType = true, Namespace = "http://quartznet.sourceforge.net/JobSchedulingData")]
[DesignerCategory("code")]
[GeneratedCode("xsd", "4.0.30319.17929")]
public class jobschedulingdataSchedule
{
	private jobdetailType[] jobField;

	private triggerType[] triggerField;

	/// <remarks />
	[XmlElement("job")]
	public jobdetailType[] job
	{
		get
		{
			return jobField;
		}
		set
		{
			jobField = value;
		}
	}

	/// <remarks />
	[XmlElement("trigger")]
	public triggerType[] trigger
	{
		get
		{
			return triggerField;
		}
		set
		{
			triggerField = value;
		}
	}
}
