using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Quartz.Xml.JobSchedulingData20;

/// <remarks />
[Serializable]
[XmlType(TypeName = "processing-directivesType", Namespace = "http://quartznet.sourceforge.net/JobSchedulingData")]
[GeneratedCode("xsd", "4.0.30319.17929")]
[DebuggerStepThrough]
[DesignerCategory("code")]
public class processingdirectivesType
{
	private bool overwriteexistingdataField;

	private bool ignoreduplicatesField;

	private bool scheduletriggerrelativetoreplacedtriggerField;

	/// <remarks />
	[DefaultValue(true)]
	[XmlElement("overwrite-existing-data")]
	public bool overwriteexistingdata
	{
		get
		{
			return overwriteexistingdataField;
		}
		set
		{
			overwriteexistingdataField = value;
		}
	}

	/// <remarks />
	[DefaultValue(false)]
	[XmlElement("ignore-duplicates")]
	public bool ignoreduplicates
	{
		get
		{
			return ignoreduplicatesField;
		}
		set
		{
			ignoreduplicatesField = value;
		}
	}

	/// <remarks />
	[XmlElement("schedule-trigger-relative-to-replaced-trigger")]
	[DefaultValue(false)]
	public bool scheduletriggerrelativetoreplacedtrigger
	{
		get
		{
			return scheduletriggerrelativetoreplacedtriggerField;
		}
		set
		{
			scheduletriggerrelativetoreplacedtriggerField = value;
		}
	}

	public processingdirectivesType()
	{
		overwriteexistingdataField = true;
		ignoreduplicatesField = false;
		scheduletriggerrelativetoreplacedtriggerField = false;
	}
}
