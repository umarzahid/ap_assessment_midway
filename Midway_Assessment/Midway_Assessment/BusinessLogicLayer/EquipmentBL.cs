using Midway_Assessment.ClassProperties;
using Midway_Assessment.DataAccessLayer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Midway_Assessment.BusinessLogicLayer
{
    public class EquipmentBL
    {
        string FilePath = string.Empty;

        public EquipmentBL(string filePath)
        {
            FilePath = filePath;
        }

        public DataTable SelectAllData()
        {
            EquipmentDB objEquipDB = new EquipmentDB();
            return GetInTable( objEquipDB.ReadAll(FilePath));
        }

        public bool AddRecord(Equipment objEquip)
        {
            EquipmentDB objEquipDB = new EquipmentDB();

            string data = (GetMaxID() + 1).ToString() + "," + objEquip.Name; //maintaining identity
            return objEquipDB.Add(FilePath, data);

        }
        public bool UpdateRecord( Equipment objEquip)
        {
            EquipmentDB objEquipDB = new EquipmentDB();
            ArrayList lines = Edit( objEquip); //This searches the targeted id and replaces name string.
           return objEquipDB.Update(FilePath, lines);
            
        }
        public bool DeleteRecord(int id)
        {
            EquipmentDB objEquipDB = new EquipmentDB();
            ArrayList lines = Delete(id); //This searches the targeted id and deletes the record.
            return objEquipDB.Update(FilePath, lines);
            
        }
        /// <summary>
        /// Searches required string by ID and then skips it.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="objEquip"></param>
        /// <returns></returns>
        private ArrayList Delete(int id)
        {
            EquipmentDB objEquipDB = new EquipmentDB();
            DataTable dtData = GetInTable(objEquipDB.ReadAll(FilePath));

            string line = string.Empty;
            ArrayList lines = new ArrayList();
            lines.Add("EquipmentId,Name");
            foreach (DataRow row in dtData.Rows)
            {
                if (int.Parse(row[0].ToString()) == id)
                { }
                else
                {
                    line = row[0].ToString() + "," + row[1].ToString();
                    lines.Add(line);
                }
            }
            return lines;
        }
       
        /// <summary>
        /// Searches required string by ID and then replaces old value with new value.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="objEquip"></param>
        /// <returns></returns>
        private ArrayList Edit( Equipment objEquip)
        {
             EquipmentDB objEquipDB = new EquipmentDB();
            DataTable dtData = GetInTable(objEquipDB.ReadAll(FilePath));

            string line = string.Empty;
            ArrayList lines = new ArrayList();
            lines.Add("EquipmentId,Name");
            foreach (DataRow row in dtData.Rows)
            {
                if (int.Parse(row[0].ToString()) == objEquip.ID)
                {
                    line = row[0].ToString() + "," + objEquip.Name;
                }
                else
                {
                    line = row[0].ToString() + "," + row[1].ToString();
                }
                lines.Add(line);
            }
            return lines;
        }
        /// <summary>
        /// Finds the record based on name of the equipment.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public Equipment Find(string name)
        {
            EquipmentDB objEquipDB = new EquipmentDB();
            Equipment objEquip = new Equipment();
            DataTable dtData = GetInTable(objEquipDB.ReadAll(FilePath));

            DataRow[] rowColl = dtData.Select("name = '"+name+"'");
            if (rowColl.Length > 0)
            {
                DataRow newRow = rowColl[0];
                objEquip.ID = int.Parse(newRow[0].ToString());
                objEquip.Name = newRow[1].ToString();

            }
            return objEquip;

        }

        /// <summary>
        /// Arranges the data into table format
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
       public DataTable GetInTable(string inputData)
        {
           
            string[] arrayInputData = inputData.Split('\n');

            DataTable dtEquipmentData = new DataTable();
            if (arrayInputData.Length > 0)
            {
                string[] arrayFirstRow = arrayInputData[0].Split(',');
                string[] arrayNextRow;
                if (arrayFirstRow.Length == 2)
                {
                    arrayFirstRow[0] = arrayFirstRow[0].Trim();
                    arrayFirstRow[1] = arrayFirstRow[1].Trim();

                    dtEquipmentData.Columns.Add(arrayFirstRow[0].Trim(), typeof(int));
                    dtEquipmentData.Columns.Add(arrayFirstRow[1].Trim());

                    for (int index = 1; index < arrayInputData.Length; ++index)
                    {
                        arrayNextRow = null;
                        arrayNextRow = arrayInputData[index].Split(',');
                        if (arrayNextRow.Length == 2)
                        {
                            DataRow drEquipment = dtEquipmentData.NewRow();
                            drEquipment[arrayFirstRow[0]] = arrayNextRow[0].Trim('\r').Trim();
                            drEquipment[arrayFirstRow[1]] = arrayNextRow[1].Trim('\r').Trim();

                            dtEquipmentData.Rows.Add(drEquipment);
                        }

                    }

                    return dtEquipmentData;
                }
                else
                {
                    return dtEquipmentData;
                }
            }
            else
            {
                return dtEquipmentData;
            }

        }
        /// <summary>
       /// Checks if there is any duplication in the file for the given name of equipment during first time save process.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="name"></param>
        /// <returns></returns>
       public bool AlreadyExists_NewRecord(string name)
       {
           if (Find(name).ID > 0)
           {
               return true;
           }
           else
           {
               return false;
           }
       }
        /// <summary>
        /// Checks if there is any duplication in the file for the given name of equipment during update process.
        /// .
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="name"></param>
        /// <param name="id"></param>
        /// <returns></returns>
       public bool AlreadyExists_Update( string name, int id)
       {
           Equipment objEquipment = Find( name);
           if (objEquipment.ID > 0)
           {
               if (objEquipment.ID == id)
                   return false;
               else
                   return true;
           }
           else
           {
               return false;
           }
       }


       public int GetMaxID()
       {
           EquipmentDB objEquipDB = new EquipmentDB();
           DataTable dtEquipData = GetInTable(objEquipDB.ReadAll(FilePath));

           int maxID = 0;
           int.TryParse(dtEquipData.Compute("Max(EquipmentId)", "").ToString(),out maxID);

           return maxID;
       }
    }
}