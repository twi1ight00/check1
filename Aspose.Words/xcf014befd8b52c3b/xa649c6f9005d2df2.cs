using System;
using x1495530f35d79681;

namespace xcf014befd8b52c3b;

internal abstract class xa649c6f9005d2df2
{
	private int xf731234783c82cd4;

	private int xe96ef9b19fb94ccb;

	private int xa29eaa2f6c57e61d;

	private int x64184b0ae058209a;

	private int xe953797caf183564;

	private string xa74e570557b549ca;

	private string x0e8f7ee8415aa9bf;

	private string x7191c8116d9359e1;

	private byte[] x93b7a9af0f720559;

	internal int x397a0ed128412c8f => xf731234783c82cd4;

	internal int xaf58b56360d8ce2d => xe96ef9b19fb94ccb;

	internal int xebe5541cca97eab4 => xa29eaa2f6c57e61d;

	internal int x1f875ed86e20ee9a => x64184b0ae058209a;

	internal int x182892fe19e15182 => xe953797caf183564;

	internal string x44f63c356a0e0a2a => xa74e570557b549ca;

	internal string x010a9b7177d08aeb => x0e8f7ee8415aa9bf;

	internal string x3b8b3c175efa9d40 => x7191c8116d9359e1;

	internal byte[] x92cd30b311b9f798 => x93b7a9af0f720559;

	protected bool x4bed28ad4f5c7865(x3c85359e1389ad43 x97bf2eeabd4abc7b)
	{
		switch (x97bf2eeabd4abc7b.xa66385d80d4d296f)
		{
		case "saltSize":
			xf731234783c82cd4 = x97bf2eeabd4abc7b.xbba6773b8ce56a01;
			break;
		case "blockSize":
			xe96ef9b19fb94ccb = x97bf2eeabd4abc7b.xbba6773b8ce56a01;
			break;
		case "keyBits":
			xa29eaa2f6c57e61d = x97bf2eeabd4abc7b.xbba6773b8ce56a01;
			break;
		case "hashSize":
			x64184b0ae058209a = x97bf2eeabd4abc7b.xbba6773b8ce56a01;
			break;
		case "cipherAlgorithm":
			xa74e570557b549ca = x97bf2eeabd4abc7b.xd2f68ee6f47e9dfb;
			break;
		case "cipherChaining":
			x0e8f7ee8415aa9bf = x97bf2eeabd4abc7b.xd2f68ee6f47e9dfb;
			break;
		case "hashAlgorithm":
			x7191c8116d9359e1 = x97bf2eeabd4abc7b.xd2f68ee6f47e9dfb;
			break;
		case "saltValue":
			x93b7a9af0f720559 = Convert.FromBase64String(x97bf2eeabd4abc7b.xd2f68ee6f47e9dfb);
			break;
		case "spinCount":
			xe953797caf183564 = x97bf2eeabd4abc7b.xbba6773b8ce56a01;
			break;
		default:
			return false;
		}
		return true;
	}
}
