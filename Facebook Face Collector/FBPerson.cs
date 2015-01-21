using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook_Face_Collector
{
    class FBPerson
    {
        public string id;
        public List<string> photoIDs;
        public FBPerson(string id)
        {
            this.id = id;
            photoIDs = new List<string>();
        }

        public void addPhoto(string id)
        {
            photoIDs.Add(id);
        }
    }
}
