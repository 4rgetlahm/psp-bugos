using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace psp_bugos.Models.Update
{
    public record UpdateEmployeePrivileges
    {
        [BindRequired]
        /** <summary>List of privileges to be granted</summary>
         * <example>customers.read; customers.update; discount.create;</example>
         */
        public List<string>? AddEmployeePrivileges { get; set; }
        [BindRequired]
        /** <summary>List of privileges to be revoked</summary>
         * <example>customers.read; customers.update; discount.create;</example>
         */
        public List<string>? RemoveEmployeePrivileges { get; set; }
    }
}
