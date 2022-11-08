namespace psp_bugos.Models;

public class TimeSlot
{
    public Guid Id { get; set; }
    
    public Guid AssignedEmployeeId { get; set; }
    
    public Guid LocationId { get; set; }
    
    public Guid ServiceId { get; set; }
    
    public DateTime From { get; set; }
    
    public DateTime To { get; set; }
}