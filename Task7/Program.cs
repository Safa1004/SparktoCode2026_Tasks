namespace Task7;

class Room
{
    public int RoomNumber { get; set; }
    public string RoomType { get; set; }
    public double PricePerNight { get; set; }
    public bool IsAvailable { get; set; }
    
    // constructor
    // IsAvailable isn't a param - hardcoded true, task says a new room is
    // always available when first added
    // values passed in at once
    public Room(int roomNumber, string roomType, double pricePerNight) // Params 
    {
        RoomNumber = roomNumber;
        RoomType = roomType;
        PricePerNight = pricePerNight;
        IsAvailable = true;
    }
    // method 
    public void displayRoom()
    {
        // ternary operator (shorter) 
        string status = IsAvailable ? "Available" : "Booked";
        Console.WriteLine($"Room {RoomNumber} | {RoomType} | OMR {PricePerNight:F2}/night | {status}");// F2= 2 decimal places
        
    
    }
    
}

class Guest
{
    public string GuestId { get; set; }
    public string GuestName { get; set; }
    public string RoomNumber { get; set; } // string since it needs to hold "Not Assigned" as a default before booking happens
    public string CheckInDate { get; set; }
    public int TotalNights { get; set; }
    
    
    // constructor
    // RoomNumber isn't a param ( hardcoded "Not Assigned")
    public Guest(string guestId, string guestName, string checkInDate, int totalNights)
    {
        GuestId = guestId;
        GuestName = guestName;
        CheckInDate = checkInDate;
        TotalNights = totalNights;
        RoomNumber = "Not Assigned";
    }
    public void displayGuest()
    {
        Console.WriteLine($"{GuestId} | {GuestName} | Room: {RoomNumber} | Check-in: {CheckInDate} | Nights: {TotalNights}");
    }
    
    // new fix : calculateTotalCost - needed for case 3's booking confirmation
    // takes Room as a param instead of storing price on Guest - keeps price
    // live off the room
    // this method takes in one argument, an object of type Room, and we'll refer to it as room inside the method body
    public double calculateTotalCost(Room room) //Room is the class/ room is the param 
    {
        if (room == null) return 0;
        return room.PricePerNight * TotalNights; //room is Room object and we access the PricePerNight property insde Room class 
        // take the room's price, multiply it by however many nights this guest is staying, return that number
    }


    
}


class Program
{
    static void Main(string[] args)
    {
       // declare lists 
       List<Room> rooms = new List<Room>();
       List<Guest> guests = new List<Guest>();
       
       // fills the rooms list with 6 starter rooms before anything else happens
       PreloadRooms(rooms);
       bool exitApp = false;
       while (!exitApp) // True 
       {
           Console.WriteLine("\n================================================");
           Console.WriteLine("GRAND VISTA HOTEL — MANAGEMENT SYSTEM");
           Console.WriteLine("================================================");
           Console.WriteLine(" 1. Add New Room");
           Console.WriteLine(" 2. Register New Guest");
           Console.WriteLine(" 3. Book a Room for a Guest");
           Console.WriteLine(" 4. View All Rooms");
           Console.WriteLine(" 5. View All Guests");
           Console.WriteLine(" 6. Search & Filter Rooms");
           Console.WriteLine(" 7. Guest & Booking Statistics");
           Console.WriteLine(" 8. Update Room Price");
           Console.WriteLine(" 9. Guest Lookup by Name");
           Console.WriteLine("10. Room Type Breakdown Report");
           Console.WriteLine("11. Check Out a Guest");
           Console.WriteLine("12. Remove Unavailable Rooms");
           Console.WriteLine("13. Extend Guest Stay");
           Console.WriteLine("14. Highest Revenue Booking");
           Console.WriteLine("15. Guest Pagination Viewer");
           Console.WriteLine(" 0. Exit");
           Console.WriteLine("================================================");
           Console.Write("Enter your choice: ");
           
           int choice;
           // Try-Catch (error handling)
           try
           {
               choice = int.Parse(Console.ReadLine());
           }
           catch (Exception)
           {
               Console.WriteLine("Invalid input. Please enter a number from 0 to 15.");
               continue;
           }
           switch (choice)
           {
               case 1: AddNewRoom(rooms); break;
               case 2: RegisterNewGuest(guests); break;
               case 3: BookRoomForGuest(guests, rooms); break;
               case 4: ViewAllRooms(rooms); break;
               case 5: ViewAllGuests(guests); break;
               case 6: SearchAndFilterRooms(rooms); break;
               case 7: GuestAndBookingStatistics(guests, rooms); break;
               case 8: UpdateRoomPrice(rooms); break;
               case 9: GuestLookupByName(guests); break;
               case 10: RoomTypeBreakdownReport(rooms); break;
               case 11: CheckOutGuest(guests, rooms); break;
               case 12: RemoveUnavailableRooms(rooms, guests); break;
               case 13: ExtendGuestStay(guests, rooms); break; // fix 
               case 14: HighestRevenueBooking(guests, rooms); break; // fix 
               case 15: GuestPaginationViewer(guests); break;
               case 0:
                   exitApp = true;
                   Console.WriteLine("Goodbye!");
                   break;
               default:
                   Console.WriteLine("Invalid option, please choose between 0 and 15.");
                   break;
           }

           if (!exitApp)
           {
               Console.Write("\npress any key to continue...");
               Console.ReadKey();
               Console.Clear();
           }
           
           
       }

    }
    
