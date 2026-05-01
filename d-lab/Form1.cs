using d.labdemo.DB;
using Microsoft.Data.SqlClient;



namespace d.labdemo
{
    public partial class d_lab : Form
    {
        bool sidebarexpand;

        public string Role { get; private set; }

        public d_lab()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            if (sidebarexpand)
            {
                sidebar.Width = MaximumSize.Width;

            }
        }

        private void logibtn_Click(object sender, EventArgs e)
        {

                string query = "SELECT Role From Admins WHERE Username = '" + namebx.Text + "' OR Email = '" + namebx.Text + "' AND Password =' " + passbx.Text + "'";
            
                if (Role == "Admin")
                {
                    loginpnl.Visible = false;
                    userpnl.Visible = false;
                    adminpnl.Visible = true;
                }
                else if (Role == "user")
                {
                    loginpnl.Visible = false;
                    userpnl.Visible = true;
                    adminpnl.Visible = false;
                }
                else if (string.IsNullOrWhiteSpace(namebx.Text) || string.IsNullOrWhiteSpace(passbx.Text)  ){
                    MessageBox.Show("Please enter your username and password.", "Warning",MessageBoxButtons.OK, MessageBoxIcon.Warning);
    
                }
                else
                {
                    MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                }

        
        }
        
    }
}
