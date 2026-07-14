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
    
    //smth


    
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
}