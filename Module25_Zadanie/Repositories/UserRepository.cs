using Module25_Zadanie.Entity;

namespace Module25_Zadanie.DataAccessLayer.Repositories
{
    public class UserRepository : IUserRepository
    {
        //Задание 25.3.5*
        public void CreateUser(User user)
        {
            using (var dataBase = new DB.AppContext())
            {
                dataBase.Users.Add(user);
                dataBase.SaveChanges();
            }
        }

        public void DeleteUser(User user)
        {
            using (var dataBase = new DB.AppContext())
            {
                dataBase.Users.Remove(user);
                dataBase.SaveChanges();
            }
        }

        public List<User> FindAllUsers()
        {
            using (var dataBase = new DB.AppContext())
            {
                var users = dataBase.Users.ToList();
                return users;
            }
        }

        public User FindUserById(Guid Id)
        {
            using (var dataBase = new DB.AppContext())
            {
                var user = dataBase.Users.Where(user => user.Id == Id).FirstOrDefault();
                return user;
            }
        }

        public void UpdateUserName(Guid Id, string name)
        {
            using (var dataBase = new DB.AppContext())
            {
                var user = dataBase.Users.Where(user => user.Id == Id).FirstOrDefault();
                if (user != null)
                {
                    user.Name = name;
                    dataBase.SaveChanges();
                }
            }
        }

        //Задание 25.5.4*
        //Получать булевый флаг о том, есть ли определенная книга на руках у пользователя.
        public bool UserHasBook(User user, Book bookFind)
        {
            bool result = false;
            if (user.Books.Count >= 1)
            {
                result = user.Books.Where(book => book.Id == bookFind.Id).Any();
            }
            return result;
        }

        //Получать количество книг на руках у пользователя.
        public int UserBooks(User user)
        {
            using (var dataBase = new DB.AppContext())
            {
                var books = dataBase.Books.ToList();
                int count = 0;
                foreach (var book in books)
                {
                    if (book.UserId == user.Id) count++;
                }
                return count;
            }
        }

        //Получение пользователем книги
        public void AddBook(User inputUser, Book inputBook)
        {
            using (var dataBase = new DB.AppContext())
            {
                var findUser = FindUserById(inputUser.Id);
                var findBook = dataBase.Books.Where(book => book.Id == inputBook.Id).FirstOrDefault();
                findBook.UserId = findUser.Id;
                dataBase.SaveChanges();
            }
        }

        //Возврат пользователем книги
        public void ReturnBook(Book inputBook)
        {
            using (var dataBase = new DB.AppContext())
            {
                var findBook = dataBase.Books.Where(book => book.Id == inputBook.Id).FirstOrDefault();
                findBook.UserId = null;
                dataBase.SaveChanges();
            }
        }
    }
}