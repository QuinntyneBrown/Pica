using Pica.Api.Core;
using Pica.Api.DomainEvents;
using System;

namespace Pica.Api.Models
{
    public class Profile: AggregateRoot
    {
        public Guid ProfileId { get; private set; }
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public string ImageUrl { get; private set; }
        public string CompanyImageUrl { get; private set; }
        private Profile()
        {

        }

        public Profile(CreateProfile @event)
        {
            Apply(@event);
        }

        protected override void When(dynamic @event) => When(@event);

        private void When(CreateProfile @event)
        {
            ProfileId = @event.ProfileId;
            Firstname = @event.Firstname;
            Lastname = @event.Lastname;
            ImageUrl = @event.ImageUrl;
            CompanyImageUrl = @event.CompanyImageUrl;
        }

        private void When(UpdateProfileImageUrl @event)
        {
            ImageUrl = @event.ImageUrl;
        }

        private void When(UpdateCompanyImageUrl @event)
        {
            CompanyImageUrl = @event.CompanyImageUrl;
        }

        protected override void EnsureValidState()
        {
            if(string.IsNullOrEmpty(Firstname) || string.IsNullOrEmpty(Lastname))
            {
                throw new Exception("Invalid Profile");
            }
        }
    }
}
