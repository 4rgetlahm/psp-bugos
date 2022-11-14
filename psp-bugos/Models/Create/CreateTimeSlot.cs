using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace psp_bugos.Models.Create;

public record CreateTimeSlot
{
    /** <summary>GUID of an employee, who will deliver/provide the service.</summary>
     *  <example>160de46e-b037-45d1-bc57-890c487172a6</example>
     */
    [BindRequired]
    public Guid AssignedEmployeeId { get; set; }

    /** <summary>GUID of a bussiness location where the servvice should be provided.</summary>
     *  <example>cda46ed8-fcf5-482f-836b-60621ebdde7d</example>
     */
    [BindRequired]
    public Guid LocationId { get; set; }

    /** <summary>Datetime when the service can be provided.</summary>
     *  <example>2022-11-03T16:00:00.000Z</example>
     */
    [BindRequired]
    public DateTime From { get; set; }
}