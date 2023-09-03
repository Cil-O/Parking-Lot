public class Vehicle
{
    public string RegistrationNo { get; }
    public string Colour { get; }
    public string Type { get; }

    public Vehicle(string registrationNo, string colour, string type)
    {
        RegistrationNo = registrationNo;
        Colour = colour;
        Type = type;
    }
}
