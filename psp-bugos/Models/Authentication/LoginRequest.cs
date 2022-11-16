namespace psp_bugos.Models.Authentication
{
    public record LoginRequest
    {
        /** <summary>Username of an account</summary>
         *  <example>Jonas360</example>
         */
        public string? Username { get; set; }

        /** <summary>Password of an account</summary>
         *  <example>f2q86a1v747AZZ</example>
         */
        public string? Password { get; set; }
    }
}
