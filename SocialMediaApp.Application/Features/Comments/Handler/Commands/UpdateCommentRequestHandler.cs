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
    public class UpdateCommentRequestHandler : IRequestHandler<UpdateCommentRequest, Unit>
    {
        private readonly IMapper? _mapper;

        private ICommentRepository? _commentRepository;

        public UpdateCommentRequestHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            this._mapper = mapper;  
            this._commentRepository = commentRepository;
        }
        public Task<Unit> Handle(UpdateCommentRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
