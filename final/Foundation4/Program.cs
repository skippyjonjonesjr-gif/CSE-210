using System;

namespace ExerciseTracking
{
    class Program
    {
        static void Main(string[] args)
        {
            Activity[] activities = new Activity[3];

            activities[0] = new Running("14 Jul 2022", 20, 2.0);
            activities[1] = new StationaryBike("16 Jul 2022", 30, 16);
            activities[2] = new Swimming("17 Jul 2022", 10, 4); 

            Console.WriteLine("--- Fitness Activity Tracking Summary ---\n");
            
            for (int i = 0; i < activities.Length; i++)
            {
                Console.WriteLine(activities[i].GetSummary());
            }
        }
    }
}