using Jab;

namespace WebApp;

[ServiceProvider]
[Singleton(typeof(IDateOnlyProvider), typeof(DateOnlyProvider))]
[Singleton(typeof(IDateStringProvider), typeof(DateStringProvider))]
[Singleton(typeof(ICustomerRepo), typeof(CustomerRepo))]
[Singleton(typeof(IDateTimeProvider), typeof(DateTimeProvider))]
public partial class ServiceProviderSG{}
