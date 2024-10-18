namespace VetOutils.Services;

public interface IGestionnaireDeFiches
{
    
}

public class GestionnaireDeFiches : IGestionnaireDeFiches
{
    private static Listefiche? _listefiche;
    
    public GestionnaireDeFiches()
    {
        if (_listefiche == null)
        {
            _listefiche = new Listefiche();
            _listefiche.InitialisationListeFiche();
        }
        _listefiche.AjoutListeFiches();
    }
    
    public int? AjoutFiche(Fiche fiche)
    {
        if (_listefiche?._listefiche == null)
        {
            return 1;
        }
        else
        {
            var idMax = _listefiche._listefiche.Max(p => p.Id)+1;
            fiche.Id = idMax;
            _listefiche._listefiche.Add(fiche);
            return fiche.Id;
        }
    }

    public Fiche? RecuperationFiche(int id)
    {
        if (_listefiche?._listefiche != null)
        {
            return _listefiche._listefiche.Find(f => f.Id == id);
        }
        else
        {
            return null;
        }
    }

    /// <summary>
    /// Supprime une fiche par identifiant
    /// </summary>
    /// <param name="id">l'identifiant de la fiche à supprimer</param>
    /// <returns>Renvoie true si la fiche a été supprimée</returns>
    public bool SuppressionFiche(int id)
    {
        if (_listefiche?._listefiche != null)
        {
            int res = _listefiche._listefiche.RemoveAll(f => f.Id == id);
            if (res == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    public List<Fiche>? RechercheFiches(params Etiquette[] etiquettes)
    {
        if (_listefiche?._listefiche != null)
        {
            return _listefiche._listefiche
                .Where(f =>f.Etiquettes.Any(e => etiquettes.Contains(e)))
                .ToList();
            
        }
        else
        {
            return null;
        }
    }
    
    public bool RechercheFichesSucces(params Etiquette[] etiquettes)
    {
        if (_listefiche?._listefiche != null)
        {
            List<Fiche> fichesTrouvees = _listefiche._listefiche
                .Where(f => f.Etiquettes.Any(e => etiquettes.Contains(e)))
                .ToList();
            if (fichesTrouvees.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        else
        {
            return false;
        }
    }

    public Fiche? RechercheFicheParId(int id)
    {   
        // Obtenir une fiche par Id
        if (_listefiche?._listefiche != null)
        {
            Fiche? res = _listefiche._listefiche.Find(f => f.Id == id);
            return res;
        }
        else
        {
            return null;
        }
    }
}
