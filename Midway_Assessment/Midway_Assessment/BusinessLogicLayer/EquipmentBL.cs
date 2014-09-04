using Midway_Assessment.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Midway_Assessment.BusinessLogicLayer
{
    public class EquipmentBL
    {

        public DataTable GetInTable(string inputData)
        {
            EquipmentDB objEquipDB = new EquipmentDB();

            string[] arrayInputData = inputData.Split( '\n');

            DataTable dtEquipmentData = new DataTable();
            if (arrayInputData.Length > 0)
            {
                string[] arrayFirstRow = arrayInputData[0].Split(',');
                string[] arrayNextRow;
                if (arrayFirstRow.Length == 2)
                {
                    arrayFirstRow[0] = arrayFirstRow[0].Trim();
                    arrayFirstRow[1] = arrayFirstRow[1].Trim();

                    dtEquipmentData.Columns.Add(arrayFirstRow[0].Trim());
                    dtEquipmentData.Columns.Add(arrayFirstRow[1].Trim());

                    for (int index = 1; index < arrayInputData.Length; ++index)
                    {
                        arrayNextRow = null;
                        arrayNextRow = arrayInputData[index].Split(',');
                        if (arrayNextRow.Length == 2)
                        {
                            DataRow drEquipment = dtEquipmentData.NewRow();
                            drEquipment[arrayFirstRow[0]] = arrayNextRow[0];
                            drEquipment[arrayFirstRow[1]] = arrayNextRow[1];

                            dtEquipmentData.Rows.Add(drEquipment);
                        }
                       
                    }

                    return dtEquipmentData;
                }
                else
                {
                    return dtEquipmentData;
                }
            }
            else
            {
                return dtEquipmentData;
            }
            
            

 
        }
    }
}