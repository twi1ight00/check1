using System.Collections;
using System.Reflection;
using xa604c4d210ae0581;

namespace x16f9a31f749b8bb1;

[DefaultMember("Item")]
internal class xa37c212c70888855 : ArrayList
{
	public x98d75821045fe9bd xe6d4b1b411ed94b5 => (x98d75821045fe9bd)base[xc0c4c459c6ccbd00];

	internal x98d75821045fe9bd xed3e432f7c9bf846 => this.get_xe6d4b1b411ed94b5(Count - 1);

	internal int x2e39a445d52f6ea8()
	{
		int num = 0;
		for (int i = 0; i < Count; i++)
		{
			num += this.get_xe6d4b1b411ed94b5(i).xf73ef160527516c8.Length;
		}
		return num;
	}

	internal x32939c68497cb083 x4f0c985cdc1a8a55()
	{
		return xed3e432f7c9bf846.xa7539800dadf4e5b.xc77edd00162b84f4.x32939c68497cb083;
	}
}
