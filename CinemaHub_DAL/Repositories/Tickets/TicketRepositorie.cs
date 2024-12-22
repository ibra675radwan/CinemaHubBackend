﻿using CinemaHub_DAL.Models;
using CinemaHub_DAL.Repositories._GenericRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaHub_DAL.Repositories.Tickets
{
    public class TicketRepositorie : GenericRepositories<TicketsTable>, iTicketRepositorie
    {
        public TicketRepositorie(CinemaHubContext context) : base(context)
        {




        }
    }
}