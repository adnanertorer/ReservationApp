namespace Reservation.Service.ResponseProviders.Tables.ResponseDtos
{
    public class TableDto
    {
        public long Id { get; set; }
        public string TableName { get; set; }
        public int Capacity { get; set; }
        public short? Status { get; set; }
    }
}
