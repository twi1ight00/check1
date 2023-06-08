namespace ns309;

internal class Class7103
{
	internal float float_0;

	internal int int_0;

	internal float float_1;

	internal float float_2;

	internal int int_1;

	internal float[] float_3;

	internal float float_4;

	internal float float_5;

	internal float float_6;

	internal float float_7;

	internal float float_8;

	internal float float_9;

	internal float float_10;

	public virtual float Top => float_2;

	public virtual int Baseline => int_1;

	public virtual float[] BaselineLevelSet => float_3;

	public virtual float Bottom => float_4;

	public virtual float Height => float_5;

	public virtual float UnderlineLevel => float_7;

	public virtual float UnderlineWidth => float_8;

	public virtual float OverlineOffset => float_9;

	public virtual float OverlineThickness => float_10;

	public virtual float Leading => float_0;

	public virtual int Length => int_0;

	public virtual float StrikeLevel => float_1;

	public virtual float StrikeWidth => float_6;

	public Class7103()
	{
	}

	public Class7103(Class7103 lineMetrics)
	{
		float_2 = lineMetrics.Top;
		int_1 = lineMetrics.Baseline;
		float_3 = lineMetrics.BaselineLevelSet;
		float_4 = lineMetrics.Bottom;
		float_5 = lineMetrics.Height;
		float_0 = lineMetrics.Leading;
		int_0 = lineMetrics.Length;
		float_1 = lineMetrics.StrikeLevel;
		float_6 = lineMetrics.StrikeWidth;
		float_7 = lineMetrics.UnderlineLevel;
		float_8 = lineMetrics.UnderlineWidth;
		float_9 = 0f - float_2;
		float_10 = float_8;
	}

	public Class7103(Class7103 lineMetrics, float scale)
	{
		float_2 = lineMetrics.Top * scale;
		int_1 = lineMetrics.Baseline;
		float_3 = lineMetrics.BaselineLevelSet;
		for (int i = 0; i < float_3.Length; i++)
		{
			float_3[i] *= scale;
		}
		float_4 = lineMetrics.Bottom * scale;
		float_5 = lineMetrics.Height * scale;
		float_0 = lineMetrics.Leading;
		int_0 = lineMetrics.Length;
		float_1 = lineMetrics.StrikeLevel * scale;
		float_6 = lineMetrics.StrikeWidth * scale;
		float_7 = lineMetrics.UnderlineLevel * scale;
		float_8 = lineMetrics.UnderlineWidth * scale;
		float_9 = 0f - float_2;
		float_10 = float_8;
	}

	public Class7103(float topLevel, int baselineNumber, float[] baselineLevelSet, float bottomLevel, float height, float leading, int charSetLength, float strikethroughPosition, float strikethroughWidth, float underlineLevel, float underlineWidth, float overlinePosition, float lineWidth)
	{
		float_2 = topLevel;
		int_1 = baselineNumber;
		float_3 = baselineLevelSet;
		float_4 = bottomLevel;
		float_5 = height;
		float_0 = leading;
		int_0 = charSetLength;
		float_1 = strikethroughPosition;
		float_6 = strikethroughWidth;
		float_7 = underlineLevel;
		float_8 = underlineWidth;
		float_9 = overlinePosition;
		float_10 = lineWidth;
	}
}
