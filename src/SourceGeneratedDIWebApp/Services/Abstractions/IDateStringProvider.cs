using System.Threading.Tasks;

namespace WebApp;

public interface IDateStringProvider
{
    Task<string> GetStringDate();
}