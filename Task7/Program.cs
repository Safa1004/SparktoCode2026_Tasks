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
               case 13: ExtendGuestStay(guests); break;
               case 14: HighestRevenueBooking(guests); break;
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
        
    }
    static void ViewAllRooms(List<Room> rooms) { }
    static void ViewAllGuests(List<Guest> guests) { }
    static void SearchAndFilterRooms(List<Room> rooms) { }
    static void GuestAndBookingStatistics(List<Guest> guests, List<Room> rooms) { }
    static void UpdateRoomPrice(List<Room> rooms) { }
    static void GuestLookupByName(List<Guest> guests) { }
    static void RoomTypeBreakdownReport(List<Room> rooms) { }
    static void CheckOutGuest(List<Guest> guests, List<Room> rooms) { }
    static void RemoveUnavailableRooms(List<Room> rooms, List<Guest> guests) { }
    static void ExtendGuestStay(List<Guest> guests) { }
    static void HighestRevenueBooking(List<Guest> guests) { }
    static void GuestPaginationViewer(List<Guest> guests) { }
}