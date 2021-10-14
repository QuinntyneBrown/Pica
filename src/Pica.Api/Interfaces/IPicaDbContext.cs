using Pica.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;

namespace Pica.Api.Interfaces
{
    public interface IPicaDbContext
    {
        DbSet<Profile> Profiles { get; }
        DbSet<StoredEvent> StoredEvents { get; }
        DbSet<DigitalAsset> DigitalAssets { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        
    }
}
