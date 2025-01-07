using System.ComponentModel.DataAnnotations;

namespace Einkaufsliste.Models;

public class Position
{
    [Required(ErrorMessage = "Bitte Artikelname eingeben")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Bitte Menge eingeben")]
    public int Menge { get; set; }    
    [Required(ErrorMessage = "Bitte Geschäft eingeben")]
    public string Shop { get; set; }
}