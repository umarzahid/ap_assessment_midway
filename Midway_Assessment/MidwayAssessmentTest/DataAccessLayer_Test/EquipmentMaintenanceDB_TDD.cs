using Microsoft.VisualStudio.TestTools.UnitTesting;
using Midway_Assessment.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidwayAssessmentTest.DataAccessLayer_Test
{
    [TestClass]
    public class EquipmentMaintennaceDB_TDD
    {
        string filePath = @"C:\Users\pcPareto\Documents\ap_assessment_midway\Midway_Assessment\Midway_Assessment\Database\MaintenanceWorks.csv";

        //Testing DB Layer
        [TestMethod]
        public void ReadAll()
        {
            EquipmentMaintenanceDB equipMaintennaceDB = new EquipmentMaintenanceDB();

            string result = equipMaintennaceDB.ReadAll(filePath);
            Assert.AreNotEqual(string.Empty, result);
        }
        /// <summary>
        /// Testing if data is getting added successfully
        /// </summary>
        [TestMethod]

        public void Append()
        {
            EquipmentMaintenanceDB equipMaintenaceDB = new EquipmentMaintenanceDB();

            bool result = equipMaintenaceDB.Add(filePath, "1,test,test,test");
            Assert.AreEqual(true, result);
        }

    }
}
