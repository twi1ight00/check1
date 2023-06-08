using System;
using System.Collections.Generic;

namespace Richfit.Garnet.Module.Workflow.Application.DTO.Migration;

[Serializable]
public class DataMigrationDTO
{
	public Guid oldId { get; set; }

	public string newId { get; set; }

	public bool isJump { get; set; }

	public List<DataMigrationDTO> activitys { get; set; }

	public DataMigrationDTO()
	{
		isJump = false;
	}
}
