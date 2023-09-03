using System;
using System.Collections.Generic;
class ParkingLot
{
    private readonly int totalLots;
    private readonly Dictionary<int, Vehicle> parkedVehicles;
    private readonly HashSet<string> occupiedPlates;

    public ParkingLot(int totalLots)
    {
        this.totalLots = totalLots;
        this.parkedVehicles = new Dictionary<int, Vehicle>();
        this.occupiedPlates = new HashSet<string>();
    }

    public Dictionary<int, Vehicle> ParkedVehicles => parkedVehicles;

    public int TotalLots => totalLots;

    public bool IsFull => parkedVehicles.Count >= totalLots;

    public int ParkVehicle(Vehicle vehicle)
    {
        if (IsFull)
        {
            return -1; // Parking lot is full
        }

        int slotNumber = FindAvailableSlot();
        parkedVehicles[slotNumber] = vehicle;
        occupiedPlates.Add(vehicle.RegistrationNo);
        return slotNumber;
    }

    public void LeaveVehicle(int slotNumber)
    {
        if (parkedVehicles.ContainsKey(slotNumber))
        {
            Vehicle vehicle = parkedVehicles[slotNumber];
            occupiedPlates.Remove(vehicle.RegistrationNo);
            parkedVehicles.Remove(slotNumber);
        }
    }

    public int GetVehicleCountByType(string type)
    {
        return parkedVehicles.Values.Count(vehicle => vehicle.Type.Equals(type, StringComparison.OrdinalIgnoreCase));
    }

    public List<string> GetOddPlates()
    {
        return occupiedPlates.Where(plate => IsPlateOdd(plate)).ToList();
    }

    public List<string> GetEvenPlates()
    {
        return occupiedPlates.Where(plate => !IsPlateOdd(plate)).ToList();
    }

    public List<string> GetMatchingColourPlates(string colour)
    {
        return parkedVehicles
            .Where(kvp => kvp.Value.Colour.Equals(colour, StringComparison.OrdinalIgnoreCase))
            .Select(kvp => kvp.Value.RegistrationNo)
            .ToList();
    }

    public List<int> GetMatchingColourSlots(string colour)
    {
        return parkedVehicles
            .Where(kvp => kvp.Value.Colour.Equals(colour, StringComparison.OrdinalIgnoreCase))
            .Select(kvp => kvp.Key)
            .ToList();
    }

    public int GetSlotNumberByRegistrationNo(string registrationNo)
    {
        foreach (var kvp in parkedVehicles)
        {
            if (kvp.Value.RegistrationNo.Equals(registrationNo, StringComparison.OrdinalIgnoreCase))
            {
                return kvp.Key;
            }
        }
        return -1; // Tidak ditemukan
    }

    private int FindAvailableSlot()
    {
        for (int slotNumber = 1; slotNumber <= totalLots; slotNumber++)
        {
            if (!parkedVehicles.ContainsKey(slotNumber))
            {
                return slotNumber;
            }
        }
        return -1; // Tidak ada slot tersedia
    }

    private bool IsPlateOdd(string plate)
    {
        char lastChar = plate[^1]; // Mendapatkan karakter terakhir dari nomor plat
        return (lastChar - '0') % 2 == 1;
    }
}