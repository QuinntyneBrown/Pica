using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Pica.Api.Models;
using Pica.Api.Core;
using Pica.Api.Interfaces;

namespace Pica.Api.Features
{
    public class CreateProfile
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
                var profile = new Profile(new (request.Profile.Firstname, request.Profile.Lastname, request.Profile.ImageUrl, request.Profile.CompanyImageUrl));
                
                _context.Profiles.Add(profile);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    Profile = profile.ToDto()
                };
            }
            
        }
    }
}
