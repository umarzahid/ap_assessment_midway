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

        public DataTable ReadAllData(string filePath)
        {
            EquipmentDB objEquipDB = new EquipmentDB();
            return GetInTable( objEquipDB.ReadAll(filePath));
        }

        public bool AddRecord(string filePath, Equipment objEquip)
        {
            EquipmentDB objEquipDB = new EquipmentDB();
            string data = objEquip.ID + "," + objEquip.Name;
            return objEquipDB.Add(filePath, data);

        }
        public bool UpdateRecord(string filePath, Equipment objEquip)
        {
            EquipmentDB objEquipDB = new EquipmentDB();
            ArrayList lines = Edit(filePath, objEquip); //This searches the targeted id and replaces name string.
           return objEquipDB.Update(filePath, lines);
            
        }
        public bool DeleteRecord(string filePath, int id)
        {
            EquipmentDB objEquipDB = new EquipmentDB();
            ArrayList lines = Delete(filePath, id); //This searches the targeted id and deletes the record.
            return objEquipDB.Update(filePath, lines);
            
        }
        /// <summary>
        /// Searches required string by ID and then skips it.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="objEquip"></param>
        /// <returns></returns>
        private ArrayList Delete(string filePath, int id)
        {
            EquipmentDB objEquipDB = new EquipmentDB();
            DataTable dtData = GetInTable(objEquipDB.ReadAll(filePath));

            string line = string.Empty;
            ArrayList lines = new ArrayList();
            lines.Add("EquipmentId,Name");
            foreach (DataRow row in dtData.Rows)
            {
                if (int.Parse(row[0].ToString()) == id)
                { }
                else
                    line = row[0].ToString() + "," + row[1].ToString();
                lines.Add(line);
            }
            return lines;
        }
       
        /// <summary>
        /// Searches required string by ID and then replaces old value with new value.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="objEquip"></param>
        /// <returns></returns>
        private ArrayList Edit(string filePath, Equipment objEquip)
        {
             EquipmentDB objEquipDB = new EquipmentDB();
            DataTable dtData = GetInTable(objEquipDB.ReadAll(filePath));

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
        public Equipment Find( string filePath,string name)
        {
            EquipmentDB objEquipDB = new EquipmentDB();
            Equipment objEquip = new Equipment();
            DataTable dtData = GetInTable(objEquipDB.ReadAll(filePath));

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

                    dtEquipmentData.Columns.Add(arrayFirstRow[0].Trim());
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
       public bool AlreadyExists_NewRecord(string filePath, string name)
       {
           if (Find(filePath, name).ID > 0)
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
       public bool AlreadyExists_Update(string filePath, string name, int id)
       {
           Equipment objEquipment = Find(filePath, name);
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

    }
}