
using System.Windows;
using System.Data.SqlClient;
using System.Data;


namespace DemTREN3
{

    public partial class AutoWindow : Window
    {
        DB db = new DB();
        public AutoWindow()
        {
            InitializeComponent();
        }

        private void Enter_Button_Click(object sender, RoutedEventArgs e)
        {
            var _login = Auto_Login_Reg.Text.Trim();
            var _password = Auto_Password_Reg.Password.Trim();

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string request = $"select login, password from Auto where Login = '{_login}' and password = '{_password}'";

            SqlCommand command = new SqlCommand(request, db.GetConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count == 1)
            {
                MessageBox.Show("Авторизация успешна");
                Hide();
                new Cabinet().ShowDialog();
                ShowDialog();
            }
            else
            {
                MessageBox.Show("Авторизация не успешна");
            }
        }
    }
}
