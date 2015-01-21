using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Drawing;
using System.IO;
namespace Facebook_Face_Collector
{
    class WebHandler
    {

        public HttpWebResponse makeGETRequest(string url)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);



            req.Method = "GET";
            req.ContentType = "application/x-www-form-urlencoded";
            
            try
            {
                return (HttpWebResponse)req.GetResponse();
            }
            catch (WebException e)
            {
                throw e;
            }
        }


        public Stream downloadImage(string url)
        {
            try
            {
                HttpWebResponse resp = makeGETRequest(url);

                
                return resp.GetResponseStream();           
            } 
            catch(WebException e)
            {
                throw e;
            }
        }
    }
}
