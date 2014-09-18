using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Midway_Assessment.DataAccessLayer
{
    public class FileOperations
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

                using (StreamWriter objWriter = new StreamWriter(filePath, true))
                    {
                        objWriter.WriteLine(data);
                        savedSuccessfully = true;
                        objWriter.Close();
                        objWriter.Dispose();
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
                    using (StreamWriter objWriter = new StreamWriter(filePath, false))
                    {
                        foreach (string line in lines)
                            objWriter.WriteLine(line);
                        objWriter.Close();
                        objWriter.Dispose();
                        updatedSuccessfully = true;
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