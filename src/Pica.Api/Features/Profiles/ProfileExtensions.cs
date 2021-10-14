using Pica.Api.Models;

namespace Pica.Api.Features
{
    public static class ProfileExtensions
    {
        public static ProfileDto ToDto(this Profile profile)
            => new (profile.Firstname, profile.Lastname, profile.ImageUrl, profile.CompanyImageUrl);
    }
}
