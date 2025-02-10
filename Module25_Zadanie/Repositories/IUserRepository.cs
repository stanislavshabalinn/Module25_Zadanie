using Module25_Zadanie.Entity;

namespace Module25_Zadanie.DataAccessLayer.Repositories
{
    public interface IUserRepository
    {
        //Задание 25.3.5*
        public User FindUserById(Guid Id);

        public List<User> FindAllUsers();

        public void CreateUser(User user);

        public void DeleteUser(User user);

        public void UpdateUserName(Guid Id, string name);

        //Задание 25.5.4*
        //Получать булевый флаг о том, есть ли определенная книга на руках у пользователя.
        public bool UserHasBook(User user, Book book);

        //Получать количество книг на руках у пользователя.
        public int UserBooks(User user);

        public void AddBook(User user, Book book);

        public void ReturnBook(Book book);
    }
}