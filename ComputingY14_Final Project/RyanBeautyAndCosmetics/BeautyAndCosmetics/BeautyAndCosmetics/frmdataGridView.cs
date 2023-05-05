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
    public partial class frmdataGridView : Form
    {
        public frmdataGridView()
        {
            InitializeComponent();
            CustomDesign();
        }

        public string TableCheck;

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

                    //Message box asking whether to delete the user or not, gives them the option to cancel or accept
                     string message = "Are You Sure You Want To Delete User" + txtBeauty1.Texts.ToString(); //This show the user the customer code to let them know what user they are deleting
                    const string caption = "Delete User";
                    var result = MessageBox.Show(message, caption,
                                                 MessageBoxButtons.OKCancel,
                                                 MessageBoxIcon.Question);





                    if (result == DialogResult.OK)
                    {

                        //DELETE BOOKING
                        ConnectionString.Connect.Close();

                        ConnectionString.Connect.Open();
                        //SQL command to delete the customers booking information so the customer can be deleted successfully 
                        SqlCommand a1 = new SqlCommand("DeleteAllBooking", ConnectionString.Connect);
                        a1.CommandType = CommandType.StoredProcedure;
                        //Checks the customer Code and delete that record depending on the code
                        a1.Parameters.AddWithValue("@CustomerNumber", lblCustomerNumber2.Text);
                        a1.ExecuteNonQuery();
                        ConnectionString.Connect.Close();



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



                    }
                    catch(Exception ex)
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

                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);


                    }

                    break;


                    //Same as other Case Deletes
                case "StaffDelete":


                     string messagea = "Are You Sure You Want To Delete User" + txtBeauty1.Texts.ToString();
                    const string captiona = "Deleting User";
                    var resulta = MessageBox.Show(messagea, captiona,
                                                 MessageBoxButtons.OKCancel,
                                                 MessageBoxIcon.Question);





                    if (resulta == DialogResult.OK)
                    {
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


                    string messageaa = "Are You Sure You Want To Delete Room" + txtBeauty1.Texts.ToString();
                    const string captionaa = "Deleting Room";
                    var resultaa = MessageBox.Show(messageaa, captionaa,
                                                 MessageBoxButtons.OKCancel,
                                                 MessageBoxIcon.Question);


                    if (resultaa == DialogResult.OK)
                    {
                      
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

                    ConnectionString.Connect.Open();
                    aaa.ExecuteNonQuery();
                    ConnectionString.Connect.Close();
                    LoadInformationRoom();
                    MessageBox.Show("Updated Successfully");
                    clearing();
                    RenamingRoom();





                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                   
                    break;

                    //Same as other Case Adds
                case "ProductAdd":

                    try

                    {
                        Product product = new Product(txtBeauty2.Texts,txtBeauty3.Texts);
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


                    string message111 = "Are You Sure You Want To Delete Product" + txtBeauty1.Texts.ToString();
                    const string acaption = "Delete Product";
                    var aresult = MessageBox.Show(message111, caption,
                                                 MessageBoxButtons.OKCancel,
                                                 MessageBoxIcon.Question);





                    if (aresult == DialogResult.OK)
                    {
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



                    }
                    catch(Exception ex)
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


                    string message1111 = "Are You Sure You Want To Delete Slots" + txtBeauty1.Texts.ToString();
                    const string acaption1 = "Delete Slots";
                    var aresult1 = MessageBox.Show(message1111, caption,
                                                 MessageBoxButtons.OKCancel,
                                                 MessageBoxIcon.Question);





                    if (aresult1 == DialogResult.OK)
                    {
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
                        commander.Parameters.AddWithValue("@SlotsNumber", cmbSlots.Text[1]);
                        commander.Parameters.AddWithValue("@CustomerNumber", lblCustomerNumber.Text);
                        commander.Parameters.AddWithValue("@RoomNumber", lblRoom.Text);


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


                    string amessage1111 = "Are You Sure You Want To Delete Slots" + txtBeauty1.Texts.ToString();
                    const string aacaption1 = "Delete Booking";
                    var aaresult1 = MessageBox.Show(amessage1111, caption,
                                                 MessageBoxButtons.OKCancel,
                                                 MessageBoxIcon.Question);





                    if (aaresult1 == DialogResult.OK)
                    {
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



                    break;

                case "BookingUpdate":


                    try
                    {
                        // add Class VAlidation
                        ConnectionString.Connect.Close();
                        ConnectionString.Connect.Open();


                        SqlCommand sin = new SqlCommand("UpdateBooking", ConnectionString.Connect);
                        sin.CommandType = CommandType.StoredProcedure;
                        sin.Parameters.AddWithValue("@BD", monthCalendarBooking.SelectionRange.Start.ToString("yyyy-MM-dd"));
                        sin.Parameters.AddWithValue("@SN", cmbSlots.Text[1]);
                        sin.Parameters.AddWithValue("@BC", txtBeauty1.Texts);

                        sin.ExecuteNonQuery();
                        ConnectionString.Connect.Close();

                        LoadInformationBooking();
                        MessageBox.Show("Updated Successfully");
                        clearing();
                        cmbSlots.SelectedIndex = -1;
                        
                  



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

                case "Customer":
                    enablingTextBoxes();
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

                    break;

                case "Staff":
                    //Calls in the method to fill the data grid view from the Staff Table in SQL

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


                    //enter what to do


                    break;

                case "Slots":
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


                    break;

                case "Product":
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

                    break;

            }
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

            ConnectionString.Connect.Open();
            var customerNo = command.ExecuteScalar().ToString();
            lblCustomerNumber.Text = customerNo;
            ConnectionString.Connect.Close();
        }

        void SelectRoomNumber()
        {
            ConnectionString.Connect.Close();


            SqlCommand command = new SqlCommand("SelectRoomCode", ConnectionString.Connect);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@RoomCode", cmbRoom.Text);

            ConnectionString.Connect.Open();
            var customerNo = command.ExecuteScalar().ToString();
            lblRoom.Text = customerNo;
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
            txtBeauty6.Enabled = false;
            txtBeauty7.Enabled = false;
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
            txtBeauty6.Enabled = true;
            txtBeauty7.Enabled = true;
            monthCalendarBooking.Enabled = true;
            cmbSlots.Enabled = true;
            cmbRoom.Enabled = true;


        }




        private void button3_Click(object sender, EventArgs e)
        {
            PanelHiding();
            //Changes the CellContentChecking string to Customer so when it passes through the Switch it will call in the suitable commands

            CellContentChecking = "Customer";

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
            enablingTextBoxes();
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


        }


        public void PanelHiding()
        {

            panelBookinginformation.Size = new Size(44, 53);
            panelBookinginformation.Location = new Point(1060, 146);
            panelBookinginformation.SendToBack();
            panelBookinginformation.Visible = false;
            txtBeauty7.Visible = false;
            txtBeauty6.Visible = false;

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

            CellContentChecking = "Room";
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


            txtBeauty2.Enabled = true;
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
            enablingTextBoxes();

            //Calls in the method to load in the slots


         

            //Changes the CellContentChecking string to Booking so when it passes through the Switch it will call in the suitable commands

            CellContentChecking = "Booking";

            //Calls in the method to clear all the textbox's
            clearing();


            HideSub();

            //Calls in the method to load the Booking table from SQL into the datagrid view
            LoadInformationBooking();
            TableCheck = "BookingAdd";
            panelMain.Visible = true;
            //enter what to do
           // RenamingRoom();
            HideSub();
            panelMain.Size = new Size(1132, 752);
            panelMain.Location = new Point(273, 0);
            panelMain.BringToFront();
            btnAddDeleteUpdate.Text = "Add";
            txtBeauty3.Visible = true;
            txtBeauty4.Visible = true;
            txtBeauty5.Visible = true;
            txtBeauty1.Visible = true;

            txtBeauty6.Visible = false;
            txtBeauty7.Visible = false;

            panelBookinginformation.Visible = true;
            LoadIntoComboCustomer();
            LoadIntoComboRoom();
            cmbNameSurname.Text = "Select Customer";

            panelBookinginformation.Location = new Point(33, 335);
            panelBookinginformation.Size = new Size(362, 407);
            panelBookinginformation.BringToFront();


            txtBeauty2.Enabled = true;
            txtBeauty5.Enabled = true;

        }

        private void button13_Click(object sender, EventArgs e)
        {
            disablingTextBoxes();
            CellContentChecking = "BookingDelete";

           

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


            HideSub();

        }

        public void UpdatingBooking()
        {
            panelBookinginformation.BringToFront();
            panelBookinginformation.Visible = true;
            panelBookinginformation.Size = new Size(362, 407);
            panelBookinginformation.Location = new Point(34, 398);
            cmbNameSurname.Visible = false;
            txtBeauty6.Visible = false;
            txtBeauty7.Visible = false;

        }

        private void button12_Click(object sender, EventArgs e)
        {
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

            LoadIntoComboRoom();


            txtBeauty2.Enabled = false;
            txtBeauty5.Enabled = false;
            txtBeauty1.Enabled = false;


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
            CellContentChecking = "Staff";

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

            txtBeauty2.Enabled = true;
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
            CellContentChecking = "Slots";

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


            txtBeauty2.Enabled = true;
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

            if(txtBeauty2.Texts == "" && CellContentChecking == "Customer")
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

            if (txtBeauty2.Texts == "" && CellContentChecking == "Staff" )
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

       


        
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

             void Checks(string form)
            {
                switch (form)
                {

                    case "Staff":

                        txtBeauty1.Texts = dataGridViewBeautyCosmetics.Rows[e.RowIndex].Cells[0].Value.ToString();
                        //customerNo = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

                     

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


                        void SelectCustomerNumber2()
                        {
                            ConnectionString.Connect.Close();


                            SqlCommand command = new SqlCommand("SelectCustomerNumber", ConnectionString.Connect);
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@CustomerCode", dataGridViewBeautyCosmetics.Rows[e.RowIndex].Cells[0].Value.ToString());

                            ConnectionString.Connect.Open();
                            var customerNo = command.ExecuteScalar().ToString();
                            lblCustomerNumber2.Text = customerNo;
                            ConnectionString.Connect.Close();
                        }

                        SelectCustomerNumber2();


                        break;
                    case "Room":
                        txtBeauty1.Texts = dataGridViewBeautyCosmetics.Rows[e.RowIndex].Cells[0].Value.ToString();

                        txtBeauty2.Texts = dataGridViewBeautyCosmetics.Rows[e.RowIndex].Cells[1].Value.ToString();

                        break;

                    case "Product":

                        txtBeauty1.Texts = dataGridViewBeautyCosmetics.Rows[e.RowIndex].Cells[0].Value.ToString();

                        txtBeauty2.Texts = dataGridViewBeautyCosmetics.Rows[e.RowIndex].Cells[1].Value.ToString();

                        txtBeauty3.Texts = dataGridViewBeautyCosmetics.Rows[e.RowIndex].Cells[2].Value.ToString();

                        break;

                    case "Slots":

                        txtBeauty1.Texts = dataGridViewBeautyCosmetics.Rows[e.RowIndex].Cells[0].Value.ToString();

                        txtBeauty2.Texts = dataGridViewBeautyCosmetics.Rows[e.RowIndex].Cells[1].Value.ToString();

                     

                        break;

                    case "Booking":

                        // add other fields after
                        txtBeauty1.Texts = dataGridViewBeautyCosmetics.Rows[e.RowIndex].Cells[0].Value.ToString();
                        txtBeauty2.Texts = dataGridViewBeautyCosmetics.Rows[e.RowIndex].Cells[2].Value.ToString();
                        txtBeauty3.Texts = dataGridViewBeautyCosmetics.Rows[e.RowIndex].Cells[3].Value.ToString();
                        txtBeauty4.Texts = dataGridViewBeautyCosmetics.Rows[e.RowIndex].Cells[4].Value.ToString();
                        txtBeauty5.Texts = dataGridViewBeautyCosmetics.Rows[e.RowIndex].Cells[5].Value.ToString();
                        txtBeauty6.Texts = dataGridViewBeautyCosmetics.Rows[e.RowIndex].Cells[6].Value.ToString();
                        txtBeauty7.Texts = dataGridViewBeautyCosmetics.Rows[e.RowIndex].Cells[7].Value.ToString();
                        DateTime dt = (DateTime)dataGridViewBeautyCosmetics.Rows[e.RowIndex].Cells[1].Value; 
                        monthCalendarBooking.SetDate(dt);



                        break;

                    case "BookingDelete":


   LoadSlots();

                        txtBeauty1.Texts = dataGridViewBeautyCosmetics.Rows[e.RowIndex].Cells[0].Value.ToString();
                        DateTime dta = (DateTime)dataGridViewBeautyCosmetics.Rows[e.RowIndex].Cells[1].Value;
                        monthCalendarBooking.SetDate(dta);
                        cmbSlots.Text = dataGridViewBeautyCosmetics.Rows[e.RowIndex].Cells[6].Value.ToString();
                        cmbRoom.Text = dataGridViewBeautyCosmetics.Rows[e.RowIndex].Cells[7].Value.ToString();




                        break;






                            








                }
            }

            Checks(CellContentChecking);
            


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

        public void clearing()
        {
            txtBeauty1.Clear();
            txtBeauty2.Clear();
            txtBeauty3.Clear();
            txtBeauty4.Clear();
            txtBeauty5.Clear();
        }


        private void rjButton1_Click(object sender, EventArgs e)
        {
         
            //try
            //{
            //    Customer a = new (rjTextbox2.Texts, rjTextbox3.Texts, rjTextbox4.Texts, rjTextbox5.Texts);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}



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

            if (txtBeauty3.Texts == "Staff Surname" )
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
            CellContentChecking = "Product";

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


            txtBeauty2.Enabled = true;
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
             cmbSlots.SelectedIndex = -1;
            cmbSlots.Text = "";
             LoadSlots();
            // LoadSlots();
            //   LoadRoomDescription();



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
            SelectRoomNumber();
        }
    }
}
