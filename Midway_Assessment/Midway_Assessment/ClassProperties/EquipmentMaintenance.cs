using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Midway_Assessment.ClassProperties
{
    public class EquipmentMaintenance
    {
        ClassProperties.Equipment objEquip;
        int id;
        DateTime workDateTime;
        int timeTaken;
        string description;

        public EquipmentMaintenance()
        {
            objEquip = new Equipment();
            id = -1;
            workDateTime = DateTime.Now;
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
        public DateTime WorkDateTime
        {
            get
            {
                return this.workDateTime;
            }
            set
            {
                this.workDateTime = value;
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
    }
}