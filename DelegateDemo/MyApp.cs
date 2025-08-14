
// Amir Moeini Rad
// August 14, 2025.

// Main Concept: Delegates
// In this example code, three applications of delegates are demonstrated:
// (1) Using delegates directly to point to other methods.
// (2) Using delegates as input parameters to a method (passing methods as parameters).
// (3) Using delegates to fire or trigger an event.


using System;


namespace DelegateDemo
{
    internal class MyApp
    {
        // Static fields belong to the class itself.
        private static int _val1, _val2;


        // Defining a delegate as a function pointer similar to C++.
        // The delegate 'SampleDelegate' can point to any method that takes two integers as parameters and returns an integer.
        private delegate int SampleDelegate(int p, int q);


        public static void Main()
        {
            Console.WriteLine("----------------------");
            Console.WriteLine("Delegates in C#.NET...");
            Console.WriteLine("----------------------");
            
            _val1 = 3;
            _val2 = 4;


            // Pointing to two new methods based on the above-defined delegate.
            // 'Add' and 'Subtract' methods match the signature of the 'SampleDelegate'.
            SampleDelegate addDelegate = Add;
            SampleDelegate subtractDelegate = Subtract;


            // (1) Using the delegates directly to point to other methods.
            // Invoking the 'Add' and 'Subtract' methods using the delegates.
            int a = addDelegate(3, 4);
            int b = subtractDelegate(3, 4);


            Console.WriteLine("\n(1)");
            Console.WriteLine("The result of the arithmetic operation '+' on 3 and 4: {0}", a);
            Console.WriteLine("The result of the arithmetic operation '-' on 3 and 4: {0}", b);

            Console.WriteLine();


            // (2) Using delegates as input parameters. 
            // Using a method that receives both delegates or methods being delegated as an input parameter.
            Console.WriteLine("(2)");
            int result = DoArithmetic(addDelegate);
            Console.WriteLine("The result of the arithmetic operation '+' on 3 and 4: {0}", result);

            result = DoArithmetic(subtractDelegate);
            Console.WriteLine("The result of the arithmetic operation '-' on 3 and 4: {0}", result);


            // (3) Firing or triggering the 'Change' event.
            // The 'Changed' event must be fired on an object of the class 'MyApp'.
            Console.WriteLine("\n(3)");
            var app = new MyApp();

            // Subscribing to the 'Changed' event using the 'OnChangedHandler' method.
            app.Changed += OnChangedHandler;

            // Triggering the 'Changed' event.
            app.OnChanged();


            Console.WriteLine("\nDone.");
        }

        
        ////////////////////////////////////////////////
        

        private static int Add(int a, int b)
        {
            return (a + b);
        }

        
        ////////////////////////////////////////////////
        

        private static int Subtract(int a, int b)
        {
            return (a - b);
        }

        
        ////////////////////////////////////////////////
        

        // A General method that performs an arithmetic operation based on the input delegate.
        private static int DoArithmetic(SampleDelegate method)
        {
            return method(_val1, _val2);
        }


        ////////////////////////////////////////////////


        // Using a delegate to invoke an event
        // Declare a custom event 'Changed' based on the predefined 'EventHandler' delegate:
        // 'Changed' is an event that can be subscribed to by other classes or methods.
        // The 'EventHandler' delegate defines the signature of methods that can be used as event handlers or subscribers.
        // public delegate void EventHandler(object sender, System.EventArgs e);        
        private event EventHandler Changed;

        // Raising the event as a producer
        // The event can be raised anywhere within the class by calling the OnChanged() method.
        private void OnChanged()
        {
            Console.WriteLine("The 'Changed' event was fired.");
            
            if (Changed == null) return;
            
            Changed(this, EventArgs.Empty);
        }


        ////////////////////////////////////////////////


        // An example of a method that subscribes to the 'Changed' event.
        // This method (event handler) will be called when the 'Changed' event is triggered.
        private static void OnChangedHandler(object sender, EventArgs e)
        {
            Console.WriteLine("The 'Changed' event handler 'OnChangedHandler()' was called!");
        }        
    }
}