using System.ComponentModel.DataAnnotations;

namespace MusicLibraryWebAPI.Models
{
    public class Song
    {
        [Key]
        public int Id { get; set; }
    }
}
