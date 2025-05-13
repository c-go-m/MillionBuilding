using Entities;

namespace DataAccess.Common
{
    public static class DbInitializer
    {
        public static void Seed(MainContext context)
        {
            AddOwners(context);
            AddProperties(context);
            AddUser(context);
        }
        public static void AddOwners(MainContext context)
        {
            if (!context.Set<Owner>().Any())
            {
                context.Set<Owner>().AddRange(
                    new Owner { Name = "Owner1", Address = "Address1", Photo = "Photo1.jpg", Birthday = new DateTime(1980, 1, 1) },
                    new Owner { Name = "Owner2", Address = "Address2", Photo = "Photo2.jpg", Birthday = new DateTime(1985, 2, 2) },
                    new Owner { Name = "Owner3", Address = "Address3", Photo = "Photo3.jpg", Birthday = new DateTime(1990, 3, 3) },
                    new Owner { Name = "Owner4", Address = "Address4", Photo = "Photo4.jpg", Birthday = new DateTime(1995, 4, 4) },
                    new Owner { Name = "Owner5", Address = "Address5", Photo = "Photo5.jpg", Birthday = new DateTime(2000, 5, 5) },
                    new Owner { Name = "Owner6", Address = "Address6", Photo = "Photo6.jpg", Birthday = new DateTime(2005, 6, 6) },
                    new Owner { Name = "Owner7", Address = "Address7", Photo = "Photo7.jpg", Birthday = new DateTime(2010, 7, 7) },
                    new Owner { Name = "Owner8", Address = "Address8", Photo = "Photo8.jpg", Birthday = new DateTime(2015, 8, 8) },
                    new Owner { Name = "Owner9", Address = "Address9", Photo = "Photo9.jpg", Birthday = new DateTime(2020, 9, 9) },
                    new Owner { Name = "Owner10", Address = "Address10", Photo = "Photo10.jpg", Birthday = new DateTime(2025, 10, 10) }
                );
                context.SaveChanges();
            }
        }

        public static void AddProperties(MainContext context)
        {
            if (!context.Set<Property>().Any())
            {
                context.Set<Property>().AddRange(
                    new Property { Name = "Property1", Address = "Address1", Price = 100000, CodeInternal = "P001", Year = 2000, IdOwner = 1 },
                    new Property { Name = "Property2", Address = "Address2", Price = 150000, CodeInternal = "P002", Year = 2005, IdOwner = 2 },
                    new Property { Name = "Property3", Address = "Address3", Price = 200000, CodeInternal = "P003", Year = 2010, IdOwner = 3 },
                    new Property { Name = "Property4", Address = "Address4", Price = 250000, CodeInternal = "P004", Year = 2015, IdOwner = 4 },
                    new Property { Name = "Property5", Address = "Address5", Price = 300000, CodeInternal = "P005", Year = 2020, IdOwner = 5 },
                    new Property { Name = "Property6", Address = "Address6", Price = 350000, CodeInternal = "P006", Year = 2021, IdOwner = 6 },
                    new Property { Name = "Property7", Address = "Address7", Price = 400000, CodeInternal = "P007", Year = 2022, IdOwner = 7 },
                    new Property { Name = "Property8", Address = "Address8", Price = 450000, CodeInternal = "P008", Year = 2023, IdOwner = 8 },
                    new Property { Name = "Property9", Address = "Address9", Price = 500000, CodeInternal = "P009", Year = 2024, IdOwner = 9 },
                    new Property { Name = "Property10", Address = "Address10", Price = 550000, CodeInternal = "P010", Year = 2025, IdOwner = 10 }
                );
                context.SaveChanges();
            }
        }

        public static void AddUser(MainContext context)
        {
            if (!context.Set<User>().Any())
            {
                context.Set<User>().Add(new User { UserName = "admin", Password = "YWRtaW4=" });
                context.SaveChanges();
            }
        }       
    }
}
