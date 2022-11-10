namespace psp_bugos.Models;

public class Order
{
    public Guid Id { get; set; }
    
    public Guid BusinessId { get; set; }
    
    public Guid CustomerId { get; set; }
    
    public Guid EmployeeId { get; set; }
    
    public Guid LocationId { get; set; }
    
    public PaymentType PaymentType { get; set; }
    
    public decimal TotalAmount { get; set; }
    
    public decimal Taxes { get; set; }
    
    public decimal Tips { get; set; }
    
    public decimal AmountPaid { get; set; }
    
    public decimal Change { get; set; }
    
    public DateTime Date { get; set; }
    
    public OrderStatus Status { get; set; }
}