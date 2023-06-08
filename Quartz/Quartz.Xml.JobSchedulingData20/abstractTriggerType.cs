using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Quartz.Xml.JobSchedulingData20;

/// <remarks />
[Serializable]
[XmlInclude(typeof(calendarIntervalTriggerType))]
[XmlType(Namespace = "http://quartznet.sourceforge.net/JobSchedulingData")]
[XmlInclude(typeof(cronTriggerType))]
[XmlInclude(typeof(simpleTriggerType))]
[GeneratedCode("xsd", "4.0.30319.17929")]
[DebuggerStepThrough]
[DesignerCategory("code")]
public abstract class abstractTriggerType
{
	private string nameField;

	private string groupField;

	private string descriptionField;

	private string jobnameField;

	private string jobgroupField;

	private string priorityField;

	private string calendarnameField;

	private jobdatamapType jobdatamapField;

	private object itemField;

	private DateTime endtimeField;

	private bool endtimeFieldSpecified;

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
	[XmlElement("job-name")]
	public string jobname
	{
		get
		{
			return jobnameField;
		}
		set
		{
			jobnameField = value;
		}
	}

	/// <remarks />
	[XmlElement("job-group")]
	public string jobgroup
	{
		get
		{
			return jobgroupField;
		}
		set
		{
			jobgroupField = value;
		}
	}

	/// <remarks />
	[XmlElement(DataType = "nonNegativeInteger")]
	public string priority
	{
		get
		{
			return priorityField;
		}
		set
		{
			priorityField = value;
		}
	}

	/// <remarks />
	[XmlElement("calendar-name")]
	public string calendarname
	{
		get
		{
			return calendarnameField;
		}
		set
		{
			calendarnameField = value;
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

	/// <remarks />
	[XmlElement("start-time", typeof(DateTime))]
	[XmlElement("start-time-seconds-in-future", typeof(string), DataType = "nonNegativeInteger")]
	public object Item
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

	/// <remarks />
	[XmlElement("end-time")]
	public DateTime endtime
	{
		get
		{
			return endtimeField;
		}
		set
		{
			endtimeField = value;
		}
	}

	/// <remarks />
	[XmlIgnore]
	public bool endtimeSpecified
	{
		get
		{
			return endtimeFieldSpecified;
		}
		set
		{
			endtimeFieldSpecified = value;
		}
	}
}
