using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace BeautyAndCosmetics
{
    public partial class frmSimpsonsInformation : Form
    {
        public frmSimpsonsInformation()
        {
            InitializeComponent();
            CustomDesign();
        }

        public string TableCheck;
        string slot1;

        //Method that hides all panels
        private void CustomDesign()
        {
            panelCustomer.Visible = false;
            panelRoom.Visible = false;
            panelBooking.Visible = false;
            panelProduct.Visible = false;
            panelStaff.Visible = false;
            panellast.Visible = false;



        }


        //Method that checks if a panel is visible, this will be called in on click of a panel and if it is visible the panels will hide
        private void HideSub()
        {
            if (PanelSelectCategory.Visible == true)
            {
                if (panelCustomer.Visible == true)
                {
                    panelCustomer.Visible = false;

                }



                if (panelRoom.Visible == true)
                {
                    panelRoom.Visible = false;

                }




                if (panelBooking.Visible == true)
                {
                    panelBooking.Visible = false;

                }
                if (panelProduct.Visible == true)
                {
                    panelProduct.Visible = false;

                }
                if (panelStaff.Visible == true)
                {
                    panelStaff.Visible = false;

                }

                if (panellast.Visible == true)
                {
                    panellast.Visible = false;

                }
            }
        }
        //This method is called in on a panel click which shows the panels if they aren't shown 
        private void ShowSub(Panel SubMenu)
        {
            if (SubMenu.Visible == false)
            {
                HideSub();
                SubMenu.Visible = true;
            }
            else
            {
                SubMenu.Visible = false;

            }

        }


        //This Switch Statement is For Adding, Deleting and Updating the Customer, Stock, Staff, Room, Product, Slots and Booking
        public void WhatToDo(string form)
        {
            switch (form)
            {


                //Updating Customer
                case "CustomerUpdate":

                    try
                    {
                        //Calls in the Constructor for Customer to ensure the textbox's are validated
                        Customer cust = new Customer(txtBeauty2.Texts, txtBeauty3.Texts, txtBeauty4.Texts, txtBeauty5.Texts);

                        ConnectionString.Connect.Close();
                        ConnectionString.Connect.Open();

                        //Calls in the SQL command to update the customer
                        SqlCommand s = new SqlCommand("UpdateCustomer", ConnectionString.Connect);
                        s.CommandType = CommandType.StoredProcedure;
                        s.Parameters.AddWithValue("@SF", txtBeauty2.Texts);
                        s.Parameters.AddWithValue("@SS", txtBeauty3.Texts);
                        s.Parameters.AddWithValue("@SE", txtBeauty4.Texts);
                        s.Parameters.AddWithValue("@SP", txtBeauty5.Texts);
                        s.Parameters.AddWithValue("@SN", txtBeauty1.Texts);

                        s.ExecuteNonQuery();
                        ConnectionString.Connect.Close();

                        //Calls in the method to populate the Data Grid View
                        LoadInformationCustomer();
                        MessageBox.Show("Updated Successfully");
                        //Method to clear the textbox's so the user can't input the same data twice
                        clearing();

                        //Populates the textbox's text to allow the user to understand what data to type into what textbox
                        RenamingCustomer();

                        disablingTextBoxes();


                    }
                    catch (Exception ex)
                    {
                        //Message box show's the error the user has inputted (Validation)
                        MessageBox.Show(ex.Message);
                    }



                    break;


                //Adds the Customer to the Table
                case "CustomerAdd":

                    try
                    {
                        //Calls in the constructor to validate the textbox's
                        Customer cust = new Customer(txtBeauty2.Texts, txtBeauty3.Texts, txtBeauty4.Texts, txtBeauty5.Texts);
                        ConnectionString.Connect.Close();
                        ConnectionString.Connect.Open();

                        //Calls in the SQL command to add the customer to the table
                        SqlCommand commander = new SqlCommand("AddCustomerBeauty", ConnectionString.Connect);
                        commander.CommandType = CommandType.StoredProcedure;
                        commander.Parameters.AddWithValue("@CustomerForename", txtBeauty2.Texts);
                        commander.Parameters.AddWithValue("@CustomerSurname", txtBeauty3.Texts);
                        commander.Parameters.AddWithValue("@CustomerEmail", txtBeauty4.Texts);
                        commander.Parameters.AddWithValue("@CustomerPhone", txtBeauty5.Texts);
                        commander.ExecuteNonQuery();
                        ConnectionString.Connect.Close();

                        //Calls in the method to populate the data into the datagrid view
                        LoadInformationCustomer();

                        //Calls in the method to clear all the textbox's
                        clearing();

                        //Calls in the method to populate the text in each tetxbox to allow the user to understand what to input to each textbox
                        RenamingCustomer();


                    }
                    catch (Exception ex)
                    {
                        //Message box shows if any text did not meet the requirements
                        MessageBox.Show(ex.Message);
                    }


                    break;




                //Deleting a Customer
                case "CustomerDelete":

                    if (txtBeauty1.Texts == "Customer Code" || txtBeauty2.Texts == "Customer Name" || txtBeauty3.Texts == "Customer Surname" || txtBeauty4.Texts == "Customer Email" || txtBeauty1.Texts == "Customer Phone")
                    {
                        MessageBox.Show("Please Select A Customer before attempting to delete");
                    }
                    else
                    {
                        //Message box asking whether to delete the user or not, gives them the option to cancel or accept
                        string message = "Are You Sure You Want To Delete User" + txtBeauty1.Texts.ToString() + " It Will Remove All Their Existing Bookings "; //This show the user the customer code to let them know what user they are deleting
                        const string caption = "Delete User";
                        var result = MessageBox.Show(message, caption,
                                                     MessageBoxButtons.OKCancel,
                                                     MessageBoxIcon.Question);

                        if (result == DialogResult.OK)
                        {

                            //DELETE BOOKING
                            //ConnectionString.Connect.Close();

                            //ConnectionString.Connect.Open();
                            ////SQL command to delete the customers booking information so the customer can be deleted successfully 
                            //SqlCommand a1 = new SqlCommand("DeleteAllBooking", ConnectionString.Connect);
                            //a1.CommandType = CommandType.StoredProcedure;
                            ////Checks the customer Code and delete that record depending on the code
                            //a1.Parameters.AddWithValue("@CustomerNumber", lblCustomerNumber2.Text);
                            //a1.ExecuteNonQuery();
                            //ConnectionString.Connect.Close();

                            //DELETE BOOKING
                            ConnectionString.Connect.Close();

                            ConnectionString.Connect.Open();
                            //SQL command to delete the customers information
                            SqlCommand a = new SqlCommand("DeleteBooking", ConnectionString.Connect);
                            a.CommandType = CommandType.StoredProcedure;
                            //Checks the customer Code and delete that record depending on the code
                            a.Parameters.AddWithValue("@BookingCode", txtBeauty1.Texts);
                            a.ExecuteNonQuery();
                            ConnectionString.Connect.Close();

                            //////////////////////////////////////////////////

                            ConnectionString.Connect.Open();
                            //SQL command to delete the customers information
                            SqlCommand aa = new SqlCommand("DeleteCustomer3", ConnectionString.Connect);
                            aa.CommandType = CommandType.StoredProcedure;
                            //Checks the customer Code and delete that record depending on the code
                            aa.Parameters.AddWithValue("@CustomerCode", txtBeauty1.Texts);
                            aa.ExecuteNonQuery();
                            ConnectionString.Connect.Close();
                            //Calls in the method to populate the data grid view
                            LoadInformationCustomer();

                            //Clears all the textbox's
                            clearing();
                            //Changes the text for each textbox, dependig on what the user needs to input
                            RenamingCustomer();

                        }

                    }

                    break;

                //Updates Staff
                case "StaffUpdate":




                    try
                    {
                        //Calls in the constructor to ensure the user inserts the corrct information
                        Staff TheStaff = new Staff(txtBeauty2.Texts, txtBeauty3.Texts, txtBeauty4.Texts);

                        //Calls in the SQL update command 
                        SqlCommand aa = new SqlCommand("UpdateStaff", ConnectionString.Connect);
                        aa.CommandType = CommandType.StoredProcedure;
                        //The textbox's used to update the fields
                        aa.Parameters.AddWithValue("@SN", txtBeauty1.Texts);
                        aa.Parameters.AddWithValue("@SF", txtBeauty2.Texts);
                        aa.Parameters.AddWithValue("@SS", txtBeauty3.Texts);
                        aa.Parameters.AddWithValue("@SC", txtBeauty4.Texts);

                        ConnectionString.Connect.Close();

                        ConnectionString.Connect.Open();
                        aa.ExecuteNonQuery();
                        ConnectionString.Connect.Close();

                        //Calls in the method to populate the data grid view
                        LoadInformationStaff();
                        MessageBox.Show("Updated Successfully");
                        //Calls in a method to clear the textbox's
                        clearing();
                        //Changes the text for each textbox so the user knows what information to enter for each field 
                        RenamingStaff();

                        disablingTextBoxes();

                    }
                    catch (Exception ex)
                    {
                        //If the user inserts the incorrect information a message box will show
                        MessageBox.Show(ex.Message);
                    }

                    break;

                //Add Staff
                case "StaffAdd":

                    try
                    {

                        //Calls in the constructor to ensure the user inserts the corrct information
                        Staff TheStaff = new Staff(txtBeauty2.Texts, txtBeauty3.Texts, txtBeauty4.Texts);
                        ConnectionString.Connect.Close();
                        ConnectionString.Connect.Open();

                        //SQL command to add the staff to the table
                        SqlCommand aaaaa = new SqlCommand("AddStaff", ConnectionString.Connect);
                        aaaaa.CommandType = CommandType.StoredProcedure;

                        //The textbox's which the data is being taken from
                        aaaaa.Parameters.AddWithValue("@StaffForename", txtBeauty2.Texts);
                        aaaaa.Parameters.AddWithValue("@StaffSurname", txtBeauty3.Texts);
                        //Changes whatever the user inputs to all capital, to meet the vaildation
                        aaaaa.Parameters.AddWithValue("@StaffContract", txtBeauty4.Texts.ToUpper());
                        aaaaa.ExecuteNonQuery();
                        ConnectionString.Connect.Close();

                        //Calls in the method to load the information into the table
                        LoadInformationStaff();

                        //Clears the text
                        clearing();
                        RenamingStaff();


                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);


                    }

                    break;


                //Same as other Case Deletes
                case "StaffDelete":

                    if (txtBeauty1.Texts == "Staff Code" || txtBeauty2.Texts == "Staff Name" || txtBeauty3.Texts == "Staff Surname" || txtBeauty4.Texts == "Staff Contract")
                    {
                        MessageBox.Show("Please Select Member before attempting to delete");
                    }
                    else
                    {
                        string messagea = "Are You Sure You Want To Delete User" + txtBeauty1.Texts.ToString();
                        const string captiona = "Deleting User";
                        var resulta = MessageBox.Show(messagea, captiona,
                                                     MessageBoxButtons.OKCancel,
                                                     MessageBoxIcon.Question);

                        if (resulta == DialogResult.OK)
                        {
                            ConnectionString.Connect.Close();

                            ConnectionString.Connect.Open();
                            SqlCommand aaaa = new SqlCommand("DeleteStaff", ConnectionString.Connect);
                            aaaa.CommandType = CommandType.StoredProcedure;
                            aaaa.Parameters.AddWithValue("@StaffCode", txtBeauty1.Texts);
                            aaaa.ExecuteNonQuery();
                            ConnectionString.Connect.Close();
                            LoadInformationStaff();
                            clearing();
                            RenamingStaff();

                        }

                    }

                    break;

                //Same as other case Add's
                case "RoomAdd":

                    try

                    {
                        Room hello = new Room(txtBeauty2.Texts);
                        ConnectionString.Connect.Close();
                        ConnectionString.Connect.Open();
                        SqlCommand commander = new SqlCommand("AddRoom", ConnectionString.Connect);
                        commander.CommandType = CommandType.StoredProcedure;
                        commander.Parameters.AddWithValue("@RoomDescription", txtBeauty2.Texts);
                        commander.ExecuteNonQuery();
                        ConnectionString.Connect.Close();
                        LoadInformationRoom();
                        clearing();
                        RenamingRoom();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }


                    break;

                //Same as other Case deletes
                case "RoomDelete":

                    if (txtBeauty1.Texts == "Room Code")
                    {
                        MessageBox.Show("Please select a Room before attempting to delete");
                    }
                    else
                    {
   string messageaa = "Are You Sure You Want To Delete Room" + txtBeauty1.Texts.ToString();
                    const string captionaa = "Deleting Room";
                    var resultaa = MessageBox.Show(messageaa, captionaa,
                                                 MessageBoxButtons.OKCancel,
                                                 MessageBoxIcon.Question);


                    if (resultaa == DialogResult.OK)
                    {
                            ConnectionString.Connect.Close();

                            ConnectionString.Connect.Open();
                        SqlCommand h = new SqlCommand("DeleteRoom", ConnectionString.Connect);
                        h.CommandType = CommandType.StoredProcedure;
                        h.Parameters.AddWithValue("@RoomCode", txtBeauty1.Texts);
                        h.ExecuteNonQuery();
                        ConnectionString.Connect.Close();
                        LoadInformationRoom();
                        clearing();
                        RenamingRoom();
                    }




                    }
                 

                    break;

                //Same as other case updates
                case "RoomUpdate":



                    try
                    {

                        Room hello = new Room(txtBeauty2.Texts);

                        SqlCommand aaa = new SqlCommand("UpdateRoom", ConnectionString.Connect);
                        aaa.CommandType = CommandType.StoredProcedure;
                        aaa.Parameters.AddWithValue("@RD", txtBeauty2.Texts);
                        aaa.Parameters.AddWithValue("@RC", txtBeauty1.Texts);

                        ConnectionString.Connect.Close();

                        ConnectionString.Connect.Open();
                        aaa.ExecuteNonQuery();
                        ConnectionString.Connect.Close();
                        LoadInformationRoom();
                        MessageBox.Show("Updated Successfully");
                        clearing();
                        RenamingRoom();


                        disablingTextBoxes();


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }


                    break;

                //Same as other Case Adds
                case "ProductAdd":

                    try

                    {
                        Product product = new Product(txtBeauty2.Texts, txtBeauty3.Texts);
                        ConnectionString.Connect.Close();
                        ConnectionString.Connect.Open();
                        SqlCommand commander = new SqlCommand("AddProduct", ConnectionString.Connect);
                        commander.CommandType = CommandType.StoredProcedure;
                        commander.Parameters.AddWithValue("@ProductName", txtBeauty2.Texts);
                        commander.Parameters.AddWithValue("@ProductPrice", txtBeauty3.Texts);

                        commander.ExecuteNonQuery();
                        ConnectionString.Connect.Close();
                        LoadInformationProduct();
                        clearing();
                        RenamingProduct();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }


                    break;

                //Same as other case deletes
                case "ProductDelete":


                    if(txtBeauty1.Texts == "Product Code")
                    {
                        MessageBox.Show("Please Select a Product before attempting to delete");
                    }
                    else
                    {
  string message111 = "Are You Sure You Want To Delete Product" + txtBeauty1.Texts.ToString();
                    const string acaption = "Delete Product";
                    var aresult = MessageBox.Show(message111, acaption,
                                                 MessageBoxButtons.OKCancel,
                                                 MessageBoxIcon.Question);

                    if (aresult == DialogResult.OK)
                    {
                            ConnectionString.Connect.Close();
                        ConnectionString.Connect.Open();
                        SqlCommand a = new SqlCommand("DeleteProduct", ConnectionString.Connect);
                        a.CommandType = CommandType.StoredProcedure;
                        a.Parameters.AddWithValue("@ProductCode", txtBeauty1.Texts);
                        a.ExecuteNonQuery();
                        ConnectionString.Connect.Close();
                        LoadInformationProduct();
                        clearing();
                        RenamingProduct();

                    }
                    }

                  
                    break;

                //Same as other case updates
                case "ProductUpdate":


                    try
                    {
                        Product product = new Product(txtBeauty2.Texts, txtBeauty3.Texts);

                        ConnectionString.Connect.Close();
                        ConnectionString.Connect.Open();


                        SqlCommand sin = new SqlCommand("UpdateProduct", ConnectionString.Connect);
                        sin.CommandType = CommandType.StoredProcedure;
                        sin.Parameters.AddWithValue("@PN", txtBeauty2.Texts);
                        sin.Parameters.AddWithValue("@PC", txtBeauty3.Texts);
                        sin.Parameters.AddWithValue("@SN", txtBeauty1.Texts);

                        sin.ExecuteNonQuery();
                        ConnectionString.Connect.Close();

                        LoadInformationProduct();
                        MessageBox.Show("Updated Successfully");
                        clearing();
                        RenamingProduct();

                        disablingTextBoxes();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }



                    break;
                //Same as other case Add's
                case "SlotsAdd":

                    try

                    {
                        // ADD CLASS VALIDATION
                        ConnectionString.Connect.Close();
                        ConnectionString.Connect.Open();
                        SqlCommand commander = new SqlCommand("AddSlots", ConnectionString.Connect);
                        commander.CommandType = CommandType.StoredProcedure;
                        commander.Parameters.AddWithValue("@BookingSlot", txtBeauty2.Texts);

                        commander.ExecuteNonQuery();
                        ConnectionString.Connect.Close();
                        LoadInformationSlots();
                        clearing();
                        RenamingSlots();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }


                    break;

                //Same as other Case deletes
                case "SlotsDelete":

                    if (txtBeauty1.Texts == "Slots Code")
                    {
                        MessageBox.Show("Please selete a Slot befor attempting to delete");
                    }

                    else
                    {

                        string message1111 = "Are You Sure You Want To Delete Slots" + txtBeauty1.Texts.ToString();
                        const string acaption1 = "Delete Slots";
                        var aresult1 = MessageBox.Show(message1111, acaption1,
                                                     MessageBoxButtons.OKCancel,
                                                     MessageBoxIcon.Question);





                        if (aresult1 == DialogResult.OK)
                        {
                            ConnectionString.Connect.Close();

                            ConnectionString.Connect.Open();
                            SqlCommand a = new SqlCommand("DeleteSlots", ConnectionString.Connect);
                            a.CommandType = CommandType.StoredProcedure;
                            a.Parameters.AddWithValue("@SlotsCode", txtBeauty1.Texts);
                            a.ExecuteNonQuery();
                            ConnectionString.Connect.Close();
                            LoadInformationSlots();
                            clearing();
                            RenamingSlots();

                        }
                    }
                  

                    break;

                //Same as other case updates
                case "SlotsUpdate":


                    try
                    {
                        // add Class VAlidation
                        ConnectionString.Connect.Close();
                        ConnectionString.Connect.Open();


                        SqlCommand sin = new SqlCommand("UpdateSlots", ConnectionString.Connect);
                        sin.CommandType = CommandType.StoredProcedure;
                        sin.Parameters.AddWithValue("@BS", txtBeauty2.Texts);
                        sin.Parameters.AddWithValue("@SN", txtBeauty1.Texts);

                        sin.ExecuteNonQuery();
                        ConnectionString.Connect.Close();

                        LoadInformationSlots();
                        MessageBox.Show("Updated Successfully");
                        clearing();
                        RenamingSlots();

                        disablingTextBoxes();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }



                    break;

                //Same as other case Add's
                case "BookingAdd":

                    try

                    {

                        // ADD CLASS VALIDATION
                        ConnectionString.Connect.Close();
                        ConnectionString.Connect.Open();
                        SqlCommand commander = new SqlCommand("AddBookingSlot", ConnectionString.Connect);
                        commander.CommandType = CommandType.StoredProcedure;
                        //Selects the date the user enters
                        commander.Parameters.AddWithValue("@BookingDate", monthCalendarBooking.SelectionRange.Start.ToString("yyyy-MM-dd"));
                        string slot;
                        if (Char.IsDigit(cmbSlots.Text[2]))
                        {
                            slot = cmbSlots.Text[1].ToString() + cmbSlots.Text[2].ToString();
                        }
                        else
                        {
                            slot = cmbSlots.Text[1].ToString();
                        }

                        commander.Parameters.AddWithValue("@SlotsNumber", slot);
                        commander.Parameters.AddWithValue("@CustomerNumber", lblCustomerNumber.Text);
                        commander.Parameters.AddWithValue("@RoomNumber", lblRoom.Text);
                        commander.Parameters.AddWithValue("@Treatment", cmbTreatment.Text);
                        commander.Parameters.AddWithValue("@BookingPrice", lblPrice.Text);
                        commander.Parameters.AddWithValue("@Paid", Paid);






                        commander.ExecuteNonQuery();
                        ConnectionString.Connect.Close();
                        LoadInformationBooking();
                        clearing();

                        //Clears the Combo Box
                        cmbSlots.SelectedIndex = -1;

                        LoadSlots();
                        LoadRoomDescription();


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }


                    break;

                case "BookingDelete":

                    if (txtBeauty1.Texts == "Booking Code")
                    {
                        MessageBox.Show("Please select a Booking before attempting to delete");
                    }

                    else
                    {
                    string amessage1111 = "Are You Sure You Want To Delete Booking" + txtBeauty1.Texts.ToString();
                    const string aacaption1 = "Delete Booking";
                    var aaresult1 = MessageBox.Show(amessage1111, aacaption1,
                                                 MessageBoxButtons.OKCancel,
                                                 MessageBoxIcon.Question);


                    if (aaresult1 == DialogResult.OK)
                    {
                            ConnectionString.Connect.Close();

                            ConnectionString.Connect.Open();
                        SqlCommand a = new SqlCommand("DeleteBooking", ConnectionString.Connect);
                        a.CommandType = CommandType.StoredProcedure;
                        a.Parameters.AddWithValue("@BookingCode", txtBeauty1.Texts);
                        a.ExecuteNonQuery();
                        ConnectionString.Connect.Close();
                        LoadInformationBooking();
                        clearing();
                        cmbSlots.Text = "";
                        txtBeauty1.Clear();

                        //Add renaming Booking
                    }


                    }

                  
                    break;

                case "BookingUpdate":


                    try
                    {

                        BookingSimpsons book = new BookingSimpsons(txtBeauty1.Texts, cmbSlots.Text, cmbRoom.Text, cmbTreatment.Text, cmbStaff.Text, Paid);


                        ConnectionString.Connect.Close();
                        ConnectionString.Connect.Open();




                        //Code to Get Room Code
                        SqlCommand command = new SqlCommand("SelectRoomCode", ConnectionString.Connect);
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@RoomCode", cmbRoom.Text);
                        var RoomNumbero = command.ExecuteScalar().ToString();
                        lblRoom.Text = RoomNumbero;
                        RoomNumber = lblRoom.Text;
                        //////////////////////////////////////////////////////////////////
                        



                        //STILL NEED TO ADD STAFF PRIMARY KEY BESIDE STAFF NAME, WHEN USER CLICKS ON THE DATA GRID VIEW THE PRIMARY KEY DOES NOT SHOW, CHANGE A STAFF USER FOR IT TO WORK AS PRMARY KEY SHOWS

                        string[] StaffNumb = cmbStaff.Text.ToString().Split(':');


                        //string[] SlotNumberr = cmbSlots.Text.ToString().Split(',');

                        string[] slotsar = cmbSlots.Text.ToString().Split('[');
                        string[] slotaris = slotsar[1].Split(',');

                       

                        SqlCommand updatetheb = new SqlCommand("UpdateBooking", ConnectionString.Connect);
                        updatetheb.CommandType = CommandType.StoredProcedure;
                        updatetheb.Parameters.AddWithValue("@BD", monthCalendarBooking.SelectionRange.Start.ToString("yyyy-MM-dd"));
                        updatetheb.Parameters.AddWithValue("@SN", slotaris[0]);
                        updatetheb.Parameters.AddWithValue("@BC", txtBeauty1.Texts);
                        updatetheb.Parameters.AddWithValue("@BT", cmbTreatment.Text);
                        updatetheb.Parameters.AddWithValue("@RN", Convert.ToInt32(RoomNumber));
                        updatetheb.Parameters.AddWithValue("@STN", Convert.ToInt32(StaffNumb[0]));
                        updatetheb.ExecuteNonQuery();

                     
                        LoadInformationBooking();
                        MessageBox.Show("Updated Successfully");

                    

                       // clearing();
                      //  cmbSlots.SelectedIndex = -1;

                        ConnectionString.Connect.Close();

                        disablingTextBoxes();

                        txtBeauty1.Texts = "Booking Code";
                        cmbSlots.Text = "Time Slots";
                        cmbTreatment.Text = "Treatments";
                        cmbTreatment.Enabled = false;
                        cmbRoom.Text = "Rooms";
                        cmbStaff.Text = "Staff Member";
                        cmbStaff.Enabled = false;
                        Paid = null;
                        Picture = null;
                        pctPayNow.Image = null;
                        pctPayLater.Image = null;
                        lblPayNow.Visible = false;
                        lblPrice.Text = "£0.00";





                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }



                    break;


            }
        }

        //Csse statement to chage the layout of the form, depenidng on what table the user wants to view
        public void LoadingShow(string form)
        {
            switch (form)
            {
                case "ProductUpdate":
                    enablingTextBoxes();
                    PanelHiding();
                    CellContentChecking = "Product";

                    LoadInformationProduct();
                    clearing();
                    RenamingProduct();
                    TableCheck = "ProductUpdate";
                    HideSub();
                    txtBeauty5.Visible = false;
                    txtBeauty4.Visible = false;


                    txtBeauty2.Enabled = true;
                    txtBeauty5.Enabled = true;

                    panelMain.Visible = true;
                    //enter what to do
                    HideSub();
                    panelMain.Size = new Size(1132, 752);
                    panelMain.Location = new Point(273, 0);
                    panelMain.BringToFront();
                    btnAddDeleteUpdate.Text = "Update";
                    txtBeauty5.Visible = false;
                    txtBeauty4.Visible = false;
                    txtBeauty3.Visible = true;
                    txtBeauty2.Visible = true;
                    txtBeauty1.Visible = true;
                    txtBeauty1.Enabled = false;

                    disablingTextBoxes();
                    break;


                case "ProductDelete":
                    disablingTextBoxes();
                    PanelHiding();
                    CellContentChecking = "ProductDelete";

                    LoadInformationProduct();
                    txtBeauty5.Visible = false;
                    txtBeauty4.Visible = false;
                    TableCheck = "ProductDelete";
                    clearing();
                    RenamingProduct();


                    panelMain.Visible = true;
                    //enter what to do
                    HideSub();
                    panelMain.Size = new Size(1132, 752);
                    panelMain.Location = new Point(273, 0);
                    panelMain.BringToFront();
                    btnAddDeleteUpdate.Text = "Delete";
                    txtBeauty5.Visible = false;
                    txtBeauty4.Visible = false;
                    txtBeauty3.Visible = true;
                    txtBeauty2.Visible = true;
                    txtBeauty1.Visible = true;


                    txtBeauty2.Enabled = false;
                    txtBeauty5.Enabled = true;
                    HideSub();
                    break;

                case "SlotsUpdate":
                    enablingTextBoxes();
                    PanelHiding();
                    CellContentChecking = "Slots";

                    LoadInformationSlots();
                    clearing();
                    RenamingSlots();
                    TableCheck = "SlotsUpdate";
                    HideSub();
                    txtBeauty5.Visible = false;
                    txtBeauty4.Visible = false;
                    txtBeauty3.Visible = false;

                    txtBeauty2.Enabled = true;
                    txtBeauty5.Enabled = true;


                    panelMain.Visible = true;
                    //enter what to do
                    HideSub();
                    panelMain.Size = new Size(1132, 752);
                    panelMain.Location = new Point(273, 0);
                    panelMain.BringToFront();
                    btnAddDeleteUpdate.Text = "Update";
                    txtBeauty5.Visible = false;

                    txtBeauty2.Visible = true;
                    txtBeauty1.Visible = true;

                    HideSub();
                    txtBeauty1.Enabled = false;

                    disablingTextBoxes();
                    break;

                case "SlotsDelete":
                    disablingTextBoxes();
                    PanelHiding();
                    CellContentChecking = "SlotsDelete";

                    LoadInformationSlots();
                    txtBeauty5.Visible = false;
                    TableCheck = "SlotsDelete";
                    clearing();
                    RenamingSlots();


                    panelMain.Visible = true;
                    //enter what to do
                    HideSub();
                    panelMain.Size = new Size(1132, 752);
                    panelMain.Location = new Point(273, 0);
                    panelMain.BringToFront();
                    btnAddDeleteUpdate.Text = "Delete";
                    txtBeauty5.Visible = false;
                    txtBeauty4.Visible = false;
                    txtBeauty3.Visible = false;
                    txtBeauty2.Visible = true;
                    txtBeauty1.Visible = true;


                    txtBeauty2.Enabled = false;
                    txtBeauty5.Enabled = true;
                    HideSub();

                    break;


                case "StaffUpdate":

                    enablingTextBoxes();
                    PanelHiding();
                    CellContentChecking = "Staff";

                    LoadInformationStaff();
                    clearing();
                    RenamingStaff();
                    TableCheck = "StaffUpdate";
                    HideSub();
                    txtBeauty5.Visible = false;



                    panelMain.Visible = true;
                    //enter what to do
                    HideSub();
                    panelMain.Size = new Size(1132, 752);
                    panelMain.Location = new Point(273, 0);
                    panelMain.BringToFront();
                    btnAddDeleteUpdate.Text = "Update";
                    txtBeauty5.Visible = false;
                    txtBeauty4.Visible = true;
                    txtBeauty3.Visible = true;
                    txtBeauty2.Visible = true;
                    txtBeauty1.Visible = true;

                    txtBeauty2.Enabled = true;
                    txtBeauty5.Enabled = true;
                    txtBeauty1.Enabled = false;

                    disablingTextBoxes();
                    //enter what to do
                    break;


                case "StaffDelete":

                    disablingTextBoxes();
                    PanelHiding();
                    CellContentChecking = "StaffDelete";

                    LoadInformationStaff();
                    txtBeauty5.Visible = false;
                    TableCheck = "StaffDelete";
                    clearing();
                    RenamingStaff();


                    panelMain.Visible = true;
                    //enter what to do
                    HideSub();
                    panelMain.Size = new Size(1132, 752);
                    panelMain.Location = new Point(273, 0);
                    panelMain.BringToFront();
                    btnAddDeleteUpdate.Text = "Delete";
                    txtBeauty5.Visible = false;
                    txtBeauty4.Visible = true;
                    txtBeauty3.Visible = true;
                    txtBeauty2.Visible = true;
                    txtBeauty1.Visible = true;

                    txtBeauty2.Enabled = false;
                    txtBeauty5.Enabled = true;

                    HideSub();

                    break;


                case "BookingUpdate":

                    panelBookingUpdate.Location = new Point(3, 165);
                    panelBookingUpdate.BringToFront();
                    enablingTextBoxes();
                    CellContentChecking = "BookingUpdate";


                    clearing();
                    // renamin();
                    UpdatingBooking();

                    LoadSlots();

                    LoadInformationBooking();
                    TableCheck = "BookingUpdate";
                    panelMain.Visible = true;
                    //enter what to do
                    HideSub();
                    panelMain.Size = new Size(1132, 752);
                    panelMain.Location = new Point(273, 0);
                    panelMain.BringToFront();
                    btnAddDeleteUpdate.Text = "Update";
                    txtBeauty3.Visible = false;
                    txtBeauty4.Visible = false;
                    txtBeauty5.Visible = false;
                    txtBeauty1.Visible = true;
                    TableCheck = "BookingUpdate";

                    LoadIntoComboRoom();


                    txtBeauty2.Enabled = false;
                    txtBeauty5.Enabled = false;
                    txtBeauty1.Enabled = false;
                    txtBeauty1.Texts = "Booking Code";
                    cmbSlots.Text = "Time Slots";
                    cmbRoom.Text = "Rooms";

                    disablingTextBoxes();
                    cmbTreatment.Enabled = false;
                    cmbStaff.Enabled = false;
                    pctPayNow.Enabled = false;
                    pctPayLater.Enabled = false;

                    cmbTreatment.Text = "Select Treatment";
                    cmbStaff.Text = "Select Staff Member";
                    pctPayLater.Image = null;
                    pctPayNow.Image = null;


                    break;

                case "BookingDelete":
                    panelBookingUpdate.Location = new Point(3, 165);
                    panelBookingUpdate.BringToFront();
                    disablingTextBoxes();
                    CellContentChecking = "Booking";

                    cmbTreatment.Enabled = false;
                    cmbStaff.Enabled = false;
                    pctPayLater.Enabled = false;
                    pctPayNow.Enabled = false;

                    UpdatingBooking();
                    LoadInformationBooking();
                    clearing();

                    HideSub();
                    // renaming();

                    TableCheck = "BookingDelete";
                    panelMain.Visible = true;
                    //enter what to do
                    panelMain.Size = new Size(1132, 752);
                    panelMain.Location = new Point(273, 0);
                    panelMain.BringToFront();
                    btnAddDeleteUpdate.Text = "Delete";

                    txtBeauty5.Visible = false;
                    txtBeauty4.Visible = false;
                    txtBeauty3.Visible = false;
                    txtBeauty1.Visible = true;
                    txtBeauty2.Visible = true;
                    txtBeauty3.Visible = true;

                    txtBeauty2.Enabled = false;
                    txtBeauty5.Enabled = false;

                    txtBeauty1.Texts = "Booking Code";
                    cmbSlots.Text = "Time Slots";
                    cmbRoom.Text = "Rooms";

                    cmbTreatment.Text = "Treatment's";
                    pctPayNow.Image = null;
                    pctPayLater.Image = null;
                    lblPrice.Text = "";


                    HideSub();
                    break;

                case "RoomDelete":
                    disablingTextBoxes();

                    CellContentChecking = "RoomDelete";
                    PanelHiding();
                    LoadInformationRoom();
                    clearing();

                    HideSub();
                    RenamingRoom();

                    TableCheck = "RoomDelete";
                    panelMain.Visible = true;
                    //enter what to do
                    panelMain.Size = new Size(1132, 752);
                    panelMain.Location = new Point(273, 0);
                    panelMain.BringToFront();
                    btnAddDeleteUpdate.Text = "Delete";

                    txtBeauty5.Visible = false;
                    txtBeauty4.Visible = false;
                    txtBeauty3.Visible = false;
                    txtBeauty1.Visible = true;


                    txtBeauty2.Enabled = false;
                    txtBeauty5.Enabled = true;
                    HideSub();
                    break;

                case "RoomUpdate":
                    enablingTextBoxes();
                    CellContentChecking = "Room";
                    PanelHiding();

                    clearing();
                    RenamingRoom();

                    HideSub();
                    LoadInformationRoom();
                    TableCheck = "RoomUpdate";
                    panelMain.Visible = true;
                    //enter what to do
                    HideSub();
                    panelMain.Size = new Size(1132, 752);
                    panelMain.Location = new Point(273, 0);
                    panelMain.BringToFront();
                    btnAddDeleteUpdate.Text = "Update";
                    txtBeauty3.Visible = false;
                    txtBeauty4.Visible = false;
                    txtBeauty5.Visible = false;
                    txtBeauty1.Visible = true;

                    txtBeauty2.Enabled = true;
                    txtBeauty5.Enabled = true;
                    txtBeauty1.Enabled = false;

                    disablingTextBoxes();
                    break;


                case "Customer":
                    enablingTextBoxes();
                    PanelHiding();
                    txtBeauty2.Enabled = true;
                    txtBeauty5.Enabled = true;

                    CellContentChecking = "Customer";


                    //rjTextbox1.Texts = "Customer Code";
                    //rjTextbox2.Texts = "Customer Name";
                    //rjTextbox3.Texts = "Customer Surname";
                    //rjTextbox4.Texts = "Customer Email";
                    //rjTextbox5.Texts = "Customer Phone";


                    //Method to clear all textbox's
                    clearing();
                    //Method to change the text in the textbox's to all relate to the Customer, so the user knows what information to put in each textbox

                    RenamingCustomer();




                    //Calls in the method to load in the Customer Table from SQL to the datagrid view, this is to the user can see their newest Customer be added to the table
                    LoadInformationCustomer();
                    //Changes the TableCheck string to CustomerAdd so when it passes through the Switch it will call in the suitable commands
                    TableCheck = "CustomerAdd";
                    panelMain.Visible = true;
                    //Enter what to do
                    HideSub();
                    panelMain.Size = new Size(1132, 752);
                    panelMain.Location = new Point(273, 0);
                    panelMain.BringToFront();
                    btnAddDeleteUpdate.Text = "Add";
                    txtBeauty5.Visible = true;
                    txtBeauty4.Visible = true;
                    txtBeauty3.Visible = true;
                    txtBeauty1.Visible = false;



                    break;

                case "CustomerUpdate":

                    PanelHiding();
                    CellContentChecking = "Customer";

                    LoadInformationCustomer();
                    clearing();
                    RenamingCustomer();


                    TableCheck = "CustomerUpdate";

                    HideSub();
                    panelMain.Visible = true;
                    //enter what to do

                    panelMain.Size = new Size(1132, 752);
                    panelMain.Location = new Point(273, 0);
                    panelMain.BringToFront();

                    btnAddDeleteUpdate.Text = "Update";
                    txtBeauty5.Visible = true;
                    txtBeauty4.Visible = true;
                    txtBeauty1.Visible = true;

                    txtBeauty3.Visible = true;


                    txtBeauty2.Enabled = true;
                    txtBeauty5.Enabled = true;

                    txtBeauty1.Enabled = false;
                    disablingTextBoxes();





                    break;

                case "CustomerDelete":
                    PanelHiding();
                    //Changes the CellContentChecking string to Customer so when it passes through the Switch it will call in the suitable commands

                    CellContentChecking = "CustomerDelete";

                    //Calls the method to call in the Customer table in SQL and insert the fields into the data grid view
                    LoadInformationCustomer();

                    //Calls in the method to clear all the textbox's so the user can't accidentally input their data twice
                    clearing();
                    //Calls in the method to change the text in the textbox so the users what information to type in each fields
                    RenamingCustomer();


                    HideSub();
                    //Changes the TableCheck string to CustomerDelete so when it passes through the Switch it will call in the suitable commands

                    txtBeauty1.Enabled = false;

                    disablingTextBoxes();

                    TableCheck = "CustomerDelete";
                    panelMain.Visible = true;
                    //enter what to do
                    panelMain.Size = new Size(1132, 752);
                    panelMain.Location = new Point(273, 0);
                    panelMain.BringToFront();
                    btnAddDeleteUpdate.Text = "Delete";
                    txtBeauty5.Visible = true;
                    txtBeauty4.Visible = true;
                    txtBeauty3.Visible = true;
                    txtBeauty1.Visible = true;

                    break;




                case "Staff":
                    //Calls in the method to fill the data grid view from the Staff Table in SQL

                    enablingTextBoxes();
                    PanelHiding();
                    CellContentChecking = "Staff";

                    LoadInformationStaff();
                    txtBeauty5.Visible = false;
                    txtBeauty4.Visible = true;
                    txtBeauty3.Visible = true;

                    clearing();
                    RenamingStaff();

                    TableCheck = "StaffAdd";
                    panelMain.Visible = true;
                    //enter what to do
                    HideSub();
                    panelMain.Size = new Size(1132, 752);
                    panelMain.Location = new Point(273, 0);
                    panelMain.BringToFront();
                    btnAddDeleteUpdate.Text = "Add";
                    txtBeauty5.Visible = false;
                    txtBeauty4.Visible = true;
                    txtBeauty3.Visible = true;
                    txtBeauty2.Visible = true;
                    txtBeauty1.Visible = false;


                    txtBeauty2.Enabled = true;
                    txtBeauty5.Enabled = true;
                    HideSub();



                    break;

                case "Slots":
                    enablingTextBoxes();
                    PanelHiding();
                    CellContentChecking = "Slots";

                    LoadInformationSlots();
                    txtBeauty5.Visible = false;
                    txtBeauty4.Visible = false;
                    txtBeauty3.Visible = false;


                    clearing();
                    RenamingSlots();

                    TableCheck = "SlotsAdd";
                    panelMain.Visible = true;
                    //enter what to do
                    HideSub();
                    panelMain.Size = new Size(1132, 752);
                    panelMain.Location = new Point(273, 0);
                    panelMain.BringToFront();
                    btnAddDeleteUpdate.Text = "Add";
                    txtBeauty5.Visible = false;
                    txtBeauty2.Visible = true;
                    txtBeauty1.Visible = false;



                    txtBeauty2.Enabled = true;
                    txtBeauty5.Enabled = true;
                    HideSub();
                    break;


                case "Booking":
                    enablingTextBoxes();
                    CellContentChecking = "BookingDelete";


                    clearing();
                    // renamin();
                    UpdatingBooking();

                    LoadSlots();

                    LoadInformationBooking();
                    TableCheck = "BookingUpdate";
                    panelMain.Visible = true;
                    //enter what to do
                    HideSub();
                    panelMain.Size = new Size(1132, 752);
                    panelMain.Location = new Point(273, 0);
                    panelMain.BringToFront();
                    btnAddDeleteUpdate.Text = "Update";
                    txtBeauty3.Visible = false;
                    txtBeauty4.Visible = false;
                    txtBeauty5.Visible = false;
                    txtBeauty1.Visible = true;
                    TableCheck = "BookingUpdate";

                    txtBeauty2.Enabled = false;
                    txtBeauty5.Enabled = false;
                    txtBeauty1.Enabled = false;

                    break;


                case "Room":
                    enablingTextBoxes();
                    CellContentChecking = "Room";

                    PanelHiding();



                    HideSub();
                    LoadInformationRoom();
                    TableCheck = "RoomAdd";
                    panelMain.Visible = true;
                    //enter what to do
                    RenamingRoom();
                    HideSub();
                    panelMain.Size = new Size(1132, 752);
                    panelMain.Location = new Point(273, 0);
                    panelMain.BringToFront();
                    btnAddDeleteUpdate.Text = "Add";
                    txtBeauty3.Visible = false;
                    txtBeauty4.Visible = false;
                    txtBeauty5.Visible = false;
                    txtBeauty1.Visible = false;


                    txtBeauty2.Enabled = true;
                    txtBeauty5.Enabled = true;


                    break;

                case "Product":
                    enablingTextBoxes();
                    PanelHiding();
                    CellContentChecking = "Product";

                    LoadInformationProduct();
                    txtBeauty5.Visible = false;
                    txtBeauty4.Visible = false;
                    txtBeauty3.Visible = false;


                    clearing();
                    RenamingProduct();

                    TableCheck = "ProductAdd";
                    panelMain.Visible = true;
                    //enter what to do
                    HideSub();
                    panelMain.Size = new Size(1132, 752);
                    panelMain.Location = new Point(273, 0);
                    panelMain.BringToFront();
                    btnAddDeleteUpdate.Text = "Add";
                    txtBeauty5.Visible = false;
                    txtBeauty4.Visible = false;
                    txtBeauty3.Visible = true;
                    txtBeauty2.Visible = true;
                    txtBeauty1.Visible = false;

                    txtBeauty2.Enabled = true;
                    txtBeauty5.Enabled = true;

                    HideSub();

                    break;

            }
        }

        public void LoadingSlots()
        {
            ConnectionString.Connect.Close();

            ConnectionString.Connect.Open();

            Dictionary<int, string> slots = Booking.getSlots();
            //SQL command to select all the slots
            SqlCommand command = new SqlCommand("gettingBooking", ConnectionString.Connect);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@S", monthCalendarBooking.SelectionRange.Start.ToString("yyyy-MM-dd"));
            SqlDataReader read = command.ExecuteReader();

            while (read.Read())
            {
                slots.Remove(read.GetInt32(0));
            }
            cmbSlots.Items.Clear();

            foreach (object slot in slots)
            {
                cmbSlots.Items.Add(slot);
            }
            ConnectionString.Connect.Close();
            BookingDate = monthCalendarBooking.SelectionRange.Start.ToString("yyyy-MM-dd");
        }

        string CellContentChecking;

        private void frmdataGridView_Load(object sender, EventArgs e)
        {


            //Stops the user from scrolling
            PanelSelectCategory.AutoScroll = false;

            //Calls in the Switch Statement to change the design of the form, depending on what table they want to view
            LoadingShow(ClassLogin.TableS);
            this.BringToFront();

            btnCustomer.Size = new Size(267, 78);
            btnRoom.Size = new Size(267, 78);
            btnBooking.Size = new Size(267, 78);
            btnStaff.Size = new Size(267, 78);
            btnSlots.Size = new Size(267, 78);
            btnProduct.Size = new Size(267, 78);

            btnCustomerAdd.Size = new Size(267, 78);
            btnCustomerDelete.Size = new Size(267, 78);
            btnCustomerUpdate.Size = new Size(267, 78);
            btnRoomUpdate.Size = new Size(267, 78);
            btnRoomDelete.Size = new Size(267, 78);
            btnRoomAdd.Size = new Size(267, 78);
            btnBookingUpdate.Size = new Size(267, 78);
            btnBookingDelete.Size = new Size(267, 78);
            btnBookingAdd.Size = new Size(267, 78);
            btnStaffUpdate.Size = new Size(267, 78);
            btnStaffDelete.Size = new Size(267, 78);
            btnStaffAdd.Size = new Size(267, 78);
            btnSlotsUpdate.Size = new Size(267, 78);
            btnSlotsDelete.Size = new Size(267, 78);
            btnSlotsAdd.Size = new Size(267, 78);
            btnProductUpdate.Size = new Size(267, 78);
            btnProductDelete.Size = new Size(267, 78);
            btnProductAdd.Size = new Size(267, 78);


            panelCustomer.Size = new Size(267, 234);
            panelRoom.Size = new Size(267, 234);
            panelBooking.Size = new Size(267, 234);
            panelStaff.Size = new Size(267, 234);
            panellast.Size = new Size(267, 234);
            panelProduct.Size = new Size(267, 234);

            panelMain.Show();

        }

        //Method to Call in the Customer Table from SQL and fill the data grid view, with the details in the table
        void LoadInformationCustomer()
        {
            DataTable datatable = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter("CustomerShow", ConnectionString.Connect);
            adapt.Fill(datatable);
            dataGridViewBeautyCosmetics.DataSource = datatable;
        }




        void SelectCustomerNumber()
        {
            ConnectionString.Connect.Close();


            SqlCommand command = new SqlCommand("SelectCustomerCode", ConnectionString.Connect);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@CustomerNameSurname", cmbNameSurname.Text);
            ConnectionString.Connect.Close();

            ConnectionString.Connect.Open();
            var customerNo = command.ExecuteScalar().ToString();
            lblCustomerNumber.Text = customerNo;
            ConnectionString.Connect.Close();
        }

        string RoomNumber;
        void SelectRoomNumber()
        {
            ConnectionString.Connect.Close();



            SqlCommand command = new SqlCommand("SelectRoomCode", ConnectionString.Connect);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@RoomCode", cmbRoom.Text);

            ConnectionString.Connect.Close();

            ConnectionString.Connect.Open();
            var customerNo = command.ExecuteScalar().ToString();
            lblRoom.Text = customerNo;
            RoomNumber = lblRoom.Text;
            ConnectionString.Connect.Close();
        }

        //Method to Call in the Room Table from SQL and fill the data grid view, with the details in the table

        void LoadInformationRoom()
        {
            DataTable datatable = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter("RoomShow", ConnectionString.Connect);
            adapt.Fill(datatable);
            dataGridViewBeautyCosmetics.DataSource = datatable;
        }

        //Method to Call in the Staff Table from SQL and fill the data grid view, with the details in the table

        void LoadInformationStaff()
        {
            DataTable datatable = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter("StaffShow", ConnectionString.Connect);
            adapt.Fill(datatable);
            dataGridViewBeautyCosmetics.DataSource = datatable;
        }

        //Method to Call in the Slots Table from SQL and fill the data grid view, with the details in the table

        void LoadInformationSlots()
        {
            DataTable datatable = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter("SlotsShow", ConnectionString.Connect);
            adapt.Fill(datatable);

            dataGridViewBeautyCosmetics.DataSource = datatable;
        }
        //Method to Call in the Booking Table from SQL and fill the data grid view, with the details in the table







        void LoadIntoComboCustomer()
        {
            ConnectionString.Connect.Close();

            ConnectionString.Connect.Open();
            SqlCommand s = new SqlCommand("SELECT (CustomerNameSurname) from Customer ", ConnectionString.Connect);
            SqlDataReader read;
            read = s.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("CustomerNameSurname", typeof(string));
            dt.Load(read);
            cmbNameSurname.ValueMember = "CustomerNameSurname";
            cmbNameSurname.DataSource = dt;
            ConnectionString.Connect.Close();



        }

        void LoadIntoComboStaff()
        {
            ConnectionString.Connect.Close();

            ConnectionString.Connect.Open();
            SqlCommand s = new SqlCommand("SELECT (StaffForename) from Staff ", ConnectionString.Connect);
            SqlDataReader read;
            read = s.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("StaffForename", typeof(string));
            dt.Load(read);
            cmbStaff.ValueMember = "StaffForename";
            cmbStaff.DataSource = dt;
            ConnectionString.Connect.Close();



        }




        void LoadIntoComboRoom()
        {
            ConnectionString.Connect.Close();

            ConnectionString.Connect.Open();
            SqlCommand s = new SqlCommand("SELECT (RoomDescription) from Room ", ConnectionString.Connect);
            SqlDataReader read;
            read = s.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("RoomDescription", typeof(string));
            dt.Load(read);
            cmbRoom.ValueMember = "RoomDescription";
            cmbRoom.DataSource = dt;
            ConnectionString.Connect.Close();



        }


        void LoadInformationBooking()
        {
          
            DataTable datatable = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter("bookingShow1", ConnectionString.Connect);
            adapt.Fill(datatable);
            dataGridViewBeautyCosmetics.DataSource = datatable;
        }


        //Method to Call in the Product Table from SQL and fill the data grid view, with the details in the table

        void LoadInformationProduct()
        {
            DataTable datatable = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter("ProductShow", ConnectionString.Connect);
            adapt.Fill(datatable);
            dataGridViewBeautyCosmetics.DataSource = datatable;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void btmMedia_Click(object sender, EventArgs e)
        {
            ShowSub(panelCustomer);
        }


        //Method to change the text in the textbox's to all relate to the customer, so the user knows what information to put in each textbox
        public void RenamingCustomer()
        {
            txtBeauty1.Texts = "Customer Code";
            txtBeauty2.Texts = "Customer Name";
            txtBeauty3.Texts = "Customer Surname";
            txtBeauty4.Texts = "Customer Email";
            txtBeauty5.Texts = "Customer Phone";

        }
        //Method to change the text in the textbox's to all relate to the Product, so the user knows what information to put in each textbox

        public void RenamingProduct()
        {
            txtBeauty1.Texts = "Product Code";
            txtBeauty2.Texts = "Product Name";
            txtBeauty3.Texts = "Product Price";



        }
        //Method to change the text in the textbox's to all relate to the Staff, so the user knows what information to put in each textbox

        public void RenamingStaff()
        {
            txtBeauty1.Texts = "Staff Code";
            txtBeauty2.Texts = "Staff Name";
            txtBeauty3.Texts = "Staff Surname";
            txtBeauty4.Texts = "Staff Contract";

        }
        //Method to change the text in the textbox's to all relate to the Slots, so the user knows what information to put in each textbox

        public void RenamingSlots()
        {
            txtBeauty1.Texts = "Slots Code";
            txtBeauty2.Texts = "Booking Slot";


        }
        //Method to change the text in the textbox's to all relate to the Room, so the user knows what information to put in each textbox

        public void RenamingRoom()
        {
            txtBeauty1.Texts = "Room Code";
            txtBeauty2.Texts = "Room Description";


        }



        private void button2_Click(object sender, EventArgs e)
        {
            enablingTextBoxes();
            PanelHiding();
            txtBeauty2.Enabled = true;
            txtBeauty5.Enabled = true;

            CellContentChecking = "Customer";


            //rjTextbox1.Texts = "Customer Code";
            //rjTextbox2.Texts = "Customer Name";
            //rjTextbox3.Texts = "Customer Surname";
            //rjTextbox4.Texts = "Customer Email";
            //rjTextbox5.Texts = "Customer Phone";


            //Method to clear all textbox's
            clearing();
            //Method to change the text in the textbox's to all relate to the Customer, so the user knows what information to put in each textbox

            RenamingCustomer();




            //Calls in the method to load in the Customer Table from SQL to the datagrid view, this is to the user can see their newest Customer be added to the table
            LoadInformationCustomer();
            //Changes the TableCheck string to CustomerAdd so when it passes through the Switch it will call in the suitable commands
            TableCheck = "CustomerAdd";
            panelMain.Visible = true;
            //Enter what to do
            HideSub();
            panelMain.Size = new Size(1132, 752);
            panelMain.Location = new Point(273, 0);
            panelMain.BringToFront();
            btnAddDeleteUpdate.Text = "Add";
            txtBeauty5.Visible = true;
            txtBeauty4.Visible = true;
            txtBeauty3.Visible = true;
            txtBeauty1.Visible = false;




        }

        public void disablingTextBoxes()
        {
            txtBeauty1.Enabled = false;
            txtBeauty2.Enabled = false;
            txtBeauty3.Enabled = false;
            txtBeauty4.Enabled = false;
            txtBeauty5.Enabled = false;

            monthCalendarBooking.Enabled = false;
            cmbSlots.Enabled = false;
            cmbRoom.Enabled = false;


        }

        public void enablingTextBoxes()
        {
            txtBeauty1.Enabled = true;
            txtBeauty2.Enabled = true;
            txtBeauty3.Enabled = true;
            txtBeauty4.Enabled = true;
            txtBeauty5.Enabled = true;

            monthCalendarBooking.Enabled = true;
            cmbSlots.Enabled = true;
            cmbRoom.Enabled = true;
            cmbTreatment.Enabled = true;
            cmbStaff.Enabled = true;
         


        }




        private void button3_Click(object sender, EventArgs e)
        {
            PanelHiding();
            //Changes the CellContentChecking string to Customer so when it passes through the Switch it will call in the suitable commands

            CellContentChecking = "CustomerDelete";

            //Calls the method to call in the Customer table in SQL and insert the fields into the data grid view
            LoadInformationCustomer();

            //Calls in the method to clear all the textbox's so the user can't accidentally input their data twice
            clearing();
            //Calls in the method to change the text in the textbox so the users what information to type in each fields
            RenamingCustomer();


            HideSub();
            //Changes the TableCheck string to CustomerDelete so when it passes through the Switch it will call in the suitable commands

            txtBeauty1.Enabled = false;

            disablingTextBoxes();

            TableCheck = "CustomerDelete";
            panelMain.Visible = true;
            //enter what to do
            panelMain.Size = new Size(1132, 752);
            panelMain.Location = new Point(273, 0);
            panelMain.BringToFront();
            btnAddDeleteUpdate.Text = "Delete";
            txtBeauty5.Visible = true;
            txtBeauty4.Visible = true;
            txtBeauty3.Visible = true;
            txtBeauty1.Visible = true;









        }


        private void button4_Click(object sender, EventArgs e)
        {
            PanelHiding();
            CellContentChecking = "Customer";

            LoadInformationCustomer();
            clearing();
            RenamingCustomer();


            TableCheck = "CustomerUpdate";

            HideSub();
            panelMain.Visible = true;
            //enter what to do

            panelMain.Size = new Size(1132, 752);
            panelMain.Location = new Point(273, 0);
            panelMain.BringToFront();

            btnAddDeleteUpdate.Text = "Update";
            txtBeauty5.Visible = true;
            txtBeauty4.Visible = true;
            txtBeauty1.Visible = true;

            txtBeauty3.Visible = true;


            txtBeauty2.Enabled = true;
            txtBeauty5.Enabled = true;

            txtBeauty1.Enabled = false;
            disablingTextBoxes();


        }


        public void PanelHiding()
        {

            panelBookinginformation.Size = new Size(44, 53);
            panelBookinginformation.Location = new Point(1060, 146);
            panelBookinginformation.SendToBack();
            panelBookinginformation.Visible = false;


        }
        private void button1_Click(object sender, EventArgs e)
        {
            ShowSub(panelRoom);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            enablingTextBoxes();
            CellContentChecking = "Room";

            PanelHiding();



            HideSub();
            LoadInformationRoom();
            TableCheck = "RoomAdd";
            panelMain.Visible = true;
            //enter what to do
            RenamingRoom();
            HideSub();
            panelMain.Size = new Size(1132, 752);
            panelMain.Location = new Point(273, 0);
            panelMain.BringToFront();
            btnAddDeleteUpdate.Text = "Add";
            txtBeauty3.Visible = false;
            txtBeauty4.Visible = false;
            txtBeauty5.Visible = false;
            txtBeauty1.Visible = false;


            txtBeauty2.Enabled = true;
            txtBeauty5.Enabled = true;

        }

        private void button8_Click(object sender, EventArgs e)
        {
            disablingTextBoxes();

            CellContentChecking = "RoomDelete";
            PanelHiding();
            LoadInformationRoom();
            clearing();

            HideSub();
            RenamingRoom();

            TableCheck = "RoomDelete";
            panelMain.Visible = true;
            //enter what to do
            panelMain.Size = new Size(1132, 752);
            panelMain.Location = new Point(273, 0);
            panelMain.BringToFront();
            btnAddDeleteUpdate.Text = "Delete";

            txtBeauty5.Visible = false;
            txtBeauty4.Visible = false;
            txtBeauty3.Visible = false;
            txtBeauty1.Visible = true;


            txtBeauty2.Enabled = false;
            txtBeauty5.Enabled = true;
            HideSub();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            enablingTextBoxes();
            CellContentChecking = "Room";
            PanelHiding();

            clearing();
            RenamingRoom();

            HideSub();
            LoadInformationRoom();
            TableCheck = "RoomUpdate";
            panelMain.Visible = true;
            //enter what to do
            HideSub();
            panelMain.Size = new Size(1132, 752);
            panelMain.Location = new Point(273, 0);
            panelMain.BringToFront();
            btnAddDeleteUpdate.Text = "Update";
            txtBeauty3.Visible = false;
            txtBeauty4.Visible = false;
            txtBeauty5.Visible = false;
            txtBeauty1.Visible = true;

            txtBeauty2.Enabled = true;
            txtBeauty5.Enabled = true;
            txtBeauty1.Enabled = false;

            disablingTextBoxes();


        }




        private void btnequaliser_Click(object sender, EventArgs e)
        {
            ShowSub(panelBooking);

        }


        //Method to call in the SQL procedure to load in the slots
        public void LoadSlots()
        {
            ConnectionString.Connect.Close();

            ConnectionString.Connect.Open();

            Dictionary<int, string> slots = Booking.getSlots();
            //SQL command to select all the slots
            SqlCommand command = new SqlCommand("gettingBooking", ConnectionString.Connect);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@S", monthCalendarBooking.SelectionRange.Start.ToString("yyyy/MM/dd"));
            SqlDataReader read = command.ExecuteReader();

            while (read.Read())
            {
                slots.Remove(read.GetInt32(0));
            }
            cmbSlots.Items.Clear();

            foreach (object slot in slots)
            {
                cmbSlots.Items.Add(slot);
            }
            ConnectionString.Connect.Close();
        }




        public void LoadRoomDescription()
        {
            ConnectionString.Connect.Close();

            ConnectionString.Connect.Open();

            Dictionary<int, string> room = Room.getRoom();
            //SQL command to select all the slots
            SqlCommand command = new SqlCommand("gettingRoomDescription", ConnectionString.Connect);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader read = command.ExecuteReader();

            while (read.Read())
            {
                room.Remove(read.GetInt32(0));
            }
            cmbSlots.Items.Clear();

            foreach (object Room in room)
            {
                cmbSlots.Items.Add(room);
            }
            ConnectionString.Connect.Close();


        }






        private void button14_Click(object sender, EventArgs e)
        {


            frmBooking a = new frmBooking();
            this.Hide();
            a.Show();





            //lblPrice.Text = "";
            //enablingTextBoxes();

            ////Calls in the method to load in the slots




            ////Changes the CellContentChecking string to Booking so when it passes through the Switch it will call in the suitable commands

            //CellContentChecking = "Booking";

            ////Calls in the method to clear all the textbox's
            //clearing();


            //HideSub();

            ////Calls in the method to load the Booking table from SQL into the datagrid view
            //LoadInformationBooking();
            //TableCheck = "BookingAdd";
            //panelMain.Visible = true;
            ////enter what to do
            //// RenamingRoom();
            //HideSub();
            //panelMain.Size = new Size(1132, 752);
            //panelMain.Location = new Point(273, 0);
            //panelMain.BringToFront();
            //btnAddDeleteUpdate.Text = "Add";
            //txtBeauty3.Visible = true;
            //txtBeauty4.Visible = true;
            //txtBeauty5.Visible = true;
            //txtBeauty1.Visible = true;


            //panelBookinginformation.Visible = true;
            //LoadIntoComboCustomer();
            //LoadIntoComboStaff();
            //LoadIntoComboRoom();
            //LoadSlots();
            //cmbNameSurname.Text = "Select Customer";
            //cmbRoom.Text = "Select Room";
            //cmbSlots.Text = "Check Available Time Slots";

            //panelBookinginformation.Location = new Point(33, 335);
            //panelBookinginformation.Size = new Size(362, 407);
            //panelBookinginformation.BringToFront();


            //txtBeauty2.Enabled = true;
            //txtBeauty5.Enabled = true;

            //cmbTreatment.Text = "Select Treatment";
            //cmbStaff.Text = "Select Staff Member";
            //pctPayLater.Image = null;
            //pctPayNow.Image = null;

        }

        private void button13_Click(object sender, EventArgs e)
        {
            panelBookingUpdate.Location = new Point(3, 165);
            panelBookingUpdate.BringToFront();
            disablingTextBoxes();
            CellContentChecking = "Booking";

            cmbTreatment.Enabled = false;
            cmbStaff.Enabled = false;
            pctPayLater.Enabled = false;
            pctPayNow.Enabled = false;

            UpdatingBooking();
            LoadInformationBooking();
            clearing();

            HideSub();
            // renaming();

            TableCheck = "BookingDelete";
            panelMain.Visible = true;
            //enter what to do
            panelMain.Size = new Size(1132, 752);
            panelMain.Location = new Point(273, 0);
            panelMain.BringToFront();
            btnAddDeleteUpdate.Text = "Delete";

            txtBeauty5.Visible = false;
            txtBeauty4.Visible = false;
            txtBeauty3.Visible = false;
            txtBeauty1.Visible = true;
            txtBeauty2.Visible = true;
            txtBeauty3.Visible = true;

            txtBeauty2.Enabled = false;
            txtBeauty5.Enabled = false;

            txtBeauty1.Texts = "Booking Code";
            cmbSlots.Text = "Time Slots";
            cmbRoom.Text = "Rooms";

            cmbTreatment.Text = "Treatment's";
            pctPayNow.Image = null;
            pctPayLater.Image = null;
            lblPrice.Text = "";

            lblPayNow.Visible = false;

            HideSub();

        }

        public void UpdatingBooking()
        {
            panelBookinginformation.BringToFront();
            panelBookinginformation.Visible = true;
            panelBookinginformation.Size = new Size(362, 407);
            panelBookinginformation.Location = new Point(34, 398);
            cmbNameSurname.Visible = false;


        }

        private void button12_Click(object sender, EventArgs e)
        {
            panelBookingUpdate.Location = new Point(3, 165);
            panelBookingUpdate.BringToFront();
            enablingTextBoxes();
            CellContentChecking = "BookingUpdate";

            cmbStaff.Enabled = false;
            label2.ForeColor = Color.WhiteSmoke;

            clearing();
            // renamin();
            UpdatingBooking();

            LoadSlots();

            LoadInformationBooking();
            TableCheck = "BookingUpdate";
            panelMain.Visible = true;
            //enter what to do
            HideSub();
            panelMain.Size = new Size(1132, 752);
            panelMain.Location = new Point(273, 0);
            panelMain.BringToFront();
            btnAddDeleteUpdate.Text = "Update";
            txtBeauty3.Visible = false;
            txtBeauty4.Visible = false;
            txtBeauty5.Visible = false;
            txtBeauty1.Visible = true;
            TableCheck = "BookingUpdate";

            LoadIntoComboRoom();


            txtBeauty2.Enabled = false;
            txtBeauty5.Enabled = false;
            txtBeauty1.Enabled = false;
            txtBeauty1.Texts = "Booking Code";
            cmbSlots.Text = "Time Slots";
            cmbRoom.Text = "Rooms";

            disablingTextBoxes();
            cmbTreatment.Enabled = false;
           // cmbStaff.Enabled = false;
            pctPayNow.Enabled = false;
            pctPayLater.Enabled = false;

            cmbTreatment.Text = "Treatments";
            cmbStaff.Text = "Staff Member";
            pctPayLater.Image = null;
            pctPayNow.Image = null;
            lblPrice.Text = "";


        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {
            clearing();

            HideSub();

        }

        private void button11_Click(object sender, EventArgs e)
        {
            clearing();

            HideSub();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            clearing();

            HideSub();

        }

        private void panelmusic_Click(object sender, EventArgs e)
        {
            ShowSub(panelProduct);

        }

        private void button22_Click(object sender, EventArgs e)
        {
            ShowSub(panelStaff);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            ShowSub(panellast);

        }

        private void button25_Click(object sender, EventArgs e)
        {
            HideSub();

        }

        private void button24_Click(object sender, EventArgs e)
        {
            HideSub();

        }

        private void button23_Click(object sender, EventArgs e)
        {
            HideSub();

        }

        private void button21_Click(object sender, EventArgs e)
        {
            enablingTextBoxes();
            PanelHiding();
            CellContentChecking = "Staff";

            LoadInformationStaff();
            txtBeauty5.Visible = false;
            txtBeauty4.Visible = true;
            txtBeauty3.Visible = true;

            clearing();
            RenamingStaff();

            TableCheck = "StaffAdd";
            panelMain.Visible = true;
            //enter what to do
            HideSub();
            panelMain.Size = new Size(1132, 752);
            panelMain.Location = new Point(273, 0);
            panelMain.BringToFront();
            btnAddDeleteUpdate.Text = "Add";
            txtBeauty5.Visible = false;
            txtBeauty4.Visible = true;
            txtBeauty3.Visible = true;
            txtBeauty2.Visible = true;
            txtBeauty1.Visible = false;


            txtBeauty2.Enabled = true;
            txtBeauty5.Enabled = true;
            HideSub();


        }

        private void button20_Click(object sender, EventArgs e)
        {
            disablingTextBoxes();
            PanelHiding();
            CellContentChecking = "StaffDelete";

            LoadInformationStaff();
            txtBeauty5.Visible = false;
            TableCheck = "StaffDelete";
            clearing();
            RenamingStaff();


            panelMain.Visible = true;
            //enter what to do
            HideSub();
            panelMain.Size = new Size(1132, 752);
            panelMain.Location = new Point(273, 0);
            panelMain.BringToFront();
            btnAddDeleteUpdate.Text = "Delete";
            txtBeauty5.Visible = false;
            txtBeauty4.Visible = true;
            txtBeauty3.Visible = true;
            txtBeauty2.Visible = true;
            txtBeauty1.Visible = true;

            txtBeauty2.Enabled = false;
            txtBeauty5.Enabled = true;

            HideSub();

        }

        private void button19_Click(object sender, EventArgs e)
        {
            enablingTextBoxes();
            PanelHiding();
            CellContentChecking = "Staff";

            LoadInformationStaff();
            clearing();
            RenamingStaff();
            TableCheck = "StaffUpdate";
            HideSub();
            txtBeauty5.Visible = false;



            panelMain.Visible = true;
            //enter what to do
            HideSub();
            panelMain.Size = new Size(1132, 752);
            panelMain.Location = new Point(273, 0);
            panelMain.BringToFront();
            btnAddDeleteUpdate.Text = "Update";
            txtBeauty5.Visible = false;
            txtBeauty4.Visible = true;
            txtBeauty3.Visible = true;
            txtBeauty2.Visible = true;
            txtBeauty1.Visible = true;

            txtBeauty2.Enabled = true;
            txtBeauty5.Enabled = true;
            txtBeauty1.Enabled = false;

            disablingTextBoxes();
            //enter what to do



        }

        private void button17_Click(object sender, EventArgs e)
        {
            enablingTextBoxes();
            PanelHiding();
            CellContentChecking = "Slots";

            LoadInformationSlots();
            txtBeauty5.Visible = false;
            txtBeauty4.Visible = false;
            txtBeauty3.Visible = false;


            clearing();
            RenamingSlots();

            TableCheck = "SlotsAdd";
            panelMain.Visible = true;
            //enter what to do
            HideSub();
            panelMain.Size = new Size(1132, 752);
            panelMain.Location = new Point(273, 0);
            panelMain.BringToFront();
            btnAddDeleteUpdate.Text = "Add";
            txtBeauty5.Visible = false;
            txtBeauty2.Visible = true;
            txtBeauty1.Visible = false;



            txtBeauty2.Enabled = true;
            txtBeauty5.Enabled = true;
            HideSub();

        }

        private void button16_Click(object sender, EventArgs e)
        {
            disablingTextBoxes();
            PanelHiding();
            CellContentChecking = "SlotsDelete";

            LoadInformationSlots();
            txtBeauty5.Visible = false;
            TableCheck = "SlotsDelete";
            clearing();
            RenamingSlots();


            panelMain.Visible = true;
            //enter what to do
            HideSub();
            panelMain.Size = new Size(1132, 752);
            panelMain.Location = new Point(273, 0);
            panelMain.BringToFront();
            btnAddDeleteUpdate.Text = "Delete";
            txtBeauty5.Visible = false;
            txtBeauty4.Visible = false;
            txtBeauty3.Visible = false;
            txtBeauty2.Visible = true;
            txtBeauty1.Visible = true;


            txtBeauty2.Enabled = false;
            txtBeauty5.Enabled = true;
            HideSub();

        }

        private void button10_Click(object sender, EventArgs e)
        {
            enablingTextBoxes();
            PanelHiding();
            CellContentChecking = "Slots";

            LoadInformationSlots();
            clearing();
            RenamingSlots();
            TableCheck = "SlotsUpdate";
            HideSub();
            txtBeauty5.Visible = false;
            txtBeauty4.Visible = false;
            txtBeauty3.Visible = false;

            txtBeauty2.Enabled = true;
            txtBeauty5.Enabled = true;


            panelMain.Visible = true;
            //enter what to do
            HideSub();
            panelMain.Size = new Size(1132, 752);
            panelMain.Location = new Point(273, 0);
            panelMain.BringToFront();
            btnAddDeleteUpdate.Text = "Update";
            txtBeauty5.Visible = false;

            txtBeauty2.Visible = true;
            txtBeauty1.Visible = true;

            HideSub();
            txtBeauty1.Enabled = false;

            disablingTextBoxes();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            ShowSub(panelProduct);

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }



        private void rjButton2_Click(object sender, EventArgs e)
        {
            //A message box shows up, asking the user if they want to log out or not
            const string message =
    "Are You Sure You Want To Sign Out";
            const string caption = "Singing Out Of The System...";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.OKCancel,
                                         MessageBoxIcon.Question);




            //If they click OK, they will be returned to the login form, where they will need to log in again
            if (result == DialogResult.OK)
            {
                frmLogin a = new frmLogin();
                this.Hide();
                a.Show();
            }


        }

        private void rjTextbox1_Click(object sender, EventArgs e)
        {
            //Checks the text in the textbox and if it is equal to anthing related to Customer, Product, Staff, Slots or Room it will clear it
            if (txtBeauty1.Texts == "Customer Code" && CellContentChecking == "Customer")
            {
                txtBeauty1.Clear();
            }

            if (txtBeauty2.Texts == "" && CellContentChecking == "Customer")
            {
                txtBeauty2.Texts = "Customer Name";
            }

            if (txtBeauty3.Texts == "" && CellContentChecking == "Customer")
            {
                txtBeauty3.Texts = "Customer Surname";
            }

            if (txtBeauty4.Texts == "" && CellContentChecking == "Customer")
            {
                txtBeauty4.Texts = "Customer Email";
            }

            if (txtBeauty5.Texts == "" && CellContentChecking == "Customer")
            {
                txtBeauty5.Texts = "Customer Phone";
            }


            /////////////////////////
            ///
            if (txtBeauty1.Texts == "Staff Code" && CellContentChecking == "Staff")
            {
                txtBeauty1.Clear();
            }

            if (txtBeauty2.Texts == "" && CellContentChecking == "Staff")
            {
                txtBeauty2.Texts = "Staff Name";
            }

            if (txtBeauty3.Texts == "" && CellContentChecking == "Staff")
            {
                txtBeauty3.Texts = "Staff Surname";
            }

            if (txtBeauty4.Texts == "" && CellContentChecking == "Staff")
            {
                txtBeauty4.Texts = "Staff Contract";
            }

            //////////////////////
            ///

            if (txtBeauty1.Texts == "Room Code" && CellContentChecking == "Room")
            {
                txtBeauty1.Clear();
            }

            if (txtBeauty2.Texts == "" && CellContentChecking == "Room")
            {
                txtBeauty2.Texts = "Room Description";
            }
            ///////////////////////
            ///


        }

        public void CustomerUpdateEnable()
        {
            txtBeauty2.Enabled = true;
            txtBeauty3.Enabled = true;
            txtBeauty4.Enabled = true;
            txtBeauty5.Enabled = true;

        }



        string a;
        string b;

        string SlotText;

        string BookingDate;
        int RoomNo;
        string SlotTime;
        string Testing;
        List<int> StaffNos = new List<int>();
        string StaffNumberCell;


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {

            }
            else
            {
                void Checks(string form)
                {
                    switch (form)
                    {
                        case "Paying":


                            txtBookingCodePaying.Texts = dataGridViewBeautyCosmetics.Rows[e.RowIndex].Cells[0].Value.ToString();
                            a = dataGridViewBeautyCosmetics.Rows[e.RowIndex].Cells[1].Value.ToString();

                            b = dataGridViewBeautyCosmetics.Rows[e.RowIndex].Cells[2].Value.ToString();



                            break;

                        case "Staff":

                            txtBeauty1.Texts = dataGridViewBeautyCosmetics.Rows[e.RowIndex].Cells[0].Value.ToString();



                            txtBeauty2.Texts = dataGridViewBeautyCosmetics.Rows[e.RowIndex].Cells[1].Value.ToString();

                            txtBeauty3.Texts = dataGridViewBeautyCosmetics.Rows[e.RowIndex].Cells[2].Value.ToString();

                            txtBeauty4.Texts = dataGridViewBeautyCosmetics.Rows[e.RowIndex].Cells[3].Value.ToString();

                            CustomerUpdateEnable();

                            break;

                        case "StaffDelete":

                            txtBeauty1.Texts = dataGridViewBeautyCosmetics.Rows[e.RowIndex].Cells[0].Value.ToString();

                            txtBeauty2.Texts = dataGridViewBeautyCosmetics.Rows[e.RowIndex].Cells[1].Value.ToString();

                            txtBeauty3.Texts = dataGridViewBeautyCosmetics.Rows[e.RowIndex].Cells[2].Value.ToString();

                            txtBeauty4.Texts = dataGridViewBeautyCosmetics.Rows[e.RowIndex].Cells[3].Value.ToString();

                            break;


                        case "Customer":
                            txtBeauty1.Texts = dataGridViewBeautyCosmetics.Rows[e.RowIndex].Cells[0].Value.ToString();

                            txtBeauty2.Texts = dataGridViewBeautyCosmetics.Rows[e.RowIndex].Cells[1].Value.ToString();

                            txtBeauty3.Texts = dataGridViewBeautyCosmetics.Rows[e.RowIndex].Cells[2].Value.ToString();

                            txtBeauty4.Texts = dataGridViewBeautyCosmetics.Rows[e.RowIndex].Cells[3].Value.ToString();

                            txtBeauty5.Texts = dataGridViewBeautyCosmetics.Rows[e.RowIndex].Cells[4].Value.ToString();

                            CustomerUpdateEnable();


                            void SelectCustomerNumber2()
                            {
                                ConnectionString.Connect.Close();


                                SqlCommand command1 = new SqlCommand("SelectCustomerNumber", ConnectionString.Connect);
                                command1.CommandType = CommandType.StoredProcedure;
                                command1.Parameters.AddWithValue("@CustomerCode", dataGridViewBeautyCosmetics.Rows[e.RowIndex].Cells[0].Value.ToString());

                                ConnectionString.Connect.Open();
                                var customerNo = command1.ExecuteScalar().ToString();
                                lblCustomerNumber2.Text = customerNo;
                                ConnectionString.Connect.Close();
                            }

                            SelectCustomerNumber2();







                            break;

                        case "CustomerDelete":

                            txtBeauty1.Texts = dataGridViewBeautyCosmetics.Rows[e.RowIndex].Cells[0].Value.ToString();

                            txtBeauty2.Texts = dataGridViewBeautyCosmetics.Rows[e.RowIndex].Cells[1].Value.ToString();

                            txtBeauty3.Texts = dataGridViewBeautyCosmetics.Rows[e.RowIndex].Cells[2].Value.ToString();

                            txtBeauty4.Texts = dataGridViewBeautyCosmetics.Rows[e.RowIndex].Cells[3].Value.ToString();

                            txtBeauty5.Texts = dataGridViewBeautyCosmetics.Rows[e.RowIndex].Cells[4].Value.ToString();
                            break;


                        case "Room":
                            txtBeauty1.Texts = dataGridViewBeautyCosmetics.Rows[e.RowIndex].Cells[0].Value.ToString();

                            txtBeauty2.Texts = dataGridViewBeautyCosmetics.Rows[e.RowIndex].Cells[1].Value.ToString();

                            CustomerUpdateEnable();

                            break;

                        case "RoomDelete":
                            txtBeauty1.Texts = dataGridViewBeautyCosmetics.Rows[e.RowIndex].Cells[0].Value.ToString();

                            txtBeauty2.Texts = dataGridViewBeautyCosmetics.Rows[e.RowIndex].Cells[1].Value.ToString();

                            break;

                        case "Product":

                            txtBeauty1.Texts = dataGridViewBeautyCosmetics.Rows[e.RowIndex].Cells[0].Value.ToString();

                            txtBeauty2.Texts = dataGridViewBeautyCosmetics.Rows[e.RowIndex].Cells[1].Value.ToString();

                            txtBeauty3.Texts = dataGridViewBeautyCosmetics.Rows[e.RowIndex].Cells[2].Value.ToString();

                            CustomerUpdateEnable();

                            break;

                        case "ProductDelete":

                            txtBeauty1.Texts = dataGridViewBeautyCosmetics.Rows[e.RowIndex].Cells[0].Value.ToString();

                            txtBeauty2.Texts = dataGridViewBeautyCosmetics.Rows[e.RowIndex].Cells[1].Value.ToString();

                            txtBeauty3.Texts = dataGridViewBeautyCosmetics.Rows[e.RowIndex].Cells[2].Value.ToString();


                            break;

                        case "Slots":

                            txtBeauty1.Texts = dataGridViewBeautyCosmetics.Rows[e.RowIndex].Cells[0].Value.ToString();

                            txtBeauty2.Texts = dataGridViewBeautyCosmetics.Rows[e.RowIndex].Cells[1].Value.ToString();

                            CustomerUpdateEnable();

                            break;

                        case "SlotsDelete":

                            txtBeauty1.Texts = dataGridViewBeautyCosmetics.Rows[e.RowIndex].Cells[0].Value.ToString();

                            txtBeauty2.Texts = dataGridViewBeautyCosmetics.Rows[e.RowIndex].Cells[1].Value.ToString();



                            break;

                        case "Booking":

                            // add other fields after

                            txtBeauty1.Texts = dataGridViewBeautyCosmetics.Rows[e.RowIndex].Cells[0].Value.ToString();
                            DateTime dtaa = (DateTime)dataGridViewBeautyCosmetics.Rows[e.RowIndex].Cells[1].Value;
                            monthCalendarBooking.SetDate(dtaa);
                            cmbSlots.Text = dataGridViewBeautyCosmetics.Rows[e.RowIndex].Cells[7].Value.ToString();
                            cmbRoom.Text = dataGridViewBeautyCosmetics.Rows[e.RowIndex].Cells[8].Value.ToString();
                            cmbTreatment.Text = dataGridViewBeautyCosmetics.Rows[e.RowIndex].Cells[9].Value.ToString();
                            Paid = dataGridViewBeautyCosmetics.Rows[e.RowIndex].Cells[10].Value.ToString();
                            cmbStaff.Text = dataGridViewBeautyCosmetics.Rows[e.RowIndex].Cells[5].Value.ToString();


                            if (Paid == "No")
                            {
                                Picture = "Not";
                                pctPayLater.Image = Properties.Resources.check_mark_tick_vector_graphic_21;
                                pctPayNow.Image = null;
                                lblPayNow.Visible = false;

                            }
                            else
                            {
                                if (Paid == "Yes")
                                {
                                    Picture = "Paid";
                                    pctPayNow.Image = Properties.Resources.check_mark_tick_vector_graphic_21;
                                    pctPayLater.Image = null;
                                    lblPayNow.Visible = false;

                                }
                            }

                            switch (dataGridViewBeautyCosmetics.Rows[e.RowIndex].Cells[9].Value.ToString())
                            {
                                case "Acrylics":

                                    lblPrice.Text = "£20";
                                    break;

                                case "Manicure":
                                    lblPrice.Text = "£15";

                                    break;

                                case "Basic Polish":
                                    lblPrice.Text = "£10";


                                    break;

                                case "Dip Powder":
                                    lblPrice.Text = "£25";


                                    break;

                                case "Nail Gel":
                                    lblPrice.Text = "£20";


                                    break;

                                case "Lashlift and Tint":
                                    lblPrice.Text = "£10";


                                    break;

                                case "Make Up":
                                    lblPrice.Text = "£30";


                                    break;

                                case "Laser Hair Removal":
                                    lblPrice.Text = "£50";


                                    break;

                                case "Tan":
                                    lblPrice.Text = "£25";


                                    break;

                                case "Eyebrows":
                                    lblPrice.Text = "£15";


                                    break;

                            }


                            break;

                        case "BookingUpdate":

                           


                            //  LoadingSlots();

                            cmbStaff.Items.Clear();

                            Testing = dataGridViewBeautyCosmetics.Rows[e.RowIndex].Cells[7].Value.ToString();


                            void ChangingSlotText(string form1)
                            {
                                switch (form1)
                                {


                                    //Updating Customer
                                    case "9:00 - 10:00":

                                        Testing = "[1, Slot Time: 9:00AM - 10:00AM]";

                                        break;

                                    case "9:30 - 10:30":

                                        Testing = "[2, Slot Time: 9:30AM - 10:30AM]";

                                        break;

                                    case "10:00 - 11:00":

                                        Testing = "[3, Slot Time: 10:00AM - 11:00AM]";

                                        break;

                                    case "10:30 - 11:30":

                                        Testing = "[4, Slot Time: 10:30AM - 11:30AM]";

                                        break;

                                    case "11:00 - 12:00":

                                        Testing = "[5, Slot Time: 11:00AM - 12:00PM]";

                                        break;

                                    case "12:30 - 13:30":

                                        Testing = "[6, Slot Time: 12:30PM - 13:30PM]";

                                        break;

                                    case "13:00 - 14:00":

                                        Testing = "[7, Slot Time: 13:00PM - 14:00PM]";

                                        break;

                                    case "13:30 - 14:30":

                                        Testing = "[8, Slot Time: 13:30PM - 14:30PM]";

                                        break;

                                    case "14:00 - 15:00":

                                        Testing = "[9, Slot Time: 14:00PM - 15:00PM]";

                                        break;

                                    case "14:30 - 15:30":

                                        Testing = "[10, Slot Time: 14:30PM - 15:30PM]";

                                        break;

                                    case "15:00 - 16:00":

                                        Testing = "[11, Slot Time: 15:00PM - 16:00PM]";

                                        break;

                                    case "15:30 - 16:30":

                                        Testing = "[12, Slot Time: 15:30PM - 16:30PM]";

                                        break;

                                    case "16:00 - 17:00":

                                        Testing = "[13, Slot Time: 16:00PM - 17:00PM]";

                                        break;

                                    case "16:30 - 17:30":

                                        Testing = "[14, Slot Time: 16:30PM - 17:30PM]";

                                        break;

                                    case "17:00 - 18:00":

                                        Testing = "[15, Slot Time: 17:00PM - 18:00PM]";

                                        break;

                                    case "17:30 - 18:30":

                                        Testing = "[16, Slot Time: 17:30PM - 18:30PM]";

                                        break;

                                    case "18:00 - 19:00":

                                        Testing = "[17, Slot Time: 18:00PM - 19:00PM]";

                                        break;


                                    case "18:30 - 19:30":

                                        Testing = "[18, Slot Time: 18:30PM - 19:30PM]";

                                        break;

                                    case "19:00 - 20:00":

                                        Testing = "[19, Slot Time: 19:00PM - 20:00PM]";

                                        break;

                                    case "19:30 - 20:30":

                                        Testing = "[20, Slot Time: 19:30PM - 20:30PM]";

                                        break;

                                    case "20:00 - 21:00":

                                        Testing = "[21, Slot Time: 20:00PM - 21:00PM]";

                                        break;

                                }
                            }

                            ChangingSlotText(Testing);

                            ConnectionString.Connect.Close();
                            txtBeauty1.Texts = dataGridViewBeautyCosmetics.Rows[e.RowIndex].Cells[0].Value.ToString();
                            DateTime dtaaa = (DateTime)dataGridViewBeautyCosmetics.Rows[e.RowIndex].Cells[1].Value;
                            monthCalendarBooking.SetDate(dtaaa);

                            ConnectionString.Connect.Close();
                            ConnectionString.Connect.Open();

                            SqlCommand command12 = new SqlCommand("GetStaffNumber", ConnectionString.Connect);
                            command12.CommandType = CommandType.StoredProcedure;
                            command12.Parameters.AddWithValue("@Staff", dataGridViewBeautyCosmetics.Rows[e.RowIndex].Cells[5].Value.ToString());
                            var StaffNumber = command12.ExecuteScalar().ToString();
                            StaffNumberCell = StaffNumber;

                            ConnectionString.Connect.Close();

                            cmbStaff.Text = StaffNumberCell + ":" + dataGridViewBeautyCosmetics.Rows[e.RowIndex].Cells[5].Value.ToString();



                            //cmbStaff.Text = dataGridViewBeautyCosmetics.Rows[e.RowIndex].Cells[5].Value.ToString();

                            //////////////////////////////////////////// 
                            //cmbSlots.Text = dataGridViewBeautyCosmetics.Rows[e.RowIndex].Cells[7].Value.ToString();
                            cmbSlots.Text = Testing;



                            //////////////////////////////////////////
                            cmbRoom.Text = dataGridViewBeautyCosmetics.Rows[e.RowIndex].Cells[8].Value.ToString();
                            cmbTreatment.Text = dataGridViewBeautyCosmetics.Rows[e.RowIndex].Cells[9].Value.ToString();
                            Paid = dataGridViewBeautyCosmetics.Rows[e.RowIndex].Cells[10].Value.ToString();

                            if (Paid == "No")
                            {
                                Picture = "Not";
                                pctPayLater.Image = Properties.Resources.check_mark_tick_vector_graphic_21;
                                pctPayNow.Image = null;
                                lblPayNow.Visible = true;

                            }
                            else
                            {
                                if (Paid == "Yes")
                                {
                                    Picture = "Paid";
                                    pctPayNow.Image = Properties.Resources.check_mark_tick_vector_graphic_21;
                                    pctPayLater.Image = null;
                                    lblPayNow.Visible = false;

                                }
                            }


                            void SelectSlotNumber()
                            {
                                ConnectionString.Connect.Close();


                                SqlCommand command1 = new SqlCommand("GetSlotTime", ConnectionString.Connect);
                                command1.CommandType = CommandType.StoredProcedure;
                                command1.Parameters.AddWithValue("@time", dataGridViewBeautyCosmetics.Rows[e.RowIndex].Cells[7].Value.ToString());

                                ConnectionString.Connect.Open();
                                var customerNo = command1.ExecuteScalar().ToString();
                                SlotTime = customerNo;
                                ConnectionString.Connect.Close();
                            }

                            SelectSlotNumber();


                            void LoadSlots1()
                            {
                                ConnectionString.Connect.Close();

                                ConnectionString.Connect.Open();

                                Dictionary<int, string> slots = Booking.getSlots();
                                //SQL command to select all the slots
                                SqlCommand command111 = new SqlCommand("gettingBooking", ConnectionString.Connect);
                                command111.CommandType = CommandType.StoredProcedure;
                                command111.Parameters.AddWithValue("@S", monthCalendarBooking.SelectionStart.ToString("yyyy/MM/dd"));
                                SqlDataReader read1 = command111.ExecuteReader();

                                while (read1.Read())
                                {
                                    slots.Remove(read1.GetInt32(0));
                                }
                                cmbSlots.Items.Clear();

                                foreach (object slot in slots)
                                {
                                    cmbSlots.Items.Add(slot);
                                }
                                ConnectionString.Connect.Close();
                                BookingDate = monthCalendarBooking.SelectionStart.ToString("yyyy/MM/dd");
                            }

                            LoadSlots1();


                            cmbStaff.Items.Clear();


                            ////////////////////////////////////////////////////////////////////////////
                            SqlCommand commandGetStaff = new SqlCommand("SELECT * FROM Staff", ConnectionString.Connect);

                            ConnectionString.Connect.Close();
                            ConnectionString.Connect.Open();
                            SqlDataReader readStaff = commandGetStaff.ExecuteReader();
                            while (readStaff.Read())
                            {
                                if (!(StaffNos.Contains(Convert.ToInt32(readStaff["StaffNumber"].ToString()))))
                                {
                                    string staff = readStaff["StaffNumber"].ToString() + ":" + readStaff["StaffSurname"].ToString();
                                    cmbStaff.Items.Add(staff);
                                }

                            }

                            //////////////////////////////////////////////////////////////////////////////////
                            enablingTextBoxes();
                            txtBeauty1.Enabled = false;
                            ConnectionString.Connect.Close();




                            switch (dataGridViewBeautyCosmetics.Rows[e.RowIndex].Cells[9].Value.ToString())
                            {
                                case "Acrylics":

                                    lblPrice.Text = "£20";
                                    break;

                                case "Manicure":
                                    lblPrice.Text = "£15";

                                    break;

                                case "Basic Polish":
                                    lblPrice.Text = "£10";


                                    break;

                                case "Dip Powder":
                                    lblPrice.Text = "£25";


                                    break;

                                case "Nail Gel":
                                    lblPrice.Text = "£20";


                                    break;

                                case "Lashlift and Tint":
                                    lblPrice.Text = "£10";


                                    break;

                                case "Make Up":
                                    lblPrice.Text = "£30";


                                    break;

                                case "Laser Hair Removal":
                                    lblPrice.Text = "£50";


                                    break;

                                case "Tan":
                                    lblPrice.Text = "£25";


                                    break;

                                case "Eyebrows":
                                    lblPrice.Text = "£15";


                                    break;

                            }

                            if (monthCalendarBooking.SelectionStart.DayOfWeek == DayOfWeek.Friday)
                            {
                                cmbStaff.Items.Clear();

                                SqlCommand commandGetStaff1 = new SqlCommand("SELECT * FROM Staff WHERE StaffContract = 'Full Time'", ConnectionString.Connect);

                                ConnectionString.Connect.Close();
                                ConnectionString.Connect.Open();
                                SqlDataReader readStaff1 = commandGetStaff1.ExecuteReader();
                                while (readStaff1.Read())
                                {
                                    if (!(StaffNos1a.Contains(Convert.ToInt32(readStaff1["StaffNumber"].ToString()))))
                                    {
                                        string staff = readStaff1["StaffNumber"].ToString() + ":" + readStaff1["StaffSurname"].ToString();
                                        cmbStaff.Items.Add(staff);
                                    }
                                }
                            }


                            int aaa1;
                            string[] slotscellupdate = cmbSlots.Text.ToString().Split('[');
                            string[] slotcellupdate2 = slotscellupdate[1].Split(',');
                            aaa1 = Convert.ToInt32(slotcellupdate2[0]);

                            if (aaa1 > 10)
                            {

                                cmbStaff.Items.Clear();

                                SqlCommand commandGetStaff12 = new SqlCommand("SELECT * FROM Staff WHERE StaffContract = 'Full Time'", ConnectionString.Connect);

                                ConnectionString.Connect.Close();
                                ConnectionString.Connect.Open();
                                SqlDataReader readStaff12 = commandGetStaff12.ExecuteReader();
                                while (readStaff12.Read())
                                {
                                    if (!(StaffNos1a.Contains(Convert.ToInt32(readStaff12["StaffNumber"].ToString()))))
                                    {
                                        string staff111 = readStaff12["StaffNumber"].ToString() + ":" + readStaff12["StaffSurname"].ToString();
                                        cmbStaff.Items.Add(staff111);
                                    }

                                }

                            }

                            break;

                    }
                }





                Checks(CellContentChecking);


            }
            //textbox.Add(rjTextbox1);
            //textbox.Add(rjTextbox2);
            //textbox.Add(rjTextbox3);
            //textbox.Add(rjTextbox4);
            //textbox.Add(rjTextbox5);

            //string[] columnname = new string[] { "Code", "name","surname", "phone", "email" };


            //for (int i = 0; i < 5; i++)
            //{
            //    textbox[i].Texts = columnname[i];

            //}





        }

        List<int> StaffNosa = new List<int>();
        List<int> StaffNos1a = new List<int>();

        public void clearing()
        {
            txtBeauty1.Clear();
            txtBeauty2.Clear();
            txtBeauty3.Clear();
            txtBeauty4.Clear();
            txtBeauty5.Clear();
        }


     




        void DisplayStaffAvailable()
        {
            ConnectionString.Connect.Close();

            ConnectionString.Connect.Open();

            SqlCommand command = new SqlCommand("[ShowStaffThatsAvailable]", ConnectionString.Connect);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@a", lblStaffAvailable.Text);

            var StaffAvailable = command.ExecuteScalar();

            DataTable dt = new DataTable();
            dt.Rows.Add(StaffAvailable);

            cmbStaff.DataSource = dt;
            cmbStaff.DisplayMember = "StaffForename";
            cmbStaff.Items.Add(dt);



            ConnectionString.Connect.Close();
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {

            WhatToDo(TableCheck);

        }

        private void rjButton3_Click(object sender, EventArgs e)
        {
        }

        private void rjTextbox1__TextChanged(object sender, EventArgs e)
        {

        }

        private void panelplaylist_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rjTextbox2_Click(object sender, EventArgs e)
        {
            if (txtBeauty2.Texts == "Customer Name")
            {
                txtBeauty2.Clear();
            }

            if (txtBeauty1.Texts == "" && CellContentChecking == "Customer")
            {
                txtBeauty1.Texts = "Customer Code";
            }

            if (txtBeauty3.Texts == "" && CellContentChecking == "Customer")
            {
                txtBeauty3.Texts = "Customer Surname";
            }

            if (txtBeauty4.Texts == "" && CellContentChecking == "Customer")
            {
                txtBeauty4.Texts = "Customer Email";
            }

            if (txtBeauty5.Texts == "" && CellContentChecking == "Customer")
            {
                txtBeauty5.Texts = "Customer Phone";
            }



            ///////////////////////////
            ///
            if (txtBeauty2.Texts == "Staff Name")
            {
                txtBeauty2.Clear();
            }

            if (txtBeauty1.Texts == "" && CellContentChecking == "Staff")
            {
                txtBeauty1.Texts = "Staff Code";
            }

            if (txtBeauty3.Texts == "" && CellContentChecking == "Staff")
            {
                txtBeauty3.Texts = "Staff Surname";
            }

            if (txtBeauty4.Texts == "" && CellContentChecking == "Staff")
            {
                txtBeauty4.Texts = "Staff Contract";
            }

            /////////////////////
            ///
            if (txtBeauty2.Texts == "Room Description" && CellContentChecking == "Room")
            {
                txtBeauty2.Clear();
            }

            if (txtBeauty1.Texts == "" && CellContentChecking == "Room")
            {
                txtBeauty1.Texts = "Room Code";
            }

            //////////////////
            ///

            if (txtBeauty2.Texts == "Product Name")
            {
                txtBeauty2.Clear();
            }

            if (txtBeauty3.Texts == "" && CellContentChecking == "Product")
            {
                txtBeauty3.Texts = "Product Price";
            }

            if (txtBeauty1.Texts == "" && CellContentChecking == "Product")
            {
                txtBeauty1.Texts = "Product Code";
            }

            ////////////////////////////////////////////////////
            ///
            if (txtBeauty1.Texts == "" && CellContentChecking == "Slots")
            {
                txtBeauty1.Texts = "Slots Code";
            }

            if (txtBeauty2.Texts == "Booking Slot" && CellContentChecking == "Slots")
            {
                txtBeauty2.Clear();
            }

        }

        private void rjTextbox3_Click(object sender, EventArgs e)
        {
            if (txtBeauty3.Texts == "Customer Surname")
            {
                txtBeauty3.Clear();
            }

            if (txtBeauty1.Texts == "" && CellContentChecking == "Customer")
            {
                txtBeauty1.Texts = "Customer Code";
            }

            if (txtBeauty2.Texts == "" && CellContentChecking == "Customer")
            {
                txtBeauty2.Texts = "Customer Name";
            }

            if (txtBeauty4.Texts == "" && CellContentChecking == "Customer")
            {
                txtBeauty4.Texts = "Customer Email";
            }

            if (txtBeauty5.Texts == "" && CellContentChecking == "Customer")
            {
                txtBeauty5.Texts = "Customer Phone";
            }

            //////////////////
            ///

            if (txtBeauty3.Texts == "Staff Surname")
            {
                txtBeauty3.Clear();
            }

            if (txtBeauty1.Texts == "" && CellContentChecking == "Staff")
            {
                txtBeauty1.Texts = "Staff Code";
            }

            if (txtBeauty2.Texts == "" && CellContentChecking == "Staff")
            {
                txtBeauty2.Texts = "Staff Name";
            }

            if (txtBeauty4.Texts == "" && CellContentChecking == "Staff")
            {
                txtBeauty4.Texts = "Staff Contract";
            }

            ///////////////////////
            ///

            if (txtBeauty3.Texts == "Product Price")
            {
                txtBeauty3.Clear();
            }

            if (txtBeauty1.Texts == "" && CellContentChecking == "Product")
            {
                txtBeauty1.Texts = "Product Code";
            }

            if (txtBeauty2.Texts == "" && CellContentChecking == "Product")
            {
                txtBeauty2.Texts = "Product Name";
            }


        }

        private void rjTextbox4_Click(object sender, EventArgs e)
        {
            if (txtBeauty4.Texts == "Customer Email")
            {
                txtBeauty4.Clear();
            }

            if (txtBeauty1.Texts == "" && CellContentChecking == "Customer")
            {
                txtBeauty1.Texts = "Customer Code";
            }

            if (txtBeauty3.Texts == "" && CellContentChecking == "Customer")
            {
                txtBeauty3.Texts = "Customer Surname";
            }

            if (txtBeauty2.Texts == "" && CellContentChecking == "Customer")
            {
                txtBeauty2.Texts = "Customer Name";
            }

            if (txtBeauty5.Texts == "" && CellContentChecking == "Customer")
            {
                txtBeauty5.Texts = "Customer Phone";
            }

            ///////////////////
            ///
            if (txtBeauty4.Texts == "Staff Contract")
            {
                txtBeauty4.Clear();
            }

            if (txtBeauty1.Texts == "" && CellContentChecking == "Staff")
            {
                txtBeauty1.Texts = "Staff Code";
            }

            if (txtBeauty3.Texts == "" && CellContentChecking == "Staff")
            {
                txtBeauty3.Texts = "Staff Surname";
            }

            if (txtBeauty2.Texts == "" && CellContentChecking == "Staff")
            {
                txtBeauty2.Texts = "Staff Name";
            }


        }

        private void rjTextbox5_Click(object sender, EventArgs e)
        {
            if (txtBeauty5.Texts == "Customer Phone")
            {
                txtBeauty5.Clear();
            }

            if (txtBeauty1.Texts == "" && CellContentChecking == "Customer")
            {
                txtBeauty1.Texts = "Customer Code";
            }

            if (txtBeauty3.Texts == "" && CellContentChecking == "Customer")
            {
                txtBeauty3.Texts = "Customer Surname";
            }

            if (txtBeauty4.Texts == "" && CellContentChecking == "Customer")
            {
                txtBeauty4.Texts = "Customer Email";
            }

            if (txtBeauty2.Texts == "" && CellContentChecking == "Customer")
            {
                txtBeauty2.Texts = "Customer Name";
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show(txtBeauty3.Texts.ToUpper());
        }

        private void rjTextbox4__TextChanged(object sender, EventArgs e)
        {
            txtBeauty4.Texts.ToUpper();
        }

        private void rjButton3_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show(txtBeauty3.Texts);
        }

        private void rjButton3_Click_2(object sender, EventArgs e)
        {
            MessageBox.Show(txtBeauty2.Texts);
        }

        private void button25_Click_1(object sender, EventArgs e)
        {
            enablingTextBoxes();
            PanelHiding();
            CellContentChecking = "Product";

            LoadInformationProduct();
            txtBeauty5.Visible = false;
            txtBeauty4.Visible = false;
            txtBeauty3.Visible = false;


            clearing();
            RenamingProduct();

            TableCheck = "ProductAdd";
            panelMain.Visible = true;
            //enter what to do
            HideSub();
            panelMain.Size = new Size(1132, 752);
            panelMain.Location = new Point(273, 0);
            panelMain.BringToFront();
            btnAddDeleteUpdate.Text = "Add";
            txtBeauty5.Visible = false;
            txtBeauty4.Visible = false;
            txtBeauty3.Visible = true;
            txtBeauty2.Visible = true;
            txtBeauty1.Visible = false;

            txtBeauty2.Enabled = true;
            txtBeauty5.Enabled = true;

            HideSub();


        }

        private void button24_Click_1(object sender, EventArgs e)
        {
            disablingTextBoxes();
            PanelHiding();
            CellContentChecking = "ProductDelete";

            LoadInformationProduct();
            txtBeauty5.Visible = false;
            txtBeauty4.Visible = false;
            TableCheck = "ProductDelete";
            clearing();
            RenamingProduct();


            panelMain.Visible = true;
            //enter what to do
            HideSub();
            panelMain.Size = new Size(1132, 752);
            panelMain.Location = new Point(273, 0);
            panelMain.BringToFront();
            btnAddDeleteUpdate.Text = "Delete";
            txtBeauty5.Visible = false;
            txtBeauty4.Visible = false;
            txtBeauty3.Visible = true;
            txtBeauty2.Visible = true;
            txtBeauty1.Visible = true;


            txtBeauty2.Enabled = false;
            txtBeauty5.Enabled = true;
            HideSub();

        }

        private void button23_Click_1(object sender, EventArgs e)
        {
            enablingTextBoxes();
            PanelHiding();
            CellContentChecking = "Product";

            LoadInformationProduct();
            clearing();
            RenamingProduct();
            TableCheck = "ProductUpdate";
            HideSub();
            txtBeauty5.Visible = false;
            txtBeauty4.Visible = false;


            txtBeauty2.Enabled = true;
            txtBeauty5.Enabled = true;

            panelMain.Visible = true;
            //enter what to do
            HideSub();
            panelMain.Size = new Size(1132, 752);
            panelMain.Location = new Point(273, 0);
            panelMain.BringToFront();
            btnAddDeleteUpdate.Text = "Update";
            txtBeauty5.Visible = false;
            txtBeauty4.Visible = false;
            txtBeauty3.Visible = true;
            txtBeauty2.Visible = true;
            txtBeauty1.Visible = true;
            txtBeauty1.Enabled = false;

            disablingTextBoxes();

        }

        private void panel1_Click(object sender, EventArgs e)
        {
            if (txtBeauty2.Texts == "" && CellContentChecking == "Customer")
            {
                txtBeauty2.Texts = "Customer Name";
            }

            if (txtBeauty1.Texts == "" && CellContentChecking == "Customer")
            {
                txtBeauty1.Texts = "Customer Code";
            }

            if (txtBeauty3.Texts == "" && CellContentChecking == "Customer")
            {
                txtBeauty3.Texts = "Customer Surname";
            }

            if (txtBeauty4.Texts == "" && CellContentChecking == "Customer")
            {
                txtBeauty4.Texts = "Customer Email";
            }

            if (txtBeauty5.Texts == "" && CellContentChecking == "Customer")
            {
                txtBeauty5.Texts = "Customer Phone";
            }

            ////////////////////////////////////
            ///

            if (txtBeauty2.Texts == "" && CellContentChecking == "Staff")
            {
                txtBeauty2.Texts = "Staff Name";
            }

            if (txtBeauty1.Texts == "" && CellContentChecking == "Staff")
            {
                txtBeauty1.Texts = "Staff Code";
            }

            if (txtBeauty3.Texts == "" && CellContentChecking == "Staff")
            {
                txtBeauty3.Texts = "Staff Surname";
            }

            if (txtBeauty4.Texts == "" && CellContentChecking == "Staff")
            {
                txtBeauty4.Texts = "Staff Contract";
            }


            //////////////////////////////////
            ///

            if (txtBeauty2.Texts == "" && CellContentChecking == "Room")
            {
                txtBeauty2.Texts = "Room Description";
            }

            if (txtBeauty1.Texts == "" && CellContentChecking == "Room")
            {
                txtBeauty1.Texts = "Room Code";
            }
            ////////////////////////////
            ///

            if (txtBeauty2.Texts == "" && CellContentChecking == "Product")
            {
                txtBeauty2.Texts = "Product Name";
            }

            if (txtBeauty1.Texts == "" && CellContentChecking == "Product")
            {
                txtBeauty1.Texts = "Product Code";
            }

            if (txtBeauty3.Texts == "" && CellContentChecking == "Product")
            {
                txtBeauty3.Texts = "Product Price";
            }

        }

        private void rjTextbox2_ChangeUICues(object sender, UICuesEventArgs e)
        {

        }

        private void rjButton3_Click_3(object sender, EventArgs e)
        {
            MessageBox.Show(txtBeauty2.Texts);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            LoadSlots();
            LoadRoomDescription();

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            void LoadSlots2()
            {
                ConnectionString.Connect.Close();

                ConnectionString.Connect.Open();

                Dictionary<int, string> slots = Booking.getSlots();
                //SQL command to select all the slots
                SqlCommand command111 = new SqlCommand("gettingBooking", ConnectionString.Connect);
                command111.CommandType = CommandType.StoredProcedure;
                command111.Parameters.AddWithValue("@S", monthCalendarBooking.SelectionStart.ToString("yyyy/MM/dd"));
                SqlDataReader read1 = command111.ExecuteReader();

                while (read1.Read())
                {
                    slots.Remove(read1.GetInt32(0));
                }
                cmbSlots.Items.Clear();

                foreach (object slot in slots)
                {
                    cmbSlots.Items.Add(slot);
                }
                ConnectionString.Connect.Close();
                BookingDate = monthCalendarBooking.SelectionStart.ToString("yyyy/MM/dd");
            }

            LoadSlots2();

           
            cmbSlots.Text = "Time Slots";
            cmbStaff.Text = "Staff Member";
            cmbTreatment.Text = "Treatments";
            cmbRoom.Text = "Rooms";
            lblPrice.Text = "£0.00";


            if (monthCalendarBooking.SelectionStart.DayOfWeek == DayOfWeek.Friday)
            {
                cmbStaff.Items.Clear();







                SqlCommand commandGetStaff1 = new SqlCommand("SELECT * FROM Staff WHERE StaffContract = 'Full Time'", ConnectionString.Connect);
                ConnectionString.Connect.Close();
                ConnectionString.Connect.Open();
                SqlDataReader readStaff1 = commandGetStaff1.ExecuteReader();
                while (readStaff1.Read())
                {
                    if (!(StaffNos1a.Contains(Convert.ToInt32(readStaff1["StaffNumber"].ToString()))))
                    {
                        string staff = readStaff1["StaffNumber"].ToString() + ":" + readStaff1["StaffSurname"].ToString();
                        cmbStaff.Items.Add(staff);
                    }

                }



            }

            else
            {
                cmbStaff.Items.Clear();
                SqlCommand commandGetStaff12 = new SqlCommand("SELECT * FROM Staff", ConnectionString.Connect);
                ConnectionString.Connect.Close();
                ConnectionString.Connect.Open();
                SqlDataReader readStaff1 = commandGetStaff12.ExecuteReader();
                while (readStaff1.Read())
                {
                    if (!(StaffNos1a.Contains(Convert.ToInt32(readStaff1["StaffNumber"].ToString()))))
                    {
                        string staff = readStaff1["StaffNumber"].ToString() + ":" + readStaff1["StaffSurname"].ToString();
                        cmbStaff.Items.Add(staff);
                    }

                }
            }

            cmbStaff.Enabled = false;

        }

        private void rjButton3_Click_4(object sender, EventArgs e)
        {



        }

        private void rjButton1_Click_1(object sender, EventArgs e)
        {
            monthCalendarBooking.Enabled = false;
        }

        private void cmbNameSurname_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectCustomerNumber();
        }


        private void cmbRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Gets Primary Key for selected Room
            SelectRoomNumber();

            List<string> NailBar = new List<string>();
            NailBar.Add("Acrylics");
            NailBar.Add("Manicure");
            NailBar.Add("Basic Polish");
            NailBar.Add("Gel");
            NailBar.Add("Dip Powder");


            if (cmbRoom.Text == "Nail Bar")
            {
                cmbTreatment.Items.Clear();
                cmbTreatment.Items.Add("Acrylics");
                cmbTreatment.Items.Add("Manicure");
                cmbTreatment.Items.Add("Basic Polish");
                cmbTreatment.Items.Add("Nail Gel");
                cmbTreatment.Items.Add("Dip Powder");
            }
            else
            {
                if (cmbRoom.Text == "Treatment Room 1" || cmbRoom.Text == "Treatment Room 2" || cmbRoom.Text == "Treatment Room 3")
                {
                    cmbTreatment.Items.Clear();

                    cmbTreatment.Items.Add("Lashlift and Tint");
                    cmbTreatment.Items.Add("Make Up");
                    cmbTreatment.Items.Add("Laser Hair Removal");
                    cmbTreatment.Items.Add("Tan");
                    cmbTreatment.Items.Add("Eyebrows");
                }
            }

            cmbTreatment.Text = "Treatments";
            lblPrice.Text = "£0.00";
         
        }

        private void btnExitGrid_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            frmTableSelect a = new frmTableSelect();
            this.Hide();
            a.Show();
        }

        private void pctExitBooking_Click(object sender, EventArgs e)
        {
            const string message =
"Are You Sure You Want To Exit?";
            const string caption = "Exit Applicaiton";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.OKCancel,
                                         MessageBoxIcon.Question);





            if (result == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void pctLogOutMain_Click(object sender, EventArgs e)
        {
            const string message =
"Are You Sure You Want To Log Out?";
            const string caption = "Log Out";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.OKCancel,
                                         MessageBoxIcon.Question);





            if (result == DialogResult.OK)
            {
                frmLogin a = new frmLogin();
                this.Hide();
                a.Show();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmTableSelect a = new frmTableSelect();
            this.Hide();
            a.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panelBookinginformation_Paint(object sender, PaintEventArgs e)
        {

        }

        string Treatment;
        private void cmbTreatment_SelectedIndexChanged(object sender, EventArgs e)
        {

            Treatment = cmbTreatment.Text;

            switch (Treatment)
            {
                case "Acrylics":

                    lblPrice.Text = "£20";
                    break;

                case "Manicure":
                    lblPrice.Text = "£15";

                    break;

                case "Basic Polish":
                    lblPrice.Text = "£10";


                    break;

                case "Dip Powder":
                    lblPrice.Text = "£25";


                    break;

                case "Nail Gel":
                    lblPrice.Text = "£20";


                    break;

                case "Lashlift and Tint":
                    lblPrice.Text = "£10";


                    break;

                case "Make Up":
                    lblPrice.Text = "£30";


                    break;

                case "Laser Hair Removal":
                    lblPrice.Text = "£50";


                    break;

                case "Tan":
                    lblPrice.Text = "£25";


                    break;

                case "Eyebrows":
                    lblPrice.Text = "£15";


                    break;

            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pctPayNow_Click(object sender, EventArgs e)
        {
            if (pctPayLater.Image == Properties.Resources.check_mark_tick_vector_graphic_21)
            {
                pctPayLater.Image = null;
            }
            else
            {
                pctPayNow.Image = Properties.Resources.check_mark_tick_vector_graphic_21;
            }
        }

        private void pctPayLater_Click(object sender, EventArgs e)
        {
            if (pctPayNow.Image == Properties.Resources.check_mark_tick_vector_graphic_21)
            {
                pctPayNow.Image = null;
            }
            else
            {
                pctPayLater.Image = Properties.Resources.check_mark_tick_vector_graphic_21;
            }
        }

        private void pctPayNow_Click_1(object sender, EventArgs e)
        {

            lblPayNow.Visible = false;
            Paid = "Yes";

            //if(pctPayLater.BackColor == Color.LawnGreen)
            //{
            //    pctPayLater.BackColor = Color.Transparent;
            //}
            //pctPayNow.BackColor = Color.LawnGreen;

            if (Picture == null)
            {
                Picture = "Paid";
                pctPayNow.Image = Properties.Resources.check_mark_tick_vector_graphic_21;
            }

            if (Picture == "Not")
            {
                Picture = "Paid";
                pctPayNow.Image = Properties.Resources.check_mark_tick_vector_graphic_21;
                pctPayLater.Image = null;
            }
        }

        public string Paid;
        public string Picture;



        private void pctPayLater_Click_1(object sender, EventArgs e)
        {
            lblPayNow.Visible = true;
            
            Paid = "No";

            //if(pctPayLater.BackColor == Color.LawnGreen)
            //{
            //    pctPayLater.BackColor = Color.Transparent;
            //}
            //pctPayNow.BackColor = Color.LawnGreen;

            if (Picture == null)
            {
                Picture = "Not";
                pctPayLater.Image = Properties.Resources.check_mark_tick_vector_graphic_21;
            }

            if (Picture == "Paid")
            {
                Picture = "Not";
                pctPayLater.Image = Properties.Resources.check_mark_tick_vector_graphic_21;
                pctPayNow.Image = null;
            }


        }

        private void rjButton1_Click_2(object sender, EventArgs e)
        {

        }

        int GetSlotNumber;

        public void CallInSlotNumber()
        {

            string[] slots = cmbSlots.SelectedItem.ToString().Split('[');
            string[] slot = slots[1].Split(',');
            SlotNumber = Convert.ToInt32(slot[0]);
            GetSlotNumber = Convert.ToInt32(slot[0]);

        }
        private void cmbSlots_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbSlots.Text == "" || cmbSlots.Text == "Slots")
            {

            }
            else
            {
                CallInSlotNumber();

              //  iF STAFF DOES NOT CHANGE THEIR SLOT IT WILL CRASH AS WELL
            }


            int aaa;
            string[] slotsa = cmbSlots.Text.ToString().Split('[');
            string[] slota = slotsa[1].Split(',');
            aaa = Convert.ToInt32(slota[0]);

            if (aaa > 10)
            {

                cmbStaff.Items.Clear();







                SqlCommand commandGetStaff1 = new SqlCommand("SELECT * FROM Staff WHERE StaffContract = 'Full Time'", ConnectionString.Connect);

                ConnectionString.Connect.Close();
                ConnectionString.Connect.Open();
                SqlDataReader readStaff1 = commandGetStaff1.ExecuteReader();
                while (readStaff1.Read())
                {
                    if (!(StaffNos1a.Contains(Convert.ToInt32(readStaff1["StaffNumber"].ToString()))))
                    {
                        string staff = readStaff1["StaffNumber"].ToString() + ":" + readStaff1["StaffSurname"].ToString();
                        cmbStaff.Items.Add(staff);
                    }

                }




            }
            else
            {
                if (monthCalendarBooking.SelectionStart.DayOfWeek != DayOfWeek.Friday)
                {
                    cmbStaff.Items.Clear();
                    ConnectionString.Connect.Close();
                    SqlCommand commandGetStaff = new SqlCommand("SELECT * FROM Staff", ConnectionString.Connect);

                    ConnectionString.Connect.Open();
                    SqlDataReader readStaff = commandGetStaff.ExecuteReader();
                    while (readStaff.Read())
                    {
                        if (!(StaffNos.Contains(Convert.ToInt32(readStaff["StaffNumber"].ToString()))))
                        {
                            string staff = readStaff["StaffNumber"].ToString() + ":" + readStaff["StaffSurname"].ToString();
                            cmbStaff.Items.Add(staff);
                        }

                    }


                }
            }

            cmbStaff.Enabled = true;
            cmbStaff.Text = "Staff Member";
        }

            private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            frmMainMenu a = new frmMainMenu();
            this.Hide();
            a.Show();
        }

        private void pictureBox1_Click_2(object sender, EventArgs e)
        {
            const string message =
           "Are You Sure You Want To Retun to the Main Menu?";
            const string caption = "Returning to Main Menu";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.OKCancel,
                                         MessageBoxIcon.Question);





            if (result == DialogResult.OK)
            {
                frmMainMenu a = new frmMainMenu();
                this.Hide();
                a.Show();
            }
        }

        private void txtBeauty1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtBeauty2_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtBeauty3_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtBeauty5_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtBeauty3_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            void DataInput(string a)
            {
                switch (a)
                {

                    //Updating Customer
                    case "Room":

                        if (char.IsControl(e.KeyChar) || char.IsLetterOrDigit(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || char.IsPunctuation(e.KeyChar))
                        {
                            return;
                        }
                        e.Handled = true;

                        break;


                    case "Customer":


                        if (char.IsControl(e.KeyChar) || char.IsLetter(e.KeyChar))
                        {
                            return;
                        }
                        e.Handled = true;

                        break;

                    case "Staff":


                        if (char.IsControl(e.KeyChar) || char.IsLetter(e.KeyChar))
                        {
                            return;
                        }
                        e.Handled = true;

                        break;

                    case "Product":


                        if (char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar) || e.KeyChar == '.')
                        {
                            return;
                        }
                        e.Handled = true;



                        break;

                    case "Slots":


                        if (char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || char.IsPunctuation(e.KeyChar))
                        {
                            return;
                        }
                        e.Handled = true;

                        break;




                }

            }


            DataInput(CellContentChecking);


        }


        private void txtBeauty2_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            void DataInput(string a)
            {
                switch (a)
                {

                    //Updating Customer
                    case "Room":

                        if (char.IsControl(e.KeyChar) || char.IsLetterOrDigit(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || char.IsPunctuation(e.KeyChar))
                        {
                            return;
                        }
                        e.Handled = true;

                        break;


                    case "Customer":


                        if (char.IsControl(e.KeyChar) || char.IsLetter(e.KeyChar))
                        {
                            return;
                        }
                        e.Handled = true;

                        break;

                    case "Staff":


                        if (char.IsControl(e.KeyChar) || char.IsLetter(e.KeyChar))
                        {
                            return;
                        }
                        e.Handled = true;

                        break;

                    case "Product":


                        if (char.IsControl(e.KeyChar) || char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
                        {
                            return;
                        }
                        e.Handled = true;

                        break;

                    case "Slots":


                        if (char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || char.IsPunctuation(e.KeyChar))
                        {
                            return;
                        }
                        e.Handled = true;

                        break;




                }

            }


            DataInput(CellContentChecking);


        }

        private void txtBeauty4_KeyPress(object sender, KeyPressEventArgs e)
        {
            void DataInput(string a)
            {
                switch (a)
                {

                    //Updating Customer
                    case "Staff":

                        if (char.IsControl(e.KeyChar) || char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
                        {
                            return;
                        }
                        e.Handled = true;

                        break;

                    case "Customer":

                        if (char.IsControl(e.KeyChar) || char.IsLetterOrDigit(e.KeyChar) || char.IsPunctuation(e.KeyChar))
                        {
                            return;
                        }
                        e.Handled = true;

                        break;




                }
            }


            DataInput(CellContentChecking);
        }

        private void txtBeauty5_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar))
            {
                return;
            }
            e.Handled = true;
        }




        string PaypalBank;

        
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            btnPay.Visible = true;
            txtBookingCodePaying.Visible = true;

            //if(pctPayLater.BackColor == Color.LawnGreen)
            //{
            //    pctPayLater.BackColor = Color.Transparent;
            //}
            //pctPayNow.BackColor = Color.LawnGreen;

            if (PaypalBank == null)
            {
                PaypalBank = "Bank";
                pctbankcardyes.Image = Properties.Resources.check_mark_tick_vector_graphic_21;
            }

            if (PaypalBank == "Paypal")
            {
                PaypalBank = "Bank";
                pctbankcardyes.Image = Properties.Resources.check_mark_tick_vector_graphic_21;
                pctpaypalyes.Image = null;
            }

            txtPaying1.Visible = true;
            txtPaying2.Visible = true;
            txtSecurityCode.Visible = true;


            txtPaying1.Texts = "Card Number";
            txtPaying2.Texts = "Expiry Date";
            txtSecurityCode.Texts = "Security Number";

        }

        private void pctpaypalyes_Click(object sender, EventArgs e)
        {
            txtBookingCodePaying.Visible = true;

            btnPay.Visible = true;
            txtSecurityCode.Visible = false;
            //if(pctPayLater.BackColor == Color.LawnGreen)
            //{
            //    pctPayLater.BackColor = Color.Transparent;
            //}
            //pctPayNow.BackColor = Color.LawnGreen;

            if (PaypalBank == null)
            {
                PaypalBank = "Paypal";
                pctpaypalyes.Image = Properties.Resources.check_mark_tick_vector_graphic_21;
            }

            if (PaypalBank == "Bank")
            {
                PaypalBank = "Paypal";
                pctpaypalyes.Image = Properties.Resources.check_mark_tick_vector_graphic_21;
                pctbankcardyes.Image = null;
            }

            txtPaying1.Visible = true;
            txtPaying2.Visible = true;

            txtPaying1.Texts = "Email Address";
            txtPaying2.Texts = "Password";



        }

        private void panelBookingUpdate_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rjButton1_Click_3(object sender, EventArgs e)
        {

            if (PaypalBank == "Bank" && txtPaying1.Texts.Length == 12 && txtSecurityCode.Texts.Length == 3 && txtPaying1.Texts != "Card Number" && txtPaying2.Texts != "Expiry Date" && txtSecurityCode.Texts != "Security Number")
            {
             PayingHide();
            pctLoading.Visible = true;
            pctLoading.Location = new Point(240, 19);
            pctLoading.Size = new Size (212, 205);


            lblLoading.Location = new Point(243, 234);
            lblLoading.Visible = true;
           

            //Calls in the Constructor for Customer to ensure the textbox's are validated
            timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 1000; // 1 second
            timer1.Start();



            }
            else
            {
                if (PaypalBank == "Paypal" && txtPaying1.Texts.Length > 11 && txtPaying2.Texts.Length > 5 && txtPaying1.Texts != "Email Address" && txtPaying2.Texts != "Password")
                {
                    PayingHide();
                    pctLoading.Visible = true;
                    pctLoading.Location = new Point(240, 19);
                    pctLoading.Size = new Size(212, 205);


                    lblLoading.Location = new Point(243, 234);
                    lblLoading.Visible = true;


                    //Calls in the Constructor for Customer to ensure the textbox's are validated
                    timer1 = new System.Windows.Forms.Timer();
                    timer1.Tick += new EventHandler(timer1_Tick);
                    timer1.Interval = 1000; // 1 second
                    timer1.Start();

                }

                else
                {

                    MessageBox.Show("Please Enter your correct payment details");
                }
            }






            if (PaypalBank == "Paypal")
            {

                //code checking the textboxes
            }
            else
            {
                if (PaypalBank == "Bank")
                {
                    //code checking textboxes
                }
            }




        }

        private void txtPaying1_Click(object sender, EventArgs e)
        {

            if (txtSecurityCode.Texts == "")
            {
                txtSecurityCode.Texts = "Security Number";
            }


            if (txtPaying1.Texts == "Email Address" || txtPaying1.Texts == "Card Number")
            {
                txtPaying1.Clear();
            }


            if(txtPaying2.Texts == "" && PaypalBank == "Bank")
            {
                txtPaying2.Texts = "Expiry Date";
            }
            else
            {
                if (txtPaying2.Texts == "" && PaypalBank == "Paypal")
                {
                    txtPaying2.Texts = "Password";
                }
            }
        }

        private void txtPaying2_Click(object sender, EventArgs e)
        {

            if (txtSecurityCode.Texts == "")
            {
                txtSecurityCode.Texts = "Security Number";
            }


            if (txtPaying2.Texts == "Password" || txtPaying2.Texts == "Expiry Date")
            {
                txtPaying2.Clear();
            }

            if (txtPaying1.Texts == "" && PaypalBank == "Bank")
            {
                txtPaying1.Texts = "Card Number";
            }
            else
            {
                if (txtPaying1.Texts == "" && PaypalBank == "Paypal")
                {
                    txtPaying1.Texts = "Email Address";
                }
                
            }
        }

        private void txtSecurityCode_Click(object sender, EventArgs e)
        {
            if (txtSecurityCode.Texts == "Security Number")
            {
                txtSecurityCode.Clear();
            }

            if (txtPaying1.Texts == "" && PaypalBank == "Bank")
            {
                txtPaying1.Texts = "Card Number";
            }
            else
            {
                if (txtPaying1.Texts == "" && PaypalBank == "Paypal")
                {
                    txtPaying1.Texts = "Email Address";
                }
            }


            if (txtPaying2.Texts == "" && PaypalBank == "Bank")
            {
                txtPaying2.Texts = "Expiry Date";
            }
            else
            {
                if (txtPaying2.Texts == "" && PaypalBank == "Paypal")
                {
                    txtPaying2.Texts = "Password";
                }
            }



        }

        private void txtPaying1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(PaypalBank == "Paypal")
            {
                if (char.IsControl(e.KeyChar) || char.IsLetterOrDigit(e.KeyChar) || char.IsPunctuation(e.KeyChar))
                {
                    return;
                }
                e.Handled = true;
            }
            else
            {
                if(PaypalBank == "Bank")
                {
                    if (char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar))
                    {
                        return;
                    }
                    e.Handled = true;
                }
            }
        }

        private void txtPaying2_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void txtPaying2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (PaypalBank == "Paypal")
            {
                if (char.IsControl(e.KeyChar) || char.IsLetterOrDigit(e.KeyChar) || char.IsPunctuation(e.KeyChar))
                {
                    return;
                }
                e.Handled = true;
            }
            else
            {
                if (PaypalBank == "Bank")
                {
                    if (char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar) || char.IsPunctuation(e.KeyChar))
                    {
                        return;
                    }
                    e.Handled = true;
                }
            }
        }

        private void txtSecurityCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar))
            {
                return;
            }
            e.Handled = true;


        }

        public void PayingHide()
        {

            txtPaying1.Visible = false;
            txtPaying2.Visible = false;
            txtSecurityCode.Visible = false;
            txtBookingCodePaying.Visible = false;

            pctBankCard.Visible = false;
            pctPaypal.Visible = false;
            pctbankcardyes.Visible = false;
            pctpaypalyes.Visible = false;
            btnPay.Visible = false;

        }

        public void PayingShow()
        {

            txtPaying1.Visible = true;
            txtPaying2.Visible = true;
            txtSecurityCode.Visible = true;
            txtBookingCodePaying.Visible = true;

            pctBankCard.Visible = true;
            pctPaypal.Visible = true;
            pctbankcardyes.Visible = true;
            pctpaypalyes.Visible = true;
            btnPay.Visible = true;

        }



        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            DataTable datatable = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter("CustomersNotPaid", ConnectionString.Connect);
            adapt.Fill(datatable);
            dataGridViewBeautyCosmetics.DataSource = datatable;
            
            CellContentChecking = "Paying";

            txtBookingCodePaying.Texts = "Booking Code";
            panelPaying.Size = new Size(731, 404);
            panelPaying.Location = new Point(9, 335);
            panelPaying.BringToFront();
            panelPaying.Visible = true;
            btnAddDeleteUpdate.Visible = false;
            txtBookingCodePaying.Visible = false;
            txtPaying1.Visible = false;
            txtPaying2.Visible = false;
            txtSecurityCode.Visible = false;
            PaypalBank = null;
            pctpaypalyes.Image = null;
            pctbankcardyes.Image = null;



        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            counter--;
            if (counter == 0)
            {
                //code to update

                ConnectionString.Connect.Close();
                ConnectionString.Connect.Open();

                //Calls in the SQL command to update the customer
                SqlCommand s = new SqlCommand("UpdatePaying", ConnectionString.Connect);
                s.CommandType = CommandType.StoredProcedure;
                s.Parameters.AddWithValue("@BC", txtBookingCodePaying.Texts);
                s.Parameters.AddWithValue("@P", "Yes");

                s.ExecuteNonQuery();
                ConnectionString.Connect.Close();
               

                //Calls in the method to populate the Data Grid View

                DataTable datatable = new DataTable();
                SqlDataAdapter adapt = new SqlDataAdapter("CustomersNotPaid", ConnectionString.Connect);
                adapt.Fill(datatable);
                dataGridViewBeautyCosmetics.DataSource = datatable;
                CellContentChecking = "Paying";

                pctLoading.Visible = false;
                lblLoading.Visible = false;


                MessageBox.Show(a + " has successfully paid for their " + b + " Treatment");
                PayingShow();
                txtPaying1.Clear();
                txtPaying2.Clear();
                txtBookingCodePaying.Clear();
                txtSecurityCode.Clear();

                PaypalBank = null;
                pctpaypalyes.Image = null;
                pctbankcardyes.Image = null;

                pctLoading.Visible = false;
                lblLoading.Visible = false;
                timer1.Stop();

                panelPaying.SendToBack();
                panelPaying.Visible = false;
                panelPaying.Size = new Size(31, 91);
                panelPaying.Location = new Point(939, 450);
                btnAddDeleteUpdate.Visible = true;



                panelBookingUpdate.Location = new Point(3, 165);
                panelBookingUpdate.BringToFront();
                enablingTextBoxes();
                CellContentChecking = "BookingUpdate";

                label2.ForeColor = Color.WhiteSmoke;

                clearing();
                // renamin();
                UpdatingBooking();

                LoadSlots();

                LoadInformationBooking();
                TableCheck = "BookingUpdate";
                panelMain.Visible = true;
                //enter what to do
                HideSub();
                panelMain.Size = new Size(1132, 752);
                panelMain.Location = new Point(273, 0);
                panelMain.BringToFront();
                btnAddDeleteUpdate.Text = "Update";
                txtBeauty3.Visible = false;
                txtBeauty4.Visible = false;
                txtBeauty5.Visible = false;
                txtBeauty1.Visible = true;
                TableCheck = "BookingUpdate";

                LoadIntoComboRoom();


                txtBeauty2.Enabled = false;
                txtBeauty5.Enabled = false;
                txtBeauty1.Enabled = false;
                txtBeauty1.Texts = "Booking Code";
                cmbSlots.Text = "Time Slots";
                cmbRoom.Text = "Rooms";

                disablingTextBoxes();
                cmbTreatment.Enabled = false;
                cmbStaff.Enabled = false;
                pctPayNow.Enabled = false;
                pctPayLater.Enabled = false;

                cmbTreatment.Text = "Select Treatment";
                cmbStaff.Text = "Select Staff Member";
                pctPayLater.Image = null;
                pctPayNow.Image = null;

                lblPayNow.Visible = false;
                lblPrice.Text = "";


                counter = 5;



            }
         



        }

     
        private int counter = 5;
        private void rjButton1_Click_4(object sender, EventArgs e)
        {
            timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 1000; // 1 second
            timer1.Start();
        }

        private void label5_MouseHover(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Hand;

        }

        private void pcthelpSimpsons_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"Resources\ComputingUserGuide.pdf");

        }

        private void frmSimpsonsInformation_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void frmSimpsonsInformation_KeyDown(object sender, KeyEventArgs e)
        {
          
        }

        private void label6_Click(object sender, EventArgs e)
        {
            panelPaying.SendToBack();
            panelPaying.Visible = false;
            panelPaying.Size = new Size(31, 91);
            panelPaying.Location = new Point(939, 450);
            btnAddDeleteUpdate.Visible = true;



            panelBookingUpdate.Location = new Point(3, 165);
            panelBookingUpdate.BringToFront();
            enablingTextBoxes();
            CellContentChecking = "BookingUpdate";

            label2.ForeColor = Color.WhiteSmoke;

            clearing();
            // renamin();
            UpdatingBooking();

            LoadSlots();

            LoadInformationBooking();
            TableCheck = "BookingUpdate";
            panelMain.Visible = true;
            //enter what to do
            HideSub();
            panelMain.Size = new Size(1132, 752);
            panelMain.Location = new Point(273, 0);
            panelMain.BringToFront();
            btnAddDeleteUpdate.Text = "Update";
            txtBeauty3.Visible = false;
            txtBeauty4.Visible = false;
            txtBeauty5.Visible = false;
            txtBeauty1.Visible = true;
            TableCheck = "BookingUpdate";

            LoadIntoComboRoom();


            txtBeauty2.Enabled = false;
            txtBeauty5.Enabled = false;
            txtBeauty1.Enabled = false;
            txtBeauty1.Texts = "Booking Code";
            cmbSlots.Text = "Time Slots";
            cmbRoom.Text = "Rooms";

            disablingTextBoxes();
            cmbTreatment.Enabled = false;
            cmbStaff.Enabled = false;
            pctPayNow.Enabled = false;
            pctPayLater.Enabled = false;

            cmbTreatment.Text = "Select Treatment";
            cmbStaff.Text = "Select Staff Member";
            pctPayLater.Image = null;
            pctPayNow.Image = null;

            lblPayNow.Visible = false;
            lblPrice.Text = "";

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            LoadingSlots();
            string[] slots = cmbSlots.SelectedItem.ToString().Split('[');
            string[] slot = slots[1].Split(',');
            RoomNo = Convert.ToInt32((sender as Button).Tag);
            ConnectionString.Connect.Close();
            ConnectionString.Connect.Open();
            SqlCommand command = new SqlCommand("checkStaff", ConnectionString.Connect);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@bd", monthCalendarBooking.SelectionStart.ToString("yyyy/MM/dd"));
            command.Parameters.AddWithValue("@s", slot[0]);
            SqlDataReader read = command.ExecuteReader();
            while (read.Read())
            {
                StaffNos.Add(Convert.ToInt32(read["StaffNumber"].ToString()));

                //cmbStaff.Items.Add(staff);
            }
            ConnectionString.Connect.Close();
            SqlCommand commandGetStaff = new SqlCommand("SELECT * FROM Staff", ConnectionString.Connect);

            ConnectionString.Connect.Close();
            ConnectionString.Connect.Open();
            SqlDataReader readStaff = commandGetStaff.ExecuteReader();
            while (readStaff.Read())
            {
                if (!(StaffNos.Contains(Convert.ToInt32(readStaff["StaffNumber"].ToString()))))
                {
                    string staff = readStaff["StaffNumber"].ToString() + ":" + readStaff["StaffSurname"].ToString();
                    cmbStaff.Items.Add(staff);
                }

            }


        }

        private void rjButton1_Click_5(object sender, EventArgs e)
        {
            
        }

        private void rjButton1_Click_6(object sender, EventArgs e)
        {
          
            cmbStaff.Items.Clear();
            //checkStaff
            ConnectionString.Connect.Close();
            ConnectionString.Connect.Open();
            SqlCommand command = new SqlCommand("checkStaff", ConnectionString.Connect);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@bd", monthCalendarBooking.SelectionStart.ToString("yyyy/MM/dd"));
            command.Parameters.AddWithValue("@s", SlotTime);
            SqlDataReader read = command.ExecuteReader();
            while (read.Read())
            {
                StaffNos.Add(Convert.ToInt32(read["StaffNumber"].ToString()));

                //cmbStaff.Items.Add(staff);
            }
            ConnectionString.Connect.Close();
            SqlCommand commandGetStaff = new SqlCommand("SELECT * FROM Staff", ConnectionString.Connect);

            ConnectionString.Connect.Close();

            ConnectionString.Connect.Open();
            SqlDataReader readStaff = commandGetStaff.ExecuteReader();
            while (readStaff.Read())
            {
                if (!(StaffNos.Contains(Convert.ToInt32(readStaff["StaffNumber"].ToString()))))
                {
                    string staff = readStaff["StaffNumber"].ToString() + ":" + readStaff["StaffSurname"].ToString();
                    cmbStaff.Items.Add(staff);
                }

            }
            cmbStaff.Enabled = true;
            ConnectionString.Connect.Close();
        }

        private void lblRoom_Click(object sender, EventArgs e)
        {

        }

        int SlotNumber;
        private void rjButton1_Click_7(object sender, EventArgs e)
        {
            //string[] slots = cmbSlots.SelectedItem.ToString().Split('[');
            //string[] slot = slots[1].Split(',');
            //SlotNumber = Convert.ToInt32(slot[0]);
            //GetSlotNumber = Convert.ToInt32(slot[0]);

            //label7.Text = Convert.ToString(slot[0]);

            cmbSlots.Text = "[3, Slot Time: 10:00AM - 11:00AM]";
        }

        private void cmbSlots_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

        }

        private void cmbRoom_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

        }

        private void cmbTreatment_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

        }

        private void cmbStaff_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

        }

        private void rjButton1_Click_8(object sender, EventArgs e)
        {
            MessageBox.Show(Testing);
        }

        private void cmbStaff_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
