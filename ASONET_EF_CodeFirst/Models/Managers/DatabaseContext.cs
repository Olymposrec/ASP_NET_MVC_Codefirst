using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ASONET_EF_CodeFirst.Models.Managers
{
    public class DatabaseContext: DbContext
    {
        public DbSet<Kisiler> Kisiler { get; set; }
        public DbSet<Adresler> Adresler { get; set; }
        public DatabaseContext()
        {
            Database.SetInitializer(new DatabaseCreater());
        }
    }
    public class DatabaseCreater : CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            for (int i = 0; i < 10; i++)
            {
                Kisiler kisi = new Kisiler();
                kisi.Ad = FakeData.NameData.GetFirstName();
                kisi.Soyad = FakeData.NameData.GetSurname();
                kisi.Yas = FakeData.NumberData.GetNumber(10, 90);
                kisi.Mail = FakeData.NetworkData.GetEmail();

                context.Kisiler.Add(kisi);
            }
            context.SaveChanges();
            List<Kisiler> tumKisiler = context.Kisiler.ToList();

            foreach (Kisiler kisi in tumKisiler)
            {
                for (int i = 0; i < FakeData.NumberData.GetNumber(1, 5); i++)
                {
                    Adresler adres = new Adresler();
                    adres.AdresTanim = FakeData.PlaceData.GetAddress();
                    adres.kisi = kisi;
                    context.Adresler.Add(adres);
                }
            }
            context.SaveChanges();
        }
    }
}