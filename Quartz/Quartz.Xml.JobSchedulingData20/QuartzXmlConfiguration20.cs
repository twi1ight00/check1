using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Quartz.Xml.JobSchedulingData20;

/// <remarks />
[Serializable]
[DesignerCategory("code")]
[XmlRoot("job-scheduling-data", Namespace = "http://quartznet.sourceforge.net/JobSchedulingData", IsNullable = false)]
[GeneratedCode("xsd", "4.0.30319.17929")]
[DebuggerStepThrough]
[XmlType(AnonymousType = true, Namespace = "http://quartznet.sourceforge.net/JobSchedulingData")]
public class QuartzXmlConfiguration20
{
	private preprocessingcommandsType[] preprocessingcommandsField;

	private processingdirectivesType[] processingdirectivesField;

	private jobschedulingdataSchedule[] scheduleField;

	private string versionField;

	/// <remarks />
	[XmlElement("pre-processing-commands")]
	public preprocessingcommandsType[] preprocessingcommands
	{
		get
		{
			return preprocessingcommandsField;
		}
		set
		{
			preprocessingcommandsField = value;
		}
	}

	/// <remarks />
	[XmlElement("processing-directives")]
	public processingdirectivesType[] processingdirectives
	{
		get
		{
			return processingdirectivesField;
		}
		set
		{
			processingdirectivesField = value;
		}
	}

	/// <remarks />
	[XmlElement("schedule")]
	public jobschedulingdataSchedule[] schedule
	{
		get
		{
			return scheduleField;
		}
		set
		{
			scheduleField = value;
		}
	}

	/// <remarks />
	[XmlAttribute]
	public string version
	{
		get
		{
			return versionField;
		}
		set
		{
			versionField = value;
		}
	}
}
