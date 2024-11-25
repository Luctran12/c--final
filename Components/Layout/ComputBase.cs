using Microsoft.AspNetCore.Components;

namespace BlazorApp.Components.Layout;

public class ComputBase : ComponentBase
{
    public int number1 { get; set; }
    public int number2 { get; set; }
    public int result { get; set; }

    public void Add()
    {
        result = number1 + number2;
    }

    public void Clear()
    {
        number1 = 0;
        number2 = 0;
        result = 0;
    }
}
