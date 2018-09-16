namespace SoftJail.DataProcessor
{

    using Data;
    using SoftJail.Data.Models;
    using System;
    using System.Linq;

    public class Bonus
    {
        public static string ReleasePrisoner(SoftJailDbContext context, int prisonerId)
        {

            var releasedPrisoner = context.Prisoners.FirstOrDefault(x => x.Id == prisonerId);

            if(releasedPrisoner.ReleaseDate!=null)
            {
                var date = DateTime.Now;

                releasedPrisoner.ReleaseDate = date;
                releasedPrisoner.CellId = null;


              
                context.SaveChanges();
                return $"Prisoner {releasedPrisoner.FullName} released";
            }

            else
            {
                return $"Prisoner {releasedPrisoner.FullName} is sentenced to life";
            }
           

           //throw new NotImplementedException();
        }
    }
}
