using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Pica.Api.Extensions;
using Pica.Api.Core;
using Pica.Api.Interfaces;
using Pica.Api.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Pica.Api.Features
{
    public class GetDigitalAssetsPage
    {
        public class Request : IRequest<Response>
        {
            public int PageSize { get; set; }
            public int Index { get; set; }
        }

        public class Response : ResponseBase
        {
            public int Length { get; set; }
            public List<DigitalAssetDto> Entities { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IPicaDbContext _context;

            public Handler(IPicaDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var query = from digitalAsset in _context.DigitalAssets
                            select digitalAsset;

                var length = await _context.DigitalAssets.CountAsync();

                var digitalAssets = await query.Page(request.Index, request.PageSize)
                    .Select(x => x.ToDto()).ToListAsync();

                return new()
                {
                    Length = length,
                    Entities = digitalAssets
                };
            }

        }
    }
}
