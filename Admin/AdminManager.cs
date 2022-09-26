using Factory.Business;
using Factory.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Admin
{
    public class AdminManager : IInvoke
    {
        [HttpPost]
        [Route("Invoke")]
        public async Task<string> Invoke(DTO dto)
        {
            string result = string.Empty;
            switch (dto.RequestType)
            {
                case 56:
                    result = "Regular Admin";
                    break;
                case 57:
                    result = "Super Admin";
                    break;
            }
            return result;
        }
    }
}
