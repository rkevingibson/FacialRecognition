using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.Net;
using System.IO;

namespace Facebook_Face_Collector
{
    public struct Tag
    {
        public string id;
        public float x;
        public float y;
    };

    
    class FBPhoto
    {
        public string photoID;
        public List<Tag> people;
        public string url;
        private static CascadeClassifier haar = new CascadeClassifier("./haarcascade_frontalface_default.xml");

        public FBPhoto(string id, string url)
        {
            this.photoID = id;
            this.url = url;
            people = new List<Tag>();
        }

        public void addTag(string id, float x, float y)
        {
            Tag tag;
            tag.id = id;
            tag.x = x;
            tag.y = y;

            people.Add(tag);
        }

        public void saveFaces(string folder, StreamWriter sw)
        {
            //Download image from FB save it to a temp spot.
            WebClient wc = new WebClient();
            wc.DownloadFile(url, "./temp.jpg");
            
            //Detect and save the tagged people
            //Load face in to an image
            Image<Gray, Byte> rawgrayscale = new Image<Bgr, Byte>("./temp.jpg").Convert<Gray, Byte>();
            
            var faces = haar.DetectMultiScale(rawgrayscale, 1.1, 3, Size.Empty, Size.Empty);
            int count = 0;
            foreach(var face in faces)
            {
                //Need to find the most likely match in the facebook tags, based on tag position.
                //Then, crop and save to a file.
                //Simple nearest neighbour matching - find the closest one.
                //The face also has to be within a certain distance to be counted- the tag should be within the box defined by the OpenCV finding.
                float minDist = float.PositiveInfinity;
                Point centre = new Point(face.X + (face.Width/2), face.Y + (face.Height/2));
                string id ="";
                foreach (var tag in people)
                {
                    
                    Point tagPoint = new Point((int) ((tag.x/100) * rawgrayscale.Width),(int) ((tag.y/100) * rawgrayscale.Height));
                    float dist = (centre.X - tagPoint.X) ^ 2 + (centre.Y - tagPoint.Y) ^ 2;
                    
                    if (dist < minDist && face.Contains(tagPoint))
                    {
                        minDist = dist;
                        id = tag.id;
                    }
                }

                //Now the person should be succesfully id'd
                if (id != "")
                {
                    //Crop the photo, resize to a standard size, and save to a file.
                    //What dimensions do we want? Fairly arbitrary. Let's try 80 x 110, see how that works.
                    int newWidth, newHeight;
                    if(11*face.Width < 8*face.Height)//face is too tall, need to take extra on the side
                    {
                        newHeight = face.Height;
                        newWidth = (8 * face.Height) / 11;

                    }
                    else
                    {
                        newWidth = face.Width;
                        newHeight = (11 * face.Width) / 8;
                    }

                    int x = face.X - Math.Abs(newWidth - face.Width)/2;
                    int y = face.Y - Math.Abs(newHeight - face.Height)/2;
                    Rectangle croppedRect = new Rectangle(x, y, newWidth, newHeight);
                    try
                    {
                        Image<Gray, Byte> croppedFace = rawgrayscale.GetSubRect(croppedRect);
                    
                        //So we have the cropped image, now need to save it.
                        //Want to come up with a nice way of naming the files uniquely, but easy to import later.
                        //Use similar format as FERET database: subjectID_photoID.png
                        if (croppedFace.Width > 60)
                        {
                            croppedFace.Resize(80, 110, INTER.CV_INTER_CUBIC).Save(folder + "/" + id + "_" + photoID + "_"+count+ ".jpg");
                            sw.WriteLine(folder + "/" + id + "_" + photoID + "_" + count + ".jpg");
                        }
                    }
                    catch (Exception)
                    {
                        
                    }
                }
            }
            
        
        }

    }
}
