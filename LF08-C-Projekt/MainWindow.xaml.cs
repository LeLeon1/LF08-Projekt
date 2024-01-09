using System;
using System.Collections;
using System.Windows;
using System.Data.SQLite;
using System.Data;
using System.IO;
using System.Security;
using Microsoft.Win32;

namespace LF08_C_Projekt
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SQLiteConnection conn = new SQLiteConnection(@"Data Source=C:\Users\leon\Documents\Neuer Ordner (3)\LF08-C-Projekt\LF08-C-Projekt\databases\logDb.db");
        private System.Data.DataSet dataSet;
        private ArrayList filesImported = new ArrayList();
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
            fillDataGrid("select * from logs");
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
        private void fillDataGrid(String sqliteCommand)
        {

            conn.Open();
            SQLiteCommand cmd = new SQLiteCommand(sqliteCommand, conn);
            SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd);
            //Database1DataSet ds = new Database1DataSet();
            try {
                DataTable dt = new DataTable("verstehe ich nicht");
                sda.Fill(dt);
                dataGrid1.ItemsSource = dt.DefaultView;
                /*
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dataGrid1.ItemsSource = ds.Tables[0].DefaultView;
                }
                */
            }
            catch (Exception e) {
                MessageBox.Show("Exception: " + e.Message);
            }
            conn.Close();
        }

        private void readLogFile()
        {

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();



            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".log";
            dlg.Filter = "LOG Files (*.log)|*.log";

            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                //textBox1.Text = filename;
            }
            //if (dlg.ShowDialog() == DialogResult.OK)
                    try
                    {
                        var sr = new StreamReader(dlg.FileName);
                        //SetText(sr.ReadToEnd());
                    }
                    catch (SecurityException ex)
                    {
                        MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                        $"Details:\n\n{ex.StackTrace}");
                    }
        }

        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = ".log";
            openFileDialog.Filter = "LOG Files (*.log)|*.log";
            if (openFileDialog.ShowDialog() == true)
            {
                //Wenn NICHT drin ist
                if (!filesImported.Contains(openFileDialog.FileName)){
                    //readStringFromFile(File.ReadAllText(openFileDialog.FileName));
                    filesImported.Add(openFileDialog.FileName);
                    readStringFromFile(openFileDialog.FileName);
                    
                }
                else
                {
                    MessageBox.Show("Datei wurde schonmal importiert");
                }
            }
            fillDataGrid("select * from logs");
        }

        private void readStringFromFile(String allTextString)
        {
            String line;
            try
            {
                StreamReader sr = new StreamReader(allTextString);

                conn.Open();
                line = sr.ReadLine();
                String[] arrayCsvParts;

                //Continue to read until you reach end of file
                while (line != null)
                {
                    //write the line to console window
                    arrayCsvParts = line.Split(' ');

                    arrayCsvParts[3] = arrayCsvParts[3].Remove(0, 1);
                    arrayCsvParts[4] = arrayCsvParts[4].Remove(15, 1);
                    arrayCsvParts[5] = arrayCsvParts[5].Remove(0, 1);
                    arrayCsvParts[7] = arrayCsvParts[7].Remove(8, 1);

                    arrayCsvParts[6] = arrayCsvParts[6] + " " + arrayCsvParts[7];
                    arrayCsvParts[8] = arrayCsvParts[8] + " " + arrayCsvParts[9];


                    SQLiteCommand command = conn.CreateCommand();
                    command.CommandText =
                        @"
                            INSERT INTO logs(ip_adressen, datum, zeit, methoden, pfad, error_code)
                            VALUES ($ip_adressen, $datum, $zeit, $methoden, $pfad_part_1, $error_code_part_1)
                        ";
                    command.Parameters.AddWithValue("$ip_adressen", arrayCsvParts[0]);
                    command.Parameters.AddWithValue("$datum", arrayCsvParts[3]);
                    command.Parameters.AddWithValue("$zeit", arrayCsvParts[4]);
                    command.Parameters.AddWithValue("$methoden", arrayCsvParts[5]);
                    command.Parameters.AddWithValue("$pfad_part_1", arrayCsvParts[6]);
                    command.Parameters.AddWithValue("$error_code_part_1", arrayCsvParts[8]);

                    command.ExecuteNonQuery();
                    
                    /*
                    command.CommandText =
                        @"
                            UPDATE logs SET pfad = pfad || $pfad_part_2 WHERE pfad = $pfad_part_1 AND methoden = $zeit AND datum = $methoden
                        ";
                    command.Parameters.AddWithValue("$pfad_part_2", arrayCsvParts[7]);
                    command.ExecuteNonQuery();


                    command.CommandText =
                        @"
                            UPDATE logs SET pfad = pfad || $error_code_part_2 WHERE pfad = $error_code_part_1  AND methoden = $zeit AND datum = $methoden
                        ";
                    command.Parameters.AddWithValue("$error_code_part_2", arrayCsvParts[9]);
                    command.ExecuteNonQuery();
                    */

                    

                    //Console.WriteLine(line);
                    //Read the next line
                    line = sr.ReadLine();
                }
                //close the file
                sr.Close();
                conn.Close();
            }
            catch (Exception e)
            {
                //Console.WriteLine("Exception: " + e.Message);
                MessageBox.Show("Exception: " + e.Message);
            }
        }
        private void buttonIp_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(textBoxIP.Text);
        }

        private void buttonErr_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(textBoxErr.Text);
        }

        private void buttonMeth_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(textBoxMeth.Text);
        }

        private void buttonTime_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(textBoxTime.Text);
        }
    }
}
