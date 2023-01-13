using System;
using System.Collections.Generic;
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

        // Default constructor
        public VenueSeats() 
        {
            this.tableName= string.Empty;
            this.customerName= string.Empty;
            this.occupiedSeat= false;

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
        public static void OccupancyCheck(VenueSeats[] venueArray)
        {
            // Could make venue.Array.GetL 12 because the array is fixed
            for (int i = 0; i < venueArray.GetLength(0); i++)
            {
                //
                //
                //    YOU NEED TO CHANGE THIS TO FALSE
                //      THIS TRUE IS FOR TESTING SO IT WOULDNT GET ANNOYING!
                // 
                if (venueArray[i].occupiedSeat == true)
                {
                    MessageBox.Show($"Found empty seat at: venuArray{i}");
                }

            }
        }
               
    }
}
