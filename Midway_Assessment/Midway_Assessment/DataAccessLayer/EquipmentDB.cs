using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Midway_Assessment.DataAccessLayer
{
    public class EquipmentDB
    {
        public string ReadAll(string strPath)
        {
            try
            {

                StreamReader objReader = File.OpenText(strPath);
                string str = objReader.ReadToEnd();
                objReader.Close();
                objReader.Dispose();
                return str;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}