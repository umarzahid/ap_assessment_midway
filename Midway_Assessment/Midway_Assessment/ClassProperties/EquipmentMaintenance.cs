﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Midway_Assessment.ClassProperties
{
    public class EquipmentMaintenance
    {
        ClassProperties.Equipment objEquip;
        int id;
        DateTime workDate;
        string workTime;
        int timeTaken;
        string description;

        public EquipmentMaintenance()
        {
            objEquip = new Equipment();
            id = -1;
            workDate = DateTime.Now;
            workTime = "00:00";
            timeTaken = 0;
            description = string.Empty;
        }

        public ClassProperties.Equipment ObjEquip
        {
            get
            {
                return this.objEquip;
            }
            set
            {
                this.objEquip = value;
            }
        }
        public int ID
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }
        public DateTime WorkDate
        {
            get
            {
                return this.workDate;
            }
            set
            {
                this.workDate = value;
            }
        }
        public string WorkTime
        {
            get
            {
                return this.workTime;
            }
            set
            {
                this.workTime = value;
            }
        }
        public int TimeTaken
        {
            get
            {
                return this.timeTaken;
            }
            set
            {
                this.timeTaken = value;
            }
        }
        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
            }
        }
        public override string ToString()
        {
            StringBuilder objString = new StringBuilder();
            objString.Append(id);
            objString.Append(",");
            objString.Append(workDate.Date.ToString("dd/MM/yyyy"));
            objString.Append(",");
            objString.Append(WorkTime);
            objString.Append(",");
            objString.Append(Description);
            objString.Append(",");
            objString.Append(ObjEquip.ID.ToString());
            objString.Append(",");
            objString.Append(TimeTaken);

            return objString.ToString();
        }
    }
}