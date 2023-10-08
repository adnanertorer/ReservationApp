namespace Reservation.Service.ResponseProviders.CustomerReservations.Constants
{
    public class ReservationMessages
    {
        public const string TableIsNotAvailable = "Bu masa dolu görünüyor. Başka bir masa ya da başka bir tarih seçiniz.";
        public const string TableCapacityNotAvailable = "Bu masa {0} kişilik. Siz {1} kişilik bir masa arıyorsunuz. Lütfen başka bir masa seçiniz";
        public const string MailBody = "Reservasyonunuz tamamlandı. Reservasyon bilgilerinizi aşağıdadır.</b><p>Reservasyon Sahibi: {0} {1}</p>" +
                    "<p>Reservasyon Zaman Aralığı: {2} - {3}</p><p>Masa Numarası: {4}</p>";
    }
}
