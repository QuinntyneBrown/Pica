using Pica.Api.Core;
using System;

namespace Pica.Api.DomainEvents
{
    public class CreateProfile: BaseDomainEvent {
        public Guid ProfileId { get; private set; } = Guid.NewGuid();
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public string ImageUrl { get; private set; }
        public string CompanyImageUrl { get; private set; }

        public CreateProfile(string firstname, string lastname, string imageUrl, string companyImageUrl)
        {
            Firstname = firstname;
            Lastname = lastname;
            ImageUrl = imageUrl;
            CompanyImageUrl = companyImageUrl;
        }
    }

    public class UpdateProfile : BaseDomainEvent
    {
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public string ImageUrl { get; private set; }
        public string CompanyImageUrl { get; private set; }

        public UpdateProfile(string firstname, string lastname, string imageUrl, string companyImageUrl)
        {
            Firstname = firstname;
            Lastname = lastname;
            ImageUrl = imageUrl;
            CompanyImageUrl = companyImageUrl;
        }
    }
    public class UpdateProfileImageUrl : BaseDomainEvent
    {
        public string ImageUrl { get; private set; }

        public UpdateProfileImageUrl(string imageUrl)
        {
            ImageUrl = imageUrl;
        }
    }

    public class UpdateCompanyImageUrl : BaseDomainEvent
    {
        public string CompanyImageUrl { get; private set; }

        public UpdateCompanyImageUrl(string companyImageUrl)
        {
            CompanyImageUrl = companyImageUrl;
        }
    }
}
