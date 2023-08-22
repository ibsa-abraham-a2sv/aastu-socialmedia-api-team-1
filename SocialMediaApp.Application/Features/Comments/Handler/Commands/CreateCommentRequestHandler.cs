using AutoMapper;
using MediatR;
using SocialMediaApp.Application.DTOs.Comments;
using SocialMediaApp.Application.DTOs.Comments.Validator;
using SocialMediaApp.Application.Exceptions;
using SocialMediaApp.Application.Features.Comments.Request.Commands;
using SocialMediaApp.Application.Persistence.Contracts;
using SocialMediaApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.Features.Comments.Handler.Commands;

public class CreateCommentRequestHandler : IRequestHandler<CreateCommentRequest, int>
{
    private ICommentRepository _commentRepository;
    private IMapper _mapper;
    public CreateCommentRequestHandler(ICommentRepository commentRepository, IMapper mapper)
    {
        this._commentRepository = commentRepository;
        this._mapper = mapper;
    }
    public async Task<int> Handle(CreateCommentRequest request, CancellationToken cancellationToken)
    {
        var comment = _mapper.Map<Comment>(request.creatCommentDto);
        var validator = new CreateCommentDtoValidator(_commentRepository);
        var validationResult = await validator.ValidateAsync(request.creatCommentDto, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult);
        }

        comment = await _commentRepository.Add(comment);
        return comment.Id;
    }
}
