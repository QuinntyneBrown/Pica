using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Pica.Api.Core;
using Pica.Api.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Pica.Api.Features
{
    public class UpdateProfileCompanyImage
    {
        public class Request: IRequest<Response>
        {
            public ProfileDto Profile { get; set; }
            public IFormFile File { get; set; }
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

                profile.Apply(new DomainEvents.UpdateCompanyImageUrl(request.Profile.CompanyImageUrl));

                await _context.SaveChangesAsync(cancellationToken);
                
                return new ()
                {
                    Profile = profile.ToDto()
                };
            }
            
        }
    }
}
