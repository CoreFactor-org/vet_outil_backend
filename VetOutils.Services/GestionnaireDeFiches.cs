namespace VetOutils.Services;

public interface IGestionnaireDeFiches
{
}

public class GestionnaireDeFiches : IGestionnaireDeFiches
{
    // SELECT * FROM fiches
    // private readonly List<Fiche> _fiches = new();
    // private readonly var _fiches = new List<Fiche>();
    private readonly List<Fiche> _fiches = new List<Fiche>();
    
    private int _lastId = 0;

    private int ObtenirProchaineId()
    {
        return ++_lastId;
    }
    
    public GestionnaireDeFiches()
    {

    }

    public int AjoutFiche(Fiche fiche)
    {
        if (_fiches.Contains(fiche))
        {
            return 0;
        }
        
        if (fiche.Id == 0)
        {
            fiche.Id = ObtenirProchaineId();
            // INSERT INTO fiches () VALUES () RETURNING id;
        }
        
        _fiches.Add(fiche);
        
        return fiche.Id;
    }

    public Fiche? RecuperationFiche(int id)
    {
        foreach (Fiche fiche in _fiches)
        {
            if (fiche.Id == id)
            {
                return fiche;
            }
        }
        
        return null;
    }

    /// <summary>
    /// Supprime une fiche par identifiant
    /// </summary>
    /// <param name="id">l'identifiant de la fiche à supprimer</param>
    /// <returns>Renvoie true si la fiche a été supprimée</returns>
    public bool SuppressionFiche(int id)
    {
        Fiche? fiche = RecuperationFiche(id);
        
        if (fiche == null)
        {
            return false;
        }
        
        // DELETE FROM fiches WHERE id = @id
        _fiches.Remove(fiche);
        
        return true;
    }

    public List<Fiche> RechercheFiches(params Etiquette[] etiquettes)
    {
        if (etiquettes.Length == 0) return new List<Fiche>();
        
        List<Fiche> fiches = new List<Fiche>();
        
        foreach (Fiche fiche in _fiches)
        {
            // Suggestion Rider
            // bool contientToutesLesEtiquettes = etiquettes.All(etiquette => fiche.Etiquettes.Contains(etiquette));
            
            bool contientToutesLesEtiquettes = true;
            
            foreach (Etiquette etiquette in etiquettes)
            {
                if (!fiche.Etiquettes.Contains(etiquette))
                {
                    contientToutesLesEtiquettes = false;
                    break;
                }
            }
            
            if (contientToutesLesEtiquettes)
            {
                fiches.Add(fiche);
            }
        }
        
        return fiches;
    }

    public Fiche? RechercheFicheParId(int id)
    {
        return RecuperationFiche(id);
    }
}
