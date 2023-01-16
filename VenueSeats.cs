using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment1
{


    internal class VenueSeats
    {

        public string tableName;
        public string customerName;
        public bool occupiedSeat;

        private string test;

        public string Test
        {
            get
            {
                return Test;
            }

            set 
            { 
                Test = value; 
            }

        }           

        // Declare here?
        VenueSeats[] arrayTest = new VenueSeats[12];

        // Default constructor
        public VenueSeats()
        {
            this.tableName = string.Empty;
            this.customerName = string.Empty;
            this.occupiedSeat = false;

        }

        // Overloaded constructor
        public VenueSeats(
            string tableName,
            string customerName,
            bool occupiedSeat)
        {
            this.tableName = tableName;
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

            int waitListCount = 0;
            int occupiedTables = 0;
            double occupationPercent = 0;

            waitListCount = waitList.Count;

            for (int i = 0; i < venueArray.GetLength(0); i++)
            {
                // if the current array object has a true 
                if (venueArray[i].occupiedSeat == true)
                {
                    occupiedTables++;
                    buttonList.ElementAt(i).BackColor = Color.Red;
                }

                // if the current array object has a false
                else
                {
                    // Set vacant table colour to green
                    buttonList.ElementAt(i).BackColor = Color.FromArgb(0, 192, 0);

                }
            }

            if (occupiedTables == 12)
            {
                occupationPercent = ((double)occupiedTables) / 12 * 100;
                occupancyStatus = $"Total Capacity: {occupiedTables}/12 NO CAPACITY!  - " +
                    $"({Math.Round(occupationPercent, 1)})% Capacity" +
                    $"\n{waitListCount} person(s) on waitlist";

                // Figured out how to disable buttons!
                //buttonList.ElementAt(12).Enabled = false;
            }

            else
            {
                occupationPercent = ((double)occupiedTables) / 12 * 100;
                occupancyStatus = $"Total Capacity: {occupiedTables}/12  - " +
                    $"({Math.Round(occupationPercent, 1)})% Capacity" +
                    $"\n{waitListCount} person(s) on waitlist";
            }
        }

        /// <summary>
        /// Display information about the table being clicked on
        /// </summary>
        /// <param name="tableSelection"></param>
        /// <param name="sender"></param>
        public static void TableClickedStatus(ref string tableSelection, ref object sender)
        {
            tableSelection = "";

            // Sent to a string to use .Length
            string senderString = sender.ToString();
            tableSelection = senderString.Substring(senderString.Length - 2);
            //MessageBox.Show(tableSelection);
        }

        /// <summary>
        /// Add a booking
        /// </summary>
        /// <param name="venueArray"></param>
        /// <param name="waitList"></param>
        /// <param name="userTableSelectionIndex"></param>
        /// <param name="customerName"></param>
        public static void AddBooking(
            VenueSeats[] venueArray,
            List<string> waitList,
            int userTableSelectionIndex,
            string customerName)
        {
            venueArray[userTableSelectionIndex].occupiedSeat = true;
            venueArray[userTableSelectionIndex].customerName = customerName;
        }

        /// <summary>
        /// Cancel a booking
        /// </summary>
        /// <param name="venueArray"></param>
        /// <param name="userTableSelectionIndex"></param>
        public static void CancelBooking(
            VenueSeats[] venueArray,
            int userTableSelectionIndex)
        {
            venueArray[userTableSelectionIndex].occupiedSeat = false;
            venueArray[userTableSelectionIndex].customerName = "";
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
