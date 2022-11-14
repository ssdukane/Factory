using Omi.Domain.Entities;
using Microsoft.Extensions.Options;
using Omi.Application.Configuration;
using Omi.Application.Interfaces;
using Omi.Infra.Database;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;

namespace Omi.Infra.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly OmiRepositoryContext _context;
        private readonly IOptions<ApplicationOptions> _options;

        public OwnerRepository(OmiRepositoryContext context, IOptions<ApplicationOptions> options)
        {
            _context = context;
            _options = options;
        }
        public IEnumerable<Owner> GetOwners()
        {
            var owners = _context.Owners.ToList();

            return (IEnumerable<Owner>)owners;
        }

        public async Task AddOwner()
        {
            var owner = new Owner();
            owner.Id = Guid.NewGuid();
            owner.FirstName = "Mohan";
            owner.LastName = "Dukane";
            owner.BusinessName = "MSD";
            owner.DisplayName = "OMB";
            owner.Mobile = "9860555968";

            await _context.Owners.AddAsync(owner);
            _context.SaveChanges();
        }

        public async Task AddCustomer()
        {
            var owner = new Owner();
            owner.Id = Guid.NewGuid();
            owner.FirstName = "Mohan";
            owner.LastName = "Dukane";
            owner.BusinessName = "MSD";
            owner.DisplayName = "OMB";
            owner.Mobile = "9860555968";

            await _context.Owners.AddAsync(owner);
            _context.SaveChanges();
        }
    }
}
