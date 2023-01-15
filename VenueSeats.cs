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

        // Declare here?
        VenueSeats[] arrayTest = new VenueSeats[1];

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
        /// Check for occupancy in the array
        /// </summary>
        public static void GetOccupancyLocation(
            VenueSeats[] venueArray,
            ref bool anyOccupancyCheck,
            ref int occupancyLocation)
        {
            anyOccupancyCheck = false;
            occupancyLocation = 0;
            // Could make venue.Array.GetL 12 because the array is fixed
            for (int i = 0; i < venueArray.GetLength(0); i++)
            {
                if (venueArray[i].occupiedSeat == false)
                {
                    //MessageBox.Show($"Found empty seat at: venuArray{i}");
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

        public static void TableClickedStatus(ref string tableSelection, ref object sender)
        {
            tableSelection = "";

            // Sent to a string to use .Length
            string senderString = sender.ToString();
            tableSelection = senderString.Substring(senderString.Length - 2);
            MessageBox.Show(tableSelection);
        }

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

        // Does this need to be part of the class?
        // If not, you need to add variables to the main form
        // for the occupiedtables, and occupationPercent
        public static void GetOccypancyInformation(
            VenueSeats[] venuArray,
            ref string occupancyStatus)
        {
            // Kept as int and casted to double later, just in case 
            // a decimal gets in there somehow
            int occupiedTables = 0;

            for (int i = 0; i < venuArray.GetLength(0); i++)
            {
                if (venuArray[i].occupiedSeat == true)
                {
                    // Adds one to occupiedTables each time a table has a true occupiedSeat field
                    occupiedTables++;
                }
            }

            // Should probably create an UpdateStatus method instead?
            // Ask about this

            //MessageBox.Show($"Total occupied: {occupiedTables}");

            double occupationPercent = ((double)occupiedTables) / 12 * 100;
            //MessageBox.Show($"{occupiedTables}/12 - Occupation: {occupationPercent}%");
            occupancyStatus = $"{occupiedTables}/12 - Occupation: {Math.Round(occupationPercent, 0)}%";

        }

        public static void CancelAllBookings(VenueSeats[] venueArray)
        {
            for (int i = 0; i < venueArray.GetLength(0); i++)
            {
                venueArray[i].customerName = "";
                venueArray[i].occupiedSeat = false;
            }
        }

        // Should this only fill EMPTY seats, or everything no matter what?
        public static void FillAllBookings(VenueSeats[] venueArray)
        {
            for (int i = 0; i < venueArray.GetLength(0); i++)
            {
                if (venueArray[i].occupiedSeat == false)
                {
                    venueArray[i].customerName = "AUTO-FILLED";
                    venueArray[i].occupiedSeat = true;
                }
            }
        }

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


            // Should probably create an UpdateStatus method instead?
            // Ask about this

            //MessageBox.Show($"Total occupied: {occupiedTables}");
            if (occupiedTables == 12)
            {
                occupationPercent = ((double)occupiedTables) / 12 * 100;
                //MessageBox.Show($"{occupiedTables}/12 - Occupation: {occupationPercent}%");
                occupancyStatus = $"Total Capacity: {occupiedTables}/12 NO CAPACITY!  - " +
                    $"({Math.Round(occupationPercent, 1)})% Capacity" +
                    $"\n{waitListCount} person(s) on waitlist";

                // Figured out how to disable buttons!
                //buttonList.ElementAt(12).Enabled = false;
            }

            else
            {
                occupationPercent = ((double)occupiedTables) / 12 * 100;
                //MessageBox.Show($"{occupiedTables}/12 - Occupation: {occupationPercent}%");
                occupancyStatus = $"Total Capacity: {occupiedTables}/12  - " +
                    $"({Math.Round(occupationPercent, 1)})% Capacity" +
                    $"\n{waitListCount} person(s) on waitlist";
            }
            



        }
        public static void CancelBooking(
            VenueSeats[] venueArray,
            int userTableSelectionIndex)
        {
            venueArray[userTableSelectionIndex].occupiedSeat = false;
            venueArray[userTableSelectionIndex].customerName = "";
        }

    }
}
