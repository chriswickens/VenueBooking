using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment1
{
    public partial class frmMain : Form
    {

        // Create Array
        //VenueSeats[] venueArray = new VenueSeats[12];

        // Default Constructor
        // Assign the tables here as objects
        // Initialize seat name, blank customer name, false occupied seat

        VenueSeats[] venueArray = new VenueSeats[12];

        List<string> waitingList = new List<string>();

        // Store the user table selection
        string tableSelection = "";

        public frmMain()
        {
            InitializeComponent();
        }



        private void frmMain_Load(object sender, EventArgs e)
        {
            // Initialize objects
            // Do I really need to store the table names?
            // If I'm accessing the array information, adding +1 to the array index
            // would reflect the proper table along with the char from 
            // A row
            venueArray[0] = new VenueSeats("a1", "chris wickens", true);
            venueArray[1] = new VenueSeats("a2", "Timmothy", true);
            venueArray[2] = new VenueSeats("a3", "", false);
            venueArray[3] = new VenueSeats("a4", "", false);

            // B row
            venueArray[4] = new VenueSeats("b1", "", false);
            venueArray[5] = new VenueSeats("b2", "", false);
            venueArray[6] = new VenueSeats("b3", "", false);
            venueArray[7] = new VenueSeats("b4", "", false);

            // C row
            venueArray[8] = new VenueSeats("c1", "", false);
            venueArray[9] = new VenueSeats("c2", "Tom Smith", true);
            venueArray[10] = new VenueSeats("c3", "", false);
            venueArray[11] = new VenueSeats("c4", "", false);

            // Shows all tableNames
            //for (int i = 0; i < venueArray.Length; i++)
            //{
            //    //lblSystemMessages.Text = venueArray[i].tableName;
            //    MessageBox.Show($"Array: {i}, value: {venueArray[i].tableName}");
            //}
        }

        /// <summary>
        /// Assigns the table number to a variable for use
        /// based on what button the user clicked
        /// 
        /// </summary>
        /// <param name="buttonText"></param>
        private void SelectTable(string buttonText)
        {
            tableSelection = "";
            // Removes everything except the last two characters (A1 for example)
            tableSelection = buttonText.Substring(buttonText.Length - 2);
            lblTopStatus.Text = tableSelection;
            
        }

        private void ButtonClicked(object sender, EventArgs e)
        {
            // Removes everything except the last two characters (A1 for example)
            tableSelection = sender.ToString().Substring(sender.ToString().Length - 2);
            lblTopStatus.Text = tableSelection;

            // Shows the number value of the table by using substring to only leave the last character
            // the last character will always be numeric, by subtracting 1 from that, you get the array
            // location of that table
            lblSystemMessages.Text = sender.ToString().Substring(sender.ToString().Length - 1);

            string getTableNumber = sender.ToString().Substring(sender.ToString().Length - 1);

            // This gets the array location by using -1
            int tableArrayLocation = int.Parse(getTableNumber) - 1;

            // This box just shows the output with the -1 to ensure proper array index number
            // MessageBox.Show(tableArrayLocation.ToString());

            // Check for an empty table
            //VenueSeats.OccupancyCheck(venueArray);

        }

        // YOU CHANGED FROM THIS TO THE ABOVE BUTTON CLICKED
        // using the object, eventargs it will populate in the event list for any button
        private void btnA1_Click(object sender, EventArgs e)
        {
            
            // VenueSeats.Test1();
            // That is how you call the class to create objects

            // Assigns the systemmessage label the name from venuearray[0] cust name
            lblSystemMessages.Text = venueArray[0].customerName;
            //lblTopStatus.Text = sender.ToString();
            //tableSelection = "a1";

            SelectTable(sender.ToString());

        }

        private void btnBook_Click(object sender, EventArgs e)
        {

            if (txtBxCustName.Text == "" || txtBxCustName.Text == " ")
            {
                lblSystemMessages.Text = "Invalid name";
            }

            else 
            {
                lblSystemMessages.Text = txtBxCustName.Text;
                
                // Add name to the list
                waitingList.Add(txtBxCustName.Text);
                
            }
        }

        /// <summary>
        /// Checks each button button to see if the table has an occupant
        /// Adjusts the tooltip accordingly
        /// </summary>
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
    }
}
