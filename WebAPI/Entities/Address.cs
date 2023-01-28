namespace WebAPI.Entities;

/// <summary>
/// Owned by User
/// </summary>
public class Address
{
    public string Street { get; set; }
    public string City { get; set; }
    public string Postcode { get; set; }
    public string Country { get; set; }
}