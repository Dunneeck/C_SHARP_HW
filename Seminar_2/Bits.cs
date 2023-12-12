namespace Seminar_2;

public class Bits : IBitGetable
{
    public long Value { get; private set; }
    public int Size { get; private set; }

    public Bits(byte value)
    {
        Value = value;
        Size = sizeof(byte);
    }
    public Bits(int value)
    {
        Value = value;
        Size = sizeof(int);
    }
    public Bits(long value)
    {
        Value = value;
        Size = sizeof(long);
    }


    public bool GetBitByIndex(byte index)
    {
        return (Value & (1 << index)) != 0;
    }

    public void SetBitByIndex(byte index, bool value)
    {
        if (value)
        {
            Value |= (byte)(1 << index);
        }
        else
        {
            Value &= (byte)~(1 << index);
        }
    }

    public bool this[byte index]
    {
        get => GetBitByIndex(index);
        set => SetBitByIndex(index, value);
    }

    public static implicit operator byte(Bits bits) => (byte)bits.Value;
    public static explicit operator Bits(byte value) => new(value);

    public static implicit operator int(Bits bits) => (int)bits.Value;
    public static explicit operator Bits(int value) => new(value);

    public static implicit operator long(Bits bits) => bits.Value;
    public static explicit operator Bits(long value) => new(value);
}
