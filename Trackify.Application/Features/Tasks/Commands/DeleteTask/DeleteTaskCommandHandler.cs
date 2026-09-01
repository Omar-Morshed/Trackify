using System;
using MediatR;
using Trackify.Application.Interface;

namespace Trackify.Application.Features.Tasks.Commands.DeleteTask;

public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteTaskCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public Task<int> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
