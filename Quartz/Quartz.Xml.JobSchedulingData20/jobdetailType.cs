using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Quartz.Xml.JobSchedulingData20;

/// <remarks />
[Serializable]
[DebuggerStepThrough]
[XmlType(TypeName = "job-detailType", Namespace = "http://quartznet.sourceforge.net/JobSchedulingData")]
[GeneratedCode("xsd", "4.0.30319.17929")]
[DesignerCategory("code")]
public class jobdetailType
{
	private string nameField;

	private string groupField;

	private string descriptionField;

	private string jobtypeField;

	private bool durableField;

	private bool recoverField;

	private jobdatamapType jobdatamapField;

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

	/// <remarks />
	public string description
	{
		get
		{
			return descriptionField;
		}
		set
		{
			descriptionField = value;
		}
	}

	/// <remarks />
	[XmlElement("job-type")]
	public string jobtype
	{
		get
		{
			return jobtypeField;
		}
		set
		{
			jobtypeField = value;
		}
	}

	/// <remarks />
	public bool durable
	{
		get
		{
			return durableField;
		}
		set
		{
			durableField = value;
		}
	}

	/// <remarks />
	public bool recover
	{
		get
		{
			return recoverField;
		}
		set
		{
			recoverField = value;
		}
	}

	/// <remarks />
	[XmlElement("job-data-map")]
	public jobdatamapType jobdatamap
	{
		get
		{
			return jobdatamapField;
		}
		set
		{
			jobdatamapField = value;
		}
	}
}
