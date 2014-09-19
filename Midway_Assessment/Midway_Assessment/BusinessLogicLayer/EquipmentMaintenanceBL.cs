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
        string EquipmentMaintenaceFilePath = string.Empty;
        string EquipmentFilePath = string.Empty;

        public EquipmentMaintenanceBL(string equipMaintenaceFilePath, string equipmentFilePath)
        {
            EquipmentMaintenaceFilePath = equipMaintenaceFilePath;
            EquipmentFilePath = equipmentFilePath;
        }


        /// <summary>
        /// Selects all data from the file
        /// </summary>
        /// <returns></returns>
        public List<EquipmentMaintenance> SelectAllData()
        {
            FileOperations objEquipMaintenanceDB = new FileOperations();
            return GetEquipmentMaintenaceColl(objEquipMaintenanceDB.ReadAll(EquipmentMaintenaceFilePath));
        }

        /// <summary>
        /// Returns EquipmentMaintenance in list of equipment.
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public List<EquipmentMaintenance> GetEquipmentMaintenaceColl(string inputData)
        {

            string[] arrayInputData = inputData.Split('\n');
            List<EquipmentMaintenance> objEquipMaintenanceColl = new List<EquipmentMaintenance>();

            if (arrayInputData.Length > 0)
            {

                string[] arrayNextRow;

                for (int index = 1; index < arrayInputData.Length; ++index)
                {
                    arrayNextRow = null;
                    arrayNextRow = arrayInputData[index].Split(',');
                    if (arrayNextRow.Length == 6)
                    {
                        if (!string.IsNullOrEmpty(arrayNextRow[0].Trim()))
                        {
                            EquipmentMaintenance objEquipMaintenance = GetEquipmentMaintenace(arrayNextRow[0].Trim(), arrayNextRow[1].Trim(), arrayNextRow[2].Trim(), arrayNextRow[3].Trim(), arrayNextRow[4].Trim(), arrayNextRow[5].Trim());
                            objEquipMaintenanceColl.Add(objEquipMaintenance);
                        }
                    }

                }
                return objEquipMaintenanceColl;

            }
            else
            {
                return objEquipMaintenanceColl;
            }


        }
/// <summary>
/// Returns EquipmentMaintenace object
/// </summary>
/// <param name="MaintenanceWorkId"></param>
/// <param name="Date"></param>
/// <param name="Time"></param>
/// <param name="WorksDescription"></param>
/// <param name="EquipmentId"></param>
/// <param name="TimeTaken"></param>
/// <returns></returns>
        public EquipmentMaintenance GetEquipmentMaintenace(string MaintenanceWorkId, string Date, string Time, string WorksDescription, string EquipmentId, string TimeTaken)
        {

            EquipmentMaintenance objEquipmentMaintenace = new EquipmentMaintenance();

            EquipmentBL objEquipBL = new EquipmentBL(EquipmentFilePath);
            Equipment objEquip = objEquipBL.Find(int.Parse(EquipmentId));

            objEquipmentMaintenace.ID = int.Parse(MaintenanceWorkId);
            objEquipmentMaintenace.WorkDate = DateTime.ParseExact(Date, "dd/MM/yyyy", null);
            objEquipmentMaintenace.TimeTaken = int.Parse(TimeTaken);
            objEquipmentMaintenace.WorkTime = Time;
            objEquipmentMaintenace.Description = WorksDescription;

            if (objEquip == null)
                objEquipmentMaintenace.ObjEquip = new Equipment();
            else
                objEquipmentMaintenace.ObjEquip = objEquip;

            return objEquipmentMaintenace;
        }

        public bool AddRecord(EquipmentMaintenance objEquipMaintenance)
        {
            FileOperations objEquipMaintenanceDB = new FileOperations();

            string data = (GetMaxID() + 1).ToString() + "," + objEquipMaintenance.WorkDate.Date.ToString("dd/MM/yyyy") +","+
                           objEquipMaintenance.WorkTime+","+objEquipMaintenance.Description+","+objEquipMaintenance.ObjEquip.ID.ToString()+"," +objEquipMaintenance.TimeTaken.ToString();
            return objEquipMaintenanceDB.Add(EquipmentMaintenaceFilePath, data);

        }
        public bool UpdateRecord( EquipmentMaintenance objEquipMaintenance)
        {
            FileOperations objEquipMaintenanceDB = new FileOperations();
            ArrayList lines = Edit( objEquipMaintenance); //This searches the targeted id and replaces name string.
           return objEquipMaintenanceDB.Update(EquipmentMaintenaceFilePath, lines);
            
        }
        public bool DeleteRecord(int id)
        {
            FileOperations objEquipMaintenanceDB = new FileOperations();
            ArrayList lines = Delete(id); //This searches the targeted id and deletes the record.
            return objEquipMaintenanceDB.Update(EquipmentMaintenaceFilePath, lines);
            
        }
        /// <summary>
        /// Searches required string by ID and then skips it.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="objEquipMaintenance"></param>
        /// <returns></returns>
        private ArrayList Delete(int id)
        {

            List<EquipmentMaintenance> objEquipMaintenanceColl = SelectAllData();
            objEquipMaintenanceColl.RemoveAll(equipMain => equipMain.ID == id);
            FileOperations objEquipDB = new FileOperations();
            ArrayList lines = new ArrayList();
            lines.Add("MaintenanceWorkId,Date,Time,WorksDescription,EquipmentId,TimeTaken");

            foreach (EquipmentMaintenance equipMaintenance in objEquipMaintenanceColl)
            {
                lines.Add(equipMaintenance.ToString());
            }
            return lines;

        }
       
        /// <summary>
        /// Searches required string by ID and then replaces old value with new value.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="objEquipMaintenance"></param>
        /// <returns></returns>
        private ArrayList Edit( EquipmentMaintenance objNewEquipMaintenance)
        {

            FileOperations objEquipMaintenaceDB = new FileOperations();
            List<EquipmentMaintenance> objEquipMaintenaceColl = SelectAllData();
            ArrayList lines = new ArrayList();
            lines.Add("MaintenanceWorkId,Date,Time,WorksDescription,EquipmentId,TimeTaken");
            foreach (EquipmentMaintenance equipMaintenace in objEquipMaintenaceColl)
            {
                if (equipMaintenace.ID == objNewEquipMaintenance.ID)
                    lines.Add(objNewEquipMaintenance.ToString());                    
                else
                lines.Add(equipMaintenace.ToString());
            }
            return lines;

        }
        /// <summary>
        /// Finds the record based on id of the EquipmentMaintenance.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="equipMaintenanceID"></param>
        /// <returns></returns>
        public EquipmentMaintenance Find(int equipMaintenanceID)
        {

            FileOperations objEquipMaintenanceDB = new FileOperations();
            EquipmentMaintenance objEquipMaintenance = new EquipmentMaintenance();
            List<EquipmentMaintenance> objEquipMaintenanceColl = SelectAllData();
            return objEquipMaintenanceColl.FirstOrDefault(equipMaintenance => equipMaintenance.ID == equipMaintenanceID);
            
        }

        public int GetMaxID()
        {
            List<EquipmentMaintenance> objEquipMaintenaceColl = SelectAllData();
            return objEquipMaintenaceColl.Max(r => r.ID);
        }

    }
}