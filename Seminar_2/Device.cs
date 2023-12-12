namespace Seminar_2;

public class Device : IControllable
{
    public bool IsOn { get; private set; } = false;

    public void On()
    {
        IsOn = true;
    }

    public void Off()
    {
        IsOn = false;
    }
}
