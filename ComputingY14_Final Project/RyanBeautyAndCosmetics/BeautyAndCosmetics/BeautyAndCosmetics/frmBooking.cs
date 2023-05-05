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
    public partial class frmBooking : Form
    {
        public frmBooking()
        {
            InitializeComponent();
        }

        string BookingDate;
        int RoomNo;
        public void LoadSlots()
        {
            ConnectionString.Connect.Close();

            ConnectionString.Connect.Open();

            Dictionary<int, string> slots = Booking.getSlots();
            //SQL command to select all the slots
            SqlCommand command = new SqlCommand("gettingBooking", ConnectionString.Connect);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@S", dtpDate.Value.ToString("yyyy/MM/dd"));
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
            BookingDate = dtpDate.Value.ToString("yyyy/MM/dd");
        }

        int SlotNumber;


        void LoadIntoComboCustomer()
        {
            cmbCustomer.Items.Clear();
            string[] slots = cmbSlots.SelectedItem.ToString().Split('[');
            string[] slot = slots[1].Split(',');
            SlotNumber = Convert.ToInt32(slot[0]);

            ConnectionString.Connect.Close();
            ConnectionString.Connect.Open();
            SqlCommand command = new SqlCommand("checkCustomer", ConnectionString.Connect);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@bd", dtpDate.Value.ToString("yyyy/MM/dd"));
            command.Parameters.AddWithValue("@s", slot[0]);
            SqlDataReader read = command.ExecuteReader();
            while (read.Read())
            {
                CustomerNo.Add(Convert.ToInt32(read["CustomerNumber"].ToString()));
                //cmbStaff.Items.Add(staff);
            }
            ConnectionString.Connect.Close();
            SqlCommand commandGetCustomer = new SqlCommand("SELECT * FROM Customer", ConnectionString.Connect);

            ConnectionString.Connect.Open();
            SqlDataReader readCustomer = commandGetCustomer.ExecuteReader();
            while (readCustomer.Read())
            {
                if (!(CustomerNo.Contains(Convert.ToInt32(readCustomer["CustomerNumber"].ToString()))))
                {
                    string customer = readCustomer["CustomerNumber"].ToString() + ":" + readCustomer["CustomerNameSurname"].ToString();
                    cmbCustomer.Items.Add(customer);
                }

            }
           // cmbNameSurname.Enabled = true;
            ConnectionString.Connect.Close();


 


        }




        private void frmBooking_Load(object sender, EventArgs e) 
        {


            cmbSlots.Enabled = false;
            dtpDate.MinDate = DateTime.Now;

            Label[] roomDescriptions = new Label[] { lblRoomDescription, lblRoomDescription2, lblRoomDescription3, lblRoomDescription4 };
            Label[] roomNos = new Label[] { labelRoomNo, labelRoomNo2,labelRoomNo3,labelRoomNo4 };
            Label[] roomCodes = new Label[] { labelRoomCode, labelRoomCode2, labelRoomCode3, labelRoomCode4 };

            loadRooms(roomDescriptions,roomNos,roomCodes);

            Picture = null;

        }




        public void loadRooms(Label[] roomDescriptions, Label[] roomNos, Label[] roomCodes)
        {
            SqlCommand command = new SqlCommand("Select * FROM Room", ConnectionString.Connect);
            ConnectionString.Connect.Close();
            ConnectionString.Connect.Open();
            SqlDataReader read = command.ExecuteReader();


            int counter = 0;

            while (read.Read())
            {
                
                roomNos[counter].Text= read["RoomNo"].ToString();
                roomCodes[counter].Text= read["RoomCode"].ToString();
                roomDescriptions[counter].Text= read["RoomDescription"].ToString();

                counter++;

            }
            ConnectionString.Connect.Close();

        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {

            cmbSlots.Text = "Slots";

            cmbCustomer.Text = "Customer";
            cmbTreatment.Text = "Treatment";
            cmbStaff.Text = "Staff";

            cmbCustomer.Enabled = false;
            cmbTreatment.Enabled = false;
            cmbStaff.Enabled = false;

            pctPayLater.Image = null;
            pctPayNow.Image = null;
            pctPayNow.Enabled = false;
            pctPayLater.Enabled = false;

            lblPrice.Text = "£0.00";

            pnlRooms.Visible = false;


            LoadSlots();

            cmbSlots.Enabled = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdateBooking_Click(object sender, EventArgs e)
        {
            pnlRooms.Visible = true;
        }

        List<int> StaffNos = new List<int>();
        List<int> StaffNos1 = new List<int>();


        List<int> CustomerNo = new List<int>();
        

        private void button1_Click(object sender, EventArgs e)
        {

            int a;
            string[] slotsa = cmbSlots.SelectedItem.ToString().Split('[');
            string[] slota = slotsa[1].Split(',');
            a = Convert.ToInt32(slota[0]);





                Picture = null;


            cmbCustomer.Text = "Customer";
            cmbTreatment.Text = "Treatment";
            cmbStaff.Text = "Staff";

            cmbCustomer.Enabled = false;
            cmbTreatment.Enabled = false;

            pctPayLater.Image = null;
            pctPayNow.Image = null;
            pctPayNow.Enabled = false;
            pctPayLater.Enabled = false;

            lblPrice.Text = "£0.00";

            if (dtpDate.Value.DayOfWeek == DayOfWeek.Friday)
            {



                string[] slots = cmbSlots.SelectedItem.ToString().Split('[');
                string[] slot = slots[1].Split(',');
                RoomNo = Convert.ToInt32((sender as Button).Tag);
                cmbStaff.Items.Clear();

                SqlCommand commandGetStaff1 = new SqlCommand("SELECT * FROM Staff WHERE StaffContract = 'Full Time'", ConnectionString.Connect);

                ConnectionString.Connect.Close();
                ConnectionString.Connect.Open();
                SqlDataReader readStaff1 = commandGetStaff1.ExecuteReader();
                while (readStaff1.Read())
                {
                    if (!(StaffNos1.Contains(Convert.ToInt32(readStaff1["StaffNumber"].ToString()))))
                    {
                        string staff = readStaff1["StaffNumber"].ToString() + ":" + readStaff1["StaffSurname"].ToString();
                        cmbStaff.Items.Add(staff);
                    }

                }

                cmbStaff.Enabled = true;
                ConnectionString.Connect.Close();


                List<string> NailBar = new List<string>();
                NailBar.Add("Acrylics");
                NailBar.Add("Manicure");
                NailBar.Add("Basic Polish");
                NailBar.Add("Gel");
                NailBar.Add("Dip Powder");


                if (RoomNo == 4)
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
                    cmbTreatment.Items.Clear();

                    cmbTreatment.Items.Add("Lashlift and Tint");
                    cmbTreatment.Items.Add("Make Up");
                    cmbTreatment.Items.Add("Laser Hair Removal");
                    cmbTreatment.Items.Add("Tan");
                    cmbTreatment.Items.Add("Eyebrows");

                }


            }
            else
            {

                if (a > 10)
                {


                    string[] slots = cmbSlots.SelectedItem.ToString().Split('[');
                    string[] slot = slots[1].Split(',');
                    RoomNo = Convert.ToInt32((sender as Button).Tag);
                    cmbStaff.Items.Clear();

                    SqlCommand commandGetStaff1 = new SqlCommand("SELECT * FROM Staff WHERE StaffContract = 'Full Time'", ConnectionString.Connect);

                    ConnectionString.Connect.Close();
                    ConnectionString.Connect.Open();
                    SqlDataReader readStaff1 = commandGetStaff1.ExecuteReader();
                    while (readStaff1.Read())
                    {
                        if (!(StaffNos1.Contains(Convert.ToInt32(readStaff1["StaffNumber"].ToString()))))
                        {
                            string staff = readStaff1["StaffNumber"].ToString() + ":" + readStaff1["StaffSurname"].ToString();
                            cmbStaff.Items.Add(staff);
                        }

                    }

                    cmbStaff.Enabled = true;
                    ConnectionString.Connect.Close();


                    List<string> NailBar = new List<string>();
                    NailBar.Add("Acrylics");
                    NailBar.Add("Manicure");
                    NailBar.Add("Basic Polish");
                    NailBar.Add("Gel");
                    NailBar.Add("Dip Powder");


                    if (RoomNo == 4)
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
                        cmbTreatment.Items.Clear();

                        cmbTreatment.Items.Add("Lashlift and Tint");
                        cmbTreatment.Items.Add("Make Up");
                        cmbTreatment.Items.Add("Laser Hair Removal");
                        cmbTreatment.Items.Add("Tan");
                        cmbTreatment.Items.Add("Eyebrows");

                    }






                }
                else
                {
       string[] slots = cmbSlots.SelectedItem.ToString().Split('[');
                string[] slot = slots[1].Split(',');
                RoomNo = Convert.ToInt32((sender as Button).Tag);
                cmbStaff.Items.Clear();
                    //checkStaff

                    ConnectionString.Connect.Close();
                ConnectionString.Connect.Open();
                SqlCommand command = new SqlCommand("checkStaff", ConnectionString.Connect);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@bd", dtpDate.Value.ToString("yyyy/MM/dd"));
                command.Parameters.AddWithValue("@s", slot[0]);
                SqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    StaffNos.Add(Convert.ToInt32(read["StaffNumber"].ToString()));

                    //cmbStaff.Items.Add(staff);
                }
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
                cmbStaff.Enabled = true;
                ConnectionString.Connect.Close();


                List<string> NailBar = new List<string>();
                NailBar.Add("Acrylics");
                NailBar.Add("Manicure");
                NailBar.Add("Basic Polish");
                NailBar.Add("Gel");
                NailBar.Add("Dip Powder");


                if (RoomNo == 4)
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
                    cmbTreatment.Items.Clear();

                    cmbTreatment.Items.Add("Lashlift and Tint");
                    cmbTreatment.Items.Add("Make Up");
                    cmbTreatment.Items.Add("Laser Hair Removal");
                    cmbTreatment.Items.Add("Tan");
                    cmbTreatment.Items.Add("Eyebrows");

                }





                }

         

            }




        }

        private void cmbStaff_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbCustomer.Enabled = true;
        }

        private void cmbSlots_SelectedIndexChanged(object sender, EventArgs e)
        {

            cmbCustomer.Items.Clear();
            LoadIntoComboCustomer();

            cmbCustomer.Text = "Customer";
            cmbTreatment.Text = "Treatment";
            cmbStaff.Text = "Staff";

            cmbCustomer.Enabled = false;
            cmbTreatment.Enabled = false;
            cmbStaff.Enabled = false;

            pctPayLater.Image = null;
            pctPayNow.Image = null;
            pctPayNow.Enabled = false;
            pctPayLater.Enabled = false;

            lblPrice.Text = "£0.00";



        }

        private void lblRoomDescription4_Click(object sender, EventArgs e)
        {

        }

        private void labelRoomNo4_Click(object sender, EventArgs e)
        {

        }

        private void labelRoomCode4_Click(object sender, EventArgs e)
        {

        }

        string Treatment;

        private void cmbTreatment_SelectedIndexChanged(object sender, EventArgs e)
        {
            pctPayLater.Enabled = true;
            pctPayNow.Enabled = true;

            lblPrice.Visible = true;

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

        private void btnBook_Click(object sender, EventArgs e)
        {
            try

            {

                // ADD CLASS VALIDATION
                ConnectionString.Connect.Close();
                ConnectionString.Connect.Open();
                SqlCommand commander = new SqlCommand("AddBookingSlot", ConnectionString.Connect);
                commander.CommandType = CommandType.StoredProcedure;
                //Selects the date the user enters
                commander.Parameters.AddWithValue("@BookingDate", BookingDate);
                commander.Parameters.AddWithValue("@SlotsNumber", SlotNumber);
                string[] customerNo = cmbCustomer.SelectedItem.ToString().Split(':');
                commander.Parameters.AddWithValue("@CustomerNumber", customerNo[0]);
                commander.Parameters.AddWithValue("@RoomNumber", RoomNo);
                commander.Parameters.AddWithValue("@Treatment", cmbTreatment.Text);
                commander.Parameters.AddWithValue("@BookingPrice", lblPrice.Text);
                string[] staffNo = cmbStaff.SelectedItem.ToString().Split(':');
                commander.Parameters.AddWithValue("@staffNo", staffNo[0]);
                commander.Parameters.AddWithValue("@Paid", Paid1); //update from form
                commander.ExecuteNonQuery();
                ConnectionString.Connect.Close();

                MessageBox.Show("Booking Made");
                frmSimpsonsInformation simpsons = new frmSimpsonsInformation();
                simpsons.Show();
                this.Hide();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        string Paid1;
        string Picture;
        private void pctPayNow_Click(object sender, EventArgs e)
        {

            Paid1 = "Yes";

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

       
        private void pctPayLater_Click(object sender, EventArgs e)
        {



            Paid1 = "No";

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

        private void pictureBox5_Click(object sender, EventArgs e)
        {

            Paid1 = "Yes";

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

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Paid1 = "No";
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

        private void button5_Click(object sender, EventArgs e)
        {
            pctPayNow.Image = Properties.Resources.check_mark_tick_vector_graphic_21;
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            try 

            {
                Booking b = new Booking(cmbStaff.Text, cmbCustomer.Text, cmbTreatment.Text, Paid1);

               
                ConnectionString.Connect.Close();
                ConnectionString.Connect.Open();
                SqlCommand commander = new SqlCommand("AddBookingSlot", ConnectionString.Connect);
                commander.CommandType = CommandType.StoredProcedure;
                //Selects the date the user enters
                commander.Parameters.AddWithValue("@BookingDate", BookingDate);
                commander.Parameters.AddWithValue("@SlotsNumber", SlotNumber);
                string[] customerNo = cmbCustomer.SelectedItem.ToString().Split(':');
                commander.Parameters.AddWithValue("@CustomerNumber", customerNo[0]);
                commander.Parameters.AddWithValue("@RoomNumber", RoomNo);
                commander.Parameters.AddWithValue("@Treatment", cmbTreatment.Text);
                commander.Parameters.AddWithValue("@BookingPrice", lblPrice.Text);
                string[] staffNo = cmbStaff.SelectedItem.ToString().Split(':');
                commander.Parameters.AddWithValue("@staffNo", staffNo[0]);
                commander.Parameters.AddWithValue("@Paid", Paid1); //update from form
                commander.ExecuteNonQuery();
                ConnectionString.Connect.Close();

                MessageBox.Show("Booking has been made for " + BookingDate + " for " + cmbTreatment.Text);
            

                ClassLogin.TableS = "BookingUpdate";

                frmSimpsonsInformation d = new frmSimpsonsInformation();
                this.Hide();
                d.Show();




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void rjButton2_Click(object sender, EventArgs e)
        {
          
            if (pnlRooms.Visible == true)
            {



            }
            else
            {
                if (cmbSlots.Text == "" || cmbSlots.Text == "Slots")
                {
                    MessageBox.Show("Please Select a Slot Time");
                }
                else
                {
  counter = 2;
   timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 1000; // 1 second
            timer1.Start();



            pctSearch.Visible = true;
            pctSearch.BringToFront();
            lblsearch.Visible = true;
            pctSearch.Location = new Point(240, 152);
            pctSearch.Size = new Size(302, 304);

            lblsearch.Location = new Point(310, 468);

            //pnlRooms.Visible = true;

                }
              


         
            }
           
        }
   

         int counter = 2;

        private void timer1_Tick(object sender, EventArgs e)
        {
            counter--;
            if (counter == 0)
            {
              
                pctSearch.Visible = false;
                pctSearch.SendToBack();
                lblsearch.Visible = false;
                pctSearch.Location = new Point(1, 1);
                pctSearch.Size = new Size(1, 1);

                lblsearch.Location = new Point(1, 1);

                counter = 2;

                timer1.Stop();

                pnlRooms.Visible = true;
                pnlRooms.BringToFront();


            }

        }

        private void cmbNameSurname_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbTreatment.Enabled = true;
        }

        private void cmbStaff_KeyPress(object sender, KeyPressEventArgs e)
        {
           e.Handled = true;

        }

        private void cmbSlots_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

        }

        private void cmbNameSurname_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

        }

        private void cmbTreatment_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

        }

        private void dtpDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

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

        private void pctLogOutBooking_Click(object sender, EventArgs e)
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

        private void pctReturnBooking_Click(object sender, EventArgs e)
        {
            ClassLogin.TableS = "BookingUpdate";

            frmSimpsonsInformation d = new frmSimpsonsInformation();
            this.Hide();
            d.Show();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            frmMainMenu a = new frmMainMenu();
            this.Hide();
            a.Show();
        }

        private void pcthelpSimpsons_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"Resources\ComputingUserGuide.pdf");
        }

        private void frmBooking_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }

        private void frmBooking_KeyDown(object sender, KeyEventArgs e)
        {
          
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int a;
            string[] slots = cmbSlots.SelectedItem.ToString().Split('[');
            string[] slot = slots[1].Split(',');
           a = Convert.ToInt32(slot[0]);



           
        }
    }
}
