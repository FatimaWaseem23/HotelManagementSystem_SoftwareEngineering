using VMS.SQLServerCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Configuration;
using static Roomers_Application.Models.Common;

namespace Roomers_Application.DataAccess
{
    public class ServiceAccess
    {
        private readonly DBAccess db = new DBAccess();
        
        public DataTable AuthenticateUserCredentials(string loginID, string password)
        {
            var cmd = new SqlCommand();
            cmd.Parameters.Add(new SqlParameter("@LoginID", loginID));
            cmd.Parameters.Add(new SqlParameter("@Password", password));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "AuthenticateUserCredentials";
            return db.ExecuteCommandAsDataTable(cmd);
        }

        public void Update_UserLastLoginDate(int userID)
        {
            var cmd = new SqlCommand();
            cmd.Parameters.Add(new SqlParameter("@UserID", userID));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Update_UserLastLoginDate";
            db.ExecuteCommandAsNonQuery(cmd);
        }


        public DataSet Insert_NewUser(VMS_Users user, string loggedInUserID)
        {
            var cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@LoginID", user.LoginID));
            cmd.Parameters.Add(new SqlParameter("@UserFullName", user.UserFullName));
            cmd.Parameters.Add(new SqlParameter("@Email", user.Email));
            cmd.Parameters.Add(new SqlParameter("@Password", user.Password));
            cmd.Parameters.Add(new SqlParameter("@UserType", user.UserType));
            cmd.Parameters.Add(new SqlParameter("@LoggedInUser", loggedInUserID));
            cmd.CommandText = "Insert_NewUser";
            return db.ExecuteCommandAsDataSet(cmd);
        }

        public DataSet Update_ExistingUser(VMS_Users user, string loggedInUserID)
        {
            var cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.Add(new SqlParameter("@UserID", user.UserID));
            cmd.Parameters.Add(new SqlParameter("@UserFullName", user.UserFullName));
            cmd.Parameters.Add(new SqlParameter("@Email", user.Email));
            cmd.Parameters.Add(new SqlParameter("@Password", user.Password));
            cmd.Parameters.Add(new SqlParameter("@UserType", user.UserType));
            cmd.Parameters.Add(new SqlParameter("@LoggedInUser", loggedInUserID));
            cmd.CommandText = "Update_ExistingUser";
            return db.ExecuteCommandAsDataSet(cmd);
        }


        
        public DataTable Get_ListOfUsers()
        {
            var cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Update_UserLastLoginDate";
            return db.ExecuteCommandAsDataTable(cmd);
        }

        public DataSet Get_DashboardResults(int teamID = 0)
        {
            var cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@teamID", teamID));
            cmd.CommandText = "Get_DashboardResults";
            return db.ExecuteCommandAsDataSet(cmd);
        }

        public DataSet Get_UserAssignedVulnerabilities(int teamID, int ID = 0)
        {
            var cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@teamID", teamID));
            cmd.Parameters.Add(new SqlParameter("@ID", ID));
            cmd.CommandText = "Get_UserAssignedVulnerabilities";
            return db.ExecuteCommandAsDataSet(cmd);
        }

        public DataSet Get_VulnerabilityRemarksByID(string userID, int ID = 0)
        {
            var cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@LoggedInUserID", userID));
            cmd.Parameters.Add(new SqlParameter("@ID", ID));
            cmd.CommandText = "Get_VulnerabilityRemarksByID";
            return db.ExecuteCommandAsDataSet(cmd);
        }

        

        public void UpdateVulnerabilityStatus(string userID, int vulID, int vulAssignedUser, string vulVulnerabilityRemarks, string vulTargetFixDate, string vulVulnerabilityStatus)
        {
            var cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@LoggedInUserID", userID));
            cmd.Parameters.Add(new SqlParameter("@ID", vulID));
            cmd.Parameters.Add(new SqlParameter("@AssignedTo", vulAssignedUser));
            cmd.Parameters.Add(new SqlParameter("@Remarks", vulVulnerabilityRemarks));
            cmd.Parameters.Add(new SqlParameter("@TargetFixDate", vulTargetFixDate));
            cmd.Parameters.Add(new SqlParameter("@VulStatus", vulVulnerabilityStatus));
            cmd.CommandText = "Update_VulnerabilityStatus";
            db.ExecuteCommandAsNonQuery(cmd);
        }


