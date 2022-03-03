using ShoppingModel;

namespace ShoppingBL
{
    public interface ILineItemBL
    {
        Task<LineItem> AddLineItem(LineItem b_item);
    }
}