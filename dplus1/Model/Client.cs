namespace dplus1.Model;

public class Client : ICloneable, IEquatable<Client>
{
    public string Name { get; set; } = string.Empty;
    public string Lastname { get; set; } = string.Empty;
    public int Age { get; set; } = 0;
    public string Address { get; set; } = string.Empty;

    public object Clone()
    {
        return new Client
        {
            Name = this.Name,
            Lastname = this.Lastname,
            Age = this.Age,
            Address = this.Address
        };
    }

    public Client ToClone()
    {
        return (Client)this.Clone();
    }

    public bool Equals(Client? other)
    {
        if (other == null) return false;
        return this.Name == other.Name &&
               this.Lastname == other.Lastname &&
               this.Age == other.Age &&
               this.Address == other.Address;
    }
}
