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
        public async Task<string> Invoke(int id)
        {
            string result = string.Empty;
            switch (id)
            {
                case 16:
                    result = "Users";
                    break;
            }
            return result;
        }
    }
}
