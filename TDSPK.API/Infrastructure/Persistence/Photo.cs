using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TDSPK.API.Domain;

namespace TDSPK.API.Infrastructure.Persistence
{
    public class Photo
    {
        public Guid Id { get; private set; }
        public string Url { get; private set; }
        public DateTime Date { get; private set; }

        // 1..1 - uma foto pertence a um usuário
        public Guid UserId { get; private set; }
        public User User { get; set; }

        public Photo(string url, Guid userId)
        {
            if (url == string.Empty) throw new Exception("Url vazia");

            Id = Guid.NewGuid();
            Date = DateTime.Now;
            Url = url;
            UserId = userId;
        }

        public void ValidateUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url)) {
                
                // Manda o erro para a aplicação de log
                throw new Exception("URL não pode ser nula ou vazia.");
            }

            if (!Uri.IsWellFormedUriString(url, UriKind.Absolute))
                throw new Exception("URL inválida.");
        }

        internal static Photo Create(string url, Guid id)
        {
            return new Photo(url, id);
        }
    }
}
