using System;
using System.Collections;
using System.Windows;
using System.Data.SQLite;
using System.Data;

namespace LF08_C_Projekt
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SQLiteConnection conn = new SQLiteConnection(@"Data Source=C:\Users\leon\Documents\Neuer Ordner (3)\LF08-C-Projekt\LF08-C-Projekt\databases\logDb.db");
        private System.Data.DataSet dataSet;
        public MainWindow()
        {
            InitializeComponent();
            //testComment
            /*
             MakeParentTable();
             MakeChildTable();
             MakeDataRelation();
             BindToDataGrid();
            */
            FillDataGrid();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ponies!");
            /*
            GetValue(ponyImage.VisibilityProperty);
            ponyImage.SetValue(VisibilityProperty, );
            */

            //commandIP();
        }

        private void testie() {
            ArrayList users = new ArrayList();

            users.Add("ponk");
            users.Add("twi");
            users.Add("dashie");

           // DataGrid.ItemsSource = users;

        }

        private void commandTest()
        {
            conn.Open();

            SQLiteCommand command = new SQLiteCommand("Select * from logs", conn);
            SQLiteDataReader reader = command.ExecuteReader();

            //deliverToUser(reader);

            reader.Close();
        }

        private void commandIP(String stringer)
        {
            conn.Open();

            SQLiteCommand command = new SQLiteCommand("Select * from logs", conn);
            SQLiteDataReader reader = command.ExecuteReader();

            //deliverToUserColumns(reader, "WHERE ip_adressen = '" + stringer + "'");

            deliverToUserRow(reader);

            reader.Close();
        }

        private void commandMethods()
        {
            conn.Open();

            SQLiteCommand command = new SQLiteCommand("Select * from logs", conn);
            SQLiteDataReader reader = command.ExecuteReader();

            //deliverToUser(reader);

            reader.Close();
        }

        private void commandErrors()
        {
            conn.Open();

            SQLiteCommand command = new SQLiteCommand("Select * from logs", conn);
            SQLiteDataReader reader = command.ExecuteReader();

            //deliverToUser(reader);

            reader.Close();
        }

        private void commandTimespan()
        {
            conn.Open();

            SQLiteCommand command = new SQLiteCommand("Select * from logs", conn);
            SQLiteDataReader reader = command.ExecuteReader();

            //deliverToUser(reader);

            reader.Close();
        }


        //TODO - Change name of String
        private void deliverToUserColumns(SQLiteDataReader reader, String smth)
        {
            while (reader.Read())
                Console.WriteLine(reader[smth]);

        }
        
        //TODO - Change name of String
        private void deliverToUserRow(SQLiteDataReader reader)
        {
            var test = reader.GetValues();

            Console.WriteLine();

        }

        private void deliverToUserTest(SQLiteCommand command)
        {
            /*
            DataTable dt = new DataTable("YourTable");
            SQLiteDataAdapter sda = new SQLiteDataAdapter(command);
            sda.Fill(dt);
            testDatagrid.ItemsSource = dt.DefaultView;
            */

            /*
            // Create a new DataTable.
            System.Data.DataTable table = new DataTable("ParentTable");
            // Declare variables for DataColumn and DataRow objects.
            DataColumn column;
            DataRow row;

            // Create new DataColumn, set DataType,
            // ColumnName and add to DataTable.
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "id";
            column.ReadOnly = true;
            column.Unique = true;
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);

            // Create second column.
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "ParentItem";
            column.AutoIncrement = false;
            column.Caption = "ParentItem";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the column to the table.
            table.Columns.Add(column);

            // Make the ID column the primary key column.
            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = table.Columns["id"];
            table.PrimaryKey = PrimaryKeyColumns;

            // Instantiate the DataSet variable.
            dataSet = new DataSet();
            // Add the new DataTable to the DataSet.
            dataSet.Tables.Add(table);

            testDatagrid.SetDataBinding(dataSet, "ParentTable");
            */

           
        }
        private void FillDataGrid()
        {

            conn.Open();
            SQLiteCommand cmd = new SQLiteCommand("select * from logs", conn);
            SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd);
            //Database1DataSet ds = new Database1DataSet();
            
            DataTable dt = new DataTable("verstehe ich nicht");
            sda.Fill(dt);
            dataGrid1.ItemsSource = dt.DefaultView;
            /*
            if (ds.Tables[0].Rows.Count > 0)
            {
                dataGrid1.ItemsSource = ds.Tables[0].DefaultView;
            }
            */
            conn.Close();
        }
    }
}
