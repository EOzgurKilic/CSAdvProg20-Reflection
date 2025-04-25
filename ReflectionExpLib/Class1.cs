using System.Reflection;

namespace ReflectionExpLib;

public class Class1
{
    public Class1()
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        Console.WriteLine(assembly.FullName);
    }
}
public class Class2
{
    private int privField1 = 5;
    private int privField2 = 10;
    public int Field1 { get; set; }
    public string Field2 { get; set; }
    public bool Field3 { get; set; }
    public Class2()
    {}

    public delegate void XHandler();
    public event XHandler Event1;

    public static void Method1()
    {
        Console.WriteLine("Method1");
    }

    public int Method2(int a, int b)
    {
        return Field1 + a + b;
    }
}