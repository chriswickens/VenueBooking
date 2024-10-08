﻿namespace VenueBooking
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.gbxSeats = new System.Windows.Forms.GroupBox();
            this.btnC4 = new System.Windows.Forms.Button();
            this.btnC3 = new System.Windows.Forms.Button();
            this.btnC2 = new System.Windows.Forms.Button();
            this.btnC1 = new System.Windows.Forms.Button();
            this.btnB4 = new System.Windows.Forms.Button();
            this.btnB3 = new System.Windows.Forms.Button();
            this.btnB2 = new System.Windows.Forms.Button();
            this.btnB1 = new System.Windows.Forms.Button();
            this.btnA4 = new System.Windows.Forms.Button();
            this.btnA3 = new System.Windows.Forms.Button();
            this.btnA2 = new System.Windows.Forms.Button();
            this.btnA1 = new System.Windows.Forms.Button();
            this.lblTopStatus = new System.Windows.Forms.Label();
            this.lstBxRows = new System.Windows.Forms.ListBox();
            this.lstBxCols = new System.Windows.Forms.ListBox();
            this.lblCustName = new System.Windows.Forms.Label();
            this.txtBxCustName = new System.Windows.Forms.TextBox();
            this.btnBook = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAddToWaitList = new System.Windows.Forms.Button();
            this.btnFillAll = new System.Windows.Forms.Button();
            this.btnCancelAll = new System.Windows.Forms.Button();
            this.tltpDynamicDisplay = new System.Windows.Forms.ToolTip(this.components);
            this.lstBxWaitlistDisplay = new System.Windows.Forms.ListBox();
            this.btnClearWaitlist = new System.Windows.Forms.Button();
            this.grpbxWaitlist = new System.Windows.Forms.GroupBox();
            this.grbxRows = new System.Windows.Forms.GroupBox();
            this.grbxColumns = new System.Windows.Forms.GroupBox();
            this.pnlSystemMessages = new System.Windows.Forms.Panel();
            this.txtbxSystemMessages = new System.Windows.Forms.TextBox();
            this.lblStaticStatusText = new System.Windows.Forms.Label();
            this.gbxSeats.SuspendLayout();
            this.grpbxWaitlist.SuspendLayout();
            this.grbxRows.SuspendLayout();
            this.grbxColumns.SuspendLayout();
            this.pnlSystemMessages.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxSeats
            // 
            this.gbxSeats.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.gbxSeats.Controls.Add(this.btnC4);
            this.gbxSeats.Controls.Add(this.btnC3);
            this.gbxSeats.Controls.Add(this.btnC2);
            this.gbxSeats.Controls.Add(this.btnC1);
            this.gbxSeats.Controls.Add(this.btnB4);
            this.gbxSeats.Controls.Add(this.btnB3);
            this.gbxSeats.Controls.Add(this.btnB2);
            this.gbxSeats.Controls.Add(this.btnB1);
            this.gbxSeats.Controls.Add(this.btnA4);
            this.gbxSeats.Controls.Add(this.btnA3);
            this.gbxSeats.Controls.Add(this.btnA2);
            this.gbxSeats.Controls.Add(this.btnA1);
            this.gbxSeats.Location = new System.Drawing.Point(12, 54);
            this.gbxSeats.Name = "gbxSeats";
            this.gbxSeats.Size = new System.Drawing.Size(447, 308);
            this.gbxSeats.TabIndex = 0;
            this.gbxSeats.TabStop = false;
            this.gbxSeats.Text = "Venue";
            // 
            // btnC4
            // 
            this.btnC4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnC4.Location = new System.Drawing.Point(366, 228);
            this.btnC4.Name = "btnC4";
            this.btnC4.Size = new System.Drawing.Size(75, 55);
            this.btnC4.TabIndex = 11;
            this.btnC4.Text = "C4";
            this.btnC4.UseVisualStyleBackColor = false;
            this.btnC4.Click += new System.EventHandler(this.SeatDisplayButtonClicked);
            this.btnC4.MouseHover += new System.EventHandler(this.ButtonMouseHover);
            // 
            // btnC3
            // 
            this.btnC3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnC3.Location = new System.Drawing.Point(246, 228);
            this.btnC3.Name = "btnC3";
            this.btnC3.Size = new System.Drawing.Size(75, 55);
            this.btnC3.TabIndex = 10;
            this.btnC3.Text = "C3";
            this.btnC3.UseVisualStyleBackColor = false;
            this.btnC3.Click += new System.EventHandler(this.SeatDisplayButtonClicked);
            this.btnC3.MouseHover += new System.EventHandler(this.ButtonMouseHover);
            // 
            // btnC2
            // 
            this.btnC2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnC2.Location = new System.Drawing.Point(126, 228);
            this.btnC2.Name = "btnC2";
            this.btnC2.Size = new System.Drawing.Size(75, 55);
            this.btnC2.TabIndex = 9;
            this.btnC2.Text = "C2";
            this.btnC2.UseVisualStyleBackColor = false;
            this.btnC2.Click += new System.EventHandler(this.SeatDisplayButtonClicked);
            this.btnC2.MouseHover += new System.EventHandler(this.ButtonMouseHover);
            // 
            // btnC1
            // 
            this.btnC1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnC1.Location = new System.Drawing.Point(6, 228);
            this.btnC1.Name = "btnC1";
            this.btnC1.Size = new System.Drawing.Size(75, 55);
            this.btnC1.TabIndex = 8;
            this.btnC1.Text = "C1";
            this.btnC1.UseVisualStyleBackColor = false;
            this.btnC1.Click += new System.EventHandler(this.SeatDisplayButtonClicked);
            this.btnC1.MouseHover += new System.EventHandler(this.ButtonMouseHover);
            // 
            // btnB4
            // 
            this.btnB4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnB4.Location = new System.Drawing.Point(366, 133);
            this.btnB4.Name = "btnB4";
            this.btnB4.Size = new System.Drawing.Size(75, 55);
            this.btnB4.TabIndex = 7;
            this.btnB4.Text = "B4";
            this.btnB4.UseVisualStyleBackColor = false;
            this.btnB4.Click += new System.EventHandler(this.SeatDisplayButtonClicked);
            this.btnB4.MouseHover += new System.EventHandler(this.ButtonMouseHover);
            // 
            // btnB3
            // 
            this.btnB3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnB3.Location = new System.Drawing.Point(246, 133);
            this.btnB3.Name = "btnB3";
            this.btnB3.Size = new System.Drawing.Size(75, 55);
            this.btnB3.TabIndex = 6;
            this.btnB3.Text = "B3";
            this.btnB3.UseVisualStyleBackColor = false;
            this.btnB3.Click += new System.EventHandler(this.SeatDisplayButtonClicked);
            this.btnB3.MouseHover += new System.EventHandler(this.ButtonMouseHover);
            // 
            // btnB2
            // 
            this.btnB2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnB2.Location = new System.Drawing.Point(126, 133);
            this.btnB2.Name = "btnB2";
            this.btnB2.Size = new System.Drawing.Size(75, 55);
            this.btnB2.TabIndex = 5;
            this.btnB2.Text = "B2";
            this.btnB2.UseVisualStyleBackColor = false;
            this.btnB2.Click += new System.EventHandler(this.SeatDisplayButtonClicked);
            this.btnB2.MouseHover += new System.EventHandler(this.ButtonMouseHover);
            // 
            // btnB1
            // 
            this.btnB1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnB1.Location = new System.Drawing.Point(6, 133);
            this.btnB1.Name = "btnB1";
            this.btnB1.Size = new System.Drawing.Size(75, 55);
            this.btnB1.TabIndex = 4;
            this.btnB1.Text = "B1";
            this.btnB1.UseVisualStyleBackColor = false;
            this.btnB1.Click += new System.EventHandler(this.SeatDisplayButtonClicked);
            this.btnB1.MouseHover += new System.EventHandler(this.ButtonMouseHover);
            // 
            // btnA4
            // 
            this.btnA4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnA4.Location = new System.Drawing.Point(366, 38);
            this.btnA4.Name = "btnA4";
            this.btnA4.Size = new System.Drawing.Size(75, 55);
            this.btnA4.TabIndex = 3;
            this.btnA4.Text = "A4";
            this.btnA4.UseVisualStyleBackColor = false;
            this.btnA4.Click += new System.EventHandler(this.SeatDisplayButtonClicked);
            this.btnA4.MouseHover += new System.EventHandler(this.ButtonMouseHover);
            // 
            // btnA3
            // 
            this.btnA3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnA3.Location = new System.Drawing.Point(246, 38);
            this.btnA3.Name = "btnA3";
            this.btnA3.Size = new System.Drawing.Size(75, 55);
            this.btnA3.TabIndex = 2;
            this.btnA3.Text = "A3";
            this.btnA3.UseVisualStyleBackColor = false;
            this.btnA3.Click += new System.EventHandler(this.SeatDisplayButtonClicked);
            this.btnA3.MouseHover += new System.EventHandler(this.ButtonMouseHover);
            // 
            // btnA2
            // 
            this.btnA2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnA2.Location = new System.Drawing.Point(126, 38);
            this.btnA2.Name = "btnA2";
            this.btnA2.Size = new System.Drawing.Size(75, 55);
            this.btnA2.TabIndex = 1;
            this.btnA2.Text = "A2";
            this.btnA2.UseVisualStyleBackColor = false;
            this.btnA2.Click += new System.EventHandler(this.SeatDisplayButtonClicked);
            this.btnA2.MouseHover += new System.EventHandler(this.ButtonMouseHover);
            // 
            // btnA1
            // 
            this.btnA1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnA1.Location = new System.Drawing.Point(6, 38);
            this.btnA1.Name = "btnA1";
            this.btnA1.Size = new System.Drawing.Size(75, 55);
            this.btnA1.TabIndex = 0;
            this.btnA1.Text = "A1";
            this.btnA1.UseVisualStyleBackColor = false;
            this.btnA1.Click += new System.EventHandler(this.SeatDisplayButtonClicked);
            this.btnA1.MouseHover += new System.EventHandler(this.ButtonMouseHover);
            // 
            // lblTopStatus
            // 
            this.lblTopStatus.AutoSize = true;
            this.lblTopStatus.Location = new System.Drawing.Point(15, 9);
            this.lblTopStatus.Name = "lblTopStatus";
            this.lblTopStatus.Size = new System.Drawing.Size(127, 16);
            this.lblTopStatus.TabIndex = 1;
            this.lblTopStatus.Text = "Status: (replace this)";
            // 
            // lstBxRows
            // 
            this.lstBxRows.FormattingEnabled = true;
            this.lstBxRows.ItemHeight = 16;
            this.lstBxRows.Items.AddRange(new object[] {
            "A",
            "B",
            "C"});
            this.lstBxRows.Location = new System.Drawing.Point(6, 21);
            this.lstBxRows.Name = "lstBxRows";
            this.lstBxRows.Size = new System.Drawing.Size(120, 84);
            this.lstBxRows.TabIndex = 2;
            // 
            // lstBxCols
            // 
            this.lstBxCols.FormattingEnabled = true;
            this.lstBxCols.ItemHeight = 16;
            this.lstBxCols.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.lstBxCols.Location = new System.Drawing.Point(6, 21);
            this.lstBxCols.Name = "lstBxCols";
            this.lstBxCols.Size = new System.Drawing.Size(120, 84);
            this.lstBxCols.TabIndex = 3;
            // 
            // lblCustName
            // 
            this.lblCustName.AutoSize = true;
            this.lblCustName.Location = new System.Drawing.Point(506, 178);
            this.lblCustName.Name = "lblCustName";
            this.lblCustName.Size = new System.Drawing.Size(107, 16);
            this.lblCustName.TabIndex = 6;
            this.lblCustName.Text = "Customer Name:";
            // 
            // txtBxCustName
            // 
            this.txtBxCustName.Location = new System.Drawing.Point(509, 207);
            this.txtBxCustName.Name = "txtBxCustName";
            this.txtBxCustName.Size = new System.Drawing.Size(291, 22);
            this.txtBxCustName.TabIndex = 7;
            // 
            // btnBook
            // 
            this.btnBook.Location = new System.Drawing.Point(509, 249);
            this.btnBook.Name = "btnBook";
            this.btnBook.Size = new System.Drawing.Size(95, 42);
            this.btnBook.TabIndex = 8;
            this.btnBook.Text = "&Book";
            this.btnBook.UseVisualStyleBackColor = true;
            this.btnBook.Click += new System.EventHandler(this.btnBook_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(607, 249);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 42);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAddToWaitList
            // 
            this.btnAddToWaitList.Location = new System.Drawing.Point(705, 249);
            this.btnAddToWaitList.Name = "btnAddToWaitList";
            this.btnAddToWaitList.Size = new System.Drawing.Size(95, 42);
            this.btnAddToWaitList.TabIndex = 10;
            this.btnAddToWaitList.Text = "&Add to waitlist";
            this.btnAddToWaitList.UseVisualStyleBackColor = true;
            this.btnAddToWaitList.Click += new System.EventHandler(this.btnAddToWaitList_Click);
            // 
            // btnFillAll
            // 
            this.btnFillAll.Location = new System.Drawing.Point(509, 297);
            this.btnFillAll.Name = "btnFillAll";
            this.btnFillAll.Size = new System.Drawing.Size(140, 65);
            this.btnFillAll.TabIndex = 11;
            this.btnFillAll.Text = "&Fill all seats";
            this.btnFillAll.UseVisualStyleBackColor = true;
            this.btnFillAll.Click += new System.EventHandler(this.btnFillAll_Click);
            // 
            // btnCancelAll
            // 
            this.btnCancelAll.Location = new System.Drawing.Point(660, 297);
            this.btnCancelAll.Name = "btnCancelAll";
            this.btnCancelAll.Size = new System.Drawing.Size(140, 65);
            this.btnCancelAll.TabIndex = 12;
            this.btnCancelAll.Text = "Ca&ncel all bookings";
            this.btnCancelAll.UseVisualStyleBackColor = true;
            this.btnCancelAll.Click += new System.EventHandler(this.btnCancelAll_Click);
            // 
            // lstBxWaitlistDisplay
            // 
            this.lstBxWaitlistDisplay.CausesValidation = false;
            this.lstBxWaitlistDisplay.FormattingEnabled = true;
            this.lstBxWaitlistDisplay.ItemHeight = 16;
            this.lstBxWaitlistDisplay.Location = new System.Drawing.Point(40, 29);
            this.lstBxWaitlistDisplay.Name = "lstBxWaitlistDisplay";
            this.lstBxWaitlistDisplay.Size = new System.Drawing.Size(228, 228);
            this.lstBxWaitlistDisplay.TabIndex = 15;
            // 
            // btnClearWaitlist
            // 
            this.btnClearWaitlist.Location = new System.Drawing.Point(79, 276);
            this.btnClearWaitlist.Name = "btnClearWaitlist";
            this.btnClearWaitlist.Size = new System.Drawing.Size(151, 50);
            this.btnClearWaitlist.TabIndex = 17;
            this.btnClearWaitlist.Text = "Clear &Waitlist";
            this.btnClearWaitlist.UseVisualStyleBackColor = true;
            this.btnClearWaitlist.Click += new System.EventHandler(this.btnClearWaitlist_Click);
            // 
            // grpbxWaitlist
            // 
            this.grpbxWaitlist.Controls.Add(this.lstBxWaitlistDisplay);
            this.grpbxWaitlist.Controls.Add(this.btnClearWaitlist);
            this.grpbxWaitlist.Location = new System.Drawing.Point(834, 25);
            this.grpbxWaitlist.Name = "grpbxWaitlist";
            this.grpbxWaitlist.Size = new System.Drawing.Size(304, 337);
            this.grpbxWaitlist.TabIndex = 18;
            this.grpbxWaitlist.TabStop = false;
            this.grpbxWaitlist.Text = "Waitlist";
            // 
            // grbxRows
            // 
            this.grbxRows.Controls.Add(this.lstBxRows);
            this.grbxRows.Location = new System.Drawing.Point(509, 54);
            this.grbxRows.Name = "grbxRows";
            this.grbxRows.Size = new System.Drawing.Size(134, 116);
            this.grbxRows.TabIndex = 19;
            this.grbxRows.TabStop = false;
            this.grbxRows.Text = "Row";
            // 
            // grbxColumns
            // 
            this.grbxColumns.Controls.Add(this.lstBxCols);
            this.grbxColumns.Location = new System.Drawing.Point(666, 54);
            this.grbxColumns.Name = "grbxColumns";
            this.grbxColumns.Size = new System.Drawing.Size(134, 116);
            this.grbxColumns.TabIndex = 20;
            this.grbxColumns.TabStop = false;
            this.grbxColumns.Text = "Column";
            // 
            // pnlSystemMessages
            // 
            this.pnlSystemMessages.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlSystemMessages.Controls.Add(this.txtbxSystemMessages);
            this.pnlSystemMessages.Controls.Add(this.lblStaticStatusText);
            this.pnlSystemMessages.Location = new System.Drawing.Point(12, 377);
            this.pnlSystemMessages.Name = "pnlSystemMessages";
            this.pnlSystemMessages.Size = new System.Drawing.Size(1126, 44);
            this.pnlSystemMessages.TabIndex = 21;
            // 
            // txtbxSystemMessages
            // 
            this.txtbxSystemMessages.Location = new System.Drawing.Point(54, 9);
            this.txtbxSystemMessages.Name = "txtbxSystemMessages";
            this.txtbxSystemMessages.Size = new System.Drawing.Size(1065, 22);
            this.txtbxSystemMessages.TabIndex = 23;
            // 
            // lblStaticStatusText
            // 
            this.lblStaticStatusText.AutoSize = true;
            this.lblStaticStatusText.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStaticStatusText.Location = new System.Drawing.Point(1, 12);
            this.lblStaticStatusText.Name = "lblStaticStatusText";
            this.lblStaticStatusText.Size = new System.Drawing.Size(47, 16);
            this.lblStaticStatusText.TabIndex = 22;
            this.lblStaticStatusText.Text = "Status:";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1155, 435);
            this.Controls.Add(this.pnlSystemMessages);
            this.Controls.Add(this.grbxColumns);
            this.Controls.Add(this.grbxRows);
            this.Controls.Add(this.grpbxWaitlist);
            this.Controls.Add(this.btnCancelAll);
            this.Controls.Add(this.btnFillAll);
            this.Controls.Add(this.btnAddToWaitList);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnBook);
            this.Controls.Add(this.txtBxCustName);
            this.Controls.Add(this.lblCustName);
            this.Controls.Add(this.lblTopStatus);
            this.Controls.Add(this.gbxSeats);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "VenueBooking";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.gbxSeats.ResumeLayout(false);
            this.grpbxWaitlist.ResumeLayout(false);
            this.grbxRows.ResumeLayout(false);
            this.grbxColumns.ResumeLayout(false);
            this.pnlSystemMessages.ResumeLayout(false);
            this.pnlSystemMessages.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxSeats;
        private System.Windows.Forms.Button btnC4;
        private System.Windows.Forms.Button btnC3;
        private System.Windows.Forms.Button btnC2;
        private System.Windows.Forms.Button btnC1;
        private System.Windows.Forms.Button btnB4;
        private System.Windows.Forms.Button btnB3;
        private System.Windows.Forms.Button btnB2;
        private System.Windows.Forms.Button btnB1;
        private System.Windows.Forms.Button btnA4;
        private System.Windows.Forms.Button btnA3;
        private System.Windows.Forms.Button btnA2;
        private System.Windows.Forms.Button btnA1;
        private System.Windows.Forms.Label lblTopStatus;
        private System.Windows.Forms.ListBox lstBxRows;
        private System.Windows.Forms.ListBox lstBxCols;
        private System.Windows.Forms.Label lblCustName;
        private System.Windows.Forms.TextBox txtBxCustName;
        private System.Windows.Forms.Button btnBook;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAddToWaitList;
        private System.Windows.Forms.Button btnFillAll;
        private System.Windows.Forms.Button btnCancelAll;
        private System.Windows.Forms.ToolTip tltpDynamicDisplay;
        private System.Windows.Forms.ListBox lstBxWaitlistDisplay;
        private System.Windows.Forms.Button btnClearWaitlist;
        private System.Windows.Forms.GroupBox grpbxWaitlist;
        private System.Windows.Forms.GroupBox grbxRows;
        private System.Windows.Forms.GroupBox grbxColumns;
        private System.Windows.Forms.Panel pnlSystemMessages;
        private System.Windows.Forms.Label lblStaticStatusText;
        private System.Windows.Forms.TextBox txtbxSystemMessages;
    }
}

