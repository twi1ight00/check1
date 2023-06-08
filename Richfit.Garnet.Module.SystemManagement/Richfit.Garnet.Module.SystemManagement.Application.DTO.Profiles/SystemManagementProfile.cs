using System;
using AutoMapper;
using Richfit.Garnet.Module.Base.Application.DTO;
using Richfit.Garnet.Module.Fundation.Application.DTO;
using Richfit.Garnet.Module.SystemManagement.Domain.Models;

namespace Richfit.Garnet.Module.SystemManagement.Application.DTO.Profiles;

internal class SystemManagementProfile : Profile
{
	protected override void Configure()
	{
		Mapper.CreateMap<SYS_ROLE, SYS_ROLEDTO>();
		Mapper.CreateMap<SYS_ROLEDTO, SYS_ROLE>();
		Mapper.CreateMap<SYS_USER_BUSINESS, SYS_USER_BUSINESSDTO>();
		Mapper.CreateMap<SYS_USER_BUSINESSDTO, SYS_USER_BUSINESS>();
		IMappingExpression<SYS_USER, SYS_USERDTO> userToUserDTO = Mapper.CreateMap<SYS_USER, SYS_USERDTO>();
		userToUserDTO.ForMember((SYS_USERDTO dto) => dto.USER_IDENTITY_TYPE, delegate(IMemberConfigurationExpression<SYS_USER> mc)
		{
			mc.Ignore();
		});
		Mapper.CreateMap<SYS_USERDTO, SYS_USER>();
		Mapper.CreateMap<SYS_USER, UserDTO>();
		Mapper.CreateMap<UserDTO, SYS_USER>();
		Mapper.CreateMap<SYS_ORG, SYS_ORGDTO>();
		Mapper.CreateMap<SYS_ORGDTO, SYS_ORG>();
		Mapper.CreateMap<SYS_LOG, SYS_LOGDTO>();
		Mapper.CreateMap<SYS_LOGDTO, SYS_LOG>();
		Mapper.CreateMap<SYS_USER_ROLE, SYS_USER_ROLEDTO>();
		Mapper.CreateMap<SYS_USER_ROLEDTO, SYS_USER_ROLE>();
		IMappingExpression<SYS_ORG, SYS_ORGDTO> Sys_OrgMappingExpression = Mapper.CreateMap<SYS_ORG, SYS_ORGDTO>();
		Sys_OrgMappingExpression.ForMember((SYS_ORGDTO dto) => dto.PARENT_ORG_NAME, delegate(IMemberConfigurationExpression<SYS_ORG> mc)
		{
			mc.MapFrom((SYS_ORG e) => e.SYS_ORG2.ORG_NAME);
		});
		IMappingExpression<OrgDTO, TREE_NODE> OrgDTO2TreeNode = Mapper.CreateMap<OrgDTO, TREE_NODE>();
		OrgDTO2TreeNode.ForMember((TREE_NODE dto) => dto.ID, delegate(IMemberConfigurationExpression<OrgDTO> mc)
		{
			mc.MapFrom((OrgDTO e) => e.ORG_ID);
		}).ForMember((TREE_NODE dto) => dto.NAME, delegate(IMemberConfigurationExpression<OrgDTO> mc)
		{
			mc.MapFrom((OrgDTO e) => e.ORG_NAME);
		}).ForMember((TREE_NODE dto) => dto.PARENT_ID, delegate(IMemberConfigurationExpression<OrgDTO> mc)
		{
			mc.MapFrom((OrgDTO e) => e.PARENT_ORG_ID);
		})
			.ForMember((TREE_NODE dto) => dto.PARENT_NAME, delegate(IMemberConfigurationExpression<OrgDTO> mc)
			{
				mc.MapFrom((OrgDTO e) => e.PARENT_ORG_NAME);
			})
			.ForMember((TREE_NODE dto) => dto.CHILD_COUNT, delegate(IMemberConfigurationExpression<OrgDTO> mc)
			{
				mc.MapFrom((OrgDTO e) => e.CHILD_COUNT);
			})
			.ForMember((TREE_NODE dto) => dto.TYPE, delegate(IMemberConfigurationExpression<OrgDTO> mc)
			{
				mc.MapFrom((OrgDTO e) => e.TYPE);
			})
			.ForMember((TREE_NODE dto) => dto.SORT, delegate(IMemberConfigurationExpression<OrgDTO> mc)
			{
				mc.MapFrom((OrgDTO e) => e.SORT);
			});
		IMappingExpression<OrgDTO, TREE_NODE<Guid>> OrgDTO2TreeNodeT = Mapper.CreateMap<OrgDTO, TREE_NODE<Guid>>();
		OrgDTO2TreeNodeT.ForMember((TREE_NODE<Guid> dto) => dto.ID, delegate(IMemberConfigurationExpression<OrgDTO> mc)
		{
			mc.MapFrom((OrgDTO e) => e.ORG_ID);
		}).ForMember((TREE_NODE<Guid> dto) => dto.NAME, delegate(IMemberConfigurationExpression<OrgDTO> mc)
		{
			mc.MapFrom((OrgDTO e) => e.ORG_NAME);
		}).ForMember((TREE_NODE<Guid> dto) => dto.PARENT_ID, delegate(IMemberConfigurationExpression<OrgDTO> mc)
		{
			mc.MapFrom((OrgDTO e) => e.PARENT_ORG_ID);
		})
			.ForMember((TREE_NODE<Guid> dto) => dto.PARENT_NAME, delegate(IMemberConfigurationExpression<OrgDTO> mc)
			{
				mc.MapFrom((OrgDTO e) => e.PARENT_ORG_NAME);
			})
			.ForMember((TREE_NODE<Guid> dto) => dto.CHILD_COUNT, delegate(IMemberConfigurationExpression<OrgDTO> mc)
			{
				mc.MapFrom((OrgDTO e) => e.CHILD_COUNT);
			})
			.ForMember((TREE_NODE<Guid> dto) => dto.TYPE, delegate(IMemberConfigurationExpression<OrgDTO> mc)
			{
				mc.MapFrom((OrgDTO e) => e.TYPE);
			})
			.ForMember((TREE_NODE<Guid> dto) => dto.SORT, delegate(IMemberConfigurationExpression<OrgDTO> mc)
			{
				mc.MapFrom((OrgDTO e) => e.SORT);
			});
	}
}
