using System;
using System.Collections;
using Aspose.Words.Reporting;
using x6c95d9cf46ff5f25;
using xf9a9481c3f63a419;

namespace xe86f37adaccef1c3;

internal class x8be2a8d4eef95c79 : x77c422f73b569bd1, xa11a4c48b53f49a6
{
	private readonly IDictionary xad196882e39a570c;

	private readonly string[] xf084610e631fe8fb;

	private readonly object[] x5241e222e5526fee;

	string xa11a4c48b53f49a6.x1d7098e1d9b923c4 => string.Empty;

	int xa11a4c48b53f49a6.x7114f795b22529ae => x5241e222e5526fee.Length;

	internal x8be2a8d4eef95c79(MailMerge mailMerge, string[] fieldNames, object[] fieldValues)
		: base(mailMerge)
	{
		if (fieldValues.Length != fieldNames.Length)
		{
			throw new ArgumentException("Length of fieldValues must be same as length of fieldNames.");
		}
		xad196882e39a570c = xd51c34d05311eee3.xdb04a310bbb29cff();
		for (int i = 0; i < fieldNames.Length; i++)
		{
			xad196882e39a570c[fieldNames[i]] = fieldValues[i];
		}
		xf084610e631fe8fb = fieldNames;
		x5241e222e5526fee = fieldValues;
	}

	protected override bool IsEof()
	{
		return base.x88ea13b6283cc215 >= 1;
	}

	private int x3f345eb74cf9a2f5(string x66ac3558868cc255)
	{
		for (int i = 0; i < xf084610e631fe8fb.Length; i++)
		{
			if (x0d299f323d241756.x90637a473b1ceaaa(xf084610e631fe8fb[i], x66ac3558868cc255))
			{
				return i;
			}
		}
		return -1;
	}

	int xa11a4c48b53f49a6.x74b8d10dd9d29ac2(string x66ac3558868cc255)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x3f345eb74cf9a2f5
		return this.x3f345eb74cf9a2f5(x66ac3558868cc255);
	}

	private bool x8eea839d9ccd81d6(int x8e9b5f316bf9cf3d, out object x5fc53c4ffd3eb8c9)
	{
		if (!x69c36a228a9b3b39.xda36a3450e67c2d7(this, x8e9b5f316bf9cf3d))
		{
			x5fc53c4ffd3eb8c9 = null;
			return false;
		}
		x5fc53c4ffd3eb8c9 = x5241e222e5526fee[x8e9b5f316bf9cf3d];
		return true;
	}

	bool xa11a4c48b53f49a6.x3f88a25febd23896(int x8e9b5f316bf9cf3d, out object x5fc53c4ffd3eb8c9)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x8eea839d9ccd81d6
		return this.x8eea839d9ccd81d6(x8e9b5f316bf9cf3d, out x5fc53c4ffd3eb8c9);
	}

	private bool x8eea839d9ccd81d6(string x66ac3558868cc255, out object x5fc53c4ffd3eb8c9)
	{
		if (xad196882e39a570c.Contains(x66ac3558868cc255))
		{
			x5fc53c4ffd3eb8c9 = xad196882e39a570c[x66ac3558868cc255];
			return true;
		}
		x5fc53c4ffd3eb8c9 = null;
		return false;
	}

	bool xa11a4c48b53f49a6.x3f88a25febd23896(string x66ac3558868cc255, out object x5fc53c4ffd3eb8c9)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x8eea839d9ccd81d6
		return this.x8eea839d9ccd81d6(x66ac3558868cc255, out x5fc53c4ffd3eb8c9);
	}

	private xa11a4c48b53f49a6 x24ae333dbfd93ca8(string xde5031b4f06bf874)
	{
		return null;
	}

	xa11a4c48b53f49a6 xa11a4c48b53f49a6.x438eef0af7e648c2(string xde5031b4f06bf874)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x24ae333dbfd93ca8
		return this.x24ae333dbfd93ca8(xde5031b4f06bf874);
	}
}
