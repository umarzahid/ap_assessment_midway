using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Midway_Assessment.DataAccessLayer;

namespace MidwayAssessmentTest.DataAccessLayer_Test
{
    [TestClass]
    public class EquipmentDB_TDD
    {
        string filePath = @"C:\Users\pcPareto\Documents\ap_assessment_midway\Midway_Assessment\Midway_Assessment\Database\Equipment.csv";
       
        //Testing DB Layer
        [TestMethod]
        public void ReadAll()
        {
            EquipmentDB equipDB = new EquipmentDB();

            string result = equipDB.ReadAll(filePath);
            Assert.AreNotEqual(string.Empty, result);
        }
        /// <summary>
        /// Testing if data is getting added successfully
        /// </summary>
        //[TestMethod]

        //public void Append()
        //{
        //    EquipmentDB equipDB = new EquipmentDB();

        //    bool result = equipDB.Add(filePath, "1,test");
        //    Assert.AreEqual(true, result);
        //}


    }
}
