using System;

public class CarFleet
{
    //https://leetcode.com/problems/car-fleet/
    public class Solution
    {
        public int CarFleet(int target, int[] position, int[] speed)
        {
            Array.Sort(position, speed);

            int fleets = 1;
            float arrivalTime = (target - position[^1]) / (float)speed[^1];
            float fleetArrivalTime = arrivalTime;

            for (int i = position.Length - 2; i >= 0; i--)
            {
                arrivalTime = (target - position[i]) / (float)speed[i];
                if (arrivalTime > fleetArrivalTime)
                {
                    fleets++;
                    fleetArrivalTime = arrivalTime;
                }
            }
            return fleets;
        }
    }
}