using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Midway_Assessment.DataAccessLayer
{
    public class EquipmentMaintenanceDB
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
        public bool Add(string filePath, string data)
        {
            bool savedSuccessfully = false;
            try
            {
                using (FileStream objFile = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.None))
                {
                    using (StreamWriter objWriter = new StreamWriter(objFile))
                    {
                        objWriter.WriteLine(data);
                        savedSuccessfully = true;
                        objWriter.Close();
                        objWriter.Dispose();
                    }
                    objFile.Flush();
                    objFile.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return savedSuccessfully;
        }

        internal bool Update(string filePath, System.Collections.ArrayList lines)
        {
            bool updatedSuccessfully = false;
            try
            {
                using (FileStream objFile = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.None))
                {
                    using (StreamWriter objWriter = new StreamWriter(filePath, false))
                    {
                        foreach (string line in lines)
                        objWriter.WriteLine(line);
                        objWriter.Close();
                        objWriter.Dispose();
                        updatedSuccessfully = true;
                    }
                    objFile.Flush();
                    objFile.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return updatedSuccessfully;
        }

    }
}