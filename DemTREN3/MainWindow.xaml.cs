
using System.Windows;
using System.Data.SqlClient;


namespace DemTREN3
{

    public partial class MainWindow : Window
    {
        DB db = new DB();
        public MainWindow()
        {

            InitializeComponent();
        }

        private void Reg_Button_Click(object sender, RoutedEventArgs e)
        {
            var _login = Login_Reg.Text.Trim();
            var _password1 = Password1_Reg.Password.Trim();
            var _password2 = Password2_Reg.Password.Trim();

            if(_password1 == _password2)
            {
                string request = $"insert into Auto (login, password) values ('{_login}' , '{_password1}')";

                SqlCommand command = new SqlCommand(request, db.GetConnection());

                db.OpenConnection();

                if(command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Регистрация успешна");
                    Hide();
                    new AutoWindow().ShowDialog();
                    ShowDialog();

                }
            }
            else
            {
                MessageBox.Show("Регистрация не успешна");
            }
        }

        private void Auto_Button_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            new AutoWindow().ShowDialog();
            ShowDialog();
        }
    }
}
