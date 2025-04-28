using TDSPK.API.Domain;
using TDSPK.API.Domain.Enums;

namespace TDSPK.API.Infrastructure.Persistence
{
    public class User : Audit
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        // 1..N - um usuário tem 1 ou mais fotos
        public readonly List<Photo> _photos = new();

        public IReadOnlyCollection<Photo> Photos => _photos.AsReadOnly(); // a leitura é acessada mas apenas eu consigo alterar essa lista de fotos

        public User(string name)
        {
            Id = Guid.NewGuid();
            Name = name ?? throw new Exception("Nome não pode ser vazio"); // verifica se está nulo
            Status = StatusType.Active;
        }

        public void AddPhoto(string url) {
            var photo = Photo.Create(url, Id);
            _photos.Add(photo);
        }
    }
}
