using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp;

public sealed class CustomerRepo : ICustomerRepo
{
    private Dictionary<Guid, Customer> DBcontext;

    private readonly IDateTimeProvider dateTimeProvider;

    public CustomerRepo(IDateTimeProvider dateTimeProvider)
    {
        DBcontext = new()
        {
            [Guid.Parse("86d0cda8-03e5-40c9-9008-624bfcb53739")] = new(Guid.Parse("86d0cda8-03e5-40c9-9008-624bfcb53739")),
            [Guid.Parse("505be143-d305-4912-93fc-19ec887e7b37")] = new(
                Guid.Parse("505be143-d305-4912-93fc-19ec887e7b37"),
                "Nick Chapas",
                "Youtuber",
                DateTime.Now),
            [Guid.Parse("a3616f1a-f73e-4367-9521-a0ddf9cf2c47")] = new(
                Guid.Parse("a3616f1a-f73e-4367-9521-a0ddf9cf2c47"),
                "John Lock",
                "Top from LOST",
                DateTime.Now)
        };

        this.dateTimeProvider = dateTimeProvider;
    }

    public async Task<Guid> CreateCustomer(Customer customer)
    {
        ArgumentNullException.ThrowIfNull(customer, nameof(customer));

        if(DBcontext.ContainsKey(customer.Id))
        {
            return Guid.Empty;
        }
        DBcontext.Add(customer.Id, customer with { CreatedOn = await dateTimeProvider.GetDateTime()});

        return customer.Id;
    }

    public Task<bool> DeleteCustomerById(Guid id)
    {
        if(DBcontext.ContainsKey(id))
        {
            DBcontext.Remove(id);
            return Task.FromResult(true);
        }

        return Task.FromResult(false);
    }

    public Task<Customer> GetCustomerById(Guid id)
        =>
        Task.FromResult(
            DBcontext.ContainsKey(id) ? 
            DBcontext[id] :
            new(default));

    public Task<IReadOnlyCollection<Customer>> GetCustomers()
        =>
        Task.FromResult(
            (IReadOnlyCollection<Customer>)(DBcontext.Count > 0 ? 
            DBcontext.Select(kv => kv.Value).ToArray() :
            Array.Empty<Customer>()));
}