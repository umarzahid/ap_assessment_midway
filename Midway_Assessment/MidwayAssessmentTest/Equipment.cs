using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Midway_Assessment.DataAccessLayer;
using Midway_Assessment.BusinessLogicLayer;
using Midway_Assessment.ClassProperties;
using System.Data;

namespace MidwayAssessmentTest
{
    /// <summary>
    /// Summary description for Equipment
    /// </summary>
    [TestClass]
    public class Equipment
    {
        public Equipment()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        //Testing DB Layer
        [TestMethod]
        public void ReadAll()
        {
            EquipmentDB equipDB = new EquipmentDB();

            string result = equipDB.ReadAll(@"C:\Users\pcPareto\Documents\ap_assessment_midway\Midway_Assessment\Midway_Assessment\Database\Equipment.csv");
            Assert.AreNotEqual(string.Empty, result);
        }
        /// <summary>
        /// Testing if data is getting added successfully
        /// </summary>
        [TestMethod]
        
        public void Append()
        {
            EquipmentDB equipDB = new EquipmentDB();

            bool result = equipDB.Append(@"C:\Users\pcPareto\Documents\ap_assessment_midway\Midway_Assessment\Midway_Assessment\Database\Equipment.csv","1,test");
            Assert.AreEqual(true, result);
        }


        //
        /// <summary>
        /// Testing BL Layer
        /// </summary>
        
        [TestMethod]
        public void GetInTable()
        {
            EquipmentBL equipBL = new EquipmentBL();

            EquipmentDB equipDB = new EquipmentDB();

            string result = equipDB.ReadAll(@"C:\Users\pcPareto\Documents\ap_assessment_midway\Midway_Assessment\Midway_Assessment\Database\Equipment.csv");

            DataTable resultDB = equipBL.GetInTable(result);
            Assert.AreEqual(10, resultDB.Rows.Count);
        }

        [TestMethod]
        public void Find()
        {
            EquipmentBL equipBL = new EquipmentBL();


           Midway_Assessment.ClassProperties.Equipment  result = equipBL.Find(@"C:\Users\pcPareto\Documents\ap_assessment_midway\Midway_Assessment\Midway_Assessment\Database\Equipment.csv","vel");

           Assert.AreEqual(7, result.ID);
        }

        [TestMethod]
        public void AlreadyExists_NewRecord()
        {
            EquipmentBL equipBL = new EquipmentBL();


            bool result = equipBL.AlreadyExists_NewRecord( @"C:\Users\pcPareto\Documents\ap_assessment_midway\Midway_Assessment\Midway_Assessment\Database\Equipment.csv","vel");

            Assert.AreEqual(true, result);
        }

                [TestMethod]

        public void AlreadyExists_Update()
        {
            EquipmentBL equipBL = new EquipmentBL();


            bool result = equipBL.AlreadyExists_Update(@"C:\Users\pcPareto\Documents\ap_assessment_midway\Midway_Assessment\Midway_Assessment\Database\Equipment.csv", "vel",4);

            Assert.AreEqual(true, result);
        }


    }
}
