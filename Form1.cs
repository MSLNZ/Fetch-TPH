using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Fetch_TPH_From_DateTime
{
    public partial class FetchTPHFromDateTime : Form
    {
        private string[] filelines;
        private string outputfilepath = @"C:\Users\Public\Documents\";
        private string temperaturedir;
        private string pressuredir;
        private string humiditydir;
        public FetchTPHFromDateTime()
        {
            InitializeComponent();
        }

        private void DateTimeButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Text File";
            theDialog.Filter = "TXT files|*.txt";
            try
            {
                theDialog.InitialDirectory = @"I:\MSL\Private\LENGTH\";



                if (theDialog.ShowDialog() == DialogResult.OK)
                {
                    string filename = theDialog.FileName;
                    filelines = File.ReadAllLines(filename);

                    foreach (string line in filelines)
                    {
                        DateTimeRichTextBox.AppendText(line);
                        DateTimeRichTextBox.AppendText("\n");
                    }
                }
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("Cannot Access Directory: "+ @"I:\MSL\Private\LENGTH\");
            }
            
        }

        private void ChooseOutputTextFile_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.SelectedPath = @"I:\MSL\Private\LENGTH\";
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    outputfilepath = fbd.SelectedPath;
                    OutputFileTextBox.Text = outputfilepath;
                }
            }


        }

        private void TemperatureComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (TemperatureComboBox.SelectedItem)
            {
                case "Hilger Lab":
                    temperaturedir = @"I:\MSL\Private\LENGTH\Temperature Monitoring Data\Hilger Lab";
                    break;
                case "Laser Lab":
                    temperaturedir = @"I:\MSL\Private\LENGTH\Temperature Monitoring Data\Laser Lab";
                    break;
                case "Long Room":
                    temperaturedir = @"I:\MSL\Private\LENGTH\Temperature Monitoring Data\Long Room";
                    break;
                case "Leitz Room":
                    temperaturedir = @"I:\MSL\Private\LENGTH\Temperature Monitoring Data\Leitz Lab";
                    break;
                case "Tunnel":
                    temperaturedir = @"I:\MSL\Private\LENGTH\Temperature Monitoring Data\Tunnel";
                    break;
                default:
                    temperaturedir = @"I:\MSL\Private\LENGTH\Temperature Monitoring Data\Hilger Lab";
                    break;
            }
        }

        private void PressureComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (PressureComboBox.SelectedItem)
            {
                case "Robertson Ground Floor":
                    pressuredir = @"I:\MSL\Private\LENGTH\Pressure Monitoring Data\Ground_floor_at_1m_height";
                    break;
                case "Tunnel":
                    pressuredir = @"I:\MSL\Private\LENGTH\Pressure Monitoring Data\Tunnel";
                    break;
                default:
                    pressuredir = @"I:\MSL\Private\LENGTH\Pressure Monitoring Data\Ground_floor_at_1m_height";
                    break;
            }
        }

        private void HumidityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (HumidityComboBox.SelectedItem)
            {
                case "Hilger Lab":
                    humiditydir = @"I:\MSL\Private\LENGTH\Humidity Monitoring Data\HILGERLAB";
                    break;
                case "Laser Lab":
                    humiditydir = @"I:\MSL\Private\LENGTH\Humidity Monitoring Data\LASERLAB";
                    break;
                case "Long Room":
                    humiditydir = @"I:\MSL\Private\LENGTH\Humidity Monitoring Data\LONGROOM";
                    break;
                case "Leitz Room":
                    humiditydir = @"I:\MSL\Private\LENGTH\Humidity Monitoring Data\LEITZROOM";
                    break;
                case "Tunnel":
                    humiditydir = @"I:\MSL\Private\LENGTH\Humidity Monitoring Data\TUNNEL";
                    break;
                default:
                    humiditydir = @"I:\MSL\Private\LENGTH\Humidity Monitoring Data\HILGERLAB";
                    break;
            }
        }

        private void WriteData_Click(object sender, EventArgs e)
        {
            //open a file for writing the date to.
            StreamWriter writer;
            
            using (writer = File.CreateText(outputfilepath + @"\"+"tph.txt"))
            {


                bool headingwritten = false;
                int num_elements = 0;

                if(filelines == null)
                {
                    MessageBox.Show("Choose a Text File with some DateTimes in it");
                    return;
                }

                //inspect each datetime and find all files from the previously selected laboratory fields
                foreach (string datetimestring in filelines)
                {

                    num_elements++;
                    DateTime date;
                    try { date = Convert.ToDateTime(datetimestring); }
                    catch (System.FormatException) { return;  }

                    int month = date.Month;
                    int year = date.Year;
                    string dir = temperaturedir;
                    if (TemperatureComboBox.Text != "None") dir = dir + @"\" + year.ToString() + @"\" + year.ToString() + "-" + month.ToString() + @"\";

                    string dir2 = pressuredir;
                    dir2 = dir2 + @"\" + year.ToString() + @"\" + year.ToString() + "-" + month.ToString() + @"\";

                    string dir3 = humiditydir;
                    dir3 = dir3 + @"\" + year.ToString() + @"\" + year.ToString() + "-" + month.ToString() + @"\";



                    //write the first two element of the heading line if not already written
                    if (!headingwritten) writer.Write("Target DateTime ");

                    string[] temperaturefiles = null;
                    FindTemperature(dir, headingwritten, ref writer, ref temperaturefiles);
                    string[] pressurefiles = null;
                    FindPressure(dir2, headingwritten, ref writer, ref pressurefiles);
                    string[] humidityfiles = null;
                    FindHumidity(dir3, headingwritten, ref writer, ref humidityfiles);

                    if (!headingwritten) writer.WriteLine();//finish heading
                    //heading finished
                    headingwritten = true;

                    //write the target date
                    writer.Write(date.ToString());

                    int temperaturelength = 0;
                    if (temperaturefiles == null) temperaturelength = 0;
                    else temperaturelength = temperaturefiles.Length;

                    int pressurelength = 0;
                    if (pressurefiles == null) pressurelength = 0;
                    else pressurelength = pressurefiles.Length;

                    int humiditylength = 0;
                    if (humidityfiles == null) humiditylength = 0;
                    else humiditylength = humidityfiles.Length;

                    string[] allfiles = new string[temperaturelength + pressurelength + humiditylength];

                    if (temperaturefiles != null) temperaturefiles.CopyTo(allfiles, 0);
                    if (pressurefiles != null) pressurefiles.CopyTo(allfiles, temperaturelength);
                    if (humidityfiles != null) humidityfiles.CopyTo(allfiles, pressurelength + temperaturelength);
                    if (allfiles == null) return; //no files are found

                    int fileindex = 0;
                    short filetype = 0;
                    //find the values to write for each file in the search directory
                    foreach (string fname in allfiles)
                    {
                        StreamReader reader = null;
                        if (fileindex < temperaturelength)
                        {
                            filetype = 0;
                            try
                            {
                                reader = new StreamReader(dir + fname);
                            }
                            catch (IOException)
                            {
                                MessageBox.Show("Temperature file in use");
                            }
                        }
                        else if (fileindex >= temperaturelength && fileindex < (pressurelength + temperaturelength))
                        {
                            filetype = 1;
                            try
                            {
                                reader = new StreamReader(dir2 + fname);
                            }
                            catch (IOException)
                            {
                                MessageBox.Show("pressure file in use!");
                                break;
                            }
                        }
                        else
                        {
                            filetype = 2;

                            try
                            {
                                reader = new StreamReader(dir3 + fname);
                            }
                            catch (IOException)
                            {
                                MessageBox.Show("Humidity file in use!");
                                break;
                            }
                        }

                        bool first_reading = true;

                        DateTime previousdate = DateTime.Now;
                        string[] values = new string[1];
                        string[] previousvalues = null;
                        DateTime currentdate;


                        while (!reader.EndOfStream)
                        {
                            string line = reader.ReadLine();

                            bool a = !line.Equals("Automatically Generated File!");
                            bool b = !line.Equals("");
                            if (a && b)
                            {
                                try
                                {
                                    int index = 0;
                                    while (true)
                                    {
                                        int comma_index = line.IndexOf(",");
                                        if (comma_index == -1)
                                        {
                                            values[index] = line;
                                            break;
                                        }
                                        values[index] = line.Substring(0, comma_index);
                                        Array.Resize(ref values, index + 2);
                                        //consume the part of the string we have already checked
                                        line = line.Remove(0, comma_index + 1);
                                        index++;
                                    }

                                    //the datetime should always be the third element (zero-based) in the array for temperature files and the second element for pressure and humidity files.
                                    try
                                    {
                                        if (filetype == 0) currentdate = Convert.ToDateTime(values[2]);
                                        else currentdate = Convert.ToDateTime(values[1]);
                                    }
                                    catch (IndexOutOfRangeException)
                                    {
                                        break;
                                    }

                                    //if we have two adjacent dates then compare them to find the appropriate number.
                                    if (!first_reading)
                                    {
                                        int first_comp;
                                        int second_comp;


                                        first_comp = DateTime.Compare(date, currentdate);
                                        second_comp = DateTime.Compare(date, previousdate);

                                        //we will choose whichever date is closest to the reference date 'date'.
                                        TimeSpan span1 = currentdate.Subtract(date);
                                        TimeSpan span2 = date.Subtract(previousdate);

                                        if (first_comp <= 0 && second_comp >= 0)
                                        {
                                            //the reference date was inbetween the current date and the previous date.


                                            if (span1 >= span2)
                                            {
                                                //span 2 is closer
                                                //write the value
                                                writer.Write(", " + previousvalues[0].ToString());

                                                //write the datetime the values was fetched
                                                if (filetype == 0) writer.Write(", " + previousvalues[2].ToString());
                                                else writer.Write(", " + previousvalues[1].ToString());
                                                break;
                                            }
                                            else
                                            {
                                                //span 1 is closer
                                                //write the value
                                                writer.Write(", " + values[0].ToString());

                                                //write the date the value was written
                                                if (filetype == 0) writer.Write(", " + values[2].ToString());
                                                else writer.Write(", " + values[1].ToString());
                                                break;
                                            }
                                        }
                                        //this occurs when the target date is prior to all dates in the file
                                        else if (first_comp < 0 && second_comp < 0)
                                        {

                                            //span 2 is closer
                                            //write that the value was not found.
                                            writer.Write(", -1");

                                            //write the values datetime
                                            writer.Write(", Not Found");
                                            break;
                                        }
                                        else if (reader.EndOfStream)
                                        {
                                            //write that the value was not found.
                                            writer.Write(", -1");

                                            //write the values datetime
                                            writer.Write(", Not Found");


                                        }
                                    }

                                }
                                catch (FormatException)
                                {
                                    MessageBox.Show("Invalid File Format");
                                    reader.Close();
                                    break;
                                }

                                previousvalues = new String[values.Length];
                                values.CopyTo(previousvalues, 0);
                                previousdate = currentdate;
                                first_reading = false;
                            }
                        }
                        fileindex++;
                    }
                    writer.WriteLine();
                    }
                
            }
            writer.Close();
        }
        public void FindTemperature(string dir,bool headingwritten,ref StreamWriter writer,ref string[] temperaturefiles)
        {
           
            try
            {
                temperaturefiles = Directory.GetFiles(dir, "*.txt", SearchOption.TopDirectoryOnly);
            }
            catch (DirectoryNotFoundException)
            {
                if(!headingwritten) writer.Write(", Initial File Not Found!, Date Found");
                return;
            }
            for (int i = 0; i < temperaturefiles.Length; i++)
            {
                temperaturefiles[i] = Path.GetFileName(temperaturefiles[i]);
            }
            if (!headingwritten)
            {


                foreach (string fname in temperaturefiles)
                {
                    writer.Write(", " + fname.ToString() + ", Date Found");
                }
            }
        }
        public void FindPressure(string dir2, bool headingwritten, ref StreamWriter writer,ref string[] pressurefiles)
        {
            
            try
            {
                pressurefiles = Directory.GetFiles(dir2, "*.txt", SearchOption.TopDirectoryOnly);
            }
            catch (DirectoryNotFoundException)
            {
                if (!headingwritten) writer.Write(", Initial File Not Found!, Date Found");
                return;
            }
            for (int i = 0; i < pressurefiles.Length; i++)
            {
                pressurefiles[i] = Path.GetFileName(pressurefiles[i]);
            }
            if (!headingwritten)
            {
                foreach (string fname in pressurefiles)
                {
                    writer.Write(", " + fname.ToString() + ", Date Found");
                }
            }
        }
        public void FindHumidity(string dir3, bool headingwritten, ref StreamWriter writer, ref string[] humidityfiles)
        {
            
            try
            {
                humidityfiles = Directory.GetFiles(dir3, "*.txt", SearchOption.TopDirectoryOnly);
            }
            catch (DirectoryNotFoundException)
            {
                if (!headingwritten) writer.Write(", Initial File Not Found!, Date Found");
                return;
            }
            for (int i = 0; i < humidityfiles.Length; i++)
            {
                humidityfiles[i] = Path.GetFileName(humidityfiles[i]);
            }
            if (!headingwritten)
            {
                foreach (string fname in humidityfiles)
                {
                    writer.Write(", " + fname.ToString() + ", Date Found");
                }
            }
        }
    }
}
