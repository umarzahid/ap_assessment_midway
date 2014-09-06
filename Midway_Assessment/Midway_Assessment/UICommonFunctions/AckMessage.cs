using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Midway_Assessment.UICommonFunctions
{
    public class AckMessage
    {
        public void Save(string Name, HttpResponse response)
        {
            response.Write("<p class='acknowedgement-style-successful'>" + Name + " has been saved</p>\n");
            
        }
        public void SaveFailed(string Name, HttpResponse response)
        {
            response.Write("<p class='acknowedgement-style-unsuccessful'>" + Name + " could not be saved</p>\n");

        }
        public void Update(string Name, HttpResponse response)
        {
            response.Write("<p class='acknowedgement-style-successful'>" + Name + " has been Updated</p>\n");
            
        }

        public void UpdateFailed(string Name, HttpResponse response)
        {
            response.Write("<p class='acknowedgement-style-unsuccessful'>" + Name + " could not be Updated</p>\n");

        }
        public void Delete(string Name, HttpResponse response)
        {
            response.Write("<p class='acknowedgement-style-successful'>" + Name + " has been deleted</p>\n");
            
        }
        public void DeleteFailed(string Name, HttpResponse response)
        {
            response.Write("<p class='acknowedgement-style-unsuccessful'>" + Name + " could not be deleted</p>\n");

        }
    }
}