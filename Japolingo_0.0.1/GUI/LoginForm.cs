using System;
using System.Windows.Forms;
using Japolingo_0._0._1.Implementaciones;

namespace Japolingo_0._0._1.GUI
{
    public partial class LoginForm : Form
    {
        private const string ConnectionString = @"Data Source=DESKTOP-VVV5AUP\SQLEXPRESS;Initial Catalog=BBDD Japones;Integrated Security=True";

        public LoginForm()
        {
            InitializeComponent();
            this.CenterToScreen();
        }


        
        private void Principal_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Logear(BoxUser.Text, BoxPassword.Text);
            this.Hide();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            /*
            new Registro().Show();
            */
        }
    }
}
