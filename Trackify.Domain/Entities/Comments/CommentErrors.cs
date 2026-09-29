using System;
using Trackify.Domain.Abstractions;

namespace Trackify.Domain.Entities.Comments;

public static class CommentErrors
{
    public static readonly Error NotFound = new(
        "Comment.NotFound", 
        "The specified comment was not found.");

    public static readonly Error EmptyContent = new(
        "Comment.EmptyContent", 
        "Comment content cannot be empty.");
}
