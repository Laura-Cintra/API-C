using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TDSPK.API.Domain;

namespace TDSPK.API.Infrastructure.Persistence
{
    public class Photo
    {
        public Guid Id { get; private set; }

        //public User User { get; private set; }

        [Url]
        public string Url { get; private set; }

        public DateTime Date { get; private set; }

        public Photo(string url)
        {
            if (url == string.Empty) throw new Exception("Url vazia");

            Id = Guid.NewGuid();
            Date = DateTime.Now;
            Url = url;

            //User = user;
        }      
    }
}
