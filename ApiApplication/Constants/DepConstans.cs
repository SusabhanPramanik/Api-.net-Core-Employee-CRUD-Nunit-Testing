using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace ApiApplication.Constants
{
    [ExcludeFromCodeCoverage]
    public static class DepConstans
    {
        public const string DepCreatedSuccessfully = "Department created";
        public const string DuplicateDepartment = "Department name is already exist in the database";
        public const string DepCreationFailed = "Failed to Create Department because there already have this kind of department";
        public const string DepDeleteSuccessfully = "Department has been deleted successfully";
        public const string DepDeleteFailed = "There have no Department in this ID";
        public const string DepUpdateSuccessfully = "The Department has been updated successfully";
        public const string DepUpdateFailed = "There have no such kind of department for update";
        public const string DepUpdateNameFailed = "Failed to update department because there already have this name";

        public const string UserCreatedSuccessfully = "Users created";
        public const string UserCreationFailed = "Failed to Create Users because there already have this kind of Users";
        public const string DuplicateUserCreationFailed = "There have similer Username or similer Employee Code so cheak again";
        public const string UserDeleteSuccessfully = "users has been deleted successfully";
        public const string UserDeleteFailed = "There have no users in this ID";
        public const string UserUpdateSuccessfully = "The users has been updated successfully";
        public const string UserUpdateFailed = "There have no such kind of users for update";
        public const string UserUpdateDuplicateFailed = "In the database same kind of username and employee code already exists";

        public const string SalCreatedSuccessfully = "salary record created";
        public const string SalCreationFailed = "Failed to Create salary data because there already have this kind of Users";
        public const string DuplicateSalaryCreationFailed = "In this Salary username already already exist in the database";
        public const string SalDeleteSuccessfully = "Salary data has been deleted successfully";
        public const string SalDeleteFailed = "There have no Salary in this ID";
        public const string SalUpdateSuccessfully = "The Salary has been updated successfully";
        public const string SalUpdateFailed = "There have no such kind of Salary data for update";
        public const string SalUpdateDuplicateFailed = "You can not update Salarys user id";

        public const string RoleCreatedSuccessfully = "Role created";
        public const string RoleCreationFailed = "Failed to Create Role because there already have this kind of Users";
        public const string DuplicateRoleCreationFailed = "You entered same name which is already present in the database";
        public const string RoleDeleteSuccessfully = "Role has been deleted successfully";
        public const string RoleDeleteFailed = "There have no Role in this ID";
        public const string RoleUpdateSuccessfully = "The Role has been updated successfully";
        public const string RoleUpdateFailed = "There have no such kind of Role for update";
        public const string UpdateRoleCreationFailed = "This role name already exist into the database";

        public const string UserMappingCreatedSuccessfully = "UserMapping created";
        public const string UserMappingCreationFailed = "Failed to Create UserMapping";
        public const string DuplicateUsermapingCreationFailed = "U have enters same user Id or same role ID ";
        public const string UserMappingDeleteSuccessfully = "UserMapping has been deleted successfully";
        public const string UserMappingDeleteFailed = "There have no UserMapping in this ID";
        public const string UserMappingUpdateSuccessfully = "The UserMapping has been updated successfully";
        public const string UserMappingUpdateFailed = "There have no such kind of UserMapping for update";

        public const string DepIDnotFoud = "There have no depratment in this ID";
        public const string UsersIdNotFound = "There have no User in this ID";
        public const string SalIdNotFound = "There have no Salary in this ID";
        public const string RoleIdNotFound = "There have no Role in this ID";
        public const string UsermapIDNotFound = "There have no Usermaping in this ID";

        public const string DepIDFound = "We found Department";
        public const string UserIDFound = "We found the User";
        public const string SalIDFound = "We found Salarys";
        public const string RoleIDFound = "We found Roles Information";
        public const string UsermapIDFound = "We found UserMapings";
    }
}
