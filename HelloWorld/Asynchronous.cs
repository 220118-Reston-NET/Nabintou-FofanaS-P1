namespace AsyncFunction
{
    /*
        In the context of cooking osmething
         As you know with cooking shows, to expedite the process of getting the finish product, they will cook things at the same time
         We can do the same with programming
    */
    public class Asynchronous
    {
        public async void CookRice()
        {
            Console.WriteLine("Started cooking rice...");
            await Task.Delay(3000); //This line just stops the program for 5000 milliseconds
            Console.WriteLine("Finished cooking rice");
        }

        //We want to cook the meat first and then the veggies
        public async Task<string> CookMeat()
        {
            Console.WriteLine("Started cooking meat...");
            await Task.Delay(3000); //This line just stops the program for 3000 milliseconds
            return "Finished cooking meat";
        }


        public async Task<string> CookVeggies()
        {
            Console.WriteLine("Started cooking Veggies...");
            await Task.Delay(1000); //This line just stops the program for 1000 milliseconds
            return "Finished cooking Veggies";
        }

        public string CookMeatThenVeggies()
        {
            Console.WriteLine("Preparing main course...");

            Console.WriteLine(CookMeat());
            Console.WriteLine(CookVeggies());

            return "Finished cooking the main course";
        }
    }
}