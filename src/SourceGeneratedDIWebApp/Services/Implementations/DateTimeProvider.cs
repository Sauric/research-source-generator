using System;
using System.Threading.Tasks;

namespace WebApp;

public sealed class DateTimeProvider : IDateTimeProvider
{
    private readonly IDateOnlyProvider dateOnlyProvider;

    public DateTimeProvider(IDateOnlyProvider dateOnlyProvider)
        =>
        this.dateOnlyProvider = dateOnlyProvider;

    public async Task<DateTime> GetDateTime()
    {
        var dateonly = await dateOnlyProvider.GetDateOnly();
        return dateonly.ToDateTime(new());
    }
}