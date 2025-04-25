using System.Threading.Channels;

namespace CSAdvProg20_Reflection;
using System.Reflection;
using ReflectionExpLib;

class Program
{
    static void Main(string[] args)
    {
        //Reflection
        //A feature that allows us to access any concepts' (class, struct, delegate, method, etc.) info and manipulate them in runtime.
        
        
        //Reflection has 3 main usage purposes;
        //-Type Info Check: We can review any concepts' name, properties, methods, fields, etc. info.
        //Thus, we can dynamically take actions based on this info by accessing them in runtime.
        //-New Type Creation or Load One: Reflection makes it possible to create new types or load the ones from .dll files.
        //-Running Members Dynamically: We can call or run members such as methods and properties via reflection in run time.
        
        
        //Now we can start with two different level performance;
        //Application Level Reflection: you can call all the types with app performing app-level reflection. We benefit from System.Reflection.Assembly class...
        //... to practise this action. 
        //Type Level Reflection: you can utilize from this one in case you want to access some specific types' members. We use Type class or typeof keyword to...
        //... practice this action.
        
        
        //What does assembly mean based on the context?
        //Assembly corresponds to the app or the state of the app with .dll file generated.
        //There are two types of assembly within .NET architecture;
        //-Compile Time Assembly: is what is called .dll or .exe files acquired from the source code compilation.
        //-Run Time Assembly: is assemblies that can be generated and loaded dynamically. We will access these assemblies with app level reflection.
        
        //A little introductory app level reflection: https://youtu.be/5SiAm7PlOOU?list=PLQVXoXFVVtp1yha_meMc706hDgz4WAvHH&t=818
        
        
        //What is module?
        //It's what's called assemblies referenced in assemblies.
        //To do that; first right click on the solution and create a new project by selecting library option and then...
        //... right click on our main project Add >> Reference... select the project generated and now you have a module in your main assembly.
        //Modules can be accessed via app level reflection too.
        
        
        //Sum practises
        Assembly assembly1 = Assembly.GetExecutingAssembly(); //Gets info about this file executed. To access everything defined and declared within this...
        //... file, we will utilize from this method.
        //If it was written in a class declared in another library, then it would bring the assembly's info where its declared although its...
        //... called in this assembly.
        Class1 obj1 = new Class1();
        Assembly assembly2 = Assembly.Load("ReflectionExpLib");
        Console.WriteLine(assembly1.GetName().Name);
        Console.WriteLine(assembly2.FullName);
        
        //If we wanna specifically get a type's info
        assembly2.GetType("Class1");
        assembly2.GetTypes();//Brings all the types defined
        
        
        //Type & Type Discovery
        //We utilize from Type class to have representatives of any conceptual type in programming.
        //Type encompasses a type's properties, methods, fields and other features.
        //We can get Type info of anything with GetType() method. Check below;
        Object obj2 = new();
        Console.WriteLine(obj2.GetType());
        //It is also possible to get the Type of any instance declared and encompassed by an Assembly object;
        Assembly assembly3 = Assembly.Load("ReflectionExpLib");
        Console.WriteLine(assembly3.GetType("Class1"));
        //We can use typeof() keyword for acquiring Type info for direction with the structure name instead of their instances;
        Console.WriteLine(typeof(Class1));
        //Type Discovery is what the action of getting Type objects of anything dynamically is called.
        
        
        //Accessing members of a concept with (Type level) reflection
        Type type1 = typeof(Class2);
        var members1 = type1.GetMembers();
        foreach (var VARIABLE in members1)
        {
            Console.WriteLine(VARIABLE.Name);
        }
        
        //Getting values of members of objects and change them with Type class
        Class2 obj3 = new() {Field1 = 1, Field2 = "Efe", Field3 = true};
        Type type2 = obj3.GetType();
        PropertyInfo propertyInfo1 = type2.GetProperty(nameof(Class2.Field3)); //For the type safety, we can utilize from ...
        //... nameof(*ClassName.AnyPropertyIncludingNonStatics) keyword instead of risking misspelling by giving the argument...
        //... (name of the relevant property) within parenthesis.
        //We gave the info about the property to the relevant class object.
        propertyInfo1.SetValue(obj3, false); //Now we can modify the relevant property of any relevant class instances.
        Console.WriteLine(propertyInfo1.GetValue(obj3));
        
        //Invoking Methods;
        MethodInfo methodInfo1 = type2.GetMethod(nameof(Class2.Method1));
        MethodInfo methodInfo2 = type2.GetMethod(nameof(Class2.Method2));
        methodInfo1.Invoke(obj3, null);
        Console.WriteLine(methodInfo2.Invoke(obj3, new object?[] {1, 2}));
        
        
        //Accessing private members with reflection;
        FieldInfo[] members = type2.GetFields(BindingFlags.NonPublic | BindingFlags.Instance); //Brings private members of the relevant class.
        Console.WriteLine(members == null ? "Null": members.Length);
        foreach (var VARIABLE in members)
            Console.WriteLine(VARIABLE.Name);
        //To get specifically single private member;
        FieldInfo field1 = type2.GetField("privField1", BindingFlags.NonPublic | BindingFlags.Instance);
    }
}