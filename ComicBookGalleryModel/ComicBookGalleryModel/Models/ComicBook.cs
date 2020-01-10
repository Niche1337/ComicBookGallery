using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookGalleryModel.Models
{
    public class ComicBook
    {
        //defining many to many relationship with artist class
        public ComicBook()
        {
            Artists = new List<ComicBookArtist>();
        }

        //ID, ComicBookId, ComicBookID example for names used as primary key for EF code first
        public int Id { get; set; }
        public int SeriesId { get; set; }
 //     [ForeignKey("SeriesRefId")]
        public int IssueNumber { get; set; }
        public string Description { get; set; }
        public DateTime PublishedOn { get; set; }
        public decimal? AverageRating { get; set; }

        public Series Series { get; set; }
        public ICollection<ComicBookArtist> Artists { get; set; }

        public string DisplayText
        {
            get
            {
                return $"{Series?.Title} #{IssueNumber}";
            }
        }

        public void AddArtist(Artist artist, Role role)
        {
            Artists.Add(new ComicBookArtist
            {
                Artist = artist,
                Role = role,
            });
        }
    }
}
