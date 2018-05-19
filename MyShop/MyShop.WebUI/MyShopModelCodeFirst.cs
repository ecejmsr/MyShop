namespace MyShop.WebUI
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MyShopModelCodeFirst : DbContext
    {
        public MyShopModelCodeFirst()
            : base("name=MyShopModelCodeFirst")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
