using app05;
using System;

namespace app05

{
    class Program
    {
        public static void Main()
        {
            var selectitem = 2;

            var wallets = new Wallet
            {
                Holder = "Adbu",
                Balance=9000

            };
            using (var context = new AppDbContext())
            {
               /* foreach (var wallet in context.Wallets)
                {
                    Console.WriteLine("helllllllll");
                    Console.WriteLine(wallet);
                }*/

               /* var item=context.Wallets.FirstOrDefault(x => x.Id == selectitem);
                Console.WriteLine(item);*/

                //insert 
               /* context.Wallets.Add(wallets);
                context.SaveChanges();
*/
                
                //update
               /* var wallet=context.Wallets.Single(X=> X.Id == selectitem);
                wallet.Balance += 600;
                context.SaveChanges();*/

                //delete
               /* var wallet=context.Wallets.Single(x => x.Id == 3);
                context.Wallets.Remove(wallet);
                context.SaveChanges();*/


                using (var transaction= context.Database.BeginTransaction())
                {
                     var walletFrom =context.Wallets.Single(x => x.Id == 7);
                     var walletTt =context.Wallets.Single(x => x.Id == 4);

                    var mountTransfer = 5000m;

                    walletFrom.Balance -= mountTransfer;
                    context.SaveChanges();

                    walletTt.Balance += mountTransfer;
                    context.SaveChanges();

                   transaction.Commit();
                }
            }
            Console.ReadKey();
        }
    }
}