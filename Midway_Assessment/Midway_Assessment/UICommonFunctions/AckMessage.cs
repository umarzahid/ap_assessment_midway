using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;

namespace Midway_Assessment.UICommonFunctions
{
    public class AckMessage
    {
        //public void Save(string Name, HttpResponse response)
        //{
        //    response.Write("<p class='acknowedgement-style-successful'>" + Name + " has been saved</p>\n");

        //}
        public void Save(string Name, HtmlGenericControl ackControl)
        {
            ackControl.InnerHtml = "<p class='text-success'><b> " + Name + " has been saved. <b></p>";


        }



        //public void SaveFailed(string Name, HttpResponse response)
        //{
        //    response.Write("<p class='acknowedgement-style-unsuccessful'>" + Name + " could not be saved</p>\n");

        //}
        public void SaveFailed(string Name, HtmlGenericControl ackControl)
        {
            ackControl.InnerHtml = ("<p class='text-danger'><b>" + Name + " could not be saved. </b></p>\n");

        }
        //public void Update(string Name, HttpResponse response)
        //{
        //    response.Write("<p class='acknowedgement-style-successful'>" + Name + " has been Updated</p>\n");

        //}

        public void Update(string Name, HtmlGenericControl ackControl)
        {
            ackControl.InnerHtml = ("<p class='text-success'><b>" + Name + " has been updated.</b></p>\n");

        }

        //public void UpdateFailed(string Name, HttpResponse response)
        //{
        //    response.Write("<p class='acknowedgement-style-unsuccessful'>" + Name + " could not be Updated</p>\n");

        //}
        public void UpdateFailed(string Name, HtmlGenericControl ackControl)
        {
            ackControl.InnerHtml = ("<p class='text-danger'><b>" + Name + " could not be updated.</b></p>\n");

        }
        //public void Delete(string Name, HttpResponse response)
        //{
        //    response.Write("<p class='acknowedgement-style-successful'>" + Name + " has been deleted</p>\n");

        //}
        public void Delete(string Name, HtmlGenericControl ackControl)
        {
            ackControl.InnerHtml = ("<p class='text-success'><b>" + Name + " has been deleted.</b></p>\n");

        }
        //public void DeleteFailed(string Name, HttpResponse response)
        //{
        //    response.Write("<p class='acknowedgement-style-unsuccessful'>" + Name + " could not be deleted</p>\n");

        //}
        public void DeleteFailed(string Name, HtmlGenericControl ackControl)
        {
            ackControl.InnerHtml = ("<p class='text-danger'><b>" + Name + " could not be deleted.</b></p>\n");

        }

        internal void Clear(HtmlGenericControl ackControl)
        {
            ackControl.InnerHtml = "";
        }
    }
}