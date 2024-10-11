namespace VetOutils.Services;

public interface IGestionnaireDeFiches
{
}

public class GestionnaireDeFiches : IGestionnaireDeFiches
{
    public GestionnaireDeFiches()
    {

    }

    public int AjoutFiche(Fiche fiche)
    {
        throw new NotImplementedException();
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
}
