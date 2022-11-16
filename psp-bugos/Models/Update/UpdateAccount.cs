using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace psp_bugos.Models.Update
{
    public record UpdateAccount
    {
        /** <summary>GUID of a bussiness</summary>
 *  <example>2e816ad7-5cd7-4da0-bc93-879b36633207</example>
 */
        [BindRequired]
        public Guid BusinessId { get; set; }

        /** <summary>Username of an account</summary>
         *  <example>Jonas360</example>
         */
        public string? Username { get; set; }

        /** <summary>Password of an account</summary>
         *  <example>Sl4ptaz0di5</example>
         */
        public string? Password { get; set; }

        /** <summary>Name of an account owner</summary>
         *  <example>Jonas</example>
         */
        public string? Name { get; set; }

        /** <summary>Surname of an account ownern</summary>
         *  <example>Jonaitis</example>
         */
        public string? SurName { get; set; }

        /** <summary>Surname of an account owner</summary>
         *  <example>+37064731567</example>
         */
        public string? PhoneNumber { get; set; }

        /** <summary>Email of an account owner</summary>
         *  <example>jonas@gmail.com</example>
         */
        public string? Email { get; set; }

        /** <summary>First address line of an account owner</summary>
         *  <example>Jono g. 24</example>
         */
        public string? AddressLine1 { get; set; }


        /** <summary>Second address line of an account owner</summary>
         *  <example>Jono g. 24</example>
         */
        public string? AddressLine2 { get; set; }


        /** <summary>City of adresss line filled in AdressLines</summary>
         *  <example>Jono g. 24</example>
         */
        public string? City { get; set; }
    }
}
