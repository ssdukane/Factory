using System.Threading.Tasks;

namespace Factory.Interface
{
    public interface IInvoke
    {
        Task<string> Invoke(int id);
    }
}
