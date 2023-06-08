using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Quartz.Xml.JobSchedulingData20;

/// <remarks />
[Serializable]
[GeneratedCode("xsd", "4.0.30319.17929")]
[XmlType(TypeName = "job-data-mapType", Namespace = "http://quartznet.sourceforge.net/JobSchedulingData")]
[DebuggerStepThrough]
[DesignerCategory("code")]
public class jobdatamapType
{
	private entryType[] entryField;

	/// <remarks />
	[XmlElement("entry")]
	public entryType[] entry
	{
		get
		{
			return entryField;
		}
		set
		{
			entryField = value;
		}
	}
}
