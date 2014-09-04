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
        public bool Append(string strPath, string data)
        {
            bool savedSuccessfully = false;
            try
            {

                using (StreamWriter objWriter = new StreamWriter(strPath, true))
                {
                     objWriter.WriteLine(data);
                    savedSuccessfully = true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return savedSuccessfully;
        }
        public bool Insert(string strPath, string[] data)
        {
            bool savedSuccessfully = false;
            try
            {

                using (StreamWriter objWriter = new StreamWriter(strPath, false))
                {
                    foreach(string line in data)
                    objWriter.WriteLine(line);

                    savedSuccessfully = true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return savedSuccessfully;
        }
    }
}