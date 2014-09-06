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
    public class EquipmentBL_TDD
    {
        string filePath = @"C:\Users\pcPareto\Documents\ap_assessment_midway\Midway_Assessment\Midway_Assessment\Database\Equipment.csv";
        public EquipmentBL_TDD()
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
            EquipmentBL equipBL = new EquipmentBL(filePath);

            EquipmentDB equipDB = new EquipmentDB();

            string result = equipDB.ReadAll(filePath);

            DataTable resultDB = equipBL.GetInTable(result);
            //Expected result will vary depending on number of records in the table.
            Assert.AreEqual(10, resultDB.Rows.Count);
        }

        [TestMethod]
        public void Find()
        {
            EquipmentBL equipBL = new EquipmentBL(filePath);


           Midway_Assessment.ClassProperties.Equipment  result = equipBL.Find("eu");

           Assert.AreEqual(10, result.ID);
        }

        [TestMethod]
        public void AlreadyExists_NewRecord()
        {
            EquipmentBL equipBL = new EquipmentBL(filePath);


            bool result = equipBL.AlreadyExists_NewRecord( "eu");

            Assert.AreEqual(true, result);
        }

                [TestMethod]

        public void AlreadyExists_Update()
        {
            EquipmentBL equipBL = new EquipmentBL(filePath);


            bool result = equipBL.AlreadyExists_Update("eu",4);

            Assert.AreEqual(true, result);
        }

               
                //[TestMethod]
                //public void Test_UpdateRecord()
                //{
                //    EquipmentBL equipBL = new EquipmentBL(filePath);
                //     Midway_Assessment.ClassProperties.Equipment objEquip  = new Midway_Assessment.ClassProperties.Equipment();
                //    objEquip.ID = 7;
                //    objEquip.Name = "Testing Update";
                //    bool result = equipBL.UpdateRecord(objEquip);
                //    Assert.AreEqual(true, result);
                //}
                //[TestMethod]
                //public void Test_DeleteRecord()
                //{
                //    EquipmentBL equipBL = new EquipmentBL(filePath);
                //    Midway_Assessment.ClassProperties.Equipment objEquip = new Midway_Assessment.ClassProperties.Equipment();
                //    int id = 7;
                //    bool result = equipBL.DeleteRecord( id);
                //    Assert.AreEqual(true, result);
                //}
                [TestMethod]
                public void GetMaxID()
                {
                    EquipmentBL equipBL = new EquipmentBL(filePath);
                    
                    int result = equipBL.GetMaxID();

                    Assert.AreEqual(10, result);
                }


    }
}
