using Sigga.Avaliacao.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigga.Avaliacao.Model.Condition
{
    public class ItemCondition : ModelCondition<Item>
    {
        public bool Completed { get; set; }

        public string Title { get; set; }

        public int UserId { get; set; }
    }
}
