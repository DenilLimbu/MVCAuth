using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MVCAuthentication.Models
{
    public class Laliga : IEntity
    {
        public int ID { get; set; }
        public string CLubName { get; set; }
        public int GP { get; set; }
        public int Win { get; set; }
        public int Draw { get; set; }
        public int Lost { get; set; }
        public int GoalFor { get; set; }
        public int GoalAgainst { get; set; }
        public int Goal_Difference { get; set; }
        public int Total_Points { get; set; }

        public void SetFields(DataRow dr)
        {
            this.ID = (int)dr["ID"];
            this.CLubName = (string)dr["CLubName"];
            this.GP = (int)dr["GP"];
            this.Win = (int)dr["Win"];
            this.Draw = (int)dr["Draw"];
            this.Lost = (int)dr["Lost"];
            this.GoalFor = (int)dr["GoalFor"];
            this.GoalAgainst = (int)dr["GoalAgainst"];
            this.Goal_Difference = (int)dr["GoalDifference"];
            this.Total_Points = (int)dr["Points"];
        }
    }
}