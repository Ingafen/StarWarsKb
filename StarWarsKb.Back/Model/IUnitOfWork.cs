namespace StarWarsKb.Back.Model
{
    public interface IUnitOfWork
    {
        public void SaveChanges();
    }
}