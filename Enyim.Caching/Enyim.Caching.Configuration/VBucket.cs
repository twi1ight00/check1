namespace Enyim.Caching.Configuration;

public struct VBucket
{
	private int master;

	private int[] replicas;

	public int Master => master;

	public int[] Replicas => replicas;

	public VBucket(int master, int[] replicas)
	{
		this.master = master;
		this.replicas = replicas;
	}
}
