using Factory.Business;
using Factory.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace Dashboard
{
    public class DashboardManager : IInvoke
    {
        public async Task<string> Invoke(DTO dto)
        {
            string result = string.Empty;
            switch (dto.RequestType)
            {
                case 10:
                    result = "Dashboard 1";
                    break;
                case 11:
                    result = "Dashboard 2";
                    break;
            }
            return result;
        }
    }
}
