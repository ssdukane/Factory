using Factory.Business;
using System.Threading.Tasks;

namespace Factory.Interface
{
    public interface IInvoke
    {
        Task<string> Invoke(DTO dto);
    }
}
