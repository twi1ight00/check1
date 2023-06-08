using AutoMapper;
using Richfit.Garnet.Module.Attachment.Domain.Models;

namespace Richfit.Garnet.Module.Attachment.Application.DTO.Profiles;

/// <summary>
/// DTO映射定义
/// </summary>
public class AttachmentProfiles : Profile
{
	/// <summary>
	/// 映射DTO和POCO
	/// </summary>
	protected override void Configure()
	{
		Mapper.CreateMap<AttachmentDTO, SYS_ATTACHMENT>();
		Mapper.CreateMap<SYS_ATTACHMENT, AttachmentDTO>();
		Mapper.CreateMap<AttachmentMappingDTO, SYS_ATTACHMENT_MAPPING>();
		Mapper.CreateMap<SYS_ATTACHMENT_MAPPING, AttachmentMappingDTO>();
	}
}
