using System;
using MediatR;
using Trackify.Domain.Entities;

namespace Trackify.Application.Features.Projects.Queries.GetProjects;

public record GetProjectsQuery : IRequest<IEnumerable<Project>> {}
