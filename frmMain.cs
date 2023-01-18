using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment1
{
    public partial class frmMain : Form
    {

        // Here or in the class?
        VenueSeats[] venueArray = new VenueSeats[12]; // Seat Array...The array for the seats...

        List<string> waitList = new List<string>(); // Waitlist...list

        List<Button> buttonList = new List<Button>(); // CREATE LIST FOR BUTTONS

        //List<ToolTip> tList = new List<ToolTip>();


        // Store user data
        string userSeatSelection = "";

        // Occupied seat check stuff
        // This occupancycheck bool could be replaced with an occupancy count
        // This would require a small bit of work, since the counting variable is
        // local only to the GetOccypancyInformation method in VenuSeats
        bool anyOccupancyCheck = false;
        int occupiedSeatsCount = 0; // Probably dont need this, it is in the class method
        int occupancyIndexLocation = 0;

        // Top Status bar variable
        string occupancyStatus = "";

        // row/col selection variables
        int userSeatSelectionIndex = 0;
        string rowValue = "";
        string colValue = "";
        bool rowColCheck = false;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // Add buttons to a list for various reasons
            // A buttons
            buttonList.Add(btnA1);
            buttonList.Add(btnA2);
            buttonList.Add(btnA3);
            buttonList.Add(btnA4);

            // B Buttons
            buttonList.Add(btnB1);
            buttonList.Add(btnB2);
            buttonList.Add(btnB3);
            buttonList.Add(btnB4);

            // C Buttons
            buttonList.Add(btnC1);
            buttonList.Add(btnC2);
            buttonList.Add(btnC3);
            buttonList.Add(btnC4);

            // Other control buttons
            // Index starts at 12 for these
            // You could separate these into another list
            // But do you want to spend that much time on this?
            // When you dont need to? lol
            buttonList.Add(btnBook);
            buttonList.Add(btnCancel);
            buttonList.Add(btnAddToWaitList);
            buttonList.Add(btnFillAll);
            buttonList.Add(btnCancelAll);
            buttonList.Add(btnClearWaitlist);


            // Initialize seat objects
            // A row
            venueArray[0] = new VenueSeats("A1", "chris wickens", true);
            venueArray[1] = new VenueSeats("A2", "Timmothy", true);
            venueArray[2] = new VenueSeats("A3", "", false);
            venueArray[3] = new VenueSeats("A4", "", false);

            // B row
            venueArray[4] = new VenueSeats("B1", "", false);
            venueArray[5] = new VenueSeats("B2", "Tadd Zammer", true);
            venueArray[6] = new VenueSeats("B3", "", false);
            venueArray[7] = new VenueSeats("B4", "", false);

            // C row
            venueArray[8] = new VenueSeats("C1", "", false);
            venueArray[9] = new VenueSeats("C2", "Tom Smith", true);
            venueArray[10] = new VenueSeats("C3", "", false);
            venueArray[11] = new VenueSeats("C4", "", false);

            UpdateAllOccupancyDisplays();

        }

        /// <summary>
        /// Checks for occupancy and transfers the first item in the waitlist to the empty seat
        /// Until there are no entries left in the waitList
        /// </summary>
        public void OccupancyWaitListCheck()
        {
            // The waitlist message after moving people to a seat
            string waitListStatusMessage = "";

            // Temp storage to concatenate the message
            string tempStatusMessage = "";

            // Store the waitlist count to ensure the message is concatenated properly
            int storedWaitlistCount = 0;

            if (waitList.Count > 0)
            {
                storedWaitlistCount = waitList.Count;

                while (waitList.Count > 0)
                {
                    VenueSeats.GetOccupancyLocation(venueArray, ref anyOccupancyCheck, ref occupancyIndexLocation);
                    
                    
                    // Add the first item from the list to the booking
                    if (anyOccupancyCheck == true)
                    {
                        tempStatusMessage = $"{waitList.ElementAt(0)} moved from waitlist to {venueArray[occupancyIndexLocation].seatName}";
                        VenueSeats.AddBooking(venueArray, waitList, occupancyIndexLocation, waitList.ElementAt(0));
                        
                        if (storedWaitlistCount > 1)
                        {
                            waitListStatusMessage += $"{tempStatusMessage}, ";
                        }

                        else
                        {
                            waitListStatusMessage = tempStatusMessage;
                        }
                        
                        //txtbxSystemMessages.Text = $"{waitList.ElementAt(0)} moved from waitlist to {venueArray[occupancyIndexLocation].seatName }";


                        // Remove the person from the waitList
                        waitList.RemoveAt(0);
                        
                    }

                    else if (anyOccupancyCheck == false && waitList.Count > 0)
                    {
                        txtbxSystemMessages.Text = waitListStatusMessage;
                        break;
                    }
                    
                }

                if (anyOccupancyCheck == true)
                {
                    txtbxSystemMessages.Text = waitListStatusMessage;
                }
            }

            else
            {
                txtbxSystemMessages.Text = "No people on waitlist";
            }
        }

        /// <summary>
        /// Updates all occupancy display information (seat buttons, capacity etc.)
        /// </summary>
        private void UpdateAllOccupancyDisplays()
        {
            VenueSeats.OccupancyDisplaysUpdater(venueArray, buttonList, waitList, ref occupancyStatus);

            // This will update the current wait list occupancy
            lstBxWaitlistDisplay.Items.Clear();

            for (int i = 0; i < waitList.Count; i++)
            {
                // Add items to the visible listbox
                // using i as the target for the insert index ensures
                // names are displayed in correct order (first come, first server, top to bottom)
                lstBxWaitlistDisplay.Items.Insert(i, waitList[i]);
            }

            lblTopStatus.Text = occupancyStatus;
        }

        /// <summary>
        /// Assigns the seat number to a variable for use
        /// based on what button the user clicked
        /// </summary>
        /// <param name="buttonText"></param>
        private void SeatDisplayButtonClicked(object sender, EventArgs e)
        {
            // This will be where the message goes if the user clicks a seat button
            VenueSeats.SeatClickedStatus(ref userSeatSelection, ref sender);

            // Display a status message based on if the seat is or is not empty
            for (int i = 0; i < venueArray.GetLength(0); i++)
            {
                if (venueArray[i].seatName == userSeatSelection && venueArray[i].occupiedSeat == true)
                {
                    txtbxSystemMessages.Text = $"{userSeatSelection}, {venueArray[i].customerName}";
                    break;
                }

                else
                {
                    txtbxSystemMessages.Text = $"{userSeatSelection}, vacant";
                }
            }
        }

        /// <summary>
        /// Clears the Row/Column selections
        /// </summary>
        private void ClearRowColLists()
        {
            lstBxRows.ClearSelected();
            lstBxCols.ClearSelected();
        }

        /// <summary>
        /// Checks the Row/Column selection to verify the user selected something
        /// </summary>
        private void UserSelectionRowColCheck()
        {
            // Reset before checking
            rowColCheck = false;

            try
            {

                rowValue = lstBxRows.SelectedItem.ToString();

                if (rowValue == null)
                {
                    // Error if null
                    throw new NullReferenceException();
                }

                // If the rowValue was not null, this will run
                else
                {
                    try
                    {
                        colValue = lstBxCols.SelectedItem.ToString();

                        if (colValue == null)
                        {
                            // Error if null
                            throw new NullReferenceException();
                        }

                        // Valid Row/Col selection
                        // Assign selection to userSeatSelection for future use
                        rowColCheck = true;
                        userSeatSelection = rowValue + colValue;

                    }

                    catch (NullReferenceException)
                    {
                        // Specific Error
                        txtbxSystemMessages.Text = $"ERROR! No COLUMN value selected!";
                    }

                    catch (Exception eX)
                    {
                        // Catch all
                        txtbxSystemMessages.Text = $"General Error COLUMN value";

                    }
                }
            }

            catch (NullReferenceException)
            {
                // Specific Error
                txtbxSystemMessages.Text = $"ERROR! No ROW value selected!";
            }

            catch (Exception)
            {
                // Catch all
                txtbxSystemMessages.Text = $"General Error ROW value";
            }
        }

        /// <summary>
        /// When the user clicks the booking button
        /// Check for a valid name, row and col selection, and ensure there are empty seats
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBook_Click(object sender, EventArgs e)
        {

            // Can I do checks here or in the class?
            // Checks to see if the name entered is blank
            if (txtBxCustName.Text == "" || txtBxCustName.Text == " ")
            {
                txtbxSystemMessages.Text = "Invalid name";
            }

            else
            {
                // Check occupancy, and get first empty seat location
                VenueSeats.GetOccupancyLocation(venueArray, ref anyOccupancyCheck, ref occupancyIndexLocation);

                // Check the user seat selection
                UserSelectionRowColCheck();

                // If their rowCol check was good, and there is at least one occupancy

                if (rowColCheck == true && anyOccupancyCheck == true)
                {

                    // Iterate over how many seats there are
                    for (int i = 0; i < venueArray.GetLength(0); i++)
                    {
                        // if the current seatname matches the user selection AND the seat is not occupied
                        if (venueArray[i].seatName == userSeatSelection && venueArray[i].occupiedSeat == false)
                        {

                            // Book the seat for the person at the selected location
                            userSeatSelectionIndex = i;
                            VenueSeats.AddBooking(venueArray, waitList, userSeatSelectionIndex, txtBxCustName.Text);
                            UpdateAllOccupancyDisplays();

                            txtbxSystemMessages.Text = $"{txtBxCustName.Text} booked at seat {userSeatSelection}";

                            // Clear the entered name on a successful booking too
                            ClearRowColLists();
                            txtBxCustName.Text = "";
                            break;
                        }

                        // If the seatname is correct, but it is occupied
                        else if (venueArray[i].seatName == userSeatSelection && venueArray[i].occupiedSeat == true)
                        {
                            txtbxSystemMessages.Text = "Seat is currently booked! Please pick another seat!";
                            ClearRowColLists();
                        }
                    }
                }

                // If the row-col check was good, and there is NO occupancy available
                // Add to the waitlist
                // Should I care about the row/col check since they are being waitlisted?
                else if (anyOccupancyCheck == false)
                {
                    // Add to wait list
                    txtbxSystemMessages.Text = $"{txtBxCustName.Text} added to waitlist!";
                    VenueSeats.AddToWaitlist(waitList, txtBxCustName.Text);
                    UpdateAllOccupancyDisplays();
                    ClearRowColLists();
                    txtBxCustName.Text = "";
                }
            }
        }


        /// <summary>
        /// Checks each button button to see if the seat has an occupant
        /// Adjusts the tooltip accordingly
        /// </summary>
        /// 
        private void ButtonMouseHover(object sender, EventArgs e)
        {
            // You can pass the ToolTip toolTip1 into a method/function apparently?
            // Iterates through the length of the venue seats array
            // Assigns the proper tooltip

            // Not a big fan of how much work this technically does
            // Is there a way to target the currently hovered button from code?
            // Reference: I can only see 3 ways
            // 1) this way
            // 2) hand coding the button reactions like I did below
            // 3) hand code each button hover individually in their own functions
            for (int i = 0; i < venueArray.GetLength(0); i++)
            {
                // if the current array object has a true 
                if (venueArray[i].occupiedSeat == true)
                {
                    tltpDynamicDisplay.SetToolTip(buttonList.ElementAt(i), $"OCCUPIED BY: {venueArray[i].customerName}");
                }

                // if the current array object has a false
                else
                {
                    tltpDynamicDisplay.SetToolTip(buttonList.ElementAt(i), $"AVAILABLE");
                }
            }
        }

        /// <summary>
        /// Cancel ALL bookings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelAll_Click(object sender, EventArgs e)
        {
            VenueSeats.CancelAllBookings(venueArray);
            OccupancyWaitListCheck();
            UpdateAllOccupancyDisplays();
        }

        /// <summary>
        /// Fill any EMPTY seats
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFillAll_Click(object sender, EventArgs e)
        {
            VenueSeats.FillAllBookings(venueArray);
            UpdateAllOccupancyDisplays();
        }

        /// <summary>
        /// Add the current customer name to the waitlist
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddToWaitList_Click(object sender, EventArgs e)
        {
            // Check occupancy
            VenueSeats.GetOccupancyLocation(venueArray, ref anyOccupancyCheck, ref occupancyIndexLocation);

            // If there is none, add them to the list
            if (anyOccupancyCheck == false)
            {
                txtbxSystemMessages.Text = $"{txtBxCustName.Text} added to waitlist!";
                VenueSeats.AddToWaitlist(waitList, txtBxCustName.Text);
                txtBxCustName.Text = "";
                UpdateAllOccupancyDisplays();

            }

            else
            {
                txtbxSystemMessages.Text = "Seats are available";
            }
        }

        // Clear the entire waitlist
        // Should this be in the class?
        private void btnClearWaitlist_Click(object sender, EventArgs e)
        {
            if (waitList.Count > 0)
            {
                if (MessageBox.Show($"{waitList.Count} person(s) on the wait list! " +
                    $"\nAre you sure you want to clear the wait list?",
                    "WARNING",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    waitList.Clear();
                    UpdateAllOccupancyDisplays();
                    txtbxSystemMessages.Text = "Wait list CLEARED!";
                }

                else
                {
                    txtbxSystemMessages.Text = "Wait list NOT cleared";
                }
            }

            else
            {
                txtbxSystemMessages.Text = "Wait list is empty";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

            // Reset to prevent old data from causing errors
            userSeatSelection = "";
            userSeatSelectionIndex = 0;

            // if the user selected a proper row and col
            UserSelectionRowColCheck();

            // Verified correct row col entry from user
            if (rowColCheck == true)
            {
                // you need to check what the user selected against the venueArray
                for (int i = 0; i < venueArray.GetLength(0); i++)
                {

                    if (venueArray[i].seatName == userSeatSelection && venueArray[i].occupiedSeat == true)
                    {

                        userSeatSelectionIndex = i;

                        if (MessageBox.Show($"Cancel booking at {userSeatSelection} for {venueArray[userSeatSelectionIndex].customerName}?",
                            "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            txtbxSystemMessages.Text = $"Booking at {userSeatSelection} canceled!";
                            VenueSeats.CancelBooking(venueArray, userSeatSelectionIndex);
                            VenueSeats.GetOccupancyLocation(venueArray, ref anyOccupancyCheck, ref occupancyIndexLocation);

                            // After canceling a booking, check to see if there is anyone on the waitList
                            OccupancyWaitListCheck();

                            UpdateAllOccupancyDisplays();
                            ClearRowColLists();
                            break;
                        }

                        else
                        {
                            break;
                        }
                    }

                    else if (venueArray[i].seatName == userSeatSelection && venueArray[i].occupiedSeat == false)
                    {
                        txtbxSystemMessages.Text = "Seat not occupied!";
                        ClearRowColLists();
                        break;
                    }
                }
            }

            //else
            //{
            //    txtbxSystemMessages.Text = "Please select a valid seat to cancel";
            //}
        }

    }
}
