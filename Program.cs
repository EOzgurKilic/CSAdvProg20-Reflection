namespace CSAdvProg20_Reflection;

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
    }
}