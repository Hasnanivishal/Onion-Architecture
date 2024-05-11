namespace Domain.Entities;
public class Person
{
    public Guid Id { get; set; }

    public required string Name { get; set; }

    public DateTime DateOfBirth { get; set; }

    public required string Address { get; set; }
}
