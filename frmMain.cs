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


            // Get occupancy report on load
            //CheckTables(); // Program function

            // Trying the above from class
            //VenueSeats.OccupancyDisplaysUpdater(venueArray, buttonList, ref occupancyStatus);
            UpdateAllOccupancyDisplays();
            // Update the occupancy status at top of window
            //VenueSeats.GetOccypancyInformation(venueArray, ref occupancyStatus);
            //lblTopStatus.Text = occupancyStatus;

            // Shows all tableNames
            //for (int i = 0; i < venueArray.Length; i++)
            //{
            //    //lblSystemMessages.Text = venueArray[i].tableName;
            //    MessageBox.Show($"Array: {i}, value: {venueArray[i].tableName}");
            //}
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

        // Replaced with a class method
        //private void CheckTables()
        //{
        //    for (int i = 0; i < 12; i++)
        //    {
        //        // if the current array object has a true 
        //        if (venueArray[i].occupiedSeat == true)
        //        {
        //            buttonList.ElementAt(i).BackColor = Color.Red;
        //        }

        //        // if the current array object has a false
        //        else
        //        {
        //            buttonList.ElementAt(i).BackColor = Color.FromArgb(0, 192, 0);
        //        }
        //    }
        //}

        /// <summary>
        /// Assigns the table number to a variable for use
        /// based on what button the user clicked
        /// 
        /// </summary>
        /// <param name="buttonText"></param>
        //private void SelectTable(string buttonText)
        //{
        //    // Clear userTableSelection so there's no funny business
        //    userTableSelection = "";

        //    // Removes everything except the last two characters (A1 for example)
        //    userTableSelection = buttonText.ToString().Substring(buttonText.Length - 2);
        //    lblTopStatus.Text = userTableSelection;

        //}

        private void TableDisplayButtonClicked(object sender, EventArgs e)
        {
            // This will be where the message goes if the user clicks a table button
            VenueSeats.TableClickedStatus(ref userTableSelection, ref sender);
            // If a status message is meant to be displayed, remove the messagebox from the 
            // above method, and change the lbl status here
            /*
            //SelectTable(sender.ToString());
            //// Removes everything except the last two characters (A1 for example)
            //userTableSelection = sender.ToString().Substring(sender.ToString().Length - 2);
            //lblTopStatus.Text = userTableSelection;

            //// Shows the number value of the table by using substring to only leave the last character
            //// the last character will always be numeric, by subtracting 1 from that, you get the array
            //// location of that table
            //lblSystemMessages.Text = sender.ToString().Substring(sender.ToString().Length - 1);

            //string getTableNumber = sender.ToString().Substring(sender.ToString().Length - 1);

            //// This gets the array location by using -1
            //int tableArrayLocation = int.Parse(getTableNumber) - 1;

            ////This box just shows the output with the -1 to ensure proper array index number
            //MessageBox.Show(tableArrayLocation.ToString());

            //// Check for an empty table
            ////VenueSeats.GetOccupancyLocation(venueArray);
            ///
            /// 
            */

        }

        /*
        // YOU CHANGED FROM THIS TO THE ABOVE BUTTON CLICKED
        // using the object, eventargs it will populate in the event list for any button
        //private void btnA1_Click(object sender, EventArgs e)
        //{

        //    // VenueSeats.Test1();
        //    // That is how you call the class to create objects

        //    // Assigns the systemmessage label the name from venuearray[0] cust name
        //    lblSystemMessages.Text = venueArray[0].customerName;
        //    //lblTopStatus.Text = sender.ToString();
        //    //userTableSelection = "a1";
        //    lblTopStatus.Text = sender.ToString();
        //    SelectTable(sender.ToString());

        //}
        */

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

                        // Display information
                        // This is where you would use the row/col values
                        // To book a table and stuff
                        rowColCheck = true;
                        userTableSelection = rowValue + colValue;
                        //lblSystemMessages.Text = $"Row: {rowValue} - COL: {colValue}";
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
                    
                    // concatenate the row and col values the user selected
                    // put this in the userselectionrowcol check instead userTableSelection = rowValue + colValue;
                    //lblSystemMessages.Text = userTableSelection;

                    // Iterate over how many tables there are
                    for (int i = 0; i < venueArray.GetLength(0); i++)
                    {
                        // if the current tablename matches the user selection AND the table is not occupied
                        if (venueArray[i].tableName == userTableSelection && venueArray[i].occupiedSeat == false)
                        {

                            // Book the table for the person at the selected location
                            userTableSelectionIndex = i;
                            //lblSystemMessages.Text = $"Array Location: venuArray{i} - Table Selection: {userTableSelection}";
                            VenueSeats.AddBooking(venueArray, waitList, userTableSelectionIndex, txtBxCustName.Text);
                            //VenueSeats.OccupancyDisplaysUpdater(venueArray, buttonList, ref occupancyStatus);
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

                /*
                //else
                //{
                //    lblSystemMessages.Text = "ERROR AT BOOKING LAST ELSE";
                //}



                //if (anyOccupancyCheck == true)
                //{
                //    lblSystemMessages.Text = $"Found vacant seat! Array location: {occupancyIndexLocation}";


                //    ClearRowColLists();
                //}

                //else if (anyOccupancyCheck == false)
                //{
                //    lblSystemMessages.Text = "No vacant seat!";


                //    // Add to waitlist with that function

                //    VenueSeats.AddToWaitlist(waitList, txtBxCustName.Text);

                //    lblSystemMessages.Text = $"{txtBxCustName.Text} Added to waitlist!";
                //}

                //else
                //{
                //    lblSystemMessages.Text = "Vacant table check error!";
                //}

                //if (rowValue == "" || rowValue == " ")
                //{
                //    lblSystemMessages.Text = "Invalid ROW selection";
                //    validUserRow = false;
                //}

                //if (colValue == "" || colValue == " ")
                //{
                //    lblSystemMessages.Text = "Invalid COLUMN selection";
                //    validUserCol = false;
                //}
                */
            }




            /*
             * 
             * 
             * Things get all fuckey here!
             * 
             * 
             * 
             */
            /*
            //if (rowValue == "" || colValue == "")
            //{
            //    lblSystemMessages.Text = "Invalid row/column selection!";
            //}

            //else
            //{

            //    string rowColConcat = rowValue + colValue;
            //    lblTopStatus.Text = rowColConcat;



            //    // Can I do checks here or in the class?
            //    if (txtBxCustName.Text == "" || txtBxCustName.Text == " ")
            //    {
            //        lblSystemMessages.Text = "Invalid name";
            //    }

            //    else
            //    {
            //        lblSystemMessages.Text = txtBxCustName.Text; // Just for debug
            //        string customerName = txtBxCustName.Text;

            //        for (int i = 0; i < venueArray.GetLength(0); i++)
            //        {
            //            if (venueArray[i].occupiedSeat == false)
            //            {
            //                occupiedTablesCount++; // Put this somewhere else so you can try a break here
            //                anyOccupancyCheck = true;

            //            }
            //        }



            //        /*
            //         * 
            //         * 
            //         * This replaces the code below it that lets somone add at an existing location
            //         * 
            //         * 
            //         * 
            //         * 
            //         */
            /*
            //        for (int i = 0; i < venueArray.GetLength(0); i++)
            //        {
            //            if (anyOccupancyCheck == true && venueArray[i].tableName != rowColConcat && venueArray[i].occupiedSeat == false)
            //            {
            //                userTableSelectionIndex = i;
            //                VenueSeats.AddBooking(venueArray, userTableSelectionIndex, customerName);
            //                VenueSeats.OccupancyDisplaysUpdater(venueArray, buttonList);
            //                lstBxRows.ClearSelected();
            //                lstBxCols.ClearSelected();
            //                rowValue = "";
            //                colValue = "";
            //            }

            //            else
            //            {
            //                continue;
            //            }
            //        }


            /*
             * 
             * 
             * 
             * 
             * FIX THIS, the blow code lets somone add a NEW booking ontop of an existing one
             * 
             * 
             * 
             */
            /*
            //if (anyOccupancyCheck == true)
            //{
            //    // Checking the array table names for what was selected
            //    for (int i = 0; i < venueArray.GetLength(0); i++)
            //    {
            //        if (venueArray[i].tableName == rowColConcat)
            //        {
            //            //MessageBox.Show("Found the row/col matched");
            //            userTableSelectionIndex = i;
            //            VenueSeats.AddBooking(venueArray, userTableSelectionIndex, customerName);
            //            VenueSeats.OccupancyDisplaysUpdater(venueArray, buttonList);
            //            lstBxRows.ClearSelected();
            //            lstBxCols.ClearSelected();
            //            rowValue = "";
            //            colValue= "";
            //        }
            //    }

            //    /*
            //     * 
            //     * 
            //     * 
            //     * THE BELOW CODE TO CLEAR SELECTIONS ISNT WORKING
            //     * IT'S NOT WORKING BECAUSE YOU CODED THE LISTBOXES TO REACT TO ANY CHANGE
            //     * SO WHEN THEY CLEAR, THE ROW/COL CHANGE FUNCTION IS CALLED
            //     * AND SPITS OUT AN ERROR BECUASE THERE AINT SHIT FOR THAT FUNCTION TO USE ANYMORE
            //     * 
            //     */
            /*
            //    //lstBxRows.ClearSelected();
            //    ///lstBxCols.ClearSelected();


            //}

            //else
            //{
            //    VenueSeats.AddToWaitlist(waitList, customerName);
            //    lblTopStatus.Text = $"{customerName} added to waitlist";
            //    rowValue = "";
            //    colValue = "";
            //}
            //}
            // }
            */
        }


        /// <summary>
        /// Checks each button button to see if the table has an occupant
        /// Adjusts the tooltip accordingly
        /// 
        /// 
        /// 
        /// 
        /// 
        /// TRY DOING THIS WITH THE LIST OF BUTTONS NOW!
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

        /*
        private void ButtonMouseHover(object sender, EventArgs e)
        {

            // A tables
            // Table a1
            if (venueArray[0].occupiedSeat == false)
            {
                toolTip1.SetToolTip(btnA1, "Available");
            }

            else
            {
                toolTip1.SetToolTip(btnA1, $"Booked by: {venueArray[0].customerName}");
            }

            // table a2
            if (venueArray[1].occupiedSeat == false)
            {
                toolTip1.SetToolTip(btnA2, "Available");
            }

            else
            {
                toolTip1.SetToolTip(btnA2, $"Booked by: {venueArray[1].customerName}");
            }

            // table a3
            if (venueArray[2].occupiedSeat == false)
            {
                toolTip1.SetToolTip(btnA3, "Available");
            }

            else
            {
                toolTip1.SetToolTip(btnA3, $"Booked by: {venueArray[2].customerName}");
            }

            // table a4
            if (venueArray[3].occupiedSeat == false)
            {
                toolTip1.SetToolTip(btnA4, "Available");
            }

            else
            {
                toolTip1.SetToolTip(btnA4, $"Booked by: {venueArray[3].customerName}");
            }

            // B tables
            // Table B1
            if (venueArray[4].occupiedSeat == false)
            {
                toolTip1.SetToolTip(btnB1, "Available");
            }

            else
            {
                toolTip1.SetToolTip(btnB1, $"Booked by: {venueArray[4].customerName}");
            }

            // Table B2
            if (venueArray[5].occupiedSeat == false)
            {
                toolTip1.SetToolTip(btnB2, "Available");
            }

            else
            {
                toolTip1.SetToolTip(btnB2, $"Booked by: {venueArray[5].customerName}");
            }

            // Table B3
            if (venueArray[6].occupiedSeat == false)
            {
                toolTip1.SetToolTip(btnB3, "Available");
            }

            else
            {
                toolTip1.SetToolTip(btnB3, $"Booked by: {venueArray[6].customerName}");
            }

            // Table B4
            if (venueArray[7].occupiedSeat == false)
            {
                toolTip1.SetToolTip(btnB4, "Available");
            }

            else
            {
                toolTip1.SetToolTip(btnB4, $"Booked by: {venueArray[7].customerName}");
            }

            // Table C1
            if (venueArray[8].occupiedSeat == false)
            {
                toolTip1.SetToolTip(btnC1, "Available");
            }

            else
            {
                toolTip1.SetToolTip(btnC1, $"Booked by: {venueArray[8].customerName}");
            }

            // Table C2
            if (venueArray[9].occupiedSeat == false)
            {
                toolTip1.SetToolTip(btnC2, "Available");
            }

            else
            {
                toolTip1.SetToolTip(btnC2, $"Booked by: {venueArray[9].customerName}");
            }

            // Table C3
            if (venueArray[10].occupiedSeat == false)
            {
                toolTip1.SetToolTip(btnC3, "Available");
            }

            else
            {
                toolTip1.SetToolTip(btnC3, $"Booked by: {venueArray[10].customerName}");
            }

            // Table C4
            if (venueArray[11].occupiedSeat == false)
            {
                toolTip1.SetToolTip(btnC4, "Available");
            }

            else
            {
                toolTip1.SetToolTip(btnC4, $"Booked by: {venueArray[11].customerName}");
            }

        }

        */

        /// <summary>
        /// Updates the list view of the waitList...list...
        /// 
        /// 
        /// 
        /// THIS WAS REPLACED BY THE UNIVERSAL DISPLAY UPDATE FUNCTION
        /// </summary>
        private void UpdateWaitlistDisplay()
        {
            // This will update the current wait list occupancy
            
            lstBxWaitlistDisplay.Items.Clear();

            for (int i = 0; i < waitList.Count; i++)
            {
                // Add items to the visible listbox
                // using i as the target for the insert index ensures
                // names are displayed in correct order (first come, first server, top to bottom)
                lstBxWaitlistDisplay.Items.Insert(i, waitList[i]);
            }
        }

        private void btnTestButton_Click(object sender, EventArgs e)
        {
            //waitList.Add("Poop Chris Wickelysss"); // I dont want to populate it manually every time

            //UpdateWaitlistDisplay();
            //VenueSeats.OccupancyDisplaysUpdater(venueArray, buttonList, ref occupancyStatus);
            UpdateAllOccupancyDisplays();

            //VenueSeats.OccupancyDisplaysUpdater(venueArray, buttonList);

            //UserSelectionRowColCheck();

            /*
            //string testing2 = "";
            ////MessageBox.Show(lstBxRows.SelectedItem.ToString());
            //try
            //{
            //    testing2 = lstBxCols.SelectedItem.ToString();

            //    if (testing2 == null)
            //    {
            //        throw new NullReferenceException();
            //    }
            //}


            //catch (NullReferenceException)
            //{
            //    lblSystemMessages.Text = "Please select a number from the COLUMN box";
            //}


            //catch (Exception)
            //{

            //    lblSystemMessages.Text = "Error! ";
            //}

            //try
            //{
            //    string testing = lstBxRows.SelectedItem.ToString();

            //    if (testing == null)
            //    {
            //        throw new NullReferenceException();
            //    }
            //}

            //catch (NullReferenceException nEx)
            //{
            //    lblSystemMessages.Text = "Please select a letter from the ROW box";
            //}


            //catch (Exception eX)
            //{

            //    lblSystemMessages.Text = "Error! ";
            //}

            //lblSystemMessages.Text = testing+testing2;

            //// Occupancy checks
            //string occupancyStatus = "";
            //VenueSeats.GetOccypancyInformation(venueArray, ref occupancyStatus);
            //lblTopStatus.Text = occupancyStatus;

            // MessageBox.Show($"{venueArray.Length}");

            // Simple test to get info from the button in the list
            //MessageBox.Show(buttonList.ElementAt(0).ToString());

            //buttonList.ElementAt(0).BackColor = Color.Blue;

            //// Using a list to change buttons, doesn't work well
            //foreach (var item in buttonList)
            //{
            //    for (int i = 0; i < venueArray.Length; i++)
            //    {
            //        if (venueArray[i].occupiedSeat == true)
            //        {
            //            item.BackColor = Color.Red;
            //        }

            //        else
            //        { 
            //            item.BackColor = Color.Green; 
            //        }
            //    }
            //}


            //for (int i = 0; i < venueArray.Length; i++)
            //{
            //    if (venueArray[i].occupiedSeat == true)
            //    {
            //        // turn them red

            //        Button caller = (Button)sender;
            //        MessageBox.Show(caller.ToString());
            //        caller.BackColor = Color.Red;

            //    }

            //    else
            //    {
            //        // turn them green
            //        this.BackColor = Color.Green;
            //    }
            //}

            // Iterate through 12 because there are 12 buttons
            //for (int i = 0; i < 12; i++)
            //{
            //    // if the current array object has a true 
            //    if (venueArray[i].occupiedSeat == true)
            //    {
            //        buttonList.ElementAt(i).BackColor = Color.Red;
            //    }

            //    // if the current array object has a false
            //    else
            //    {
            //        buttonList.ElementAt(i).BackColor= Color.FromArgb(0, 192, 0);
            //    }

            //}
            */
        }

        private void btnCancelAll_Click(object sender, EventArgs e)
        {
            VenueSeats.CancelAllBookings(venueArray);
            //VenueSeats.OccupancyDisplaysUpdater(venueArray, buttonList, ref occupancyStatus);
            UpdateAllOccupancyDisplays();
        }

        private void btnFillAll_Click(object sender, EventArgs e)
        {
            VenueSeats.FillAllBookings(venueArray);
            //VenueSeats.OccupancyDisplaysUpdater(venueArray, buttonList, ref occupancyStatus);
            UpdateAllOccupancyDisplays();
        }

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
                        if (MessageBox.Show($"Cancel booking at {userTableSelection} for {venueArray[userTableSelectionIndex].customerName}?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            lblSystemMessages.Text = $"Booking at {userTableSelection} canceled!";
                            VenueSeats.CancelBooking(venueArray, userTableSelectionIndex);
                            VenueSeats.GetOccupancyLocation(venueArray, ref anyOccupancyCheck, ref occupancyIndexLocation);

                            // After canceling a booking, check to see if there is anyone on the waitList
                            if (anyOccupancyCheck == true && waitList.Count > 0)
                            {
                                // Add the first item from the list to the booking
                                VenueSeats.AddBooking(venueArray, waitList, occupancyIndexLocation, waitList.ElementAt(0));
                                lblSystemMessages.Text = $"{waitList.ElementAt(0)} moved from waitlist to {userTableSelection}";

                                // Remove the person from the waitList
                                waitList.RemoveAt(0);


                            }

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
