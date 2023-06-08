using System;
using System.Collections;
using System.IO;
using x13f1efc79617a47b;

namespace xb92b7270f78a4e8d;

internal class xe7be411416cfcd54 : SortedList
{
	private Guid x31394132931742a3 = Guid.Empty;

	public Guid x933ed8cf24f04c67
	{
		get
		{
			return x31394132931742a3;
		}
		set
		{
			x31394132931742a3 = value;
		}
	}

	public xe7be411416cfcd54()
		: this(Guid.Empty)
	{
	}

	public xe7be411416cfcd54(Guid clsid)
		: base(new xccc4682d51b83ee6())
	{
		x31394132931742a3 = clsid;
	}

	public void xd6b6ed77479ef68c(string xc15bd84e01929885, MemoryStream xcf18e5243f8d5fd3)
	{
		base.Add(xc15bd84e01929885, xcf18e5243f8d5fd3);
	}

	public void xd6b6ed77479ef68c(string xc15bd84e01929885, xe7be411416cfcd54 x630baaeb4d769680)
	{
		base.Add(xc15bd84e01929885, x630baaeb4d769680);
	}

	public MemoryStream x3e19bf48aeaa5779(string xc15bd84e01929885)
	{
		MemoryStream memoryStream = this[xc15bd84e01929885] as MemoryStream;
		if (memoryStream != null)
		{
			memoryStream.Position = 0L;
		}
		return memoryStream;
	}

	public MemoryStream xb3b34047219bdc2a(string xc15bd84e01929885)
	{
		MemoryStream memoryStream = x3e19bf48aeaa5779(xc15bd84e01929885);
		if (memoryStream == null)
		{
			throw new InvalidOperationException(string.Format(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("kklffmcgpmjgmmahkmhhmmohfhfiilmiildjklkjnkbkggikglpkelglpknlpjemijlmbkcnbfjnffaogkhoifoockfpjemppddafikahibbgdibhipbihgcchnckcedkhldihceahjeahafmfhfpfofkffgacmg", 1940282215)), xc15bd84e01929885));
		}
		return memoryStream;
	}

	public xe7be411416cfcd54 x03c5de1b1357f136(string xc15bd84e01929885)
	{
		return (xe7be411416cfcd54)this[xc15bd84e01929885];
	}

	public xe7be411416cfcd54 x6ebb4c69c3381310(string xc15bd84e01929885)
	{
		xe7be411416cfcd54 xe7be411416cfcd55 = x03c5de1b1357f136(xc15bd84e01929885);
		if (xe7be411416cfcd55 == null)
		{
			throw new InvalidOperationException(string.Format(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("apialaabfbhbcbobabfccbmcllcdopjdopaeaaiedpoemkffmpmfkpdgcpkgcpbhonihbophmngiejniijejjoljljckfojkmialajhl", 1012664493)), xc15bd84e01929885));
		}
		return xe7be411416cfcd55;
	}
}
