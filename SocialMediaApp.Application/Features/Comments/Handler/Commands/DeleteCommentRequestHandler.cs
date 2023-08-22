using AutoMapper;
using MediatR;
using SocialMediaApp.Application.Features.Comments.Request.Commands;
using SocialMediaApp.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.Features.Comments.Handler.Commands
{
    public class DeleteCommentRequestHandler : IRequestHandler<DeleteCommentRequest, Unit>
    {
        private ICommentRepository? _commentRepository;

        public DeleteCommentRequestHandler(ICommentRepository commentRepository)
        {
            this._commentRepository = commentRepository;
        }
        public async Task<Unit> Handle(DeleteCommentRequest request, CancellationToken cancellationToken)
        {
            var CommentToBeDeleted = await _commentRepository.GetCommentById(request.deleteCommentDto.Id);

            if (CommentToBeDeleted == null) 
            {
                throw new Exception();
            }

            await _commentRepository.Delete(CommentToBeDeleted);
            return Unit.Value;
        }
    }
}
