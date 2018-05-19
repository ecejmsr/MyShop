namespace MyShop.WebUI
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MyShopModelCodeFirstAgain : DbContext
    {
        public MyShopModelCodeFirstAgain()
            : base("name=MyShopModelCodeFirstAgain")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
