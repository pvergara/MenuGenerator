namespace MenuGenerator
{
    internal delegate void MyDelegate();

    internal static class Program
    {

        private static void Main()
        {
            MenuGenerator(new[] { "Op1", "Op2", "Op3" , "Op4" },
                new MyDelegate[] { () => Console.WriteLine("A"), () => Console.WriteLine("B"), () => Console.WriteLine("C"), () => Console.WriteLine("D")});
        }

        private static bool MenuGenerator(IReadOnlyCollection<string>? optionNames, IReadOnlyList<MyDelegate>? myDelegates)
        {
            Console.WriteLine("Pick an option");
            var i = 1;
            if (optionNames == null || myDelegates == null || optionNames.Count != myDelegates.Count)
            {
                return false;
            }
            
            foreach (var item in optionNames) {
                Console.WriteLine($"  {i}) {item}");
                i++;
            }
            Console.WriteLine($"  {(optionNames.Count + 1)}) Exit/Option");

            var mustExit = false;
            while (!mustExit)
            {
                var options = 0;
                try{
                    options = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception){
                    options = 0;
                }

                
                if (options == optionNames.Count + 1) {
                    mustExit = true;
                }
                else
                {
                    if (options < 1 || options > optionNames.Count + 1) {
                        Console.WriteLine("Hey retry!!!");
                    }
                    else {
                        try
                        {
                            myDelegates[options-1].Invoke();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Error");
                            return false;
                            
                        }
                        
                    }
                }
            }

            return true;
        }
    }
}