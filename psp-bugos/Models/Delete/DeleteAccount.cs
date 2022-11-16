using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace psp_bugos.Models.Delete
{
    public record DeleteAccount
    {
        [BindRequired]
        /** <summary>GUID of an account</summary>
         *  <example>5c816af7-9ca7-4da0-bc93-979c36733807</example>
         */
        public Guid? AccountId { get; set; }
    }
}
