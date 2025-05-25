using static SevenFoodApp.Util.Enums;

namespace SevenFoodApp.dto;

public class UserDto
{
    public int Id { get; set; }
    public string Name { get; set; }

    public TYPE_USER Type { get; set; }
}