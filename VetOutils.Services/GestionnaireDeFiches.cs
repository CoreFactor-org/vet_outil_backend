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

    public Guid AjoutFiche(Fiche fiche)
    {
        if (_fichesParIdentifiants.TryAdd(fiche.FicheId, fiche))
        {
            return fiche.FicheId;
        }

        return Guid.Empty;
    }

    public Fiche? RecuperationFiche(Guid id)
    {
        if (_fichesParIdentifiants.ContainsKey(id))
        {
            return _fichesParIdentifiants[id];
        }

        return null;
    }

    /// <summary>
    /// Supprime une fiche par identifiant
    /// </summary>
    /// <param name="id">l'identifiant de la fiche à supprimer</param>
    /// <returns>Renvoie true si la fiche a été supprimée</returns>
    public bool SuppressionFiche(Guid id)
    {
        return _fichesParIdentifiants.Remove(id);
    }

    public List<Fiche> RechercheFiches(params Etiquette[] etiquettes)
    {
        var fichesAvecLesBonnesEtiquettes = new List<Fiche>();

        foreach (var ficheEtIdentifiant in _fichesParIdentifiants.Values)
        {
            var toutes = true;
            foreach (var etiquette in etiquettes)
            {
                if (!ficheEtIdentifiant.Etiquettes.Contains(etiquette))
                {
                    toutes = false;
                    break;
                }
            }

            if (toutes)
            {
                fichesAvecLesBonnesEtiquettes.Add(ficheEtIdentifiant);
            }
        }

        return fichesAvecLesBonnesEtiquettes;
    }
}