using Midway_Assessment.ClassProperties;
using Midway_Assessment.DataAccessLayer;
using System;
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

        public DataTable Update(string filePath)
        {
            EquipmentDB objEquipDB = new EquipmentDB();
            return GetInTable(objEquipDB.ReadAll(filePath));
        }
        //public bool AlreadyExists(string name)
        //{
        //    EquipmentDB objEquipDB = new EquipmentDB();
        //    DataTable dtData = GetInTable(objEquipDB.ReadAll(filePath));
        
        //}
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