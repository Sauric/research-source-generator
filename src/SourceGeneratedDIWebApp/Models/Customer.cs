using System;

namespace WebApp;

public sealed record class Customer(
    Guid Id, 
    string Name = "Jhon Doe", 
    string Comment = "Unknown Customer", 
    DateTime CreatedOn = new());