using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Quartz.Xml.JobSchedulingData20;

/// <remarks />
[Serializable]
[GeneratedCode("xsd", "4.0.30319.17929")]
[XmlType(Namespace = "http://quartznet.sourceforge.net/JobSchedulingData")]
[DebuggerStepThrough]
[DesignerCategory("code")]
public class triggerType
{
	private abstractTriggerType itemField;

	/// <remarks />
	[XmlElement("simple", typeof(simpleTriggerType))]
	[XmlElement("cron", typeof(cronTriggerType))]
	[XmlElement("calendar-interval", typeof(calendarIntervalTriggerType))]
	public abstractTriggerType Item
	{
		get
		{
			return itemField;
		}
		set
		{
			itemField = value;
		}
	}
}
