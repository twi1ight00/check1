namespace Quartz.Simpl;

internal class JobWrapper
{
	public readonly JobKey key;

	public IJobDetail jobDetail;

	internal JobWrapper(IJobDetail jobDetail)
	{
		this.jobDetail = jobDetail;
		key = jobDetail.Key;
	}

	public override bool Equals(object obj)
	{
		if (obj is JobWrapper)
		{
			JobWrapper jw = (JobWrapper)obj;
			if (jw.key.Equals(key))
			{
				return true;
			}
		}
		return false;
	}

	public override int GetHashCode()
	{
		return key.GetHashCode();
	}
}
