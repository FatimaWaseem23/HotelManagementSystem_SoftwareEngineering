using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Roomers_Application.Models
{
    public class Common
    {
        public class VMS_Users
        {
            public int UserID { get; set; }
            public string LoginID { get; set; }
            public string UserFullName { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string Status { get; set; }
            public DateTime Last_Login { get; set; }
            public DateTime Creation_date { get; set; }
            public int Team_ID { get; set; }
            public string DesktopId { get; set; }
            public string UserType { get; set; }

        }

        public class TeamDetail
        {
            public int Team_ID { get; set; }
            public string TeamName { get; set; }
        }

        public class VulDetail_RemarksDetail
        {
            public int ID { get; set; }

            public string VulID { get; set; }

            public int UserID { get; set; }

            public string Comment { get; set; }

            public DateTime CommentDate { get; set; }

            public DateTime Target_Fix_Date { get; set; }

            public string Status { get; set; }
            public string UserFullName { get; set; }
            public string LoginID { get; set; }

        }


        public class Application_Details
        {
            public int RowNo { get; set; }

            public string IP_Address { get; set; }

            public string DNS_Name { get; set; }

            public string OS_Version { get; set; }

        }

        public class VulMaster_Main
        {
            public int ID { get; set; }

            public string VulID { get; set; }

            public string IP_Address { get; set; }

            public string DNS_Name { get; set; }

            public string Plugin { get; set; }

            public string Plugin_Name { get; set; }

            public string Family { get; set; }

            public string Severity { get; set; }

            public string Protocol { get; set; }

            public string Port { get; set; }

            public string Exploit { get; set; }

            public string Pulgin_Text { get; set; }

            public string Synopsis { get; set; }

            public string Description { get; set; }

            public string Solution { get; set; }

            public string See_Also { get; set; }

            public string Risk_Factor { get; set; }

            public float? Vulnerability_Priority_Rating { get; set; }

            public string First_Discovered { get; set; }

            public string Last_Observed { get; set; }

            public string Vuln_Publication_Date { get; set; }

            public string Patch_Publication_Date { get; set; }

            public string Plugin_Modification_Date { get; set; }

            public string Exploit_Ease { get; set; }

            public string Exploit_Frameworks { get; set; }

            public string Check_Type { get; set; }

            public string Status { get; set; }

            public DateTime Last_Uploaded { get; set; }

            public string Target_Fix_Date { get; set; }

            public DateTime? Create_Date { get; set; }
            public string Application_Owner_TeamName { get; set; }
            public string VulnerabilityAssigned_OwnerTo_TeamName { get; set; }

        }

        public class ResponsiblityMatrix
        {
            public string Team { get; set; }
            public decimal countper { get; set; }
        }

        public class MonthlyTrend
        {
            public string Severity { get; set; }
            public string MonthYear { get; set; }
            public int TotalCount { get; set; }
        }

        public class MonthlyTrendJSonObj
        {
            public List<string> SeverityType { get; set; }
            public List<MonthlyTrendSeriesData> monthlyTrendSeriesDatas { get; set; }
            
        }

        public class MonthlyTrendSeriesData
        {
            public string name { get; set; }
            public List<int> data { get; set; }
        }
        public class VulMaster
        {
            public int RowNo { get; set; }
            public string IP_Address { get; set; }

            public string DNS_Name { get; set; }

            public string Plugin { get; set; }

            public string Plugin_Name { get; set; }

            public string Family { get; set; }

            public string Severity { get; set; }

            public string Protocol { get; set; }

            public string Port { get; set; }

            public string Exploit { get; set; }

            public string Pulgin_Text { get; set; }

            public string Synopsis { get; set; }

            public string Description { get; set; }

            public string Solution { get; set; }

            public string See_Also { get; set; }

            public string Risk_Factor { get; set; }

            public float? Vulnerability_Priority_Rating { get; set; }

            public string First_Discovered { get; set; }

            public string Last_Observed { get; set; }

            public string Vuln_Publication_Date { get; set; }

            public string Patch_Publication_Date { get; set; }
            public string Plugin_Publication_Date { get; set; }

            public string Plugin_Modification_Date { get; set; }

            public string Exploit_Ease { get; set; }

            public string Exploit_Frameworks { get; set; }

            public string Check_Type { get; set; }

        }

    }
}