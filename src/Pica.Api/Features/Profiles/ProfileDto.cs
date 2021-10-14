using System;

namespace Pica.Api.Features
{
    public class ProfileDto
    {
        public Guid? ProfileId { get; private set; }
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public string ImageUrl { get; private set; }
        public string CompanyImageUrl { get; private set; }

        public ProfileDto(string firstname, string lastname, string imageUrl, string companyImageUrl)
        {
            Firstname = firstname;
            Lastname = lastname;
            ImageUrl = imageUrl;
            CompanyImageUrl = companyImageUrl;
        }
    }
}
