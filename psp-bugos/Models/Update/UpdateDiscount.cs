namespace psp_bugos.Models.Update
{
    public record UpdateDiscount
    {
        /** <summary>GUID of a discount</summary>
         *  <example>2e816ad7-5cd7-4da0-bc93-879b36633207</example>
         */
        public Guid? DiscountId { get; set; }
        /** <summary>GUID of a bussiness</summary>
         *  <example>2e816ad7-5cd7-4da0-bc93-879b36633207</example>
         */
        public Guid? BusinessId { get; set; }

        /** <summary>Name of discount</summary>
         *  <example>Halloween discount</example>
         */
        public string? Name { get; set; }

        /** <summary>Discount rate</summary>
         *  <example>20</example>
         */
        public int? Rate { get; set; }
    }
}
