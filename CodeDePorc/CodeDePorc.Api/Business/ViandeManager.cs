namespace CodeDePorc.Api.Business
{
    /// <summary>
    /// 
    /// </summary>
    public class ViandeManager
    {
        private const decimal seuilSalmonelleAutorise = 5M;

        /// <summary>
        /// TODO.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public IEnumerable<Viande> PurgeViandeHalam()
        {
            // TODO : Prévoir de faire les tests automatisés.
            // Récupération des viandes.
            var stocks = StockViande.GetStockViandes()
            .ToList().Where(v => v.GetType() == typeof(Merguez)
            || v.GetType() == typeof(Agneau)
            || v.GetType() == typeof(Viande))
            .Select(v => v as Viande);

            // Création de la liste.
            var liste = new List<Viande>();

            // Initialisation de l'itérator.
            var i = 0;

            while (i < stocks.Count())
            {
                // Obligé à faire pour récupéré la bonne viande.
                var lotViande = stocks.ToList()[i];

                // Est ce que la viande est périmé ou non.
                var estPerime = false;

                //if (lotViande.PourcentageRisqueSalmonelle <= seuilSalmonelleAutorise)
                if (lotViande.PourcentageRisqueSalmonelle <= 5M)
                {
                    // Si la viande est de type merguez.
                    if (lotViande.GetType() == typeof(Merguez))
                    {
                        if (lotViande.DateFabrication.AddDays(10) <= DateTime.Now)
                        {
                            liste.Add(lotViande);
                            estPerime = true;
                        }

                        if (lotViande.PourcentageRisqueSalmonelle > seuilSalmonelleAutorise)
                        {
                            liste.Add(lotViande);
                            estPerime = true;
                        }
                    }

                    // Si la viande est de type agneau.
                    if (lotViande.GetType() == typeof(Agneau))
                    {
                        if (lotViande.DateFabrication.AddDays(7) <= DateTime.Now)
                        {
                            liste.Add(lotViande);
                            estPerime = true;
                        }

                        if (lotViande.PourcentageRisqueSalmonelle > seuilSalmonelleAutorise)
                        {
                            liste.Add(lotViande);
                            estPerime = true;
                        }
                    }
                }

                if (lotViande.PourcentageRisqueSalmonelle > seuilSalmonelleAutorise)
                {
                    liste.Add(lotViande);
                    estPerime = true;
                }

                if (lotViande.GetType() != typeof(Agneau) && lotViande.GetType() != typeof(Merguez))
                {
                    // On lève l'exception si c'est pas le bon type de viande.
                    throw new Exception("Viande inconnu au bataillon !");
                }

                i++;
            }

            return liste;

        }
    }
}
