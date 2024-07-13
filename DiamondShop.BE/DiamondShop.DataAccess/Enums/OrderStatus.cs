namespace DiamondShop.DataAccess.Enums
{
    public enum OrderStatus
    {
        InCart,
        Pending_Confirm,
        Confirmed,
        Pending_Deliver,        //After pay
        Delivering,
        Deliveried,
        Received,
        Pending_Refund,
        Refunded,
        Deleted
    }
}