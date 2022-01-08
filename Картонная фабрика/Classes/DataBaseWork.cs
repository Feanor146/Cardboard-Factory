using System;
using System.Data;
using System.Data.SQLite;
namespace Картонная_фабрика.Classes
{
    internal abstract class DataBaseWork
    {
        private static SQLiteConnection SQLiteConnection = new SQLiteConnection(@"data source=" + Environment.CurrentDirectory +  @"\Data\DataBase.db");
        private static SQLiteCommand SQLiteCommand = new SQLiteCommand { Connection = SQLiteConnection };
        private static SQLiteDataAdapter SQLiteDataAdapter = new SQLiteDataAdapter { SelectCommand = SQLiteCommand};
        public static void OpenConnect()
        {
            try
            {
                SQLiteConnection.Open();
            }
            catch
            {

            }
        }
        public static void CloseConnect()
        {
            try
            {
                SQLiteConnection.Close();
            }
            catch
            {

            }
        }
        public static void RegistrationUser(User user)
        {
            OpenConnect();
            try
            {
                SQLiteCommand.CommandText = "INSERT INTO Users (Login,Password) VALUES (@Login,@Password)";
                SQLiteCommand.Parameters.AddWithValue("@Login", user.Login);
                SQLiteCommand.Parameters.AddWithValue("@Password", user.Password);
                SQLiteCommand.ExecuteNonQuery();
                Message.SendMessage("Пользователь успешно добавлен");
            }
            catch
            {
                Message.SendMessage("При добавлении пользователя произошла ошибка");
            }
            SQLiteCommand.Parameters.Clear();
            CloseConnect();
        }        
        public static bool Autorization(string Login, string Password)
        {
            SQLiteCommand.CommandText = "SELECT * FROM Users WHERE Login = @Login AND Password = @Password";
            SQLiteCommand.Parameters.AddWithValue("@Login", Login);
            SQLiteCommand.Parameters.AddWithValue("@Password", Password);
            DataTable dataTable = new DataTable();
            SQLiteDataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count == 1)
            {                               
                AuthorizedUser.Login = Convert.ToString(dataTable.Rows[0][1]);
                AuthorizedUser.Password = Convert.ToString(dataTable.Rows[0][2]);
                Message.SendMessage("Вход выполнен успешно");
            }
            else if (dataTable.Rows.Count == 0)
            {
                Message.SendMessage("Неверно введено имя пользователя или пароль");
                return false;
            }
            SQLiteCommand.Parameters.Clear();
            return true;
        }        
        public static DataTable GetTable(string TableName)
        {
            SQLiteCommand.CommandText = "SELECT * FROM " + TableName;
            DataTable dataTable = new DataTable();
            SQLiteDataAdapter.Fill(dataTable);
            return dataTable;
        }
        public static void AddMaterial(Material material)
        {
            OpenConnect();
            try
            {
                SQLiteCommand.CommandText = "INSERT INTO Material ([Название материала],[Цена(р.)],Количество) VALUES (@Name,@Price,@Count)";
                SQLiteCommand.Parameters.AddWithValue("@Name", material.NameMaterial);
                SQLiteCommand.Parameters.AddWithValue("@Price", material.Price);
                SQLiteCommand.Parameters.AddWithValue("@Count", material.Count);
                SQLiteCommand.ExecuteNonQuery();
                Message.SendMessage("Материал успешно добавлен");
            }
            catch
            {
                Message.SendMessage("В ходе добавления материала произошла ошибка");
            }
            SQLiteCommand.Parameters.Clear();
            CloseConnect();            
        }
        public static void AddProduct(Product product)
        {
            OpenConnect();
            try
            {
                SQLiteCommand.CommandText = "INSERT INTO Products ([Название товара],[Цена(р.)],Количество) VALUES (@Name,@Price,@Count)";
                SQLiteCommand.Parameters.AddWithValue("@Name", product.Name);
                SQLiteCommand.Parameters.AddWithValue("@Price", product.Price);
                SQLiteCommand.Parameters.AddWithValue("@Count", product.Count);
                SQLiteCommand.ExecuteNonQuery();
                Message.SendMessage("Товар успешно добавлен");
            }
            catch
            {
                Message.SendMessage("В ходе добавления товара произошла ошибка");
            }
            SQLiteCommand.Parameters.Clear();
            CloseConnect();
        }
        public static void Delete (int ID,string TableName)
        {
            OpenConnect();
            try
            {
                SQLiteCommand.CommandText = "DELETE FROM " + TableName +" WHERE ID = @ID";
                SQLiteCommand.Parameters.AddWithValue("@ID", ID);                
                SQLiteCommand.ExecuteNonQuery();
                Message.SendMessage("Удаление прошло успешно");
            }
            catch
            {
                Message.SendMessage("В ходе удаления материала произошла ошибка");
            }
            SQLiteCommand.Parameters.Clear();
            CloseConnect();
        }
    }
}
