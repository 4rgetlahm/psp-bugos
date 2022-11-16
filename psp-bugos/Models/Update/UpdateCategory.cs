namespace psp_bugos.Models.Update
{
    public record UpdateCategory
    {
        /** <summary>GUID of a category</summary>
         *  <example>2e816ad7-5cd7-4da0-bc93-879b36633207</example>
         */
        public Guid? CategoryId { get; set; }
        /** <summary>GUID of a bussiness</summary>
         *  <example>2e816ad7-5cd7-4da0-bc93-879b36633207</example>
         */
        public Guid? BusinessId { get; set; }

        /** <summary>Name of category</summary>
         *  <example>8e816af7-5cd7-4da0-bc93-879b36633207</example>
         */
        public string? Name { get; set; }

        /** <summary>GUID of a parent category</summary>
         *  <example>8e816af7-5cd7-4da0-bc93-879b36633207</example>
         */
        public Guid? ParentGuid { get; set; }
    }
}
