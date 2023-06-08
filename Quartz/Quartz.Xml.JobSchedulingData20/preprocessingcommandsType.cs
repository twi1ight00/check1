using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Quartz.Xml.JobSchedulingData20;

/// <remarks />
[Serializable]
[GeneratedCode("xsd", "4.0.30319.17929")]
[XmlType(TypeName = "pre-processing-commandsType", Namespace = "http://quartznet.sourceforge.net/JobSchedulingData")]
[DebuggerStepThrough]
[DesignerCategory("code")]
public class preprocessingcommandsType
{
	private string[] deletejobsingroupField;

	private string[] deletetriggersingroupField;

	private preprocessingcommandsTypeDeletejob[] deletejobField;

	private preprocessingcommandsTypeDeletetrigger[] deletetriggerField;

	/// <remarks />
	[XmlElement("delete-jobs-in-group")]
	public string[] deletejobsingroup
	{
		get
		{
			return deletejobsingroupField;
		}
		set
		{
			deletejobsingroupField = value;
		}
	}

	/// <remarks />
	[XmlElement("delete-triggers-in-group")]
	public string[] deletetriggersingroup
	{
		get
		{
			return deletetriggersingroupField;
		}
		set
		{
			deletetriggersingroupField = value;
		}
	}

	/// <remarks />
	[XmlElement("delete-job")]
	public preprocessingcommandsTypeDeletejob[] deletejob
	{
		get
		{
			return deletejobField;
		}
		set
		{
			deletejobField = value;
		}
	}

	/// <remarks />
	[XmlElement("delete-trigger")]
	public preprocessingcommandsTypeDeletetrigger[] deletetrigger
	{
		get
		{
			return deletetriggerField;
		}
		set
		{
			deletetriggerField = value;
		}
	}
}
