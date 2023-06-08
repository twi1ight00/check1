using System;

namespace SolrNet.Commands.Parameters;

[Flags]
public enum TermVectorParameterOptions
{
	Default = 0,
	/// <summary>
	/// Returns document term frequency info per term in the document.
	/// </summary>
	TermFrequency = 1,
	/// <summary>
	/// Returns the Document Frequency (DF) of the term in the collection. 
	/// This can be computationally expensive.
	/// </summary>
	DocumentFrequency = 2,
	/// <summary>
	/// Returns position information.
	/// </summary>
	Positions = 4,
	/// <summary>
	/// Returns offset information for each term in the document.
	/// </summary>
	Offsets = 8,
	/// <summary>
	/// Calculates TF*IDF for each term. This can be computationally expensive. 
	/// </summary>
	TermFrequency_InverseDocumentFrequency = 0x10,
	/// <summary>
	/// Term frequency, document frequency, positions, offsets, term freq * inverse doc freq.
	/// </summary>
	All = 0x1F
}
