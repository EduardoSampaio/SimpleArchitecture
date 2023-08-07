namespace SimpleArchiteture.Domain.Entities;
public class RentCar
{
    public Guid Id { get; private set; }
    public DateTime BeginDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public decimal DailyPrice { get; private set; }
    public decimal TotalPayable { get; private set; }
    public int NumberDays { get; private set; }
    public decimal Discount { get; private set; }
    public string PickUpLocation { get; set;}
    public Guid ClientID { get; private set; }

    public RentCar(DateTime beginDate, DateTime endDate, decimal dailyPrice, string pickUpLocation, Guid clientID)
    {
        Id = Guid.NewGuid();
        BeginDate = beginDate;
        EndDate = endDate;
        DailyPrice = dailyPrice;
        PickUpLocation = pickUpLocation;
        ClientID = clientID;    
        UpdateTotal();
    }

    public void ApplyDiscount(decimal discount)
    {
        Discount = discount;
        var totalDiscount = TotalPayable * Discount;
        TotalPayable -= totalDiscount;
    }

    public void ChangeDate(DateTime beginDate, DateTime endDate)
    {
        BeginDate = beginDate;
        EndDate = endDate;
        UpdateTotal();
    }

    private void UpdateTotal()
    {
        NumberDays = EndDate.Day - BeginDate.Day;
        TotalPayable = DailyPrice * NumberDays;
    }

}
