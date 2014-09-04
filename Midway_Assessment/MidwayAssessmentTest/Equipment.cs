using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Midway_Assessment.DataAccessLayer;
using Midway_Assessment.BusinessLogicLayer;
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


        //Testing BL Layer
        [TestMethod]
        public void GetInTable()
        {
            EquipmentBL equipBL = new EquipmentBL();

            EquipmentDB equipDB = new EquipmentDB();

            string result = equipDB.ReadAll(@"C:\Users\pcPareto\Documents\ap_assessment_midway\Midway_Assessment\Midway_Assessment\Database\Equipment.csv");

            DataTable resultDB = equipBL.GetInTable(result);
            Assert.AreEqual(10, resultDB.Rows.Count);
        }


    }
}
