using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RabidBike.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RabidBike.Data.Identity
{
    public class RabidUserManager : UserManager<ApplicationUser>
    {
        public RabidUserManager(IUserStore<ApplicationUser> store, IOptions<IdentityOptions> optionsAccessor,
            IPasswordHasher<ApplicationUser> passwordHasher, IEnumerable<IUserValidator<ApplicationUser>> userValidators,
            IEnumerable<IPasswordValidator<ApplicationUser>> passwordValidators, ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<ApplicationUser>> logger)
                : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {

        }

        public async Task<ApplicationUser> FindByIdWithRelatedDataAsync(string userId)
        {
            return await Users
                            .Include(u => u.Items)
                                .ThenInclude(i => i.Condition)
                             .Include(u => u.Items)
                                .ThenInclude(i => i.Location)
                             .Include(u => u.Items)
                                .ThenInclude(i => i.Seller)
                            .Where(u => u.Id == userId)
                            .SingleAsync();
        }
    }
}
