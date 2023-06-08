using System.Collections.Specialized;
using Aspose.Words;
using Aspose.Words.Saving;
using x28925c9b27b37a46;
using x556d8f9846e43329;
using x5794c252ba25e723;

namespace x639ad3f66698fe1b;

internal class x21f0d20d41203be1
{
	private readonly x8556eed81191af11 xb36c250515e408ad;

	private readonly xbfd162a6d47f59a4 x800085dd555f7711;

	private readonly x93beff1c2303c6fc x9b287b671d592594;

	private readonly x4155bdfa7862bbeb xbe87b723aa0832ba;

	private readonly xb9e5964dad84ecc2 xa44cc83b91962898;

	private readonly xe2515fad245bf00c x226a09a3303fed2e;

	private readonly xc6381ce957044385 x50fd2f87dafc0d07;

	private readonly x785d57964efa4bd5 xe3136b4e0df7e7e5;

	private readonly xb06fc1bffc8a689b xa86f468fb82e63a7;

	private readonly x3026444e12edc9ae xa3452951a0eb4d8c;

	private readonly StringCollection x9cb399945a71ccf7 = new StringCollection();

	private bool x99d7d1b2b3aa26cb;

	private int x128fd4d397199bfe;

	private int x1bcc2cd425444087;

	private bool xadfa33361ab36175;

	internal Document x2c8c6741422a1298 => xb36c250515e408ad.x2c8c6741422a1298;

	internal x785d57964efa4bd5 x88bf28725f671e38 => xe3136b4e0df7e7e5;

	internal StringCollection x0f1b548a1d4927cb => x9cb399945a71ccf7;

	internal xb06fc1bffc8a689b x2086e697b5620586 => xa86f468fb82e63a7;

	internal x3026444e12edc9ae x05d5755b32029482 => xa3452951a0eb4d8c;

	internal x8556eed81191af11 x8556eed81191af11 => xb36c250515e408ad;

	internal RtfSaveOptions xf57de0fd37d5e97d => (RtfSaveOptions)xb36c250515e408ad.xf57de0fd37d5e97d;

	internal xbfd162a6d47f59a4 xe1410f585439c7d4 => x800085dd555f7711;

	internal x93beff1c2303c6fc x5aa326f374b3d0ef => x9b287b671d592594;

	internal x4155bdfa7862bbeb x6fca94e50472ae68 => xbe87b723aa0832ba;

	internal xb9e5964dad84ecc2 x1e8de05c1565effc => xa44cc83b91962898;

	internal xe2515fad245bf00c xf81237e03ccdf47f => x226a09a3303fed2e;

	internal xc6381ce957044385 x8b8ab0cf32b35f3c => x50fd2f87dafc0d07;

	internal bool xf41b717aaedc8265
	{
		get
		{
			return x99d7d1b2b3aa26cb;
		}
		set
		{
			x99d7d1b2b3aa26cb = value;
		}
	}

	internal int xc436e8202dc390b0
	{
		get
		{
			return x128fd4d397199bfe;
		}
		set
		{
			x128fd4d397199bfe = value;
		}
	}

	internal int x72bc9ec1224ff13e
	{
		get
		{
			return x1bcc2cd425444087;
		}
		set
		{
			x1bcc2cd425444087 = value;
		}
	}

	internal bool x5124b2bcc12d5218
	{
		get
		{
			return xadfa33361ab36175;
		}
		set
		{
			xadfa33361ab36175 = value;
		}
	}

	internal x21f0d20d41203be1(x8556eed81191af11 saveInfo, x93beff1c2303c6fc writer, x43845b10d17efb74 target)
	{
		xb36c250515e408ad = saveInfo;
		x9b287b671d592594 = writer;
		x800085dd555f7711 = new xbfd162a6d47f59a4(target, saveInfo.xf57de0fd37d5e97d.PrettyFormat);
		xbe87b723aa0832ba = new x4155bdfa7862bbeb(this);
		xa44cc83b91962898 = new xb9e5964dad84ecc2(this);
		x226a09a3303fed2e = new xe2515fad245bf00c(this);
		x50fd2f87dafc0d07 = new xc6381ce957044385(this);
		xe3136b4e0df7e7e5 = new x785d57964efa4bd5(addFirstEntry: true);
		xa86f468fb82e63a7 = new xb06fc1bffc8a689b(addFirstEntry: true);
		xa3452951a0eb4d8c = new x3026444e12edc9ae();
	}

	internal int xc4e3012717edc490(string xc15bd84e01929885)
	{
		return xb36c250515e408ad.x2c8c6741422a1298.FontInfos.x04327ff503798cdd(xc15bd84e01929885);
	}

	internal int xc15cf5804dbd5bbe(x26d9ecb4bdf0456d x6c50a99faab7d741)
	{
		return x88bf28725f671e38.xc15cf5804dbd5bbe(x6c50a99faab7d741);
	}
}
