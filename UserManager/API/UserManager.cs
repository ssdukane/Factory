using Factory.Business;
using Factory.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Users.API
{
    public class UserManager : IInvoke
    {

        [HttpPost]
        [Route("Invoke")]
        public async Task<string> Invoke(DTO dto)
        {
            string result = string.Empty;
            switch (dto.RequestType)
            {
                case 12:
                    result = "Regular User";
                    break;
                case 13:
                    result = "Super User";
                    break;
            }
            return result;
        }
    }
}
