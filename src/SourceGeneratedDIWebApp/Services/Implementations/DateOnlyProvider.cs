using System;
using System.Threading.Tasks;

namespace WebApp;
public class DateOnlyProvider : IDateOnlyProvider
{
    public Task<DateOnly> GetDateOnly()
        => Task.FromResult(DateOnly.FromDateTime(DateTime.Now));
}
