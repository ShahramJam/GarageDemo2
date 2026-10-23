namespace GarageDemo2;

public sealed class Garage
{
    private readonly List<Vehicle?> _vehicles;
    private readonly int _capacity;

    public Garage(int capacity)
    {
        if (capacity <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(capacity),
                "Kapaciteten måste vara större än noll.");
        }

        _capacity = capacity;
        _vehicles = new List<Vehicle?>(capacity);
    }

    public int Capacity => _capacity;

    public int Count => _vehicles.Count(vehicle => vehicle is not null);

    // Returnera en kopia så att anroparen inte kan ändra garagets lista.
    public IReadOnlyList<Vehicle> Vehicles
    {
        get
        {
            List<Vehicle> vehicles = new List<Vehicle>(Count);

            foreach (Vehicle? vehicle in _vehicles)
            {
                if (vehicle is not null)
                {
                    vehicles.Add(vehicle);
                }
            }

            return vehicles;
        }
    }

    public bool TryPark(Vehicle vehicle, out string message)
    {
        if (Find(vehicle.RegistrationNumber) is not null)
        {
            message = "Registreringsnumret finns redan i garaget.";
            return false;
        }

        if (Count >= _capacity)
        {
            message = "Garaget är fullt.";
            return false;
        }

        _vehicles.Add(vehicle);
        message = $"{vehicle.RegistrationNumber} har parkerats.";
        return true;
    }

    public Vehicle? Find(string registrationNumber)
    {
        foreach (Vehicle? vehicle in _vehicles)
        {
            if (vehicle is not null &&
                string.Equals(
                    vehicle.RegistrationNumber,
                    registrationNumber,
                    StringComparison.OrdinalIgnoreCase))
            {
                return vehicle;
            }
        }

        return null;
    }

    public Vehicle? Remove(string registrationNumber)
    {
        for (int i = 0; i < _vehicles.Count; i++)
        {
            if (_vehicles[i] is Vehicle vehicle &&
                string.Equals(
                    vehicle.RegistrationNumber,
                    registrationNumber,
                    StringComparison.OrdinalIgnoreCase))
            {
                _vehicles.RemoveAt(i);
                return vehicle;
            }
        }

        return null;
    }
}