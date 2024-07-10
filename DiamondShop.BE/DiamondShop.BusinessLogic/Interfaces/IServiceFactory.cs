namespace DiamondShop.BusinessLogic.Interfaces
{
    public interface IServiceFactory
    {
        IAuthService GetAuthService();

        IProductService GetProductService();

        IOrderService GetOrderService();

        IDiamondService GetDiamondService();

        ICategoryService GetCategoryService();

        IOrderDetailService GetOrderDetailService();

        IWarrantyService GetWarrantyService();
    }
}