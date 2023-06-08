using System.IO;
using Aspose;
using x1c8faa688b1f0b0c;
using xa7850104c8d8c135;

namespace x74500b509de15565;

internal abstract class x1183fab9204ba68f : x4cb7537b071ca71a
{
	protected x04bee0dec18e4b99 xe3e99d3417159bec;

	protected x28a5d52551b64191 xf86de1bd2f396938;

	protected x1183fab9204ba68f(x3fa09e8d7b952fbc metafileInfo, xb0d8039f74776744 apsBuilderContext)
		: base(metafileInfo, apsBuilderContext)
	{
	}

	protected override xb8e7e788f6d59708 DoPlay()
	{
		Stream xb8a774e0111d0fbe = base.x4aca0559c9e6ddc0.xb8a774e0111d0fbe;
		xb8a774e0111d0fbe.Position = base.x4aca0559c9e6ddc0.xeb1dab4c802b7198;
		xf86de1bd2f396938 = new x28a5d52551b64191(xb8a774e0111d0fbe);
		xe3e99d3417159bec = new x04bee0dec18e4b99(xf86de1bd2f396938);
		InitPlayer();
		while (xb8a774e0111d0fbe.Position < xb8a774e0111d0fbe.Length && (!base.xa6f30a6360be2a75.xec8728ceac69f279 || !base.x6cd834400ec1b81e) && xb8a774e0111d0fbe.Position + 8 <= xb8a774e0111d0fbe.Length)
		{
			xe3e99d3417159bec.x2785b0923dba0723();
			if (xe3e99d3417159bec.x437e3b626c0fdd43 < 8 || xe3e99d3417159bec.x3146d638ec378671 == xec95ecd2fe18d5f2.x4d0b9d4447ba7566 || xe3e99d3417159bec.x3146d638ec378671 == xec95ecd2fe18d5f2.xf75ab17da83ee889)
			{
				break;
			}
			PlayRecord();
			xe3e99d3417159bec.x0863f2d944829994();
		}
		return GetResult();
	}

	[JavaThrows(true)]
	protected abstract void InitPlayer();

	[JavaThrows(true)]
	protected abstract void PlayRecord();

	[JavaThrows(true)]
	protected abstract xb8e7e788f6d59708 GetResult();
}
