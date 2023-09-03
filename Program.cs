using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Parking System Console App");
        ParkingLot parkingLot = null;

        while (true)
        {
            Console.Write("Enter command: ");
            string input = Console.ReadLine();
            string[] tokens = input.Split(' ');

            if (tokens[0] == "create_parking_lot" && tokens.Length >= 2)
            {
                int totalLots = int.Parse(tokens[1]);
                parkingLot = new ParkingLot(totalLots);
                Console.WriteLine($"Created a parking lot with {totalLots} slots");
            }
            else if (tokens[0] == "park")
            {
                if (parkingLot != null)
                {
                    string registrationNo = tokens[1];
                    string colour = tokens[2];
                    string type = tokens[3];
                    Vehicle vehicle = new Vehicle(registrationNo, colour, type);

                    int slotNumber = parkingLot.ParkVehicle(vehicle);
                    if (slotNumber == -1)
                    {
                        Console.WriteLine("Sorry, parking lot is full");
                    }
                    else
                    {
                        Console.WriteLine($"Allocated slot number: {slotNumber}");
                    }
                }
                else
                {
                    Console.WriteLine("Parking lot is not created yet. Use 'create_parking_lot' command.");
                }
            }
            else if (tokens[0] == "leave")
            {
                if (parkingLot != null)
                {
                    if(tokens[1] != null){
                        int slotNumber = int.Parse(tokens[1]);
                        parkingLot.LeaveVehicle(slotNumber);
                        Console.WriteLine($"Slot number {slotNumber} is free");
                    }else{
                        int slotNumber = int.Parse(tokens[1]);
                        Console.WriteLine($"Slot number {slotNumber} no vehicles");
                    }
                    
                }
                else
                {
                    Console.WriteLine("Parking lot is not created yet. Use 'create_parking_lot' command.");
                }
            }
            else if (tokens[0] == "status")
            {
                if (parkingLot != null)
                {
                    Console.WriteLine("Slot\tNo.\tType\tRegistration No\tColour");
                    foreach (var kvp in parkingLot.ParkedVehicles)
                    {
                        Console.WriteLine($"{kvp.Key}\t{kvp.Value.RegistrationNo}\t{kvp.Value.Type}\t{kvp.Value.Colour}");
                    }
                }
                else
                {
                    Console.WriteLine("Parking lot is not created yet. Use 'create_parking_lot' command.");
                }
            }
            else if (tokens[0] == "type_of_vehicles")
            {
                if (parkingLot != null)
                {
                    string type = tokens[1];
                    int count = parkingLot.GetVehicleCountByType(type);
                    Console.WriteLine($"{count} {type}(s)");
                }
                else
                {
                    Console.WriteLine("Parking lot is not created yet. Use 'create_parking_lot' command.");
                }
            }
            else if (tokens[0] == "registration_numbers_for_vehicles_with_ood_plate")
            {
                if (parkingLot != null)
                {
                    List<string> oddPlates = parkingLot.GetOddPlates();
                    Console.WriteLine(string.Join(", ", oddPlates));
                }
                else
                {
                    Console.WriteLine("Parking lot is not created yet. Use 'create_parking_lot' command.");
                }
            }
            else if (tokens[0] == "registration_numbers_for_vehicles_with_event_plate")
            {
                if (parkingLot != null)
                {
                    List<string> evenPlates = parkingLot.GetEvenPlates();
                    Console.WriteLine(string.Join(", ", evenPlates));
                }
                else
                {
                    Console.WriteLine("Parking lot is not created yet. Use 'create_parking_lot' command.");
                }
            }
            else if (tokens[0] == "registration_numbers_for_vehicles_with_colour")
            {
                if (parkingLot != null)
                {
                    string colour = tokens[1];
                    List<string> matchingPlates = parkingLot.GetMatchingColourPlates(colour);
                    Console.WriteLine(string.Join(", ", matchingPlates));
                }
                else
                {
                    Console.WriteLine("Parking lot is not created yet. Use 'create_parking_lot' command.");
                }
            }
            else if (tokens[0] == "slot_numbers_for_vehicles_with_colour")
            {
                if (parkingLot != null)
                {
                    string colour = tokens[1];
                    List<int> matchingSlots = parkingLot.GetMatchingColourSlots(colour);
                    Console.WriteLine(string.Join(", ", matchingSlots));
                }
                else
                {
                    Console.WriteLine("Parking lot is not created yet. Use 'create_parking_lot' command.");
                }
            }
            else if (tokens[0] == "slot_number_for_registration_number")
            {
                if (parkingLot != null)
                {
                    string registrationNo = tokens[1];
                    int slotNumber = parkingLot.GetSlotNumberByRegistrationNo(registrationNo);
                    if (slotNumber == -1)
                    {
                        Console.WriteLine("Not found");
                    }
                    else
                    {
                        Console.WriteLine($"Slot number: {slotNumber}");
                    }
                }
                else
                {
                    Console.WriteLine("Parking lot is not created yet. Use 'create_parking_lot' command.");
                }
            }
            else if (tokens[0] == "exit")
            {
                break;
            }
        }
    }
}