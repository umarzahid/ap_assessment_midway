﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Midway_Assessment.BusinessLogicLayer;
using Midway_Assessment.DataAccessLayer;
using System.Data;

namespace MidwayAssessmentTest.BusinessAccessLayer_Test
{
    [TestClass]
    public class EquipmentMaintenanceBL_TDD
    {
        string filePath = @"C:\Users\pcPareto\Documents\ap_assessment_midway\Midway_Assessment\Midway_Assessment\Database\MaintenanceWorks.csv";
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
        public void GetInTable()
        {
            EquipmentMaintenanceBL equipMaintenanceBL = new EquipmentMaintenanceBL(filePath);

            EquipmentMaintenanceDB equipDB = new EquipmentMaintenanceDB();

            string result = equipDB.ReadAll(filePath);

            DataTable resultDB = equipMaintenanceBL.GetInTable(result);
            //Expected result will vary depending on number of records in the table.
            Assert.IsTrue(resultDB.Rows.Count>0,"First row represents column names. So it will be greater than 0.");
        }
        [TestMethod]
        public void Find()
        {
            EquipmentMaintenanceBL equipMaintenanceBL = new EquipmentMaintenanceBL(filePath);


            Midway_Assessment.ClassProperties.EquipmentMaintenance result = equipMaintenanceBL.Find(251);

            Assert.AreEqual(251, result.ID);
        }
        [TestMethod]
        public void GetMaxID()
        {
            EquipmentMaintenanceBL equipMaintenaceBL = new  EquipmentMaintenanceBL(filePath);

            int result = equipMaintenaceBL.GetMaxID();

            Assert.AreEqual(1000, result);
        }
    }
}