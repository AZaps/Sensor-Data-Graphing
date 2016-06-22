using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SensorDataGraphing
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

        private async void loadSensorDataBtn_Click(object sender, EventArgs e)
		{
			// Variable to hold input text data
			String line;

			// Breaking the string apart
			char[] delimiterChars = { ' ' };
			String[] brokenEntryString;

			// Conversion temp types
			DateTime date;
			DateTime time;
            DateTime dateTime;
            string dateTimeString = "";
			int data;
            int totalCount = 0;
            
            // Get the total amount of entries in the text file to pass to progress bar
            for (int i = 0; i < 9; i++)
            {
                totalCount = getTotalEntryCount(getCurrentSensorDataPath(i));
                Console.WriteLine("{0} has {1} entries", getCurrentSensorDataPath(i), totalCount);
            }

            // Update progress bar to total amount of entries
            dataInputProgress.Maximum = totalCount;
            dataInputProgress.Minimum = 0;
            dataInputProgress.Value = 0;

            string sensorNameString;

			// Connecting to the Database
			string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Anthony\\Documents\\Visual Studio 2015\\Projects\\SensorDataGraphing\\SensorDataGraphing\\SensorData.mdf;Integrated Security=True;";

            sensorSavedLabel.Text = "Currently saving data...";
            sensorSavedLabel.Refresh();

            for (int i = 0; i < 9; i++)
            {
                dataInputProgress.Value = 0;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(getSaveAllQuery(i), connection))
                    {
                        try
                        {
                            using (StreamReader sr = new StreamReader(getCurrentSensorDataPath(i)))
                            {
                                while ((line = await sr.ReadLineAsync()) != null)
                                {
                                    cmd.Parameters.Clear();
                                    // Break apart the line
                                    brokenEntryString = line.Split(delimiterChars);
                                    // Do conversion from the broken up string
                                    date = Convert.ToDateTime(brokenEntryString[0]);
                                    time = Convert.ToDateTime(brokenEntryString[1]);
                                    data = Convert.ToInt32(brokenEntryString[2]);
                                    dateTimeString = brokenEntryString[0] + " " + brokenEntryString[1];
                                    dateTime = Convert.ToDateTime(dateTimeString);
                                    // Insert into table
                                    cmd.CommandText = getInsertIntoTableQuery(i);
                                    cmd.Parameters.AddWithValue("@Date", date);
                                    cmd.Parameters.AddWithValue("@Time", time);
                                    cmd.Parameters.AddWithValue("@Data", data);
                                    cmd.Parameters.AddWithValue("@DateTime", dateTimeString);
                                    connection.Open();
                                    cmd.ExecuteNonQuery();
                                    connection.Close();

                                    // Update progress bar
                                    dataInputProgress.Value++;
                                }
                                sr.Dispose();
                            }
                            Console.WriteLine("Sensor path {0} saved.", getCurrentSensorDataPath(i));
                            if (i == 8)
                            {
                                sensorNameString = getSeriesName(i) + " data saved.\nAll data has been saved.";
                            } else
                            {
                                sensorNameString = getSeriesName(i) + " data saved.";
                            }
                            sensorSavedLabel.Text = sensorNameString;
                            sensorSavedLabel.Refresh();
                            cmd.Dispose();
                            connection.Dispose();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.GetType().Name);
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
            }
            dataInputProgress.Minimum = 0;
            dataInputProgress.Value = 0;
        }

        private void resetTableBtn_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Anthony\\Documents\\Visual Studio 2015\\Projects\\SensorDataGraphing\\SensorDataGraphing\\SensorData.mdf;Integrated Security=True;";
            for (int i = 0; i < 9; i++)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(getDeleteAllQuery(i), connection))
                    {
                        try
                        {
                            connection.Open();
                            cmd.ExecuteNonQuery();
                            connection.Close();
                            cmd.Dispose();
                            sensorSavedLabel.Text = "All data reset 0 entries.";
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.GetType().Name);
                            Console.WriteLine(ex.Message);
                        }

                    }
                }
            }
            sensorSavedLabel.Text = "All data cleared.";
        }

        private void amountBtn_Click(object sender, EventArgs e)
        {
            int counter = 0;
            string totalAmountString = "";
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Anthony\\Documents\\Visual Studio 2015\\Projects\\SensorDataGraphing\\SensorDataGraphing\\SensorData.mdf;Integrated Security=True;";
            for (int i = 0; i < 9; i++)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(getTotalAmountQuery(i), connection))
                    {
                        try
                        {
                            connection.Open();
                            counter = (int)cmd.ExecuteScalar();
                            connection.Close();
                            Console.WriteLine("There are {0} entries from sensor {1}.", counter, i);
                            cmd.Dispose();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.GetType().Name);
                            Console.WriteLine(ex.Message);
                        }

                    }
                }
            }
            totalAmountString = "Per sensor entries = " + counter + ". Total amount of entries = " + counter * 9 + ".";
            sensorSavedLabel.Text = totalAmountString;
        }

        private void startDateTimePicker_CloseUp(object sender, EventArgs e)
        {
            Console.WriteLine("The start date selected is {0}", startDateTimePicker.Value.ToShortDateString());
        }

        private void endDateTimePicker_CloseUp(object sender, EventArgs e)
        {
            Console.WriteLine("The end date selected is {0}", endDateTimePicker.Value.ToShortDateString());
        }

        private void graphCheckedBtn_Click(object sender, EventArgs e)
        {
            // For check boxes
            int[] sensorCheckedArray = new int[sensorCheckBox.Items.Count];
            int counter = 0;
            long startEntry;
            long endEntry;

            // Date and time information
            DateTime endDatePlusOne;

            foreach (int indexChecked in sensorCheckBox.CheckedIndices)
            {
                Console.WriteLine("Index#: " + indexChecked.ToString() + ", is checked. Checked state is:" + sensorCheckBox.GetItemCheckState(indexChecked).ToString() + ".");
                if (sensorCheckBox.GetItemCheckState(indexChecked).ToString() == "Checked")
                {
                    sensorCheckedArray[counter] = indexChecked;
                    Console.WriteLine("Current Counter {0} and current index checked {1}.", counter, indexChecked);
                    counter++;
                }
            }
            
            // Get an start entry position and an end position
            // First and last entry will be the same for each sensor since they are all saved at the same time by the Arduino program
            startEntry = getEntryPositions(Convert.ToDateTime(startDateTimePicker.Value.ToShortDateString()));
            endEntry = getEntryPositions(Convert.ToDateTime(endDateTimePicker.Value.ToShortDateString()));

            // If the days are equal, need to get the next day minus one entry since the database retrieval will stop at the same entryId since the dates are the same
            if(Convert.ToDateTime(startDateTimePicker.Value.ToShortDateString()) == Convert.ToDateTime(endDateTimePicker.Value.ToShortDateString()))
            {
                endDatePlusOne = endDateTimePicker.Value;
                endDatePlusOne = endDatePlusOne.AddDays(1);
                // endEntry = getEntryPositions(Convert.ToDateTime(endDateTimePicker.Value.ToShortDateString()));
                endEntry = getEntryPositions(Convert.ToDateTime(endDatePlusOne.ToShortDateString()));
                endEntry = endEntry - 1;
            }

            Console.WriteLine("startEntry = {0} and endEntry = {1}", startEntry, endEntry);

            graphData(sensorCheckedArray, counter, startEntry, endEntry);
        }

        private void graphData(int[] checkedSensors, int sensorsClicked, long entryStart, long entryEnd)
		{
            // Clear chart first
            sensorChart.ChartAreas.Clear();
            sensorChart.Series.Clear();
            sensorChart.Legends.Clear();

            var chartArea = new ChartArea();
            chartArea.Position = new ElementPosition(0, 0, 89, 92);
            chartArea.AxisX.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisX.MajorGrid.LineWidth = 2;
            chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisY.MajorGrid.LineWidth = 2;
            chartArea.AxisX.Title = "Date";
            chartArea.AxisY.Title = "Data";
            chartArea.Position.Width = 100;
            sensorChart.ChartAreas.Add(chartArea);

            sensorChart.Legends.Add("sensor_title");

            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Anthony\\Documents\\Visual Studio 2015\\Projects\\SensorDataGraphing\\SensorDataGraphing\\SensorData.mdf;Integrated Security=True;";

            string dataSetTableString = "Table";
            // Table for each sensor entry
            DataSet sensorDataSet = new DataSet();
            for (int i = 0; i < sensorsClicked; i++)
            {
                sensorDataSet.Tables.Add();
            }

            for (int i = 0; i < sensorsClicked; i++)
			{
                var series = new Series();
                Console.WriteLine("The passed sensor indicies" + checkedSensors[i].ToString());

                series.Name = getSeriesName(checkedSensors[i]);
                series.ChartType = SeriesChartType.Line;
                switch (checkedSensors[i])
                {
                    case 0:
                        series.Color = Color.Blue;
                        break;
                    case 1:
                        series.Color = Color.Red;
                        break;
                    case 2:
                        series.Color = Color.Orange;
                        break;
                    case 3:
                        series.Color = Color.Purple;
                        break;
                    case 4:
                        series.Color = Color.Black;
                        break;
                    case 5:
                        series.Color = Color.Green;
                        break;
                    case 6:
                        series.Color = Color.Teal;
                        break;
                    case 7:
                        series.Color = Color.LimeGreen;
                        break;
                    case 8:
                        series.Color = Color.DeepPink;
                        break;
                    default:
                        break;
                }
                series.BorderWidth = 3;
                sensorChart.Series.Add(series);
                sensorChart.Series[getSeriesName(checkedSensors[i])].ChartArea = "ChartArea1";

                Console.WriteLine("entryStart = {0} entryEnd = {1}", entryStart, entryEnd);

                string query = getGraphQuery(checkedSensors[i]);
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlDataAdapter adp = new SqlDataAdapter(query, connection))
                    {
                        try
                        {
                            // Fill temporary table with data
                            adp.SelectCommand.Parameters.AddWithValue("@entry", entryStart);
                            adp.SelectCommand.Parameters.AddWithValue("@end", entryEnd);
                            dataSetTableString = dataSetTableString + (i + 1);
                            adp.Fill(sensorDataSet.Tables[dataSetTableString]);
                            
                            sensorChart.DataSource = dataSetTableString;

                            sensorChart.Legends.Add(getSeriesName(checkedSensors[i]));

                            sensorChart.Series[getSeriesName(checkedSensors[i])].Points.DataBindXY(sensorDataSet.Tables[dataSetTableString].DefaultView, "DateTime", sensorDataSet.Tables[dataSetTableString].DefaultView, "Data");
                            adp.Dispose();
                            dataSetTableString = "Table"; 
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.GetType().Name);
                            Console.WriteLine(ex.Message);                          
                        }
                    }
                    connection.Close();
                    sensorChart.Legends[0].IsDockedInsideChartArea = false;
                    sensorChart.Legends[0].Docking = Docking.Bottom;                 
                }
            }
        }

        private long getEntryPositions(DateTime entryIDDate)
        {
            long entryPosition = 0;

            // EntryID start and end positions will be the same for all the sensors saved in the database.
            // No need to get an entry position for each
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Anthony\\Documents\\Visual Studio 2015\\Projects\\SensorDataGraphing\\SensorDataGraphing\\SensorData.mdf;Integrated Security=True;";
            string query = "SELECT EntryID FROM dbo.sensor0Table WHERE Date = @currentDate;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    try
                    {
                        cmd.Parameters.AddWithValue("@currentDate", entryIDDate);
                        connection.Open();
                        entryPosition = (int)cmd.ExecuteScalar();
                        connection.Close();
                    } catch (Exception ex)
                    {
                        Console.WriteLine(ex.GetType().Name);
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            return entryPosition;
        }

        private int getTotalEntryCount(string sensorDataPath)
        {
            int entries = 0;
            string line;
            using (StreamReader sr = new StreamReader(sensorDataPath))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    entries++;
                }
                sr.Dispose();
            }
            return entries;
        }

        /*
        * All query string information
        */
        private string getCurrentSensorDataPath(int sensorNumber)
        {
            switch (sensorNumber)
            {
                case 0:
                    return "C:\\Users\\Anthony\\Documents\\SENDATA\\SEN0.txt";
                case 1:
                    return "C:\\Users\\Anthony\\Documents\\SENDATA\\SEN1.txt";
                case 2:
                    return "C:\\Users\\Anthony\\Documents\\SENDATA\\SEN2.txt";
                case 3:
                    return "C:\\Users\\Anthony\\Documents\\SENDATA\\SEN3.txt";
                case 4:
                    return "C:\\Users\\Anthony\\Documents\\SENDATA\\SEN4.txt";
                case 5:
                    return "C:\\Users\\Anthony\\Documents\\SENDATA\\SEN5.txt";
                case 6:
                    return "C:\\Users\\Anthony\\Documents\\SENDATA\\SEN6.txt";
                case 7:
                    return "C:\\Users\\Anthony\\Documents\\SENDATA\\SEN7.txt";
                case 8:
                    return "C:\\Users\\Anthony\\Documents\\SENDATA\\SEN8.txt";
                default:
                    return "";
            }
        }

        private string getSaveAllQuery(int sensorNumber)
        {
            switch (sensorNumber)
            {
                case 0:
                    return "SELECT Date, Time, Data, DateTime FROM dbo.sensor0Table;";
                case 1:
                    return "SELECT Date, Time, Data, DateTime FROM dbo.sensor1Table;";
                case 2:
                    return "SELECT Date, Time, Data, DateTime FROM dbo.sensor2Table;";
                case 3:
                    return "SELECT Date, Time, Data, DateTime FROM dbo.sensor3Table;";
                case 4:
                    return "SELECT Date, Time, Data, DateTime FROM dbo.sensor4Table;";
                case 5:
                    return "SELECT Date, Time, Data, DateTime FROM dbo.sensor5Table;";
                case 6:
                    return "SELECT Date, Time, Data, DateTime FROM dbo.sensor6Table;";
                case 7:
                    return "SELECT Date, Time, Data, DateTime FROM dbo.sensor7Table;";
                case 8:
                    return "SELECT Date, Time, Data, DateTime FROM dbo.sensor8Table;";
                default:
                    return "";
            }
        }

        private string getInsertIntoTableQuery(int sensorNumber)
        {
            switch (sensorNumber)
            {
                case 0:
                    return "INSERT INTO dbo.sensor0Table (Date, Time, Data, DateTime) values (@Date, @Time, @Data, @DateTime);";
                case 1:
                    return "INSERT INTO dbo.sensor1Table (Date, Time, Data, DateTime) values (@Date, @Time, @Data, @DateTime);";
                case 2:
                    return "INSERT INTO dbo.sensor2Table (Date, Time, Data, DateTime) values (@Date, @Time, @Data, @DateTime);";
                case 3:
                    return "INSERT INTO dbo.sensor3Table (Date, Time, Data, DateTime) values (@Date, @Time, @Data, @DateTime);";
                case 4:
                    return "INSERT INTO dbo.sensor4Table (Date, Time, Data, DateTime) values (@Date, @Time, @Data, @DateTime);";
                case 5:
                    return "INSERT INTO dbo.sensor5Table (Date, Time, Data, DateTime) values (@Date, @Time, @Data, @DateTime);";
                case 6:
                    return "INSERT INTO dbo.sensor6Table (Date, Time, Data, DateTime) values (@Date, @Time, @Data, @DateTime);";
                case 7:
                    return "INSERT INTO dbo.sensor7Table (Date, Time, Data, DateTime) values (@Date, @Time, @Data, @DateTime);";
                case 8:
                    return "INSERT INTO dbo.sensor8Table (Date, Time, Data, DateTime) values (@Date, @Time, @Data, @DateTime);";
                default:
                    return "";
            }
        }

        private string getDeleteAllQuery(int sensorNumber)
        {
            switch (sensorNumber)
            {
                case 0:
                    return "TRUNCATE TABLE dbo.sensor0Table;";
                case 1:
                    return "TRUNCATE TABLE dbo.sensor1Table;";
                case 2:
                    return "TRUNCATE TABLE dbo.sensor2Table;";
                case 3:
                    return "TRUNCATE TABLE dbo.sensor3Table;";
                case 4:
                    return "TRUNCATE TABLE dbo.sensor4Table;";
                case 5:
                    return "TRUNCATE TABLE dbo.sensor5Table;";
                case 6:
                    return "TRUNCATE TABLE dbo.sensor6Table;";
                case 7:
                    return "TRUNCATE TABLE dbo.sensor7Table;";
                case 8:
                    return "TRUNCATE TABLE dbo.sensor8Table;";
                default:
                    return "";
            }
        }

        private string getTotalAmountQuery(int sensorNumber)
        {
            switch (sensorNumber)
            {
                case 0:
                    return "SELECT COUNT(*) FROM dbo.sensor0Table;";
                case 1:
                    return "SELECT COUNT(*) FROM dbo.sensor1Table;";
                case 2:
                    return "SELECT COUNT(*) FROM dbo.sensor2Table;";
                case 3:
                    return "SELECT COUNT(*) FROM dbo.sensor3Table;";
                case 4:
                    return "SELECT COUNT(*) FROM dbo.sensor4Table;";
                case 5:
                    return "SELECT COUNT(*) FROM dbo.sensor5Table;";
                case 6:
                    return "SELECT COUNT(*) FROM dbo.sensor6Table;";
                case 7:
                    return "SELECT COUNT(*) FROM dbo.sensor7Table;";
                case 8:
                    return "SELECT COUNT(*) FROM dbo.sensor8Table;";
                default:
                    return "";
            }
        }

        private string getSeriesName(int sensorNumber)
        {
            switch (sensorNumber)
            {
                case 0:
                    return "Propane";
                case 1:
                    return "Carbon Monoxide (CO)";
                case 2:
                    return "Smoke";
                case 3:
                    return "Liquid Petroleum Gas (LPG)";
                case 4:
                    return "Methane (CH4)";
                case 5:
                    return "Hydrogen Gas (H2)";
                case 6:
                    return "Alcohol";
                case 7:
                    return "Temperature";
                case 8:
                    return "Humidity";
                default:
                    return "";
            }
        }

        private string getGraphQuery(int sensorNumber)
        {
            switch (sensorNumber)
            {
                case 0:
                    return "SELECT Data, DateTime FROM dbo.sensor0Table WHERE EntryID >= @entry AND EntryID <= @end;";
                case 1:
                    return "SELECT Data, DateTime FROM dbo.sensor1Table WHERE EntryID >= @entry AND EntryID <= @end;";
                case 2:
                    return "SELECT Data, DateTime FROM dbo.sensor2Table WHERE EntryID >= @entry AND EntryID <= @end;";
                case 3:
                    return "SELECT Data, DateTime FROM dbo.sensor3Table WHERE EntryID >= @entry AND EntryID <= @end;";
                case 4:
                    return "SELECT Data, DateTime FROM dbo.sensor4Table WHERE EntryID >= @entry AND EntryID <= @end;";
                case 5:
                    return "SELECT Data, DateTime FROM dbo.sensor5Table WHERE EntryID >= @entry AND EntryID <= @end;";
                case 6:
                    return "SELECT Data, DateTime FROM dbo.sensor6Table WHERE EntryID >= @entry AND EntryID <= @end;";
                case 7:
                    return "SELECT Data, DateTime FROM dbo.sensor7Table WHERE EntryID >= @entry AND EntryID <= @end;";
                case 8:
                    return "SELECT Data, DateTime FROM dbo.sensor8Table WHERE EntryID >= @entry AND EntryID <= @end;";
                default:
                    return "";
            }
        }
    }
}
