namespace VetOutils.Services;

public interface IGestionnaireDeFiches
{
}

public class GestionnaireDeFiches : IGestionnaireDeFiches
{
    private readonly Dictionary<Guid, Fiche> _fichesParIdentifiants;

    public GestionnaireDeFiches()
    {
        _fichesParIdentifiants = new Dictionary<Guid, Fiche>();
    }

    public Guid AjouteFiche(Fiche paramFiche)
    {
        if (_fichesParIdentifiants.TryAdd(paramFiche.FicheGuid, paramFiche))
        {
            return paramFiche.FicheGuid;
        }

        return Guid.Empty;
    }

    public Fiche? GetFiche(Guid paramGuid)
    {
        if (_fichesParIdentifiants.ContainsKey(paramGuid))
        {
            return _fichesParIdentifiants[paramGuid];
        }

        return null;
    }

    /// <summary>
    /// Supprime une fiche par identifiant
    /// </summary>
    /// <param name="paramGuid">l'identifiant de la fiche à supprimer</param>
    /// <returns>Renvoie true si la fiche a été supprimée</returns>
    public bool SupprimeFiche(Guid paramGuid)
    {
        return _fichesParIdentifiants.Remove(paramGuid);
    }

    /// <summary>
    /// Rechercher des fiches par leurs étiquettes
    /// </summary>
    /// <param name="paramEtiquettes"></param>
    /// <returns></returns>
    public List<Fiche> RechercheFichesParEtiquettes(params Etiquette[] paramEtiquettes)
    {
        var fichesTrouvees = new List<Fiche>();

        foreach (var ficheEtIdentifiant in _fichesParIdentifiants.Values)
        {
            var toutes = true;
            foreach (var etiquette in paramEtiquettes)
            {
                if (!ficheEtIdentifiant.Etiquettes.Contains(etiquette))
                {
                    toutes = false;
                    break;
                }
            }

            if (toutes)
            {
                fichesTrouvees.Add(ficheEtIdentifiant);
            }
        }

        return fichesTrouvees;
    }
}