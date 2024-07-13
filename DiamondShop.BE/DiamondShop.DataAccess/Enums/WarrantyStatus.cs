namespace DiamondShop.DataAccess.Enums
{
    public enum WarrantyStatus
    {
        Temporary,          //When created but haven't buy yet
        Availability,       //After paying
        Expired,            //Out of time from buying date
        NotEligible,        //Not reach condition of warranty
        Processing,
        Complete,
        Deleted
    }
}
