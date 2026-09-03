using System;
using Mapster;
using Trackify.Application.Features.Tasks.DTOs;
using Task = Trackify.Domain.Entities.Task;

namespace Trackify.Application.Configuration;

public class MapsterConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Task, TaskInfoDTO>()
            .Map(dest => dest.ProjectName, src => src.Project.Name);
    }
}
