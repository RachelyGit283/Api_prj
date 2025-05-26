

namespace DTO
{
    public record OrderDto(int OrderId, int UserId, DateOnly OrderDate, double OrderSum, List<OrderItemDto> Products);

}
