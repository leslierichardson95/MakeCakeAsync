using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace MakeCakeAsync
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //Cake cake = new Cake();
            //cake.MakeCake();

            AsyncCake asyncCake = new AsyncCake();
            await asyncCake.MakeCakeAsync();
        }
    }

    class AsyncCake
    {
        public async Task MakeCakeAsync()
        {
            Task<bool> preheatTask = PreheatOvenAsync(); // start/store this task (no blocking needed!) and come back to it later
            AddCakeIngredients();                        // make cake batter while waiting for the oven to preheat
            bool isPreheated = await preheatTask;        // get the result of preheat method in order to bake the cake

            Task<bool> bakeCakeTask = BakeCakeAsync(isPreheated); // start baking the cake and do other things while baking
            AddFrostingIngredients();                             // make the frosting while the cake is baking
            Task<bool> coolFrostingTask = CoolFrostingAsync();    // start cooling the frosting and come back to it when needed
            PassTheTime();                                        // do other things while cake is baking and frosting is cooling
            bool isBaked = await bakeCakeTask;                    // get the result of BakeCakeAsync() in order to cool the cake

            Task<bool> coolCakeTask = CoolCakeAsync(isBaked);     // start cooling the cake after it's done baking

            bool cakeIsCooled = await coolCakeTask;               // get the result of CoolCakeAsync() when finished
            bool frostingIsCooled = await coolFrostingTask;       // get the result of CoolFrostingAsync() when finished
            
            FrostCake(cakeIsCooled, frostingIsCooled);            // frost the cake once the cake and frosting are cooled

            Console.WriteLine("Cake is served! Bon Appetit!");    // Enjoy!
        }

        private async Task<bool> PreheatOvenAsync()
        {
            Console.WriteLine("Preheating oven...");
            await Task.Delay(2500);
            Console.WriteLine("Oven is ready!");
            return true;
        }

        private void AddCakeIngredients()
        {
            Thread.Sleep(500);
            Console.WriteLine("Added cake mix");
            Thread.Sleep(500);
            Console.WriteLine("Added milk");
            Thread.Sleep(500);
            Console.WriteLine("Added vegetable oil");
            Thread.Sleep(500);
            Console.WriteLine("Added eggs");
           
            Console.WriteLine("Cake ingredients mixed!");
        }

        private async Task<bool> BakeCakeAsync(bool isPreheated)
        {
            if (isPreheated)
            {
                Console.WriteLine("Baking cake...");
                await Task.Delay(5000);
                Console.WriteLine("Cake is done baking!");
                return true;
            }
            return false;
        }

        private void AddFrostingIngredients()
        {
            Thread.Sleep(500);
            Console.WriteLine("Added cream cheese");
            Thread.Sleep(500);
            Console.WriteLine("Added milk");
            Thread.Sleep(500);
            Console.WriteLine("Added vegetable oil");
            Thread.Sleep(500);
            Console.WriteLine("Added eggs");

            Console.WriteLine("Frosting ingredients mixed!");
        }

        private async Task<bool> CoolFrostingAsync()
        {
            Console.WriteLine("Cooling frosting...");
            await Task.Delay(2500);
            Console.WriteLine("Frosting is cooled!");
            return true;
        }

        private async Task<bool> CoolCakeAsync(bool isBaked)
        {
            if (isBaked)
            {
                Console.WriteLine("Cooling cake...");
                await Task.Delay(2500);
                Console.WriteLine("Cake is cooled!");
                return true;
            }
            return false;
        }

        private void FrostCake(bool cakeIsCooled, bool frostingIsCooled)
        {
            if (cakeIsCooled && frostingIsCooled)
            {
                Console.WriteLine("Frosting cake...");
                Thread.Sleep(1000);
                Console.WriteLine("Cake is frosted!");
            }
        }

        private void PassTheTime()
        {
            Thread.Sleep(500);
            Console.WriteLine("Watched TV");
            Thread.Sleep(500);
            Console.WriteLine("Ate lunch");
            Thread.Sleep(500);
            Console.WriteLine("Cleaned the kitchen");
        }
    }

    class Cake
    {
        public void MakeCake()
        {
            PreheatOven();
            AddCakeIngredients();
            BakeCake();
            AddFrostingIngredients();
            CoolFrosting();
            CoolCake();
            FrostCake();

            Console.WriteLine("Cake is served! Bon Appetit!");
        }

        private void PreheatOven()
        {
            Console.WriteLine("Preheating oven...");
            Thread.Sleep(2500);
            Console.WriteLine("Oven is ready!");
        }

        private void AddCakeIngredients()
        {
            Thread.Sleep(500);
            Console.WriteLine("Added cake mix");
            Thread.Sleep(500);
            Console.WriteLine("Added milk");
            Thread.Sleep(500);
            Console.WriteLine("Added vegetable oil");
            Thread.Sleep(500);
            Console.WriteLine("Added eggs");

            Console.WriteLine("Cake ingredients mixed!");
        }

        private void BakeCake()
        {
            Console.WriteLine("Baking cake...");
            Thread.Sleep(5000);
            Console.WriteLine("Cake is done baking!");
        }

        private void AddFrostingIngredients()
        {
            Thread.Sleep(500);
            Console.WriteLine("Added cream cheese");
            Thread.Sleep(500);
            Console.WriteLine("Added milk");
            Thread.Sleep(500);
            Console.WriteLine("Added vegetable oil");
            Thread.Sleep(500);
            Console.WriteLine("Added eggs");

            Console.WriteLine("Frosting ingredients mixed!");
        }

        private void CoolFrosting()
        {
            Console.WriteLine("Cooling frosting...");
            Thread.Sleep(2500);
            Console.WriteLine("Frosting is cooled!");
        }

        private void CoolCake()
        {
            Console.WriteLine("Cooling cake...");
            Thread.Sleep(2500);
            Console.WriteLine("Cake is cooled!");
        }

        private void FrostCake()
        {
            Console.WriteLine("Cake is frosted!");
        }
    }
}
