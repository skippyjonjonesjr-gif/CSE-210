using System;

namespace EventPlanning
{
    class Program
    {
        static void Main(string[] args)
        {
            Event[] events = new Event[3];

            Address addr1 = new Address("123 Main Street", "Rexburg", "ID", "USA");
            events[0] = new Lecture("Book of Mormon 101", "Introduction to Another Testament of Jesus Christ.", "7/18/2026", "2:00 PM", addr1, "Dr. Smith", 150);

            Address addr2 = new Address("129 Temple Square", "Salt Lake City", "UT", "USA");
            events[1]  = new Reception("Jones Wedding", "Celebrating the MR. and MRS.", "8/1/2026", "12:00 PM", addr2, "rsvpwedding@gmail.com");

            Address addr3 = new Address("782 Nature Road", "Jackson Hole", "WY", "USA");
            events[2]  = new OutdoorGathering("Picnic", "Annual neighborhood gathering.", "9/8/2026", "11:00 AM", addr3, "Sunny with a light breeze, 72°F");


            for (int i = 0; i < events.Length; i++)
            {
                Console.WriteLine("========================================");
                Console.WriteLine(events[i].GetShortDescription());

                Console.WriteLine("\n" + events[i].GetStandardDetails());
                Console.WriteLine("\n" + events[i].GetFullDetails());
                Console.WriteLine("========================================\n");
            }
        }
    }
}