    static void PreloadRooms(List<Room> rooms) // takes room as param
    {
        rooms.Add(new Room(101, "Single", 25.00));
        rooms.Add(new Room(102, "Single", 25.00));
        rooms.Add(new Room(201, "Double", 40.00));
        rooms.Add(new Room(202, "Double", 40.00));
        rooms.Add(new Room(301, "Suite", 85.00));
        rooms.Add(new Room(302, "Suite", 90.00));
    }
    //-------------------------------------------------------------------------------
    // Case 1 - Add New Room 
    static void AddNewRoom(List<Room> rooms)
    {
        int roomNumber;
        
        // same try-catch 
        try
        {
            Console.Write("Enter room number: ");
            roomNumber = int.Parse(Console.ReadLine());
        }
        catch (Exception)
        {
            Console.WriteLine("Invalid room number.");
            return;
        }
        if (roomNumber <= 0)
        {
            Console.WriteLine("Room number must be positive.");
            return;
        }
        
        Console.Write("Enter room type (Single/Double/Suite): ");
        string roomType = Console.ReadLine();
        
        // same try-catch shape but for price
        double pricePerNight;
        try
        {
            Console.Write("Enter price per night: ");
            pricePerNight = double.Parse(Console.ReadLine());
        }
        catch (Exception)
        {
            Console.WriteLine("Invalid price.");
            return;
        }
        if (pricePerNight <= 0)
        {
            Console.WriteLine("Price per night must be positive.");
            return;
        }
        
        // duplicate check 
        // Any()  to check if the room number is duplicated before we add
        // so this is a quick yes/no to check 
        bool roomExists = rooms.Any(r => r.RoomNumber == roomNumber);
        if (roomExists)
        {
            Console.WriteLine("Error: a room with this number already exists.");
            return;
        }
        
        // only reaches here if BOTH validations passed AND no duplicate exists
        // now it's safe to actually create and add the room 
        // Room's constructor
        Room newRoom = new Room(roomNumber, roomType, pricePerNight); //ass params 
        rooms.Add(newRoom); // adds them to the list 
        
        Console.WriteLine("Room added successfully!");
        Console.WriteLine($"Room {newRoom.RoomNumber} | {newRoom.RoomType} | OMR {newRoom.PricePerNight:F2}/night");
        Console.WriteLine($"Total rooms: {rooms.Count}");

    }
    
