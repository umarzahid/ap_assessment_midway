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
        /// <summary>
        /// Selects all data from the file
        /// </summary>
        /// <returns></returns>
        public List<Equipment> SelectAllData()
        {
            FileOperations objEquipDB = new FileOperations();
            return GetEquipmentColl( objEquipDB.ReadAll(FilePath));
        }

        public bool AddRecord(Equipment objEquip)
        {
            FileOperations objEquipDB = new FileOperations();
         objEquip.ID = GetMaxID() + 1; // maintaining identity
            return objEquipDB.Add(FilePath, objEquip.ToString());

        }
        public bool UpdateRecord( Equipment objEquip)
        {
            FileOperations objEquipDB = new FileOperations();
            ArrayList lines = Edit( objEquip); //This searches the targeted id and replaces name string.
           return objEquipDB.Update(FilePath, lines);
            
        }
        public bool DeleteRecord(int id)
        {
            FileOperations objEquipDB = new FileOperations();
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
            List<Equipment> objEquipColl = SelectAllData();
            objEquipColl.RemoveAll(equip => equip.ID == id);
            FileOperations objEquipDB = new FileOperations();
            ArrayList lines = new ArrayList();
            lines.Add("EquipmentId,Name");
            foreach (Equipment equip in objEquipColl)
            {
                    lines.Add(equip.ToString());
            }
            return lines;
        }
       


        /// <summary>
        /// Searches required string by ID and then replaces old value with new value.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="objNewEquip"></param>
        /// <returns></returns>
        private ArrayList Edit( Equipment objNewEquip)
        {
             FileOperations objEquipDB = new FileOperations();
             List<Equipment> objEquipColl = SelectAllData();
            ArrayList lines = new ArrayList();
            lines.Add("EquipmentId,Name");
            foreach (Equipment equip in objEquipColl)
            {
                if (equip.ID == objNewEquip.ID)
                {
                    equip.Name = objNewEquip.Name;
                }
                lines.Add(equip.ToString());
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
            FileOperations objEquipDB = new FileOperations();
            Equipment objEquip = new Equipment();
            List<Equipment> objEquipColl = SelectAllData();
            return objEquipColl.FirstOrDefault(equip => equip.Name == name);
            
        }

        /// <summary>
        /// Returns equipment.
        /// </summary>
        /// <param name="equipmentID"></param>
        /// <param name="equipmentName"></param>
        /// <returns></returns>
       public Equipment GetEquipment(int equipmentID, string equipmentName)
       {

           Equipment objEquipment = new Equipment();
           objEquipment.ID = equipmentID;
           objEquipment.Name = equipmentName;
           return objEquipment;
       }
        /// <summary>
        /// Returns equipments in list of equipment.
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
       public List<Equipment> GetEquipmentColl(string inputData)
       {

           string[] arrayInputData = inputData.Split('\n');
           List<Equipment> objEquipColl = new List<Equipment>();

           if (arrayInputData.Length > 0)
           {

               string[] arrayNextRow;

               for (int index = 1; index < arrayInputData.Length; ++index)
               {
                   arrayNextRow = null;
                   arrayNextRow = arrayInputData[index].Split(',');
                   if (arrayNextRow.Length == 2)
                   {
                       if (!string.IsNullOrEmpty(arrayNextRow[0].Trim()) && !string.IsNullOrEmpty(arrayNextRow[1].Trim()))
                       {
                           Equipment objEquip = GetEquipment(int.Parse(arrayNextRow[0].Trim()), arrayNextRow[1].Trim());
                           objEquipColl.Add(objEquip);
                       }
                   }

               }
               return objEquipColl;

           }
           else
           {
               return objEquipColl;
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
           Equipment objEquip = Find(name);
           if ( objEquip !=null )
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
           if (objEquipment !=null)
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
           List<Equipment> objEquipColl = SelectAllData();
           return objEquipColl.Max(r => r.ID);
       }
    }
}