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

namespace Facebook_Face_Collector
{
    public partial class Form1 : Form
    {
        private bool working;
        private StreamWriter sw;
        public Form1()
        {
            InitializeComponent();
            working = false;
        }

        private void folderSelectButton_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.ShowDialog();
            folderPathBox.Text = folderBrowserDialog.SelectedPath;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (!working)
            {
                working = true;
                //Get access token
                string accessToken = accessTokenBox.Text;
                //Validate folder path
                string path = folderPathBox.Text;
                sw = new StreamWriter(path + "\\files.txt");
                //Start downloading, need to display some sort of progress meter.
                FBGraph fbg = new FBGraph(accessToken);

                //Get list of people
                textBox1.Text += "Getting friend list..." + Environment.NewLine;
                List<FBPerson> list = fbg.getAppleList();
                textBox1.Text += "Friend list obtained." + Environment.NewLine;
                SortedSet<string> photoIDs = new SortedSet<string>();
                //For each person, find all the photos they are tagged in

                progressBar1.Value = 5;

                textBox1.Text += "Getting photos from people." + Environment.NewLine;
                for (int i = 0; i < 5; i++)
                {
                    var p = list[i];
                    fbg.getPhotos(p);

                    textBox1.Text += "Got " + p.photoIDs.Count + " photos from " + p.id +Environment.NewLine;

                    if (p.photoIDs.Count == 0) ;

                    foreach (var s in p.photoIDs)
                    {
                        photoIDs.Add(s);
                    }

                    progressBar1.Value = (int)((((float)i) / list.Count) * 50.0) + 5;
                }

                textBox1.Text += "Got master photos list." + Environment.NewLine;



                int j = 0;
                foreach (var id in photoIDs)
                {

                    FBPhoto photo = fbg.getPhoto(id);

                    photo.saveFaces(path, sw);
                    progressBar1.Value = (int)(j * 45 / photoIDs.Count) + 55;
                    textBox1.Text += "Saved photo " + id + Environment.NewLine;
                    j++;
                }

                progressBar1.Value = 100;
                sw.Close();
                working = false;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.ScrollToCaret();
        }

    }
}
