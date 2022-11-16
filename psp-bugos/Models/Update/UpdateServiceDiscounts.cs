using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace psp_bugos.Models.Update
{
    public record UpdateServiceDiscounts
    {
        /** <summary>GUID of a service</summary>
         *  <example>2e816ad7-5cd7-4da0-bc93-879b36633207</example>
         */
        public Guid ServiceId { get; set; }
        [BindRequired]
        /** <summary>List of discount GUIDs to be removed</summary>
         * <example>2e816ad7-5cd7-4da0-bc93-879b3663320; 2e816ad7-5cd7-4da0-bc93-879b3663321; 2e816ad7-5cd7-4da0-bc93-879b3663322</example>
         */
        public List<Guid>? AddServiceDiscounts { get; set; }
        [BindRequired]
        /** <summary>List of discount GUIDs to be removed</summary>
         * <example>2e816ad7-5cd7-4da0-bc93-879b3663320; 2e816ad7-5cd7-4da0-bc93-879b3663321; 2e816ad7-5cd7-4da0-bc93-879b3663322</example>
         */
        public List<Guid>? RemoveServiceDiscounts { get; set; }
    }
}
