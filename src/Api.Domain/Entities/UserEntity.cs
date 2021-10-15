namespace Api.Domain.Entity
{
    public class UserEntity : BaseEntity
    {
        private string _name;
        public string Name
        {
            get => _name;
            set => _name = value.ToUpper();
        }
        private string _email;
        public string Email
        {
            get => _email;
            set => _email = value.ToLower();
        }
    }
}
