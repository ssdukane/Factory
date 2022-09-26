using System.Threading.Tasks;

namespace Factory.Interface
{
    public interface ILender
    {
        Task<string> CreateUser(int lender);
    }
}
