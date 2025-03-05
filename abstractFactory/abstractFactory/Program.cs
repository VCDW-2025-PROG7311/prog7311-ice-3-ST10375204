using System;
using System.Collections.Generic;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter brand you prefer (Samsung or Apple):");
        string brand = Console.ReadLine();
        GalaxyGadgetStore(brand);
    }

    // Abstract Product 
    public interface IGadget
    {
        void GetDetails(); 
    }

    // Concrete Products t

    public class SmartWatch : IGadget
    {
        public void GetDetails()
        {
            Console.WriteLine("Smart Watch: A wearable device to track your activities.");
        }
    }

    public class VRHeadset : IGadget
    {
        public void GetDetails()
        {
            Console.WriteLine("Virtual Reality Headset: Immersive gaming and experiences.");
        }
    }

    public class WirelessEarbuds : IGadget
    {
        public void GetDetails()
        {
            Console.WriteLine("Wireless Earbuds: Seamless music experience without wires.");
        }
    }

  //  factory here declares list to store products

    public interface IGadgetFactory
    {
        List<IGadget> CreateGadgets(); 
    }

   
        
    public class SamsungFactory : IGadgetFactory
    {
        public List<IGadget> CreateGadgets()
        {
            Console.WriteLine("At Samsung we offer:");
            return new List<IGadget> { new WirelessEarbuds(), new SmartWatch(), new VRHeadset() };
        }
    }


    public class AppleFactory : IGadgetFactory
    {
        public List<IGadget> CreateGadgets()
        {
            Console.WriteLine("At Apple we offer:");
            return new List<IGadget> { new WirelessEarbuds(), new SmartWatch(), new VRHeadset() };
        }
    }


    public static void GalaxyGadgetStore(string brand)
    {
        IGadgetFactory factory = null;

        if (brand.Equals("samsung", StringComparison.OrdinalIgnoreCase))
        {
            factory = new SamsungFactory();  
        }
        else if (brand.Equals("apple", StringComparison.OrdinalIgnoreCase))
        {
            factory = new AppleFactory();  
        }

        // Ensure factory is not null
        if (factory != null)
        {
            List<IGadget> gadgets = factory.CreateGadgets();  // Get multiple gadgets

            
            foreach (var gadget in gadgets)
            {
                gadget.GetDetails();  // Display the gadget details
            }
        }
        else
        {
            Console.WriteLine("No such brand found.");
        }
    }
}
