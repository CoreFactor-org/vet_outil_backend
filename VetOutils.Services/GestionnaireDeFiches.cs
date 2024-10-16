namespace VetOutils.Services;

public interface IGestionnaireDeFiches
{
}

public class GestionnaireDeFiches : IGestionnaireDeFiches
{
    private IList<Fiche> _mesFiches = new List<Fiche>();
    
    public GestionnaireDeFiches()
    {

    }

    public int AjoutFiche(Fiche fiche)
    {
        _mesFiches.Add(fiche);
        fiche.id = _mesFiches.Max(f => f.id) + 1;   // pas de bdd donc grosse triche pour l'id ;)
        return fiche.id;
    }

    public Fiche RecuperationFiche(int id)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Supprime une fiche par identifiant
    /// </summary>
    /// <param name="id">l'identifiant de la fiche à supprimer</param>
    /// <returns>Renvoie true si la fiche a été supprimée</returns>
    public bool SuppressionFiche(int id)
    {
        throw new NotImplementedException();
    }

    public List<Fiche> RechercheFiches(params Etiquette[] etiquettes)
    {
        throw new NotImplementedException();
    }

    public Fiche RechercheFicheParId(int etiquette)
    {
        throw new NotImplementedException();
    }
}
