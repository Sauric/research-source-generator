using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApp;

public interface ICustomerRepo
{
    Task<Customer> GetCustomerById(Guid id);

    Task<IReadOnlyCollection<Customer>> GetCustomers();

    Task<Guid> CreateCustomer(Customer customer);

    Task<bool> DeleteCustomerById(Guid id);
}