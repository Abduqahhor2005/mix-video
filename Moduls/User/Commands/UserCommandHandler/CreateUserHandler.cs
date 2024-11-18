using MediatR;
using MixVideo.Common.PatternResult;
using MixVideo.Moduls.User.Repository.CommandRepository;

namespace MixVideo.Moduls.User.Commands.UserCommandHandler;

public class CreateUserHandler(IUserCommandRepository userCommandRepository):IRequestHandler<CreateUserRequest,BaseResult>
{
    public async Task<BaseResult> Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {
        bool existTitle =
            (await userCommandRepository
                .FindAsync(x => x.Email.ToLower() == request.UserBaseInfo.Email
                    .ToLower())).Any();
        if (existTitle) 
            return BaseResult.Failure(Error.AlreadyExist());
        int res = await userCommandRepository.AddAsync(request.ToUser());

        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("User not saved !!!"))
            : BaseResult.Success();
    }
}