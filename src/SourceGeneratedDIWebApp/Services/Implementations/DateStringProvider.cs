using System;
using System.Threading.Tasks;

namespace WebApp;

public class DateStringProvider: IDateStringProvider
{
    private readonly IDateOnlyProvider dateOnlyProvider;

    public DateStringProvider(IDateOnlyProvider dateOnlyProvider)
    {
        this.dateOnlyProvider = dateOnlyProvider;
    }

    public async Task<string> GetStringDate()
    {
        var dateonly = await dateOnlyProvider.GetDateOnly();
        return $"It is {dateonly.ToString()} date and {DateTime.Now.ToShortTimeString()}o'clock";
    }
}