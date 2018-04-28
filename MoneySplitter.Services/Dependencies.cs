using Caliburn.Micro;
using MoneySplitter.Infrastructure;

namespace MoneySplitter.Services
{
    public class Dependencies
    {
        public IMembershipService MembershipService => IoC.Get<IMembershipService>();
    }
}
