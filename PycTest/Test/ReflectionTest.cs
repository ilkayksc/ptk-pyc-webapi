using NUnit.Framework;
using System;
using System.Linq;
using System.Reflection;

namespace PycTest.Test
{

    public class PxEmployee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }

    public class ReflectionTest
    {

        [Test]
        public void test_int()
        {
            int age = 12;
            Type type = age.GetType();

            Console.WriteLine(type.Name);
            Console.WriteLine(type.FullName);
            Console.WriteLine(type.Assembly);
            Console.WriteLine(type.IsClass);
        }

        public void sendMEssage(PxEmployee pxEmployee)
        {

        }

        [Test]
        public void test_user_props()
        {
            PxEmployee o = new PxEmployee();
            var list = o.GetType().GetProperties().ToList();

            foreach (var item in list)
            {
                Console.WriteLine(item.Name);
            }
        }


        [Test]
        public void Test3()
        {
            var user = new PxEmployee
            {
                Id = 1,
                Name = "Recep",
                Surname = "Yesil"
            };

            var nameProperty = user.GetType().GetProperty("Name");
            var value = nameProperty.GetValue(user, null);
            nameProperty.SetValue(user, "Mahmut", null);
            value = nameProperty.GetValue(user, null);


            SetValue(user, "Name", "Cengiz");
            SetValue(user, "Name", 5);
        }
   
        private static void SetValue(object container, string propertyName, object value)
        {
            container.GetType().GetProperty(propertyName).SetValue(container, value, null);
        }

        [Test]
        public void Test1()
        {
            // Declare Instance of class Assembly
            // Call the GetExecutingAssembly method
            // to load the current assembly
            Assembly executing = Assembly.GetExecutingAssembly();

            // Array to store types of the assembly
            Type[] types = executing.GetTypes().Where(x=> x.Name == "ExtensionHelper").ToArray();
            foreach (var item in types)
            {
                // Display each type
                Console.WriteLine("Class : {0}", item.Name);

                // Array to store methods
                MethodInfo[] methods = item.GetMethods();
                foreach (var method in methods)
                {
                    // Display each method
                    Console.WriteLine("--> Method : {0}", method.Name);
                                        

                    method.Invoke(10, null);
                    // Array to store parameters
                    ParameterInfo[] parameters = method.GetParameters();
                    foreach (var arg in parameters)
                    {
                        // Display each parameter
                        Console.WriteLine("----> Parameter : {0} Type : {1}",
                                                arg.Name, arg.ParameterType);
                    }
                }
            }

        }
    }
}
