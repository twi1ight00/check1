using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Richfit.Garnet.Module.Workflow.Messagge.entinfo;

/// <remarks />
[Serializable]
[GeneratedCode("System.Xml", "4.8.3752.0")]
[XmlType(Namespace = "http://tempuri.org/")]
[DebuggerStepThrough]
[DesignerCategory("code")]
public class RegistryInfo : INotifyPropertyChanged
{
	private string rESULTField;

	private string rEGISTRYCODEField;

	private string sERVICECODEField;

	private string bALANCEField;

	private string cREATEDATEField;

	private string rEGISTRYSTATEIDField;

	private string pRIORITYField;

	private string fIRSTREGISTRYDATEField;

	private string rEGISTRYDATEField;

	private string aGENTIDField;

	private string pRODUCTNAMEField;

	private string dESTMOBILEField;

	private string fLAGField;

	private string rEPLYCONTENTField;

	private string iSRETURNField;

	private string vERSIONField;

	private string gRADEField;

	private string pARENTField;

	private string sUBSIDIARYField;

	private string rOLESField;

	private string bALSTATUSField;

	private string dISCOUNTField;

	/// <remarks />
	[XmlElement(Order = 0)]
	public string RESULT
	{
		get
		{
			return rESULTField;
		}
		set
		{
			rESULTField = value;
			RaisePropertyChanged("RESULT");
		}
	}

	/// <remarks />
	[XmlElement(Order = 1)]
	public string REGISTRYCODE
	{
		get
		{
			return rEGISTRYCODEField;
		}
		set
		{
			rEGISTRYCODEField = value;
			RaisePropertyChanged("REGISTRYCODE");
		}
	}

	/// <remarks />
	[XmlElement(Order = 2)]
	public string SERVICECODE
	{
		get
		{
			return sERVICECODEField;
		}
		set
		{
			sERVICECODEField = value;
			RaisePropertyChanged("SERVICECODE");
		}
	}

	/// <remarks />
	[XmlElement(Order = 3)]
	public string BALANCE
	{
		get
		{
			return bALANCEField;
		}
		set
		{
			bALANCEField = value;
			RaisePropertyChanged("BALANCE");
		}
	}

	/// <remarks />
	[XmlElement(Order = 4)]
	public string CREATEDATE
	{
		get
		{
			return cREATEDATEField;
		}
		set
		{
			cREATEDATEField = value;
			RaisePropertyChanged("CREATEDATE");
		}
	}

	/// <remarks />
	[XmlElement(Order = 5)]
	public string REGISTRYSTATEID
	{
		get
		{
			return rEGISTRYSTATEIDField;
		}
		set
		{
			rEGISTRYSTATEIDField = value;
			RaisePropertyChanged("REGISTRYSTATEID");
		}
	}

	/// <remarks />
	[XmlElement(Order = 6)]
	public string PRIORITY
	{
		get
		{
			return pRIORITYField;
		}
		set
		{
			pRIORITYField = value;
			RaisePropertyChanged("PRIORITY");
		}
	}

	/// <remarks />
	[XmlElement(Order = 7)]
	public string FIRSTREGISTRYDATE
	{
		get
		{
			return fIRSTREGISTRYDATEField;
		}
		set
		{
			fIRSTREGISTRYDATEField = value;
			RaisePropertyChanged("FIRSTREGISTRYDATE");
		}
	}

	/// <remarks />
	[XmlElement(Order = 8)]
	public string REGISTRYDATE
	{
		get
		{
			return rEGISTRYDATEField;
		}
		set
		{
			rEGISTRYDATEField = value;
			RaisePropertyChanged("REGISTRYDATE");
		}
	}

	/// <remarks />
	[XmlElement(Order = 9)]
	public string AGENTID
	{
		get
		{
			return aGENTIDField;
		}
		set
		{
			aGENTIDField = value;
			RaisePropertyChanged("AGENTID");
		}
	}

	/// <remarks />
	[XmlElement(Order = 10)]
	public string PRODUCTNAME
	{
		get
		{
			return pRODUCTNAMEField;
		}
		set
		{
			pRODUCTNAMEField = value;
			RaisePropertyChanged("PRODUCTNAME");
		}
	}

	/// <remarks />
	[XmlElement(Order = 11)]
	public string DESTMOBILE
	{
		get
		{
			return dESTMOBILEField;
		}
		set
		{
			dESTMOBILEField = value;
			RaisePropertyChanged("DESTMOBILE");
		}
	}

	/// <remarks />
	[XmlElement(Order = 12)]
	public string FLAG
	{
		get
		{
			return fLAGField;
		}
		set
		{
			fLAGField = value;
			RaisePropertyChanged("FLAG");
		}
	}

	/// <remarks />
	[XmlElement(Order = 13)]
	public string REPLYCONTENT
	{
		get
		{
			return rEPLYCONTENTField;
		}
		set
		{
			rEPLYCONTENTField = value;
			RaisePropertyChanged("REPLYCONTENT");
		}
	}

	/// <remarks />
	[XmlElement(Order = 14)]
	public string ISRETURN
	{
		get
		{
			return iSRETURNField;
		}
		set
		{
			iSRETURNField = value;
			RaisePropertyChanged("ISRETURN");
		}
	}

	/// <remarks />
	[XmlElement(Order = 15)]
	public string VERSION
	{
		get
		{
			return vERSIONField;
		}
		set
		{
			vERSIONField = value;
			RaisePropertyChanged("VERSION");
		}
	}

	/// <remarks />
	[XmlElement(Order = 16)]
	public string GRADE
	{
		get
		{
			return gRADEField;
		}
		set
		{
			gRADEField = value;
			RaisePropertyChanged("GRADE");
		}
	}

	/// <remarks />
	[XmlElement(Order = 17)]
	public string PARENT
	{
		get
		{
			return pARENTField;
		}
		set
		{
			pARENTField = value;
			RaisePropertyChanged("PARENT");
		}
	}

	/// <remarks />
	[XmlElement(Order = 18)]
	public string SUBSIDIARY
	{
		get
		{
			return sUBSIDIARYField;
		}
		set
		{
			sUBSIDIARYField = value;
			RaisePropertyChanged("SUBSIDIARY");
		}
	}

	/// <remarks />
	[XmlElement(Order = 19)]
	public string ROLES
	{
		get
		{
			return rOLESField;
		}
		set
		{
			rOLESField = value;
			RaisePropertyChanged("ROLES");
		}
	}

	/// <remarks />
	[XmlElement(Order = 20)]
	public string BALSTATUS
	{
		get
		{
			return bALSTATUSField;
		}
		set
		{
			bALSTATUSField = value;
			RaisePropertyChanged("BALSTATUS");
		}
	}

	/// <remarks />
	[XmlElement(Order = 21)]
	public string DISCOUNT
	{
		get
		{
			return dISCOUNTField;
		}
		set
		{
			dISCOUNTField = value;
			RaisePropertyChanged("DISCOUNT");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
