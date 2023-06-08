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
public class entryType
{
	private string keyField;

	private string valueField;

	/// <remarks />
	public string key
	{
		get
		{
			return keyField;
		}
		set
		{
			keyField = value;
		}
	}

	/// <remarks />
	public string value
	{
		get
		{
			return valueField;
		}
		set
		{
			valueField = value;
		}
	}
}
