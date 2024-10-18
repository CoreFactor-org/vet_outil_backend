using System.Collections.Immutable;

namespace VetOutils.Services;

public interface IGestionnaireDeFiches
{
    
}

public class GestionnaireDeFiches : IGestionnaireDeFiches
{
    private static Listefiche listefiche;
    
    public GestionnaireDeFiches()
    {
        if (listefiche == null)
        {
            listefiche = new Listefiche();
            listefiche.InitialisationListeFiche();
        }
        listefiche.AjoutListeFiches();
    }
    
    public int AjoutFiche(Fiche fiche)
    {
        int idMax = listefiche._listefiche.Max(p => p.Id);
        fiche.Id = idMax + 1;
        listefiche._listefiche.Add(fiche);
        return fiche.Id;
    }

    public Fiche RecuperationFiche(int id)
    {
        return listefiche._listefiche.Find(f => f.Id == id);
    }

    /// <summary>
    /// Supprime une fiche par identifiant
    /// </summary>
    /// <param name="id">l'identifiant de la fiche à supprimer</param>
    /// <returns>Renvoie true si la fiche a été supprimée</returns>
    public bool SuppressionFiche(int id)
    {
        int _res = listefiche._listefiche.RemoveAll(f => f.Id == id);
        if (_res == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public List<Fiche> RechercheFiches(params Etiquette[] etiquettes)
    {
        return listefiche._listefiche
            .Where(f => f.Etiquettes.Any(e => etiquettes.Contains(e)))
            .ToList();
    }
    
    public bool RechercheFichesSucces(params Etiquette[] etiquettes)
    {
        if (listefiche._listefiche.Where(f => f.Etiquettes.Any(e => etiquettes.Contains(e)))
                .ToList().Count == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public Fiche RechercheFicheParId(int id)
    {   
        // Obtenir une fiche par Id
        return listefiche._listefiche.Find(f => f.Id == id);
    }
}
