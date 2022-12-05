namespace CodeDePorc.Api
{
    public static class StockViande
    {
        public static IEnumerable<Viande> GetStockViandes()
        {
            var listeViandes = new List<Viande>()
            {
                new Merguez()
                {
                    Id = 1,
                    DateFabrication = new DateTime(2022,10,31),
                    PourcentageRisqueSalmonelle = 2
                },
                new Merguez()
                {
                    Id = 2,
                    DateFabrication = new DateTime(2022,10,21),
                    PourcentageRisqueSalmonelle = 3
                },
                new Agneau()
                {
                    Id = 3,
                    DateFabrication = new DateTime(2022,11,03),
                    PourcentageRisqueSalmonelle = 2
                },
                 new Agneau()
                {
                    Id = 4,
                    DateFabrication = new DateTime(2022,11,04),
                    PourcentageRisqueSalmonelle = 10
                },
                new Agneau()
                {
                    Id = 5,
                    DateFabrication = new DateTime(2022,10,15),
                    PourcentageRisqueSalmonelle = 2
                },
            };

            return listeViandes;

        }
    }
}
