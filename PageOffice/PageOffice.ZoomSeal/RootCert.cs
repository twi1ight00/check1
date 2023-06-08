using System;

namespace PageOffice.ZoomSeal;

public class RootCert
{
	internal int _0002;

	private string _0003;

	internal DateTime _0005;

	private string _0008;

	private string _0006;

	private string _000E;

	private string _000F;

	private string _0002_2000;

	public int ID => _0002;

	public string CertName
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

	public DateTime CreateTime => _0005;

	public string CertPKCS7
	{
		get
		{
			return _0002_2000;
		}
		set
		{
			_0002_2000 = value;
		}
	}

	public string ValidFrom
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

	public string ValidTo
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

	public string CertSerialNum
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

	public string Description
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

	public RootCert()
	{
		_0002 = -1;
		_0003 = string.Empty;
		_0005 = DateTime.Now;
		_0006 = string.Empty;
		_000E = string.Empty;
		_000F = string.Empty;
		_0002_2000 = string.Empty;
		_0008 = string.Empty;
	}
}
