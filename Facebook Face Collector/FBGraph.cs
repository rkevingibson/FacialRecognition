using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;

namespace Facebook_Face_Collector
{
    class FBGraph
    {
        private const string BASE_URL = "https://graph.facebook.com";
        private string accessToken_;
        private WebHandler wh;
        public FBGraph(string accessToken)
        {
            accessToken_ = accessToken;
            wh = new WebHandler();
        }

        public void setAccessToken(string at)
        {
            accessToken_ = at;
        }

        public JObject makeGraphRequest(string node) 
        {
            string url = BASE_URL + node + "?access_token=" + accessToken_;
            try
            {
                JObject result = makeRawRequest(url);
                return result;
            } 
            catch(WebException e)
            {
                //Pop up a dialog to update the access token.
                AccessTokenDialog dialog = new AccessTokenDialog();
                dialog.ShowDialog();

                if(dialog.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    setAccessToken(dialog.accessTokenBox.Text);
                    return makeGraphRequest(node);
                }
                else
                {
                    System.Windows.Forms.Application.Exit();
                    return null;
                }
                //Well this seems super sketchy...
                
            }
        }

        public JObject makeRawRequest(string url)
        {
            HttpWebResponse resp = wh.makeGETRequest(url);
            StreamReader s = new StreamReader(resp.GetResponseStream());
            return JObject.Parse(s.ReadToEnd());
        }

        public List<FBPerson> getFriendList()
        {

            string node = "/me/friends";
            JObject data = makeGraphRequest(node);
            if (data != null)
            {
                List<FBPerson> friendList = new List<FBPerson>();

                foreach (var o in data["data"])
                {
                    FBPerson p = new FBPerson(o["id"].ToString());
                    friendList.Add(p);
                }
                return friendList;
            }
            
            return null;
            
        }

        public List<FBPerson> getAppleList()
        {
            string node = "/273434462674469/members";
            JObject data = makeGraphRequest(node);
            if (data != null)
            {
                List<FBPerson> friendList = new List<FBPerson>();

                foreach (var o in data["data"])
                {
                    FBPerson p = new FBPerson(o["id"].ToString());
                    friendList.Add(p);
                }
                return friendList;
            }

            return null;
        }

        public void getPhotos(FBPerson p)
        {
            string node = "/"+p.id+"/photos";
            JObject data = makeGraphRequest(node); //Get the first node

            while (data["paging"] != null)
            {
                foreach (var photo in data["data"]) //Add all the photos
                {
                    p.addPhoto(photo["id"].ToString());
                }

                data = makeRawRequest(data["paging"]["next"].ToString());
            } 
            
        }

        public FBPhoto getPhoto(string id)
        {
            JObject data = makeGraphRequest("/" + id);
            string srcURL = data["source"].ToString();

            FBPhoto photo = new FBPhoto(id, srcURL);

            foreach (var tag in data["tags"]["data"])
            {
                if (tag["id"] != null && tag["x"] != null && tag["y"] != null)
                {
                    photo.addTag(tag["id"].ToString(), (float)tag["x"], (float)tag["y"]);

                }
            }
            return photo;
        }
    }
}
