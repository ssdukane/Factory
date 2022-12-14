using Factory.Business;
using Factory.Interface;
using Microsoft.AspNetCore.Mvc;
using Omi.Application.Interfaces;
using System.Threading.Tasks;

namespace Admin
{
    public class AdminManager : IInvoke
    {
        private IOwnerRepository _ownerRepository;
        public AdminManager(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }
        [HttpPost]
        [Route("Invoke")]
        public async Task<string> Invoke(DTO dto)
        {
            string result = string.Empty;
            switch (dto.RequestType)
            {
                case 101:
                    await _ownerRepository.AddOwner();
                    result = "1";
                    break;
                case 102:
                    await _ownerRepository.AddCustomer();
                    result = "1";
                    break;
            }
            return result;
        }
    }
}
