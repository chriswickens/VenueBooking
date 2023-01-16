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
        VenueSeats[] venueArray = new VenueSeats[12]; // Table Array...The array for the tables...

        List<string> waitList = new List<string>(); // Waitlist...list

        List<Button> buttonList = new List<Button>(); // CREATE LIST FOR BUTTONS

        //List<ToolTip> tList = new List<ToolTip>();


        // Store user data
        string userTableSelection = "";
        string customerName = ""; // Not used YET

        // Occupied seat check stuff
        // This occupancycheck bool could be replaced with an occupancy count
        // This would require a small bit of work, since the counting variable is
        // local only to the GetOccypancyInformation method in VenuSeats
        bool anyOccupancyCheck = false;
        int occupiedTablesCount = 0; // Probably dont need this, it is in the class method
        int occupancyIndexLocation = 0;

        // Top Status bar variable
        string occupancyStatus = "";

        // row/col selection variables
        int userTableSelectionIndex = 0;
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


            // Initialize table objects
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

        public void OccupancyWaitListCheck()
        {

            while (waitList.Count > 0)
            {
                VenueSeats.GetOccupancyLocation(venueArray, ref anyOccupancyCheck, ref occupancyIndexLocation);
                // Add the first item from the list to the booking
                if (anyOccupancyCheck == true)
                {
                    VenueSeats.AddBooking(venueArray, waitList, occupancyIndexLocation, waitList.ElementAt(0));
                    lblSystemMessages.Text = $"{waitList.ElementAt(0)} moved from waitlist to {userTableSelection}";

                    // Remove the person from the waitList
                    waitList.RemoveAt(0);
                }

                else
                {
                    MessageBox.Show("Occupancy new function error, else after new if");
                }

            }

        }

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
        /// Assigns the table number to a variable for use
        /// based on what button the user clicked
        /// </summary>
        /// <param name="buttonText"></param>
        private void TableDisplayButtonClicked(object sender, EventArgs e)
        {
            // This will be where the message goes if the user clicks a table button
            VenueSeats.TableClickedStatus(ref userTableSelection, ref sender);
            // If a status message is meant to be displayed, remove the messagebox from the 
            // above method, and change the lbl status here

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
                        // Assign selection to userTableSelection for future use
                        rowColCheck = true;
                        userTableSelection = rowValue + colValue;

                    }

                    catch (NullReferenceException)
                    {
                        // Specific Error
                        lblSystemMessages.Text = $"ERROR! No COLUMN value selected!";
                    }

                    catch (Exception eX)
                    {
                        // Catch all
                        lblSystemMessages.Text = $"General Error COLUMN value";

                    }
                }
            }

            catch (NullReferenceException)
            {
                // Specific Error
                lblSystemMessages.Text = $"ERROR! No ROW value selected!";
            }

            catch (Exception eX)
            {
                // Catch all
                lblSystemMessages.Text = $"General Error ROW value";
            }
        }

        /// <summary>
        /// When the user clicks the booking button
        /// Check for a valid name, row and col selection, and ensure there are empty tables
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBook_Click(object sender, EventArgs e)
        {

            // Can I do checks here or in the class?
            // Checks to see if the name entered is blank
            if (txtBxCustName.Text == "" || txtBxCustName.Text == " ")
            {
                lblSystemMessages.Text = "Invalid name";
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

                    // Iterate over how many tables there are
                    for (int i = 0; i < venueArray.GetLength(0); i++)
                    {
                        // if the current tablename matches the user selection AND the table is not occupied
                        if (venueArray[i].tableName == userTableSelection && venueArray[i].occupiedSeat == false)
                        {

                            // Book the table for the person at the selected location
                            userTableSelectionIndex = i;
                            VenueSeats.AddBooking(venueArray, waitList, userTableSelectionIndex, txtBxCustName.Text);
                            UpdateAllOccupancyDisplays();

                            lblSystemMessages.Text = $"{txtBxCustName.Text} booked at seat {userTableSelection}";

                            // Clear the entered name on a successful booking too
                            ClearRowColLists();
                            txtBxCustName.Text = "";
                            break;
                        }

                        // If the tablename is correct, but it is occupied
                        else if (venueArray[i].tableName == userTableSelection && venueArray[i].occupiedSeat == true)
                        {
                            lblSystemMessages.Text = "Seat is currently booked! Please pick another seat!";
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
                    lblSystemMessages.Text = $"{txtBxCustName.Text} added to waitlist!";
                    VenueSeats.AddToWaitlist(waitList, txtBxCustName.Text);
                    UpdateAllOccupancyDisplays();
                    ClearRowColLists();
                    txtBxCustName.Text = "";
                }
            }
        }


        /// <summary>
        /// Checks each button button to see if the table has an occupant
        /// Adjusts the tooltip accordingly
        /// </summary>
        /// 
        private void ButtonMouseHover(object sender, EventArgs e)
        {
            // You can pass the ToolTip toolTip1 into a method/function apparently?
            // Iterates through the length of the venue tables array
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
                lblSystemMessages.Text = $"{txtBxCustName.Text} added to waitlist!";
                VenueSeats.AddToWaitlist(waitList, txtBxCustName.Text);
                UpdateAllOccupancyDisplays();
            }

            else
            {
                lblSystemMessages.Text = "Seats are available";
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
                    lblSystemMessages.Text = "Wait list CLEARED!";
                }

                else
                {
                    lblSystemMessages.Text = "Wait list NOT cleared";
                }
            }

            else
            {
                lblSystemMessages.Text = "Wait list is empty";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

            // Reset to prevent old data from causing errors
            userTableSelection = "";
            userTableSelectionIndex = 0;

            // if the user selected a proper row and col
            UserSelectionRowColCheck();

            // Verified correct row col entry from user
            if (rowColCheck == true)
            {
                // you need to check what the user selected against the venueArray
                for (int i = 0; i < venueArray.GetLength(0); i++)
                {

                    if (venueArray[i].tableName == userTableSelection && venueArray[i].occupiedSeat == true)
                    {

                        userTableSelectionIndex = i;

                        if (MessageBox.Show($"Cancel booking at {userTableSelection} for {venueArray[userTableSelectionIndex].customerName}?",
                            "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            lblSystemMessages.Text = $"Booking at {userTableSelection} canceled!";
                            VenueSeats.CancelBooking(venueArray, userTableSelectionIndex);
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

                    else if (venueArray[i].tableName == userTableSelection && venueArray[i].occupiedSeat == false)
                    {
                        lblSystemMessages.Text = "Seat not occupied!";
                        break;
                    }
                }
            }

            else
            {
                lblSystemMessages.Text = "Please select a valid table to cancel";
            }
        }
    }
}
