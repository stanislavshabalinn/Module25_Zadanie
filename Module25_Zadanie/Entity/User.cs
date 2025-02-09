namespace Module25_Zadanie.Entity
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string eMail { get; set; }
        public List<Book> Books { get; set; }
    }
}