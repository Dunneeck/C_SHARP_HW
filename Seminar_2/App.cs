namespace Seminar_2;

class App 
{
    public static void Main(string[] args)
    {
        Bits bits = new(4);

        //Console.WriteLine(bits.GetBitByIndex(2));
        //bits.SetBitByIndex(0, true);
        //Console.WriteLine(bits.GetBitByIndex(0));
        //bits[1] = true;
        //Console.WriteLine(bits[1]);
        //Console.WriteLine(bits.Value);
        //Console.WriteLine(bits);

        Console.WriteLine("______________");

        byte valByte = bits;
        valByte = 1;
        bits = (Bits)valByte;
        Console.WriteLine($"{valByte.GetType()} - {valByte}");


        int valInt = bits;
        valInt = 2;
        bits = (Bits)valInt;
        Console.WriteLine($"{valInt.GetType()} - {valInt}");

        long valLong = bits;
        valLong = 3;
        bits = (Bits)valLong;
        Console.WriteLine($"{valLong.GetType()} - {valLong}");



        //Devices devices = new Devices();
        //Bits bits = new Bits(122);
        //Console.WriteLine(devices);
        //devices.TurnOnOff(bits);
        //Console.WriteLine(devices);



        //Bits bitsByte = new Bits((byte)122);
        //Bits bitsInt = new Bits((int)122);
        //Bits bitsLong = new Bits((long)122);
        //Console.WriteLine(bitsByte);
        //Console.WriteLine(bitsInt);
        //Console.WriteLine(bitsLong);


        //Collection<String> str = new Collection<string>(3);
        //str[0] = "a";
        //str[1] = "b";
        //Console.WriteLine(str[1]+ str[0]);
    }
}
