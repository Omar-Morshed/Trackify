using System;
using MediatR;
using Trackify.Application.Interface;

namespace Trackify.Application.Features.Projects.Commands.DeleteProject;

public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteProjectCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.ProjectRepository.DeleteAsync(request.Id);
        return await _unitOfWork.SaveAsync() == 1;
    }
}
