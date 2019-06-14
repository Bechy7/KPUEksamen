using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security;
using System.Security.Policy;
using System.Security.Permissions;
using System.Reflection;
using System.Runtime.Remoting;

//The Sandboxer class needs to derive from MarshalByRefObject so that we can create it in another   
// AppDomain and refer to it from the default AppDomain.  
class Sandboxer : MarshalByRefObject
{
    const string pathToUntrusted = @"C:\Users\Fatima\Documents\IKT\6. semester\KPU\Opgaver\LAB5_2\LAB5_2\bin\Debug\netstandard2.0";
    const string untrustedAssembly = "LAB5_2";
    const string untrustedClass = "LAB5_2.FileReader";
    const string entryPoint = "ReadFile";
    private static Object[] parameters = { @"C:\Users\Fatima\Documents\IKT\6. semester\KPU\Opgaver\LAB5_2\testfile.txt" };
    static void Main()
    {
        //Permissions are set to only be able to execute the assembly
        PermissionSet permSet = new PermissionSet(PermissionState.None);
        permSet.AddPermission(new SecurityPermission(SecurityPermissionFlag.Execution));
        // could have used Evidence instead

        //Setting the AppDomainSetup. It is very important to set the ApplicationBase to a folder   
        //other than the one in which the sandboxer resides
        // - mitigates the risk that the pathToUntrusted cannot exploit
        AppDomainSetup adSetup = new AppDomainSetup();
        adSetup.ApplicationBase = Path.GetFullPath(pathToUntrusted);

        // create the AppDomain
        AppDomain newDomain = AppDomain.CreateDomain("Sandbox", null, adSetup, permSet, null);

        //Use CreateInstanceFrom to load an instance of the Sandboxer class into the  
        //new AppDomain.   
        ObjectHandle handle = Activator.CreateInstanceFrom(
            newDomain, typeof(Sandboxer).Assembly.ManifestModule.FullyQualifiedName,
            typeof(Sandboxer).FullName
            );

        //Unwrap the new domain instance into a reference in this domain and use it to execute the   
        //untrusted code.  
        Sandboxer newDomainInstance = (Sandboxer)handle.Unwrap();

        newDomainInstance.ExecuteUntrustedCode(untrustedAssembly, untrustedClass, entryPoint, parameters);
    }

    public void ExecuteUntrustedCode(string assemblyName, string typeName, string entryPoint, Object[] parameters)
    {
        //Load the MethodInfo for a method in the new Assembly. This might be a method you know, or   
        //you can use Assembly.EntryPoint to get to the main function in an executable.  
        MethodInfo target = Assembly.Load(assemblyName).GetType(typeName).GetMethod(entryPoint);
        try
        {
            //Now invoke the method.  
            Console.WriteLine("Attempting to invoke method in sandbox .. ");
            var retVal = target.Invoke(null, parameters);
            Console.WriteLine(retVal);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{assemblyName} does not have permission to do stuff!");
            // When we print informations from a SecurityException extra information can be printed if we are   
            //calling it with a full-trust stack.  
            // new PermissionSet(PermissionState.Unrestricted).Assert();
            Console.WriteLine("SecurityException caught:\n{0}", ex.ToString());
            //CodeAccessPermission.RevertAssert();
            Console.ReadLine();
        }
    }
}