    //-------------------------------------------------------------------------------
    // Case 2 -  Register New Guest 
    // no room assigned here - that's case 03's job, this one just registers the
    // guest with an auto-generated ID and a "Not Assigned" room by default
    static void RegisterNewGuest(List<Guest> guests)
    {
        Console.Write("Enter guest name: ");
        string guestName = Console.ReadLine();

        Console.Write("Enter check-in date: ");
        string checkInDate = Console.ReadLine();
        // same try-catch pattern as always
        int totalNights;
        try
        {
            Console.Write("Enter number of nights: ");
            totalNights = int.Parse(Console.ReadLine());
        }
        catch (Exception)
        {
            Console.WriteLine("Invalid number of nights.");
            return;
        }
        // same positive check 
        if (totalNights <= 0)
        {
            Console.WriteLine("Number of nights must be a positive number.");
            return;
        }
        // auto-generate guest ID from current list size
        // task says: (format: G001, G002, G003 ...) guests
        // guests.Count BEFORE adding this one gives us the right number 
        // (0 guests in list = this is guest #1 = G001)
        // ToString("D3") pads the number with leading zeros to always be 3 digits
        int nextIdNumber = guests.Count + 1;
        string guestId = "G" + nextIdNumber.ToString("D3");
        
        // only reaches here if nights validation passed
        //  RoomNumber isn't set here - Guest's constructor already hardcodes it
        // to "Not Assigned", nothing extra needed on this end
        Guest newGuest = new Guest(guestId, guestName, checkInDate, totalNights);
        guests.Add(newGuest);

        Console.WriteLine("Guest registered successfully!");
        Console.WriteLine($"Guest ID: {newGuest.GuestId} | Name: {newGuest.GuestName} | Check-in: {newGuest.CheckInDate} | Nights: {newGuest.TotalNights}");
        Console.WriteLine($"Total guests: {guests.Count}");
        
    }
    //-------------------------------------------------------------------------------
    // Case 3 -  Book a Room for a Guest 
    static void BookRoomForGuest(List<Guest> guests, List<Room> rooms)
    {
        Console.Write("Enter guest ID: ");
        string guestId = Console.ReadLine();
        
        // same try-catch pattern 
        int roomNumber;
        try
        {
            Console.Write("Enter room number: ");
            roomNumber = int.Parse(Console.ReadLine());
        }
        catch (Exception)
        {
            Console.WriteLine("Invalid room number.");
            return;
        }
        // FirstOrDefault() for the guest lookup
        //  returns null if no match found instead of crashing
        Guest foundGuest = guests.FirstOrDefault(g => g.GuestId == guestId);
        if (foundGuest == null)
        {
            Console.WriteLine("Error: guest not found.");
            return;
        }
        // same FirstOrDefault() pattern, this time on rooms
        Room foundRoom = rooms.FirstOrDefault(r => r.RoomNumber == roomNumber);
        if (foundRoom == null)
        {
            Console.WriteLine("Error: room not found.");
            return;
        }
        // availability check
        // if the room is not ! available then...
        if (!foundRoom.IsAvailable)
        {
            Console.WriteLine("Room is already booked.");
            return;
        }
        // only reaches here if guest found + room found + room available 
        
        
        foundGuest.RoomNumber = foundRoom.RoomNumber.ToString();
        // the left side is int since it was declared up there as int in Room class
        // the right side is in Guest class and it's a string it needs to hold "Not Assigned" as a default, which an int can't do
        // we cant assign them like this directly hat'd be trying to put an int into a string variable C# won't allow it
        // .ToString(); converts the left side (int) to string so now types would match and the assigment works 
        foundRoom.IsAvailable = false;
        // flips the status since now  booked by this guest
        
        // calculateTotalCost() needs the Room object - we already have foundRoom
        // right here from the lookup above, so pass it straight in
        double totalCost = foundGuest.calculateTotalCost(foundRoom);
        Console.WriteLine("Booking confirmed!");
        Console.WriteLine($"Guest: {foundGuest.GuestName} | Room: {foundRoom.RoomNumber} | Type: {foundRoom.RoomType}");
        Console.WriteLine($"Price per night: OMR {foundRoom.PricePerNight:F2} | Nights: {foundGuest.TotalNights}");
        Console.WriteLine($"Total cost: OMR {totalCost:F2}");
        
    }
    
