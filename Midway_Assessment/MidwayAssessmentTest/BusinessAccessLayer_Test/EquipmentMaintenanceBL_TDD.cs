using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Midway_Assessment.BusinessLogicLayer;
using Midway_Assessment.DataAccessLayer;
using System.Data;
using System.Collections.Generic;
using Midway_Assessment.ClassProperties;

namespace MidwayAssessmentTest.BusinessAccessLayer_Test
{
    [TestClass]
    public class EquipmentMaintenanceBL_TDD
    {
        string filePath_equipmentMaintenance = @"C:\Users\pcPareto\Documents\ap_assessment_midway\Midway_Assessment\Midway_Assessment\Database\MaintenanceWorks.csv";
        string filePath_equipment = @"C:\Users\pcPareto\Documents\ap_assessment_midway\Midway_Assessment\Midway_Assessment\Database\Equipment.csv";
        public EquipmentMaintenanceBL_TDD()
        {
            //
            // TODO: Add constructor logic here
            //
        }
       
        //
        /// <summary>
        /// Testing BL Layer
        /// </summary>
        
        [TestMethod]
        public void GetEquipmentMaintenanceColl_Test()
        {
            EquipmentMaintenanceBL equipMaintenanceBL = new EquipmentMaintenanceBL(filePath_equipmentMaintenance,filePath_equipment);

            FileOperations equipDB = new FileOperations();

            string result = equipDB.ReadAll(filePath_equipmentMaintenance);

            List<EquipmentMaintenance> resultColl = equipMaintenanceBL.GetEquipmentMaintenaceColl(result);
            //Expected result will vary depending on number of records in the table.
            Assert.IsTrue(resultColl.Count>0,"First row represents column names. So it will be greater than 0.");
        }
        [TestMethod]
        public void Find()
        {
            EquipmentMaintenanceBL equipMaintenanceBL = new EquipmentMaintenanceBL(filePath_equipmentMaintenance,filePath_equipment);


            Midway_Assessment.ClassProperties.EquipmentMaintenance result = equipMaintenanceBL.Find(251);

            Assert.AreEqual(251, result.MaintenanceWorkId);
        }
        [TestMethod]
        public void GetMaxID()
        {
            EquipmentMaintenanceBL equipMaintenaceBL = new  EquipmentMaintenanceBL(filePath_equipmentMaintenance,filePath_equipment);

            int result = equipMaintenaceBL.GetMaxID();
            //Result may vary depending on the number of records.
            Assert.AreEqual(1003, result);
        }
    }
}
