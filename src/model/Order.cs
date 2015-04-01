
namespace oncast_taos.src.model
{
    public class Order
    {
        public string Property;
        public OrderDirection Direction;
    }

    public enum OrderDirection
    {
        Ascendent,
        Descendent
    }
}
