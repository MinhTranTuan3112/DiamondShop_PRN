namespace DiamondShop.DataAccess.Enums
{
    public enum WarrantyType
    {
        Comprehensive,  //Full all product
        Gemstones,      //only gemstone, not include metal frame
        MetalFrame,     //Only metal frame of product, not included diamond
        Period,         //Only in available period
        Repairs,        //For damaged product
        Replacement,    //Replace with an approximately product or new if can't repair
        Cleaning,       //Free cleaning in warranty period
        Polishing       //Free polishing in warranty period
    }
}
