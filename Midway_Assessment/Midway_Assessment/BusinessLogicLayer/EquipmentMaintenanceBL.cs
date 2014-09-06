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
    public class EquipmentMaintenanceBL
    {
        string FilePath = string.Empty;

        public EquipmentMaintenanceBL(string filePath)
        {
            FilePath = filePath;
        }

        public DataTable ReadAllData()
        {
            EquipmentMaintenanceDB objEquipMaintenanceDB = new EquipmentMaintenanceDB();
            return GetInTable( objEquipMaintenanceDB.ReadAll(FilePath));
        }

        public bool AddRecord(EquipmentMaintenance objEquipMaintenance)
        {
            EquipmentMaintenanceDB objEquipMaintenanceDB = new EquipmentMaintenanceDB();

            string data = (GetMaxID() + 1).ToString() + "," + objEquipMaintenance.WorkDateTime.Date.ToString("dd/MM/yyyy") +","+
                           objEquipMaintenance.WorkDateTime.Date.ToString("HH:mm")+","+objEquipMaintenance.Description+","+objEquipMaintenance.ObjEquip.ID.ToString()+"," +objEquipMaintenance.TimeTaken.ToString();
            return objEquipMaintenanceDB.Add(FilePath, data);

        }
        public bool UpdateRecord( EquipmentMaintenance objEquipMaintenance)
        {
            EquipmentMaintenanceDB objEquipMaintenanceDB = new EquipmentMaintenanceDB();
            ArrayList lines = Edit( objEquipMaintenance); //This searches the targeted id and replaces name string.
           return objEquipMaintenanceDB.Update(FilePath, lines);
            
        }
        public bool DeleteRecord(int id)
        {
            EquipmentMaintenanceDB objEquipMaintenanceDB = new EquipmentMaintenanceDB();
            ArrayList lines = Delete(id); //This searches the targeted id and deletes the record.
            return objEquipMaintenanceDB.Update(FilePath, lines);
            
        }
        /// <summary>
        /// Searches required string by ID and then skips it.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="objEquipMaintenance"></param>
        /// <returns></returns>
        private ArrayList Delete(int id)
        {
            EquipmentMaintenanceDB objEquipMaintenanceDB = new EquipmentMaintenanceDB();
            DataTable dtData = GetInTable(objEquipMaintenanceDB.ReadAll(FilePath));

            string line = string.Empty;
            ArrayList lines = new ArrayList();
            lines.Add("MaintenanceWorkId,Date,Time,WorksDescription,EquipmentId,TimeTaken");
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
        /// <param name="objEquipMaintenance"></param>
        /// <returns></returns>
        private ArrayList Edit( EquipmentMaintenance objEquipMaintenance)
        {
             EquipmentMaintenanceDB objEquipMaintenanceDB = new EquipmentMaintenanceDB();
            DataTable dtData = GetInTable(objEquipMaintenanceDB.ReadAll(FilePath));

            string line = string.Empty;
            ArrayList lines = new ArrayList();
            lines.Add("MaintenanceWorkId,Date,Time,WorksDescription,EquipmentId,TimeTaken");
            foreach (DataRow row in dtData.Rows)
            {
                if (int.Parse(row[0].ToString()) == objEquipMaintenance.ID)
                {
                    line = row[0].ToString() + "," + objEquipMaintenance.WorkDateTime.Date.ToString("dd/MM/yyyy") +","+
                           objEquipMaintenance.WorkDateTime.Date.ToString("HH:mm")+","+objEquipMaintenance.Description+","+objEquipMaintenance.ObjEquip.ID.ToString()+"," +objEquipMaintenance.TimeTaken.ToString();
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
        /// Finds the record based on name of the EquipmentMaintenance.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="equipMaintenanceID"></param>
        /// <returns></returns>
        public EquipmentMaintenance Find(int equipMaintenanceID)
        {
            EquipmentMaintenanceDB objEquipMaintenanceDB = new EquipmentMaintenanceDB();
            EquipmentMaintenance objEquipMaintenance = new EquipmentMaintenance();
            DataTable dtData = GetInTable(objEquipMaintenanceDB.ReadAll(FilePath));

            DataRow[] rowColl = dtData.Select("MaintenanceWorkId = " + equipMaintenanceID + "");
            if (rowColl.Length > 0)
            {
                DataRow newRow = rowColl[0];
                objEquipMaintenance.ID = int.Parse(newRow[0].ToString());
                objEquipMaintenance.WorkDateTime =DateTime.ParseExact( newRow[1].ToString()+" "+newRow[2].ToString(), "dd/MM/yyyy HH:mm", null);
                objEquipMaintenance.Description = newRow[3].ToString();
                objEquipMaintenance.ObjEquip.ID = int.Parse(newRow[4].ToString());
                objEquipMaintenance.TimeTaken = int.Parse(newRow[5].ToString());


            }
            return objEquipMaintenance;

        }

        /// <summary>
        /// Arranges the data into table format
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
       public DataTable GetInTable(string inputData)
        {
           
            string[] arrayInputData = inputData.Split('\n');

            DataTable dtEquipmentMaintenanceData = new DataTable();
            if (arrayInputData.Length > 0)
            {
                string[] arrayFirstRow = arrayInputData[0].Split(',');
                string[] arrayNextRow;
                if (arrayFirstRow.Length == 6)
                {
                    arrayFirstRow[0] = arrayFirstRow[0].Trim('\r').Trim();
                    arrayFirstRow[1] = arrayFirstRow[1].Trim('\r').Trim();
                    arrayFirstRow[2] = arrayFirstRow[2].Trim('\r').Trim();
                    arrayFirstRow[3] = arrayFirstRow[3].Trim('\r').Trim();
                    arrayFirstRow[4] = arrayFirstRow[4].Trim('\r').Trim();
                    arrayFirstRow[5] = arrayFirstRow[5].Trim('\r').Trim();

                    dtEquipmentMaintenanceData.Columns.Add(arrayFirstRow[0].Trim('\r').Trim(), typeof(int));
                    dtEquipmentMaintenanceData.Columns.Add(arrayFirstRow[1].Trim('\r').Trim());
                    dtEquipmentMaintenanceData.Columns.Add(arrayFirstRow[2].Trim('\r').Trim());
                    dtEquipmentMaintenanceData.Columns.Add(arrayFirstRow[3].Trim('\r').Trim());
                    dtEquipmentMaintenanceData.Columns.Add(arrayFirstRow[4].Trim('\r').Trim());
                    dtEquipmentMaintenanceData.Columns.Add(arrayFirstRow[5].Trim('\r').Trim());
                    
                    for (int index = 1; index < arrayInputData.Length; ++index)
                    {
                        arrayNextRow = null;
                        arrayNextRow = arrayInputData[index].Split(',');
                        if (arrayNextRow.Length == 6)
                        {
                            DataRow drEquipmentMaintenance = dtEquipmentMaintenanceData.NewRow();
                            drEquipmentMaintenance[arrayFirstRow[0]] = arrayNextRow[0].Trim('\r').Trim();
                            drEquipmentMaintenance[arrayFirstRow[1]] = arrayNextRow[1].Trim('\r').Trim();
                            drEquipmentMaintenance[arrayFirstRow[2]] = arrayNextRow[2].Trim('\r').Trim();
                            drEquipmentMaintenance[arrayFirstRow[3]] = arrayNextRow[3].Trim('\r').Trim();
                            drEquipmentMaintenance[arrayFirstRow[4]] = arrayNextRow[4].Trim('\r').Trim();
                            drEquipmentMaintenance[arrayFirstRow[5]] = arrayNextRow[5].Trim('\r').Trim();


                            dtEquipmentMaintenanceData.Rows.Add(drEquipmentMaintenance);
                        }

                    }

                    return dtEquipmentMaintenanceData;
                }
                else
                {
                    return dtEquipmentMaintenanceData;
                }
            }
            else
            {
                return dtEquipmentMaintenanceData;
            }

        }
       // /// <summary>
       ///// Checks if there is any duplication in the file for the given name of EquipmentMaintenance during first time save process.
       // /// </summary>
       // /// <param name="filePath"></param>
       // /// <param name="name"></param>
       // /// <returns></returns>
       //public bool AlreadyExists_NewRecord(string name)
       //{
       //    if (Find(name).ID > 0)
       //    {
       //        return true;
       //    }
       //    else
       //    {
       //        return false;
       //    }
       //}
       // /// <summary>
       // /// Checks if there is any duplication in the file for the given name of EquipmentMaintenance during update process.
       // /// .
       // /// </summary>
       // /// <param name="filePath"></param>
       // /// <param name="name"></param>
       // /// <param name="id"></param>
       // /// <returns></returns>
       //public bool AlreadyExists_Update( string name, int id)
       //{
       //    EquipmentMaintenance objEquipMaintenancementMaintenance = Find( name);
       //    if (objEquipMaintenancementMaintenance.ID > 0)
       //    {
       //        if (objEquipMaintenancementMaintenance.ID == id)
       //            return false;
       //        else
       //            return true;
       //    }
       //    else
       //    {
       //        return false;
       //    }
       //}


       public int GetMaxID()
       {
           EquipmentMaintenanceDB objEquipMaintenanceDB = new EquipmentMaintenanceDB();
           DataTable dtEquipData = GetInTable(objEquipMaintenanceDB.ReadAll(FilePath));

           int maxID = 0;
           int.TryParse(dtEquipData.Compute("Max(MaintenanceWorkId)", "").ToString(), out maxID);

           return maxID;
       }
    }
}