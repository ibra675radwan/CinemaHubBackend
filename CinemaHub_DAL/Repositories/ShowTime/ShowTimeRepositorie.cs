using CinemaHub_DAL.Models;
using CinemaHub_DAL.Repositories._GenericRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaHub_DAL.Repositories.ShowTime
{
    public class ShowTimeRepositorie : GenericRepositories<Showtime>, iShowTimeRepositorie
    {
        public ShowTimeRepositorie(CinemaHubContext Context) : base(Context)
        {


        }
    }
}
