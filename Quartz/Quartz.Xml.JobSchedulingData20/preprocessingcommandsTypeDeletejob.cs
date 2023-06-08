using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Quartz.Xml.JobSchedulingData20;

/// <remarks />
[Serializable]
[XmlType(AnonymousType = true, Namespace = "http://quartznet.sourceforge.net/JobSchedulingData")]
[GeneratedCode("xsd", "4.0.30319.17929")]
[DebuggerStepThrough]
[DesignerCategory("code")]
public class preprocessingcommandsTypeDeletejob
{
	private string nameField;

	private string groupField;

	/// <remarks />
	public string name
	{
		get
		{
			return nameField;
		}
		set
		{
			nameField = value;
		}
	}

	/// <remarks />
	public string group
	{
		get
		{
			return groupField;
		}
		set
		{
			groupField = value;
		}
	}
}
