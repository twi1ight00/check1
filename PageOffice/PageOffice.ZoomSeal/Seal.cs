using System;

namespace PageOffice.ZoomSeal;

public class Seal
{
	internal int _0002;

	private string _0003;

	private string _0005;

	private string _0008;

	private int _0006;

	private int _000E;

	private string _000F;

	internal DateTime _0002_2000;

	internal DateTime _0003_2000;

	internal string _0005_2000;

	private string _0008_2000;

	private string _0006_2000;

	private string _000E_2000;

	private string _000F_2000;

	private string _0002_2001;

	private string _0003_2001;

	private string _0005_2001;

	private string _0008_2001;

	private byte[] _0006_2001;

	private string _000E_2001;

	public int ID => _0002;

	public string SealName
	{
		get
		{
			return _0003;
		}
		set
		{
			_0003 = value;
		}
	}

	public string SealType
	{
		get
		{
			return _0005;
		}
		set
		{
			if (value == global::_0005_2000._0002(1402790528))
			{
				_0005 = global::_0005_2000._0002(1402790528);
			}
			else
			{
				_0005 = global::_0005_2000._0002(1402786945);
			}
		}
	}

	public string SignerName
	{
		get
		{
			return _0008;
		}
		set
		{
			_0008 = value;
		}
	}

	public int SignerID
	{
		get
		{
			return _0006;
		}
		set
		{
			_0006 = value;
		}
	}

	public int DeptID
	{
		get
		{
			return _000E;
		}
		set
		{
			_000E = value;
		}
	}

	public string DeptName
	{
		get
		{
			return _000F;
		}
		set
		{
			_000F = value;
		}
	}

	public DateTime CreateTime => _0002_2000;

	public DateTime UpdateTime => _0003_2000;

	public string AuthType
	{
		get
		{
			return _0006_2000;
		}
		set
		{
			if (value == global::_0005_2000._0002(1402790608))
			{
				_0006_2000 = global::_0005_2000._0002(1402790608);
			}
			else
			{
				_0006_2000 = global::_0005_2000._0002(1402790631);
			}
		}
	}

	public string Status => _0005_2000;

	public string CertPKCS7
	{
		get
		{
			return _0008_2001;
		}
		set
		{
			_0008_2001 = value;
		}
	}

	public string ValidFrom
	{
		get
		{
			return _0003_2001;
		}
		set
		{
			_0003_2001 = value;
		}
	}

	public string ValidTo
	{
		get
		{
			return _0005_2001;
		}
		set
		{
			_0005_2001 = value;
		}
	}

	public string CertSerialNum
	{
		get
		{
			return _0002_2001;
		}
		set
		{
			_0002_2001 = value;
		}
	}

	public string IssueBy
	{
		get
		{
			return _000F_2000;
		}
		set
		{
			_000F_2000 = value;
		}
	}

	public string IssueTo
	{
		get
		{
			return _000E_2000;
		}
		set
		{
			_000E_2000 = value;
		}
	}

	public string Description
	{
		get
		{
			return _0008_2000;
		}
		set
		{
			_0008_2000 = value;
		}
	}

	public byte[] SealImage
	{
		get
		{
			return _0006_2001;
		}
		set
		{
			if (value != null)
			{
				byte[] array = new byte[value.Length];
				value.CopyTo(array, 0);
				_0006_2001 = array;
			}
		}
	}

	public string SealImageType
	{
		get
		{
			return _000E_2001;
		}
		set
		{
			_000E_2001 = value;
		}
	}

	public Seal()
	{
		_0002 = -1;
		_0005 = global::_0005_2000._0002(1402790528);
		_0002_2000 = DateTime.Now;
		_0003_2000 = DateTime.Now;
		_000E_2000 = string.Empty;
		_000F_2000 = string.Empty;
		_0002_2001 = string.Empty;
		_0003_2001 = string.Empty;
		_0005_2001 = string.Empty;
		_0008_2001 = string.Empty;
		_000E_2001 = string.Empty;
		_0008_2000 = string.Empty;
		_0006_2001 = null;
		_000E = 1;
		_000F = global::_0005_2000._0002(1402790541);
		_0005_2000 = global::_0005_2000._0002(1402790650);
		_0006_2000 = global::_0005_2000._0002(1402790631);
		_0006 = 1;
	}
}
