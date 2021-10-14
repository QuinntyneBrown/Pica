using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Pica.Api.Core;
using Pica.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Pica.Api.Features
{
    public class UpdateProfile
    {
        public class Validator: AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Profile).NotNull();
                RuleFor(request => request.Profile).SetValidator(new ProfileValidator());
            }
        
        }

        public class Request: IRequest<Response>
        {
            public ProfileDto Profile { get; set; }
        }

        public class Response: ResponseBase
        {
            public ProfileDto Profile { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IPicaDbContext _context;
        
            public Handler(IPicaDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var profile = await _context.Profiles.SingleAsync(x => x.ProfileId == request.Profile.ProfileId);

                profile.Apply(new DomainEvents.UpdateProfile(request.Profile.Firstname, request.Profile.Lastname, request.Profile.ImageUrl, request.Profile.CompanyImageUrl));

                await _context.SaveChangesAsync(cancellationToken);
                
                return new ()
                {
                    Profile = profile.ToDto()
                };
            }
            
        }
    }
}
