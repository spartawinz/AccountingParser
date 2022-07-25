using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace AccountingParser
{
    public partial class Form1 : Form
    {
        private List<string> prnList = new List<string>();
        private int entries = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void OpenFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void InputFileBttn_Click(object sender, EventArgs e)
        {
            csvFile.Filter = "CSV Files (CSV)|*.csv";
            DialogResult result = csvFile.ShowDialog();
            if (result == DialogResult.OK)
            {
                csvFileTxt.Text = csvFile.FileName;
            }
            Console.WriteLine(result);
        }

        private void OutputFileBttn_Click(object sender, EventArgs e)
        {
            outputFile.Filter = "PRN Files (PRN)|*.prn";
            DialogResult result = outputFile.ShowDialog();
            if (result == DialogResult.OK)
            {
                outputFileTxt.Text = outputFile.FileName;
            }
            Console.WriteLine(result);
        }

        private void OKBttn_Click(object sender, EventArgs e)
        {
            clearError();
            if (csvFileTxt.Text == "")
            {
                errLbl.Text = "Missing CSV File input location.";
                return;
            }
            if (outputFileTxt.Text == "")
            {
                errLbl.Text = "Missing output location.";
                return;
            }
            List<string> data = new List<string>();
            //returns if fails.
            if(!getData(data,csvFileTxt.Text))
            {
                return;
            }
            //if empty it returns
            if (data.Count == 0)
            {
                return;
            }
            // if fails returns
            if (!buildString(data))
            {
                return;
            }
            //if fails returns
            if(!writeFile())
            {
                return;
            }
            popupForm form = new popupForm();
            form.Show();
            clearEverything();
            showEntries();
        }

        private void CancelBttn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //clears error label
        private void clearError()
        {
            errLbl.Text = "";
        }
        public void clearEverything()
        {
            //clears fields
            csvFileTxt.Text = "";
            outputFileTxt.Text = "";
            clearError();
        }
        //grabs data from input csv file and parses it into a list.
        private bool getData(List<string> d, string path)
        {
            try
            {
                var reader = new StreamReader(File.OpenRead(path));
            
                List<String> lines = new List<string>();
                //updates error label if CSV is empty and returns.
                if (reader.EndOfStream)
                {
                    errLbl.Text = "CSV is empty.";
                    reader.Close();
                    return false;
                }
                //skips column names
                reader.ReadLine();
                //reads lines into a list for further changes.
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    lines.Add(line);
                }
                reader.Close();
                //takes lines and splits them based on commas
                foreach (var x in lines)
                {
                    string[] hold = x.Split(',');
                    for (int i = 0; i < hold.Length; i++)
                    {
                        d.Add(hold[i]);
                    }
                }
                Console.WriteLine(d.Count);
                return true;
            }
            catch (Exception e)
            {
                errLbl.Text = "Please close the file before continuing.";
                Console.WriteLine(e.Message);
                return false;
            }
        }
        //builds the lines for the PRN file.
        private bool buildString(List<string> d)
        {
            try {
                int count = 1;
                for (int i = 0; i < d.Count; i++)
                {
                    string line = "S";
                    //make
                    if (d[i].Trim().Length == 5)
                    {
                        line += d[i].ToUpper();
                        i++;
                    }
                    else
                    {
                        if (d[i].Length > 5)
                        {
                            errLbl.Text = "make not valid length at line number " + count.ToString();
                            return false;
                        }
                        else
                        {
                            line += d[i].Trim().PadRight(5).ToUpper();
                            i++;
                        }
                    }
                    //year
                    if (d[i].Trim().Length == 4)
                    {
                        line += d[i].Trim();
                        i++;
                    }
                    else
                    {
                        errLbl.Text = "Year not valid length at line number " + count.ToString();
                        return false;
                    }
                    //VIN
                    if (d[i].Trim().Length == 21)
                    {
                        line += d[i].ToUpper();
                        i++;
                    }
                    else
                    {
                        if (d[i].Trim().Length > 21)
                        {
                            errLbl.Text = "VIN not valid length at line number " + count.ToString();
                            return false;
                        }
                        else
                        {
                            line += d[i].Trim().PadRight(21).ToUpper();
                            i++;
                        }
                    }
                    //Model
                    if (d[i].Trim().Length == 10)
                    {
                        line += d[i].Trim().ToUpper();
                        i++;
                    }
                    else
                    {
                        if (d[i].Trim().Length < 10)
                        {
                            line += d[i].Trim().PadRight(10).ToUpper();
                            i++;
                        }
                        else
                        {
                            errLbl.Text = "Error on Model length at line number " + count.ToString();
                            return false;
                        }
                    }
                    //body style
                    if (d[i].Trim().Length == 5)
                    {
                        line += d[i].Trim().ToUpper();
                        i++;
                    }
                    else
                    {
                        if (d[i].Trim().Length < 5)
                        {
                            line += d[i].Trim().PadRight(5).ToUpper();
                            i++;
                        }
                        else
                        {
                            errLbl.Text = "Error on body style length at line number " + count.ToString();
                            return false;
                        }
                    }
                    //Odometer
                    if (d[i].Trim().Length == 6)
                    {
                        line += d[i].Trim();
                        i++;
                    }
                    else
                    {
                        if (d[i].Trim().Length < 6)
                        {
                            line += d[i].Trim().PadLeft(6,'0');
                            i++;
                        }
                        else
                        {
                            errLbl.Text = "Error on Odometer length at line number " + count.ToString();
                            return false;
                        }
                    }
                    //KOV
                    if (d[i].Trim().Length == 1)
                    {
                        line += d[i].Trim().ToUpper();
                        i++;
                    }
                    else
                    {
                        errLbl.Text = "Error on KOV length at line number " + count.ToString();
                        return false;
                    }
                    //TOS
                    if (d[i].Trim().Length == 1)
                    {
                        line += d[i].Trim().ToUpper();
                        i++;
                    }
                    else
                    {
                        errLbl.Text = "Error on TOS length at line number " + count.ToString();
                        return false;
                    }
                    //MO previous title number
                    if (d[i].Trim().Length == 10)
                    {
                        line += d[i].Trim().ToUpper();
                        i++;
                    }
                    else
                    {
                        if (d[i].Trim().Length < 10)
                        {
                            line += d[i].Trim().PadRight(10).ToUpper();
                            i++;
                        }
                        else
                        {
                            errLbl.Text = "Error on MO prev title number length at line number " + count.ToString();
                            return false;
                        }
                    }
                    //new/used
                    if (d[i].Trim().Length == 1)
                    {
                        line += d[i].Trim().ToUpper();
                        i++;
                    }
                    else
                    {
                        errLbl.Text = "Error on new/used length at line number " + count.ToString();
                        return false;
                    }
                    //date sold
                    //removes / if any and adds zeros were needed
                    if (d[i].Contains("/"))
                    {
                        string[] hold;
                        hold = d[i].Split('/');
                        if (hold[0].Length == 1)
                        {
                            hold[0] = hold[0].PadLeft(2, '0');
                        }
                        if (hold[1].Length == 1)
                        {
                            hold[1] = hold[1].PadLeft(2, '0');
                        }
                        d[i] = hold[0] + hold[1] + hold[2];
                    }
                    if (d[i].Trim().Length == 8)
                    {
                        line += d[i].Trim();
                        i++;
                    }
                    else
                    {
                        errLbl.Text = "Error on date sold length at line number " + count.ToString();
                        return false;
                    }
                    //purchaser name
                    if (d[i].Trim().Length == 50)
                    {
                        line += d[i].Trim().ToUpper();
                        i++;
                    }
                    else
                    {
                        if (d[i].Trim().Length < 50)
                        {
                            line += d[i].Trim().PadRight(50).ToUpper();
                            i++;
                        }
                        else
                        {
                            errLbl.Text = "Error on purchaser name length at line number " + count.ToString();
                            return false;
                        }
                    }
                    //purchaser address
                    if (d[i].Trim().Length == 38)
                    {
                        line += d[i].Trim().ToUpper();
                        i++;
                    }
                    else
                    {
                        if (d[i].Trim().Length < 38)
                        {
                            line += d[i].Trim().PadRight(38).ToUpper();
                            i++;
                        }
                        else
                        {
                            errLbl.Text = "Error on purchaser address length at line number " + count.ToString();
                            return false;
                        }
                    }
                    //purchaser city
                    if (d[i].Trim().Length == 15)
                    {
                        line += d[i].Trim().ToUpper();
                        i++;
                    }
                    else
                    {
                        if (d[i].Trim().Length < 15)
                        {
                            line += d[i].Trim().PadRight(15).ToUpper();
                            i++;
                        }
                        else
                        {
                            errLbl.Text = "Error on purchaser city length at line number " + count.ToString();
                            return false;
                        }
                    }
                    //purchaser state
                    if (d[i].Trim().Length == 2)
                    {
                        line += d[i].Trim().ToUpper();
                        i++;
                    }
                    else
                    {
                        errLbl.Text = "Error on purchaser state length at line number " + count.ToString();
                        return false;
                    }
                    //purchaser zip
                    if (d[i].Trim().Length == 5)
                    {
                        line += d[i].Trim().ToUpper();
                        i++;
                    }
                    else
                    {
                        errLbl.Text = "Error on zip length at line number " + count.ToString();
                        return false;
                    }
                    //purchaser dob
                    if (d[i].Contains("/"))
                    {
                        string[] hold;
                        hold = d[i].Split('/');
                        if (hold[0].Length == 1)
                        {
                            hold[0] = hold[0].PadLeft(2, '0');
                        }
                        if (hold[1].Length == 1)
                        {
                            hold[1] = hold[1].PadLeft(2, '0');
                        }
                        d[i] = hold[0] + hold[1] + hold[2];
                    }
                    if (d[i].Trim().Length == 8)
                    {
                        line += d[i].Trim();
                        i++;
                    }
                    else
                    {
                        if (d[i].Trim().Length == 0)
                        {
                            line += d[i].Trim().PadRight(8);
                            i++;
                        }
                        else
                        {
                            errLbl.Text = "Error on purchaser dob length at line number " + count.ToString();
                            return false;
                        }
                    }
                    //purchaser DLN
                    if (d[i].Trim().Length == 10)
                    {
                        line += d[i].Trim().ToUpper();
                        i++;
                    }
                    else
                    {
                        if (d[i].Trim().Length < 10)
                        {
                            line += d[i].Trim().PadRight(10).ToUpper();
                            i++;
                        }
                        else
                        {
                            errLbl.Text = "Error on purchaser DLN length at line number " + count.ToString();
                            return false;
                        }
                    }
                    //temporary permit
                    if (d[i].Trim().Length == 6)
                    {
                        line += d[i].Trim().ToUpper();
                        i++;
                    }
                    else
                    {
                        if (d[i].Trim().Length == 0)
                        {
                            line += d[i].Trim().PadRight(6).ToUpper();
                            i++;
                        }
                        else
                        {
                            errLbl.Text = "Error on Temporary permit length at line number " + count.ToString();
                            return false;
                        }
                    }
                    //sale price
                    //removes decimal if it can find one
                    if (d[i].Contains("."))
                    {
                        string[] hold;
                        hold = d[i].Split('.');
                        d[i] = hold[0] + hold[1];
                    }
                    if (d[i].Trim().Length == 8)
                    {
                        line += d[i].Trim();
                        i++;
                    }
                    else
                    {
                        if (d[i].Trim().Length < 8)
                        {
                            line += d[i].Trim().PadLeft(8, '0');
                            i++;
                        }
                        else
                        {
                            errLbl.Text = "Error on sale price length at line number " + count.ToString();
                            return false;
                        }
                    }
                    //trade-in
                    //removes decimal if it can find one
                    if (d[i].Contains("."))
                    {
                        string[] hold;
                        hold = d[i].Split('.');
                        d[i] = hold[0] + hold[1];
                    }
                    if (d[i].Trim().Length == 8)
                    {
                        line += d[i].Trim();
                        i++;
                    }
                    else
                    {
                        if (d[i].Trim().Length < 8)
                        {
                            line += d[i].Trim().PadLeft(8, '0');
                            i++;
                        }
                        else
                        {
                            errLbl.Text = "Error on trade-in length at line number " + count.ToString();
                            return false;
                        }
                    }
                    //rebate
                    //removes decimal if it can find one
                    if (d[i].Contains("."))
                    {
                        string[] hold;
                        hold = d[i].Split('.');
                        d[i] = hold[0] + hold[1];
                    }
                    if (d[i].Trim().Length == 8)
                    {
                        line += d[i].Trim();
                        i++;
                    }
                    else
                    {
                        if (d[i].Trim().Length < 8)
                        {
                            line += d[i].Trim().PadLeft(8, '0');
                            i++;
                        }
                        else
                        {
                            errLbl.Text = "Error on rebate length at line number " + count.ToString();
                            return false;
                        }
                    }
                    //other credit
                    //removes decimal if it can find one
                    if (d[i].Contains("."))
                    {
                        string[] hold;
                        hold = d[i].Split('.');
                        d[i] = hold[0] + hold[1];
                    }
                    if (d[i].Trim().Length == 8)
                    {
                        line += d[i].Trim();
                        i++;
                    }
                    else
                    {
                        if (d[i].Trim().Length < 8)
                        {
                            line += d[i].Trim().PadLeft(8, '0');
                            i++;
                        }
                        else
                        {
                            errLbl.Text = "Error on other credit length at line number " + count.ToString();
                            return false;
                        }
                    }
                    //net price
                    //removes decimal if it can find one
                    if (d[i].Contains("."))
                    {
                        string[] hold;
                        hold = d[i].Split('.');
                        d[i] = hold[0] + hold[1];
                    }
                    if (d[i].Trim().Length == 8)
                    {
                        line += d[i].Trim();
                        i++;
                    }
                    else
                    {
                        if (d[i].Trim().Length < 8)
                        {
                            if (d[i].Contains("-"))
                            {
                                string hold = d[i];
                                hold = hold.Trim().Remove(0);
                                hold = hold.Trim().PadLeft(7, '0');
                                hold = "-" + hold;
                                line += hold;
                                i++;
                            }
                            else
                            {
                                line += d[i].Trim().PadLeft(8, '0');
                                i++;
                            }
                        }
                        else
                        {
                            errLbl.Text = "Error on net price length at line number " + count.ToString();
                            return false;
                        }
                    }
                    //dealer number prefix
                    if (d[i].Trim().Length == 1)
                    {
                        line += d[i].Trim().ToUpper();
                        i++;
                    }
                    else
                    {
                        errLbl.Text = "Error on dealer number prefix length at line number " + count.ToString();
                        return false;
                    }
                    //dealer number
                    if (d[i].Trim().Length == 4)
                    {
                        line += d[i].Trim();
                        i++;
                    }
                    else
                    {
                        if (d[i].Trim().Length < 4)
                        {
                            line += d[i].Trim().PadLeft(4, '0');
                            i++;
                        }
                        else
                        {
                            errLbl.Text = "Error on dealer number length at line number " + count.ToString();
                            return false;
                        }
                    }
                    //dealer suffix
                    if (d[i].Trim().Length == 1)
                    {
                        line += d[i].Trim().ToUpper();
                        i++;
                    }
                    else
                    {
                        if (d[i].Trim().Length < 1)
                        {
                            line += d[i].Trim().PadRight(1);
                            i++;
                        }
                        else
                        {
                            errLbl.Text = "Error on dealer suffix length at line number " + count.ToString();
                            return false;
                        }
                    }
                    //first-lien
                    if (d[i].Trim().Length == 1)
                    {
                        line += d[i].Trim().ToUpper();
                        i++;
                    }
                    else
                    {
                        if(d[i].Trim().Length ==0)
                        {
                            line += d[i].Trim().ToUpper().PadRight(1);
                            i++;
                        }
                        else
                        {
                            errLbl.Text = "Error on first-lien length at line number " + count.ToString();
                            return false;
                        }
                    }
                    //lien date
                    //removes / if any and adds zeros were needed
                    if (d[i].Contains("/"))
                    {
                        string[] hold;
                        hold = d[i].Split('/');
                        if (hold[0].Length == 1)
                        {
                            hold[0] = hold[0].PadLeft(2, '0');
                        }
                        if (hold[1].Length == 1)
                        {
                            hold[1] = hold[1].PadLeft(2, '0');
                        }
                        d[i] = hold[0] + hold[1] + hold[2];
                    }
                    if (d[i].Trim().Length == 8)
                    {
                        line += d[i].Trim();
                        i++;
                    }
                    else
                    {
                        if (d[i].Trim().Length < 8)
                        {
                            line += d[i].Trim().ToUpper().PadRight(8);
                            i++;
                        }
                        else
                        {
                            errLbl.Text = "Error on lien length at line number " + count.ToString();
                            return false;
                        }
                    }
                    //lien holder phone
                    //removes - and ( and ) if any
                    if (d[i].Contains("-"))
                    {
                        string[] hold;
                        hold = d[i].Split('-');
                        d[i] = hold[0] + hold[1];
                    }
                    if (d[i].Contains("("))
                    {
                        string[] hold;
                        hold = d[i].Split('(');
                        d[i] = hold[0] + hold[1];
                    }
                    if (d[i].Contains(")"))
                    {
                        string[] hold;
                        hold = d[i].Split(')');
                        d[i] = hold[0] + hold[1];
                    }
                    if (d[i].Trim().Length == 10)
                    {
                        line += d[i].Trim();
                        i++;
                    }
                    else
                    {
                        if (d[i].Trim().Length == 0)
                        {
                            line += d[i].Trim().PadRight(10);
                            i++;
                        }
                        else
                        {
                            errLbl.Text = "Error on lien holder phone length at line number " + count.ToString();
                            return false;
                        }
                    }
                    //second lien
                    if (d[i].Trim().Length == 1)
                    {
                        line += d[i].Trim().ToUpper();
                        i++;
                    }
                    else
                    {
                        if (d[i].Trim().Length < 1)
                        {
                            line += d[i].Trim().ToUpper().PadRight(1);
                            i++;
                        }
                        else
                        {
                            errLbl.Text = "Error on second lien length at line number " + count.ToString();
                            return false;
                        }
                    }
                    //first-lien-name
                    if (d[i].Trim().Length == 20)
                    {
                        line += d[i].Trim().ToUpper();
                        i++;
                    }
                    else
                    {
                        if (d[i].Trim().Length < 20)
                        {
                            line += d[i].Trim().PadRight(20).ToUpper();
                            i++;
                        }
                        else
                        {
                            errLbl.Text = "Error on First lien name length at line number " + count.ToString();
                            return false;
                        }
                    }
                    //first-lien-address
                    if (d[i].Trim().Length == 20)
                    {
                        line += d[i].Trim().ToUpper();
                        i++;
                    }
                    else
                    {
                        if (d[i].Trim().Length < 20)
                        {
                            line += d[i].Trim().PadRight(20).ToUpper();
                            i++;
                        }
                        else
                        {
                            errLbl.Text = "Error on first-lien-address length at line number " + count.ToString();
                            return false;
                        }
                    }
                    //first-lien-city
                    if (d[i].Trim().Length == 15)
                    {
                        line += d[i].Trim();
                        i++;
                    }
                    else
                    {
                        if (d[i].Trim().Length < 15)
                        {
                            line += d[i].Trim().PadRight(15).ToUpper();
                            i++;
                        }
                        else
                        {
                            errLbl.Text = "Error on first-lien-city length at line number " + count.ToString();
                            return false;
                        }
                    }
                    //first-lien-state
                    if (d[i].Trim().Length == 2)
                    {
                        line += d[i].Trim().ToUpper();
                        i++;
                    }
                    else
                    {
                        if (d[i].Trim().Length == 0)
                        {
                            line += d[i].Trim().PadRight(2).ToUpper();
                            i++;
                        }
                        else
                        {
                            errLbl.Text = "Error on first-lien-state length at line number " + count.ToString();
                            return false;
                        }
                    }
                    //first-lien-zip
                    if (d[i].Trim().Length == 5)
                    {
                        line += d[i].Trim();
                        i++;
                    }
                    else
                    {
                        if (d[i].Trim().Length == 0)
                        {
                            line += d[i].Trim().PadRight(5);
                            i++;
                        }
                        else
                        {
                            errLbl.Text = "Error on first-lien-zip length at line number " + count.ToString();
                            return false;
                        }
                    }
                    //second-lien-name
                    if (d[i].Trim().Length == 20)
                    {
                        line += d[i].Trim().ToUpper();
                        i++;
                    }
                    else
                    {
                        if (d[i].Trim().Length < 20)
                        {
                            line += d[i].Trim().PadRight(20).ToUpper();
                            i++;
                        }
                        else
                        {
                            errLbl.Text = "Error on First lien name length at line number " + count.ToString();
                            return false;
                        }
                    }
                    //second-lien-address
                    if (d[i].Trim().Length == 20)
                    {
                        line += d[i].Trim().ToUpper();
                        i++;
                    }
                    else
                    {
                        if (d[i].Trim().Length < 20)
                        {
                            line += d[i].Trim().PadRight(20).ToUpper();
                            i++;
                        }
                        else
                        {
                            errLbl.Text = "Error on first-lien-address length at line number " + count.ToString();
                            return false;
                        }
                    }
                    //second-lien-city
                    if (d[i].Trim().Length == 15)
                    {
                        line += d[i].Trim().ToUpper();
                        i++;
                    }
                    else
                    {
                        if (d[i].Trim().Length < 15)
                        {
                            line += d[i].Trim().PadRight(15).ToUpper();
                            i++;
                        }
                        else
                        {
                            errLbl.Text = "Error on first-lien-city length at line number " + count.ToString();
                            return false;
                        }
                    }
                    //second-lien-state
                    if (d[i].Trim().Length == 2)
                    {
                        line += d[i].Trim().ToUpper();
                        i++;
                    }
                    else
                    {
                        if (d[i].Trim().Length == 0)
                        {
                            line += d[i].Trim().PadRight(2).ToUpper();
                            i++;
                        }
                        else
                        {
                            errLbl.Text = "Error on first-lien-state length at line number " + count.ToString();
                            return false;
                        }
                    }
                    //second-lien-zip
                    if (d[i].Trim().Length == 5)
                    {
                        line += d[i].Trim();
                        i++;
                    }
                    else
                    {
                        if (d[i].Trim().Length == 0)
                        {
                            line += d[i].Trim().PadRight(5);
                            i++;
                        }
                        else
                        {
                            errLbl.Text = "Error on first-lien-zip length at line number " + count.ToString();
                            return false;
                        }
                    }
                    //STFA
                    if (d[i].Trim().Length == 1)
                    {
                        line += d[i].Trim().ToUpper();
                        i++;
                    }
                    else
                    {
                        if(d[i].Trim().Length < 1)
                        {
                            line += d[i].Trim().ToUpper().PadRight(1);
                            i++;
                        }
                        else
                        {
                            errLbl.Text = "Error on STFA length at line number " + count.ToString();
                            return false;
                        }
                    }
                    //file lien electronicly
                    if (d[i].Trim().Length == 1)
                    {
                        line += d[i].Trim().ToUpper();
                        i++;
                    }
                    else
                    {
                        if (d[i].Trim().Length < 1)
                        {
                            line += d[i].Trim().PadRight(1).ToUpper();
                            i++;
                        }
                        else
                        {
                            errLbl.Text = "Error on file lien electronicly length at line number " + count.ToString();
                            return false;
                        }
                    }
                    //header error
                    if (d[i].Trim().Length == 1)
                    {
                        line += d[i].Trim().ToUpper();
                        i++;
                    }
                    else
                    {
                        if (d[i].Trim().Length < 1)
                        {
                            line += d[i].Trim().PadRight(1).ToUpper();
                            i++;
                        }
                        else
                        {
                            errLbl.Text = "Error on header error length at line number " + count.ToString();
                            return false;
                        }
                    }
                    //vin error
                    if (d[i].Trim().Length == 1)
                    {
                        line += d[i].Trim().ToUpper();
                        i++;
                    }
                    else
                    {
                        if (d[i].Trim().Length < 1)
                        {
                            line += d[i].Trim().PadRight(1).ToUpper();
                            i++;
                        }
                        else
                        {
                            errLbl.Text = "Error on vin error length at line number " + count.ToString();
                            return false;
                        }
                    }
                    //make error
                    if (d[i].Trim().Length == 1)
                    {
                        line += d[i].Trim().ToUpper();
                        i++;
                    }
                    else
                    {
                        if (d[i].Trim().Length < 1)
                        {
                            line += d[i].Trim().PadRight(1).ToUpper();
                            i++;
                        }
                        else
                        {
                            errLbl.Text = "Error on make error length at line number " + count.ToString();
                            return false;
                        }
                    }
                    //trailer error
                    if (d[i].Trim().Length == 1)
                    {
                        line += d[i].Trim().ToUpper();
                        i++;
                    }
                    else
                    {
                        if (d[i].Trim().Length < 1)
                        {
                            line += d[i].Trim().PadRight(1).ToUpper();
                            i++;
                        }
                        else
                        {
                            errLbl.Text = "Error on trailer error length at line number " + count.ToString();
                            return false;
                        }
                    }
                    //Sold without Title
                    if (d[i].Trim().Length == 1)
                    {
                        line += d[i].Trim().ToUpper();
                        i++;
                    }
                    else
                    {
                        if (d[i].Trim().Length < 1)
                        {
                            line += d[i].Trim().PadRight(1).ToUpper();
                            i++;
                        }
                        else
                        {
                            errLbl.Text = "Error on sold without title length at line number " + count.ToString();
                            return false;
                        }
                    }
                    //Administrative Fee
                    if (d[i].Trim().Length == 1 && (d[i].Trim() == "E" || d[i].Trim() == "Y" ))
                    {
                        line += d[i].Trim().ToUpper();
                    }
                    else
                    {
                            errLbl.Text = "Error on Administrative Fee at line number " + count.ToString();
                            return false;
                    }
                    string space = "";
                    line += space.PadRight(47);
                    prnList.Add(line);
                    count++;
                }
                entries = count - 1;
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                errLbl.Text = e.Message;
                return false;
            }
        }

        private bool writeFile()
        {
            try
            {
                using (StreamWriter output = new StreamWriter(outputFileTxt.Text))
                {
                    foreach (string line in prnList)
                    {
                        output.WriteLine(line);
                    }
                }
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                errLbl.Text = e.Message;
                return false;
            }
        }
        private void showEntries()
        {
            entryLbl.Text = "Processed " + entries.ToString() + " entries.";
        }
    }
}