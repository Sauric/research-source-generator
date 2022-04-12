using System;
using System.Threading.Tasks;

namespace WebApp;

public interface IDateOnlyProvider
{
    Task<DateOnly> GetDateOnly();
}
