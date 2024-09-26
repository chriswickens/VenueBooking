using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VenueBooking
{

    /// <summary>
    /// This class creates the seat objects
    /// for the venue
    /// seatName - Name of the seat
    /// customerName - Name of customer booked at seat
    /// occupiedSeat - bool to show occupied/vacant seat
    /// </summary>
    internal class VenueSeats
    {
        // set to private later
        internal string seatName;
        internal string customerName;
        internal bool occupiedSeat;


        // Default constructor
        public VenueSeats()
        {
            this.seatName = string.Empty;
            this.customerName = string.Empty;
            this.occupiedSeat = false;
        }

        // Overloaded constructor
        public VenueSeats(
            string seatName,
            string customerName,
            bool occupiedSeat)
        {
            this.seatName = seatName;
            this.customerName = customerName;
            this.occupiedSeat = occupiedSeat;
        }

        /// <summary>
        /// Get first index of vacant position in venueArray
        /// </summary>
        public static void GetOccupancyLocation(
            VenueSeats[] venueArray,
            ref bool anyOccupancyCheck,
            ref int occupancyLocation)
        {
            // Resetting to avoid old data
            anyOccupancyCheck = false;
            occupancyLocation = 0;

            for (int i = 0; i < venueArray.GetLength(0); i++)
            {
                if (venueArray[i].occupiedSeat == false)
                {
                    anyOccupancyCheck = true;
                    occupancyLocation = i;

                    // Break after finding first empty location
                    // Otherwise it will only report the LAST location
                    break;
                }

                else
                {
                    anyOccupancyCheck = false;
                }
            }
        }

        /// <summary>
        /// Updates all occupancy information
        /// Top status, Seat buttons etc.
        /// </summary>
        /// <param name="venueArray"></param>
        /// <param name="buttonList"></param>
        /// <param name="waitList"></param>
        /// <param name="occupancyStatus"></param>
        public static void OccupancyDisplaysUpdater(
            VenueSeats[] venueArray,
            List<Button> buttonList,
            List<string> waitList,
            ref string occupancyStatus)
        {

            int waitListCount = waitList.Count;
            int occupiedSeats = 0;
            double occupationPercent = 0;


            for (int i = 0; i < venueArray.GetLength(0); i++)
            {
                if (venueArray[i].occupiedSeat == true)
                {
                    occupiedSeats++;
                    buttonList.ElementAt(i).BackColor = Color.Red;
                }

                else
                {                    
                    buttonList.ElementAt(i).BackColor = Color.FromArgb(0, 192, 0);
                }
            }

            if (occupiedSeats == 12)
            {
                occupationPercent = ((double)occupiedSeats) / 12 * 100;
                occupancyStatus = $"Total Capacity: {occupiedSeats}/12 NO CAPACITY!  - " +
                    $"({Math.Round(occupationPercent, 1)}%) Capacity" +
                    $"\n{waitListCount} person(s) on waitlist";
            }

            else
            {
                occupationPercent = ((double)occupiedSeats) / 12 * 100;
                occupancyStatus = $"Total Capacity: {occupiedSeats}/12  - " +
                    $"({Math.Round(occupationPercent, 1)}%) Capacity" +
                    $"\n{waitListCount} person(s) on waitlist";
            }
        }

        /// <summary>
        /// Display information about the seat being clicked on
        /// </summary>
        /// <param name="seatSelection"></param>
        /// <param name="sender"></param>
        public static void SeatClickedStatus(ref string seatSelection, ref object sender)
        {
            // Sent to a string to use .Length
            string senderString = sender.ToString();
            seatSelection = senderString.Substring(senderString.Length - 2);
        }

        /// <summary>
        /// Add a booking
        /// </summary>
        /// <param name="venueArray"></param>
        /// <param name="waitList"></param>
        /// <param name="userSeatSelectionIndex"></param>
        /// <param name="customerName"></param>
        public static void AddBooking(
            VenueSeats[] venueArray,
            int userSeatSelectionIndex,
            string customerName)
        {
            venueArray[userSeatSelectionIndex].occupiedSeat = true;
            venueArray[userSeatSelectionIndex].customerName = customerName;
        }

        /// <summary>
        /// Cancel a booking
        /// </summary>
        /// <param name="venueArray"></param>
        /// <param name="userSeatSelectionIndex"></param>
        public static void CancelBooking(
            VenueSeats[] venueArray,
            int userSeatSelectionIndex)
        {
            venueArray[userSeatSelectionIndex].occupiedSeat = false;
            venueArray[userSeatSelectionIndex].customerName = "";
        }

        /// <summary>
        /// Add customer to waiting list
        /// </summary>
        /// <param customerName="waitList"></param>
        /// <param customerName="customerName"></param>
        public static void AddToWaitlist(
            List<string> waitList,
            string customerName)
        {
            waitList.Add(customerName);
        }

        /// <summary>
        /// Fill all bookings, does not overwrite existing bookings
        /// </summary>
        /// <param name="venueArray"></param>
        public static void FillAllBookings(VenueSeats[] venueArray)
        {
            for (int i = 0; i < venueArray.GetLength(0); i++)
            {
                if (venueArray[i].occupiedSeat == false)
                {
                    venueArray[i].customerName = "OCCUPIED";
                    venueArray[i].occupiedSeat = true;
                }
            }
        }

        /// <summary>
        /// Cancel all bookings
        /// </summary>
        /// <param name="venueArray"></param>
        public static void CancelAllBookings(VenueSeats[] venueArray)
        {
            for (int i = 0; i < venueArray.GetLength(0); i++)
            {
                venueArray[i].customerName = "";
                venueArray[i].occupiedSeat = false;
            }
        }
    }
}
