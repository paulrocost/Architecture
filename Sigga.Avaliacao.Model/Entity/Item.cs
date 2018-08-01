using System;

namespace Sigga.Avaliacao.Model.Entity
{
    public class Item
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public Boolean Completed { get; set; }
    }
}