        public void Insert_VulnerabilitiesMaster(DataTable _vulerabilities)
        {
            var cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Vulnerabilities", _vulerabilities));
            cmd.CommandText = "Insert_VulnerabilitiesMaster";
            db.ExecuteCommandAsNonQuery(cmd);
        }

        public void Insert_ApplicationDetails(DataTable _vulerabilities)
        {
            var cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@ApplicationDetails", _vulerabilities));
            cmd.CommandText = "Insert_ApplicationDetails";
            db.ExecuteCommandAsNonQuery(cmd);
        }

        public DataTable Get_ApplicationDetails(string userID, int ID = 0)
        {
            var cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@LoggedInUserID", userID));
            cmd.CommandText = "Get_ApplicationDetails";
            return db.ExecuteCommandAsDataTable(cmd);
        }

        public DataSet Get_TeamDetails(string userID)
        {
            var cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@LoggedInUserID", userID));
            cmd.CommandText = "Get_TeamDetails";
            return db.ExecuteCommandAsDataSet(cmd);
        }

        public DataSet Get_AllUser()
        {
            var cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Get_AllUser";
            return db.ExecuteCommandAsDataSet(cmd);
        }
        
        public DataSet Insert_NewTeam(string userID, string teamName, string familyName)
        {
            var cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@TeamName", teamName));
            cmd.Parameters.Add(new SqlParameter("@FamilyName", familyName));
            cmd.Parameters.Add(new SqlParameter("@LoggedInUserID", userID));
            cmd.CommandText = "Insert_NewTeam";
            return db.ExecuteCommandAsDataSet(cmd);
        }

        public DataSet Update_ExistingTeam(string userID, int teamID, string familyName)
        {
            var cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Team_ID", teamID));
            cmd.Parameters.Add(new SqlParameter("@FamilyName", familyName));
            cmd.Parameters.Add(new SqlParameter("@LoggedInUserID", userID));
            cmd.CommandText = "Update_ExistingTeam";
            return db.ExecuteCommandAsDataSet(cmd);
        }

        public DataSet Insert_NewApplication(string applicationName, int applicationTeamID, string applicationClassification, string applicationPCIScope, string loggedInUserID)
        {
            var cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@ApplicationName", applicationName));
            cmd.Parameters.Add(new SqlParameter("@Team_ID", applicationTeamID));
            cmd.Parameters.Add(new SqlParameter("@Classification", applicationClassification));
            cmd.Parameters.Add(new SqlParameter("@PCIScope", applicationPCIScope));
            cmd.Parameters.Add(new SqlParameter("@LoggedInUserID", loggedInUserID));
            cmd.CommandText = "Insert_NewApplication";
            return db.ExecuteCommandAsDataSet(cmd);
        }

        public DataSet Update_ExistingApplication(int applicationID, int applicationTeamID, string applicationClassification, string applicationPCIScope, string loggedInUserID)
        {
            var cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@ApplicationID", applicationID));
            cmd.Parameters.Add(new SqlParameter("@Team_ID", applicationTeamID));
            cmd.Parameters.Add(new SqlParameter("@Classification", applicationClassification));
            cmd.Parameters.Add(new SqlParameter("@PCIScope", applicationPCIScope));
            cmd.Parameters.Add(new SqlParameter("@LoggedInUserID", loggedInUserID));
            cmd.CommandText = "Update_ExistingApplication";
            return db.ExecuteCommandAsDataSet(cmd);
        }

        
        public DataSet Update_MapIpApplication(int ApplicationID, int MapIpApplicationID, string userID)
        {
            var cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@ApplicationID", ApplicationID));
            cmd.Parameters.Add(new SqlParameter("@MapIpApplicationID", MapIpApplicationID));
            cmd.Parameters.Add(new SqlParameter("@LoggedInUserID", userID));
            cmd.CommandText = "Update_MapIpApplication";
            return db.ExecuteCommandAsDataSet(cmd);
        }
        

    }
}