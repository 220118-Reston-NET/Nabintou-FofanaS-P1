using ShoppingModel;
using ShoppingDL;

namespace ShoppingBL
{
    public class LineItemBL: ILineItemBL
    {
        private readonly IRepository_cart _itemRepo;

        public LineItemBL(IRepository_cart b_itemRepo)
        {
            _itemRepo = b_itemRepo;
        }

    public async Task<LineItem> AddLineItem(LineItem b_item)
    {
        return await _itemRepo.AddLineItem(b_item);
    }
}
}