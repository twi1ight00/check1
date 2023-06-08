using System;

namespace Richfit.Garnet.Module.Base.Application.DTO;

public class EncryptAttribute : Attribute
{
	public bool IsEncrypt { get; set; }

	public EncryptAttribute()
	{
	}

	public EncryptAttribute(bool isEncrypt)
	{
		IsEncrypt = isEncrypt;
	}
}
