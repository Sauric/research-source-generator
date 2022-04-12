using System;
using System.Threading.Tasks;

namespace WebApp;

public interface IDateTimeProvider
{
    Task<DateTime> GetDateTime();
}