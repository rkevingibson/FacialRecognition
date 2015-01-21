using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.IO;

namespace Facebook_Face_Collector
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {



            string accessToken = "CAACEdEose0cBADJTO7ulP1cwM5TceZBEBQ5Gfupxf2QgblumUF7RNscDaH5GgHrVbYCyApcTxLV8JSGJkmiouFoJZBW0KT4dgSJGCua69Q2VSZAidZBP0R7STo0ZAi5vCuX6QZCv9H1sU3721oPrWJ56ZAZC7I4uB2gs4BTRZAnhab0tetLZAQ6E3Y2ZCZBDZAQZBBnTbZBxxhWRT4z8AZDZD";//accessTokenBox.Text;
            
            //Validate folder path
            string path = ".";//folderPathBox.Text;
            
            //Start downloading, need to display some sort of progress meter.
            FBGraph fbg = new FBGraph(accessToken);

#if true
            StreamWriter sw = new StreamWriter(path + "\\ids.txt");
            //Get list of people
            //textBox1.Text += "Getting friend list..." + Environment.NewLine;
            Console.WriteLine("Getting Friend List");
            List<FBPerson> list = fbg.getFriendList();
            //textBox1.Text += "Friend list obtained." + Environment.NewLine;
            SortedSet<string> photoIDs = new SortedSet<string>();
            //For each person, find all the photos they are tagged in

            //progressBar1.Value = 5;

            //textBox1.Text += "Getting photos from people." + Environment.NewLine;
            Console.WriteLine("Getting photos from people.");

            for (int i = 0; i < list.Count(); i++)
            {
                var p = list[i];
                fbg.getPhotos(p);

                if (p.photoIDs.Count == 0)
                {
                    Console.WriteLine("Got no photos from " + p.id);
                }
                else
                {
                    Console.WriteLine("Got " + p.photoIDs.Count + " photos from " + p.id);
                }

                foreach (var s in p.photoIDs)
                {
                    photoIDs.Add(s);
                }
            }

            foreach (var item in photoIDs)
            {
                sw.WriteLine(item);
            }
#else
            StreamReader sr = new StreamReader(path + "\\ids.txt");
            StreamWriter sw = new StreamWriter(path + "\\files.txt");


            //Load the list of photoIDs...
            SortedSet<string> photoIDs = new SortedSet<string>();

            while (!sr.EndOfStream)
            {
                photoIDs.Add(sr.ReadLine());
            }

            //Find which ones haven't been done. We'll enter the last photoID processed.
            string lastFileDone = "";
            
            bool lastFileFound = false;
            int j=0;
            if (lastFileDone.Equals(""))
                lastFileFound = true;

            foreach (var id in photoIDs)
            {

                if(lastFileFound)
                {
                    FBPhoto photo = fbg.getPhoto(id);
                    photo.saveFaces(path, sw);
                }
                else
                {
                    if (photoIDs.ElementAt(j).Equals(lastFileDone))
                    {
                        lastFileFound = true;
                    }
                }                
                j++;
            }

#endif

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
        }
    }
}
