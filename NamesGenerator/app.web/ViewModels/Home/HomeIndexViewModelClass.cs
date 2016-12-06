using app.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapp.ViewModels.Home
{
    public class HomeIndexViewModelClass
    {
        public int Id { get; set; }
        public IQueryable<DogName> DogNames { get; set; }
    }
}