    //-------------------------------------------------------------------------------
    // Case 4 -  View All Rooms
    static void ViewAllRooms(List<Room> rooms)
    {
        // empty check first
        if (rooms.Count == 0)
        {
            Console.WriteLine("No rooms have been added yet.");
            return;
        }
        
        // OrderBy() returns a NEW sorted list, doesn't touch the original rooms
        // OrderBy() sorts ascending (Low=>High)
        var sortedRooms = rooms.OrderBy(r => r.RoomNumber).ToList(); // var auto figure out the type 
        
        Console.WriteLine($"Total rooms: {rooms.Count}");
        foreach (Room r in sortedRooms)
        {
            r.displayRoom();
        }
    }
    //-------------------------------------------------------------------------------
    // Case 5 -  View All Guests
    // Same as case 4
    static void ViewAllGuests(List<Guest> guests)
    {
        // same empty check pattern 
        if (guests.Count == 0)
        {
            Console.WriteLine("No guests have been registered yet.");
            return;
        }
        // OrderBy() returns a NEW sorted list, doesn't touch the original guests
        // OrderBy() sorts ascending (Low=>High)
        var sortedGuests = guests.OrderBy(g => g.GuestName).ToList(); // var auto figure out the type
        
        Console.WriteLine($"Total guests: {guests.Count}");
        foreach (Guest g in sortedGuests)
        {
            g.displayGuest();
        }

    }
    //-------------------------------------------------------------------------------
    // Case 6 -  Search & Filter Rooms 
    static void SearchAndFilterRooms(List<Room> rooms)
    {
        // this one's a sub-menu, not a single action - keeps looping until the user
        // picks 0 (Back), same while/switch shape as the main menu but smaller
        bool backToMain = false;
        while (!backToMain) //true 
        {
            Console.WriteLine("\n--- Search & Filter Rooms ---");
            Console.WriteLine("1. Show all available rooms");
            Console.WriteLine("2. Filter by room type");
            Console.WriteLine("3. Filter by max price");
            Console.WriteLine("4. Room price statistics");
            Console.WriteLine("0. Back");
            Console.Write("Enter your choice: ");
            
            
            int subChoice;
            try
            {
                subChoice = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input.");
                continue;
            }

            switch (subChoice)
            {
                case 1:
                // Where() filters down to available rooms only, OrderBy()
                // sorts the result by price ascending - same "must not modify
                // rooms" cuz in here Where/OrderBy both return NEW lists
                var availableRooms = rooms.Where(r => r.IsAvailable).OrderBy(r => r.PricePerNight).ToList();
                // var auto figure out the type
                if (availableRooms.Count == 0)
                {
                    Console.WriteLine("No rooms found for the selected criteria.");
                }
                else
                {
                    Console.WriteLine($"Available rooms: {availableRooms.Count}");
                    foreach (Room r in availableRooms)
                        r.displayRoom();
                }
                break;
                
                case 2:
                    Console.Write("Enter room type to filter by: ");
                    string typeFilter = Console.ReadLine();
                // Where() on RoomType this time, no availability
                // condition here - task says "regardless of availability"
                    var typeRooms = rooms.Where(r => r.RoomType == typeFilter).ToList(); // var auto figure out the type
                    if (typeRooms.Count == 0)
                    {
                        Console.WriteLine("No rooms found for the selected criteria.");
                    }
                    else
                    {
                        Console.WriteLine($"Rooms of type '{typeFilter}': {typeRooms.Count}");
                        foreach (Room r in typeRooms)
                            r.displayRoom();
                    }
                    break;
                case 3:
                    double maxPrice;
                    try
                    {
                        Console.Write("Enter maximum price: ");
                        maxPrice = double.Parse(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid price.");
                        break;
                    }
                    // TWO conditions in one Where() - available AND at
                    // or below maxPrice, combined with && same as a normal if-statement
                    var affordableRooms = rooms.Where(r => r.IsAvailable && r.PricePerNight <= maxPrice)
                        .OrderBy(r => r.PricePerNight).ToList(); // var auto figure out the type
                    if (affordableRooms.Count == 0)
                    {
                        Console.WriteLine("No rooms found for the selected criteria.");
                    }
                    else
                    {
                        Console.WriteLine($"Rooms at or below OMR {maxPrice:F2}: {affordableRooms.Count}");
                        foreach (Room r in affordableRooms)
                            r.displayRoom();
                    }
                    break;
                case 4:
                // aggregation methods - these all scan the WHOLE
                // list and return ONE value (not a filtered list like Where does)
                // Min()/Max()/Average() would all crash on an empty list, so
                // checking Count first is a safety net
                if (rooms.Count == 0)
                {
                    Console.WriteLine("No rooms found for the selected criteria.");
                    break;
                }
                int totalRooms = rooms.Count();
                int availableCount = rooms.Count(r => r.IsAvailable);
                double avgPrice = rooms.Average(r => r.PricePerNight);
                double minPrice = rooms.Min(r => r.PricePerNight);
                double maxPriceVal = rooms.Max(r => r.PricePerNight);
                
                Console.WriteLine($"Total rooms: {totalRooms}");
                Console.WriteLine($"Available rooms: {availableCount}");
                Console.WriteLine($"Average price: OMR {avgPrice:F2}");
                Console.WriteLine($"Cheapest price: OMR {minPrice:F2}");
                Console.WriteLine($"Most expensive price: OMR {maxPriceVal:F2}");
                break;  
                case 0:
                    backToMain = true;
                    break;

                default:
                    Console.WriteLine("Invalid option, please choose between 0 and 4.");
                    break;



            }
        }
    }
    
    
    //-------------------------------------------------------------------------------
    // Case 7 -  Guest & Booking Statistics
    // mixes both lists - counts/averages on guests AND rooms, plus a top 3
    // ranking that needs calculateTotalCost() called INSIDE the LINQ itself
    static void GuestAndBookingStatistics(List<Guest> guests, List<Room> rooms)
    {
        // Count() with a Where condition - counts guests whose RoomNumber isn't
        // the default "Not Assigned" string, meaning they have an active booking
        int totalGuests = guests.Count();
        int guestsWithRoom = guests.Count(g => g.RoomNumber != "Not Assigned");
        
        // same idea but on the rooms list - counting booked rooms (not available)
        int totalRooms = rooms.Count();
        int bookedRooms = rooms.Count(r => !r.IsAvailable);
        
        Console.WriteLine($"Total guests: {totalGuests} | Guests with a room: {guestsWithRoom}");
        Console.WriteLine($"Total rooms: {totalRooms} | Booked rooms: {bookedRooms}");
        
        // if nobody's booked, skip straight to the message - Average()
        // on an empty filtered sequence would crash, same reasoning as case 06's
        // Min/Max guard
        // double avgNights = withBookings.Average(g => g.TotalNights); => this a crash 
        if (guestsWithRoom == 0)
        {
            Console.WriteLine("No active bookings recorded.");
            return;
        }
        // Average() with a Where filter (only averaging nights for guests who
        // actually have a booking, not the whole guests list)
        double avgNights = guests.Where(g => g.RoomNumber != "Not Assigned").Average(g => g.TotalNights);
        Console.WriteLine($"Average nights (active bookings): {avgNights:F2}");
        
        // top 3 highest spenders (this one made my mind blow up lol)
        // Where() first narrows down to guests with an active booking, then
        // OrderByDescending() (high to low)  sorts by calculateTotalCost() result, highest first,
        // then Take(3) grabs only the first 3 from that sorted list
        // calculateTotalCost() needs a Room, so inside the lambda we do a
        // FirstOrDefault() lookup to find THAT guest's specific room by RoomNumber
        var topSpenders = guests
            .Where(g => g.RoomNumber != "Not Assigned")
            .OrderByDescending(g => g.calculateTotalCost(rooms.FirstOrDefault(r => r.RoomNumber.ToString() == g.RoomNumber)))
            .Take(3) // take the first 3 
            .ToList();
        
        Console.WriteLine("Top 3 highest-spending guests:");
        foreach (Guest g in topSpenders)
        {
            Room theirRoom = rooms.FirstOrDefault(r => r.RoomNumber.ToString() == g.RoomNumber);
            double cost = g.calculateTotalCost(theirRoom);
            Console.WriteLine($"{g.GuestName} | Room {g.RoomNumber} | OMR {cost:F2}");
        }
        
        // Select() to build one formatted summary line per booked guest -
        // same FirstOrDefault() lookup pattern inside the lambda as above
        Console.WriteLine("Booking summaries:");
        var summaries = guests
            .Where(g => g.RoomNumber != "Not Assigned")
            .Select(g =>
            {
                Room theirRoom = rooms.FirstOrDefault(r => r.RoomNumber.ToString() == g.RoomNumber);
                double cost = g.calculateTotalCost(theirRoom);
                return $"{g.GuestName} — Room {g.RoomNumber} — {g.TotalNights} nights — OMR {cost:F2}";
            })
            .ToList();

        foreach (string line in summaries)
            Console.WriteLine(line); // this is a shortcut in of the loop only one statment lets you drop the { } entirely





    }
    //-------------------------------------------------------------------------------
    // Case 8 -  Update Room Price
    static void UpdateRoomPrice(List<Room> rooms)
    {
        int roomNumber;
        try
        {
            Console.Write("Enter room number: ");
            roomNumber = int.Parse(Console.ReadLine());
        }
        catch (Exception)
        {
            Console.WriteLine("Invalid room number.");
            return;
        }
        
        // FirstOrDefault() to locate the room 
        Room foundRoom = rooms.FirstOrDefault(r => r.RoomNumber == roomNumber);
        if (foundRoom == null)
        {
            Console.WriteLine("Error: room not found.");
            return;
        }
        
        double newPrice;
        try
        {
            Console.Write("Enter new price per night: ");
            newPrice = double.Parse(Console.ReadLine());
        }
        catch (Exception)
        {
            Console.WriteLine("Invalid price.");
            return;
        }
        
        // same positive check 
        if (newPrice <= 0)
        {
            Console.WriteLine("Price must be positive. No change made.");
            return;
        }
        // grab the old price BEFORE overwriting it - once we assign
        // the new value, the old one is gone, so we snapshot it now to show
        // both in the confirmation message 
        double oldPrice = foundRoom.PricePerNight; 
        foundRoom.PricePerNight = newPrice;

        Console.WriteLine($"Room {foundRoom.RoomNumber} price updated: OMR {oldPrice:F2} → OMR {foundRoom.PricePerNight:F2}");
    }
    
    //-------------------------------------------------------------------------------
    // Case 9 -  Guest Lookup by Name 

    static void GuestLookupByName(List<Guest> guests)
    {
        Console.Write("Enter name or partial name to search: ");
        string searchText = Console.ReadLine();
        
        // ToLower() on both sides makes this case-insensitive - without
        // it, searching "safa" wouldn't match a guest named "Safa" since strings
        // are case-sensitive by default in C#
        // Contains() checks if searchText appears ANYWHERE inside the name, not
        // just at the start - that's what makes this a "partial" match search
        var matches = guests.Where(g => g.GuestName.ToLower().Contains(searchText.ToLower())).ToList();

        if (matches.Count == 0)
        {
            Console.WriteLine("No guests matched that search.");
            return;
        }
        
        Console.WriteLine($"Matches found: {matches.Count}");
        foreach (Guest g in matches)
        {
            Console.WriteLine($"{g.GuestId} | {g.GuestName} | Room: {g.RoomNumber}");
        }

    }
    
    //-------------------------------------------------------------------------------
    // Case 10 -  Room Type Breakdown Report

    static void RoomTypeBreakdownReport(List<Room> rooms)
    {
        // array of the 3 fixed types
        // loop through this array and reuse the
        // same Count()/Average() logic for each one
        string[] roomTypes = { "Single", "Double", "Suite" };
        foreach (string type in roomTypes)
        {
            // Count() with a Where condition - how many rooms of THIS type exist
            int typeCount = rooms.Count(r => r.RoomType == type);
            // BEFORE calling Average() - if typeCount is 0,
            // Average() on that filtered (empty) sequence would crash, same
            if (typeCount == 0)
            {
                Console.WriteLine($"{type}: 0 rooms | Average price: N/A");
            }
            else
            {
                double typeAvg = rooms.Where(r => r.RoomType == type).Average(r => r.PricePerNight);
                Console.WriteLine($"{type}: {typeCount} rooms | Average price: OMR {typeAvg:F2}");
            }
        }
        
        // overall average across ALL rooms regardless of type 
        
        if (rooms.Count == 0)
        {
            Console.WriteLine("Overall average price: N/A");
        }
        else
        {
            double overallAvg = rooms.Average(r => r.PricePerNight);
            Console.WriteLine($"Overall average price: OMR {overallAvg:F2}");
        }

    }
    
    //-------------------------------------------------------------------------------
    // Case 11 -  Check Out a Guest

    static void CheckOutGuest(List<Guest> guests, List<Room> rooms)
    {
        Console.Write("Enter guest ID to check out: ");
        string guestId = Console.ReadLine();

        // first lookup - find the guest
        Guest foundGuest = guests.FirstOrDefault(g => g.GuestId == guestId);
        if (foundGuest == null)
        {
            Console.WriteLine("Error: guest not found.");
            return;
        }
        // active booking check - a guest can exist but have no room yet
        // so checking existence alone isn't enough here
        if (foundGuest.RoomNumber == "Not Assigned")
        {
            Console.WriteLine("This guest has no active booking.");
            return;
        }
        
        // second lookup - LINKED to the first one lookup , using foundGuest.RoomNumber
        // (not user input) to find their specific room, same .ToString() type
        // (RoomNumber is int on Room, string on Guest)
        // Room is found and guest is found (they match)
        Room foundRoom = rooms.FirstOrDefault(r => r.RoomNumber.ToString() == foundGuest.RoomNumber);
        
        // final bill, calculateTotalCost() needs foundRoom which I just got above
        double totalCost = foundGuest.calculateTotalCost(foundRoom);
        Console.WriteLine("----- Final Bill -----");
        Console.WriteLine($"Guest: {foundGuest.GuestName} | Room: {foundRoom.RoomNumber} | Type: {foundRoom.RoomType}");
        Console.WriteLine($"Check-in: {foundGuest.CheckInDate} | Nights: {foundGuest.TotalNights}");
        Console.WriteLine($"Price per night: OMR {foundRoom.PricePerNight:F2} | Total cost: OMR {totalCost:F2}");

        Console.Write("Confirm checkout? (Y/N): ");
        string confirm = Console.ReadLine();

        // only proceed on Y - ToUpper() so lowercase "y" still works
        if (confirm.ToUpper() != "Y")
        {
            Console.WriteLine("Checkout cancelled. No changes made.");
            return;
        }
        
        // room MUST be freed before the guest is removed 
        // this order matters, so IsAvailable flips first, THEN Remove() happens
        foundRoom.IsAvailable = true;
        guests.Remove(foundGuest);

        Console.WriteLine("Checkout complete!");
        Console.WriteLine($"Remaining guests: {guests.Count} | Remaining rooms: {rooms.Count}");

        // Any() => (yes/no) to confirm the room shows as available now 
        bool roomIsFree = rooms.Any(r => r.RoomNumber == foundRoom.RoomNumber && r.IsAvailable);
        // ternary operator (shorter) // if the room is not available 
        Console.WriteLine(roomIsFree ? $"Room {foundRoom.RoomNumber} is now available." : "Something went wrong freeing the room.");


    }
    
    //-------------------------------------------------------------------------------
    // Case 12 - Remove Unavailable Rooms
    // a room is only removable if it's unavailable AND no
    // guest currently holds that room number

    static void RemoveUnavailableRooms(List<Room> rooms, List<Guest> guests)
    {
        // local function lets us write the removability check 
        bool IsRemovable(Room r)
        {
            // unavailable AND no guest anywhere in guests has this room number 
            // Any() here asks does no guest have this room number?
            // see if room number matches guest room number and ofc making both of them have same data type 
            return !r.IsAvailable && !guests.Any(g => g.RoomNumber == r.RoomNumber.ToString());
        }
        
        // preview - Where() => (filter) using the local function above, sorted by room number
        var removableRooms = rooms.Where(r => IsRemovable(r)).OrderBy(r => r.RoomNumber).ToList();

        if (removableRooms.Count == 0)
        {
            Console.WriteLine("All unavailable rooms are currently occupied. No rooms can be decommissioned.");
            return;
        }
        
        Console.WriteLine($"Rooms safe to remove: {removableRooms.Count}");
        foreach (Room r in removableRooms)
        {
            Console.WriteLine($"Room {r.RoomNumber} | {r.RoomType} | OMR {r.PricePerNight:F2}");
        }

        Console.Write("Confirm removal? (Y/N): ");
        string confirm = Console.ReadLine();

        if (confirm.ToUpper() != "Y")
        {
            Console.WriteLine("Removal cancelled. No rooms removed.");
            return;
        }
        
        // RemoveAll() takes a lambda (function let me write inline), calling the SAME local function
        // here as the preview used above - this is what guarantees "preview and
        // RemoveAll must apply identical logic" just like what the case req 
        int removedCount = rooms.RemoveAll(r => IsRemovable(r));

        Console.WriteLine($"Removed {removedCount} room(s).");
        Console.WriteLine($"Total rooms remaining: {rooms.Count}");

        // Select() to project just room number + type for what's left
        var remaining = rooms.Select(r => $"{r.RoomNumber} - {r.RoomType}").ToList();
        Console.WriteLine("Remaining rooms:");
        foreach (string line in remaining)
            Console.WriteLine(line);

    }
    
    //-------------------------------------------------------------------------------
    // Case 13 - Extend Guest Stay
    // validate active booking, add nights, recalc cost via calculateTotalCost()
    // add rooms cuz we need to cal the cost (calculateTotalCost() needs a Room object)
    static void ExtendGuestStay(List<Guest> guests, List<Room> rooms) // fix
    {
        
        //validate active booking
        Console.Write("Enter guest ID: ");
        string guestId = Console.ReadLine();

        Guest foundGuest = guests.FirstOrDefault(g => g.GuestId == guestId);
        if (foundGuest == null)
        {
            Console.WriteLine("Error: guest not found.");
            return;
        }
        
        if (foundGuest.RoomNumber == "Not Assigned")
        {
            Console.WriteLine("This guest has no active booking to extend.");
            return;
        }
        
        int additionalNights;
        try
        {
            Console.Write("Enter additional nights: ");
            additionalNights = int.Parse(Console.ReadLine());
        }
        catch (Exception)
        {
            Console.WriteLine("Invalid number of nights. No change made.");
            return;
        }
        
        // same positive check pattern
        if (additionalNights <= 0)
        {
            Console.WriteLine("Additional nights must be a positive number. No change made.");
            return;
        }
        // only reaches here if guest found + active booking + valid nights 
        
        foundGuest.TotalNights += additionalNights;
        Console.WriteLine($"Stay extended! New total nights: {foundGuest.TotalNights}");
    }
    
    //-------------------------------------------------------------------------------
    // Case 14 - Highest Revenue Booking 
    
    //which single active booking is generating the most revenue
    static void HighestRevenueBooking(List<Guest> guests, List<Room> rooms)
    {
        // Where() first - only guests with an active booking count here
        var activeGuests = guests.Where(g => g.RoomNumber != "Not Assigned").ToList();

        if (activeGuests.Count == 0)
        {
            Console.WriteLine("No active bookings recorded.");
            return;
        }
        
        // Select() to project each guest into an anonymous object
        // holding just the 3 fields we actually need (name, room, cost) 
        // same inside the lambda 
        var projected = activeGuests.Select(g =>
        {
            Room theirRoom = rooms.FirstOrDefault(r => r.RoomNumber.ToString() == g.RoomNumber);
            double cost = g.calculateTotalCost(theirRoom);
            return new { Name = g.GuestName, Room = g.RoomNumber, Cost = cost };
        });
        
        // OrderByDescending on the Cost field from what we just projected (highest one)
        var topEarner = projected.OrderByDescending(x => x.Cost).Take(1).ToList();

        Console.WriteLine("Highest revenue booking:");
        foreach (var entry in topEarner)
        {
            Console.WriteLine($"{entry.Name} | Room {entry.Room} | OMR {entry.Cost:F2}");
        }


       
    }
    static void GuestPaginationViewer(List<Guest> guests) { }
}