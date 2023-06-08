namespace ns36;

internal interface Interface8
{
	object LabelValue { get; set; }

	bool IsCulture { get; set; }

	string SourceFormat { get; set; }

	bool IsDate { get; set; }

	bool IsNull { get; set; }

	Interface7 Children { get; }

	Interface8 Parent { get; }
}
