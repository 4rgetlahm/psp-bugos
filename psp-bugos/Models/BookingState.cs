namespace psp_bugos.Models;

public enum BookingState
{
    Created,
    Confirmed,
    ClientArrived,
    Recheduled,
    Refunded,
    Cancelled
}