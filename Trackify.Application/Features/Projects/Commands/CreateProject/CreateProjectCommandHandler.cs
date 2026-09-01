using System;
using System.Diagnostics;
using MediatR;
using Trackify.Application.Interface;
using Trackify.Domain.Entities;

namespace Trackify.Application.Features.Projects.Commands.CreateProject;

public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateProjectCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var project = new Project()
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Title = request.Title,
                Description = request.Description,
            };
            await _unitOfWork.ProjectRepository.AddAsync(project);
            await _unitOfWork.SaveAsync();
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error: {ex.Message}");
            return false;
        }
    }
}
