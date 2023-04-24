/*

create class library for creating sample data.  Create methods to create random bools, ints (in a range) and names (first and last based off of names from text files)

Bonus:
Add random doubles (in a range), random phone numbers (in the (xxx) xxx-xxxx format), and random zip codes (in the xxxxx-xxxx format).  Support other numeric style formats without additional methods.
*/


using SampleDataBll;

var sd = new Sample();
System.Console.WriteLine("-------------Bool------------------");
for (int i = 0; i < 11; i++)
{
    System.Console.WriteLine(sd.GenerateRandomBool());
}
System.Console.WriteLine("-------------Int------------------");
for (int i = 0; i < 11; i++)
{
    System.Console.WriteLine(sd.GenerateRandomInt());
}
System.Console.WriteLine("-------------First------------------");
for (int i = 0; i < 11; i++)
{
    System.Console.WriteLine(sd.GenerateRandomLastName());
}
System.Console.WriteLine("-------------Last------------------");
for (int i = 0; i < 11; i++)
{
    System.Console.WriteLine(sd.GenerateRandomFirstName());
}
System.Console.WriteLine("--------------Full-----------------");
for (int i = 0; i < 11; i++)
{
    System.Console.WriteLine(sd.GenerateFullName());
}
System.Console.WriteLine("--------------Doubles-----------------");
for (int i = 0; i < 11; i++)
{
    System.Console.WriteLine(sd.GenerateRandomDouble(0, 100));
}
System.Console.WriteLine("--------------Phone-----------------");
for (int i = 0; i < 11; i++)
{
    System.Console.WriteLine(sd.GenerateRandomPhone());
}
System.Console.WriteLine("--------------Zip-----------------");
for (int i = 0; i < 11; i++)
{
    System.Console.WriteLine(sd.GenerateRandomZip());
}

System.Console.WriteLine("--------------xxx-xx-xxxx-----------------");
for (int i = 0; i < 11; i++)
{
    System.Console.WriteLine(sd.GenerateRandomNumberMatch("xxx-xx-xxxx"));
}

