using System;

namespace PageOffice.ZoomSeal;

public class User
{
	internal int _0002;

	private string _0003;

	internal string _0005;

	internal string _0008;

	private int _0006;

	private string _000E;

	internal DateTime _000F;

	internal DateTime _0002_2000;

	private int _0003_2000;

	private string _0005_2000;

	private string _0008_2000;

	private string _0006_2000;

	private string _000E_2000;

	private string _000F_2000;

	private string _0002_2001;

	private string _0003_2001;

	private string _0005_2001;

	private string _0008_2001;

	private string _0006_2001;

	public int ID => _0002;

	public string UserName
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

	public string Password
	{
		set
		{
			_0005 = value;
		}
	}

	public int DeptID
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

	public string DeptName
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

	public DateTime CreateTime => _000F;

	public DateTime UpdateTime => _0002_2000;

	public int RoleID
	{
		get
		{
			return _0003_2000;
		}
		set
		{
			_0003_2000 = value;
		}
	}

	public string RoleName
	{
		get
		{
			return _0005_2000;
		}
		set
		{
			_0005_2000 = value;
		}
	}

	public string EmployNo
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

	public string Duty
	{
		get
		{
			return _0006_2000;
		}
		set
		{
			_0006_2000 = value;
		}
	}

	public string Sex
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

	public string Tel
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

	public string Email
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

	public string Description
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

	public string IP
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

	public string Status
	{
		get
		{
			return _0006_2001;
		}
		set
		{
			_0006_2001 = value;
		}
	}

	public User()
	{
		_0002 = -1;
		_000F = DateTime.Now;
		_0002_2000 = DateTime.Now;
		_0006 = 1;
		_000E = global::_0005_2000._0002(1402790541);
		_0003 = string.Empty;
		_0005 = string.Empty;
		_0008 = string.Empty;
		_0003_2000 = 1;
		_0005_2000 = string.Empty;
		_0008_2000 = string.Empty;
		_0006_2000 = string.Empty;
		_000E_2000 = global::_0005_2000._0002(1402794130);
		_000F_2000 = string.Empty;
		_0002_2001 = string.Empty;
		_0003_2001 = string.Empty;
		_0005_2001 = string.Empty;
		_0008_2001 = string.Empty;
		_0006_2001 = global::_0005_2000._0002(1402794141);
	}
}
