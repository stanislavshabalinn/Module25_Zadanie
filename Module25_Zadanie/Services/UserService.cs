using Module25_Zadanie.BusinessLogicLayer.Models;
using Module25_Zadanie.Entity;
using Module25_Zadanie.DataAccessLayer.Repositories;
using System.ComponentModel.DataAnnotations;

namespace Module25_Zadanie.BusinessLogicLayer.Services
{
    public class UserService
    {
        private IUserRepository _userRepository;
        private IBookRepository _bookRepository;

        public UserService()
        {
            _userRepository = new UserRepository();
            _bookRepository = new BookRepository();
        }

        public void Register(UserRegistrationData userRegistrationData)
        {
            if (string.IsNullOrEmpty(userRegistrationData.Name) || string.IsNullOrEmpty(userRegistrationData.LastName))
            {
                throw new ArgumentNullException();
            }
            if (string.IsNullOrEmpty(userRegistrationData.eMail))
            {
                throw new ArgumentNullException();
            }
            if (!new EmailAddressAttribute().IsValid(userRegistrationData.eMail))
            {
                throw new ArgumentNullException();
            }
            var user = new User()
            {
                Name = userRegistrationData.Name,
                LastName = userRegistrationData.LastName,
                eMail = userRegistrationData.eMail,
                Books = new List<Book>()
            };
            _userRepository.CreateUser(user);
        }

        public void DeleteRegister(Guid userId)
        {
            var user = _userRepository.FindUserById(userId);
            if (user == null)
            {
                throw new ArgumentNullException();
            }
            _userRepository.DeleteUser(user);
        }

        public void UserAddBook(UserData userData, BookData bookData)
        {
            var user = _userRepository.FindUserById(userData.Id);
            if (user == null)
            {
                throw new ArgumentNullException();
            }
            var book = _bookRepository.FindById(bookData.Id);
            if (book == null)
            {
                throw new ArgumentNullException();
            }
            List<UserData> users = GetAllUsers();
            foreach (UserData userDataItem in users)
            {
                if (UserHasBook(userDataItem.Id, book.Id))
                {
                    throw new Exception("Книга на руках у другого пользователя.");
                }
            }
            _userRepository.AddBook(user, book);
        }

        public void UserReturnBook(Guid bookId)
        {
            var book = _bookRepository.FindById(bookId);
            _userRepository.ReturnBook(book);
        }

        public List<UserData> GetAllUsers()
        {
            List<User> users = _userRepository.FindAllUsers();
            List<UserData> userData = new List<UserData>();
            if (users != null && users.Count > 0)
            {
                foreach (var user in users)
                {
                    userData.Add(new UserData()
                    {
                        Id = user.Id,
                        Name = user.Name,
                        LastName = user.LastName,
                        eMail = user.eMail
                    });
                }
                return userData;
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public UserData FindUserById(Guid Id)
        {
            var user = _userRepository.FindUserById(Id);
            if (user == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                var userData = new UserData()
                {
                    Id = user.Id,
                    Name = user.Name,
                    LastName = user.LastName,
                    eMail = user.eMail
                };
                return userData;
            }
        }

        public void UpdateUserName(string inputName, Guid Id)
        {
            var user = _userRepository.FindUserById(Id);
            if (user == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                _userRepository.UpdateUserName(Id, inputName);
            }
        }

        public bool UserHasBook(Guid userId, Guid bookId)
        {
            var findUser = _userRepository.FindUserById(userId);
            var findBook = _bookRepository.FindById(bookId);
            if (findUser == null)
            {
                throw new ArgumentNullException();
            }
            if (findBook == null)
            {
                throw new ArgumentNullException();
            }
            return findBook.UserId == findUser.Id;
        }

        public int UserBooksCount(UserData userData)
        {
            var findUser = _userRepository.FindUserById(userData.Id);
            if (findUser == null)
            {
                throw new ArgumentNullException();
            }
            return _userRepository.UserBooks(findUser);
        }
    }
}