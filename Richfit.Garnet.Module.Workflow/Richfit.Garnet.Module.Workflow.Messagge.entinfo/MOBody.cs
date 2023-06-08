using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Richfit.Garnet.Module.Workflow.Messagge.entinfo;

/// <remarks />
[Serializable]
[GeneratedCode("System.Xml", "4.8.3752.0")]
[DesignerCategory("code")]
[XmlType(Namespace = "http://tempuri.org/")]
[DebuggerStepThrough]
public class MOBody : INotifyPropertyChanged
{
	private string total_numField;

	private string this_numField;

	private string recvtelField;

	private string senderField;

	private string contentField;

	private string recdateField;

	/// <remarks />
	[XmlElement(Order = 0)]
	public string total_num
	{
		get
		{
			return total_numField;
		}
		set
		{
			total_numField = value;
			RaisePropertyChanged("total_num");
		}
	}

	/// <remarks />
	[XmlElement(Order = 1)]
	public string this_num
	{
		get
		{
			return this_numField;
		}
		set
		{
			this_numField = value;
			RaisePropertyChanged("this_num");
		}
	}

	/// <remarks />
	[XmlElement(Order = 2)]
	public string recvtel
	{
		get
		{
			return recvtelField;
		}
		set
		{
			recvtelField = value;
			RaisePropertyChanged("recvtel");
		}
	}

	/// <remarks />
	[XmlElement(Order = 3)]
	public string sender
	{
		get
		{
			return senderField;
		}
		set
		{
			senderField = value;
			RaisePropertyChanged("sender");
		}
	}

	/// <remarks />
	[XmlElement(Order = 4)]
	public string content
	{
		get
		{
			return contentField;
		}
		set
		{
			contentField = value;
			RaisePropertyChanged("content");
		}
	}

	/// <remarks />
	[XmlElement(Order = 5)]
	public string recdate
	{
		get
		{
			return recdateField;
		}
		set
		{
			recdateField = value;
			RaisePropertyChanged("recdate");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
