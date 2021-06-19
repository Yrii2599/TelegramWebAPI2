using AbstractionsLayer;
using DAL.SqlDb;

namespace DAL.DataManager
{
    public class DataManager
    {
        public IMessageData Messages { get; set; }
        public DataManager()
        {
            Messages = new MassageSqlDb();
        }



    }
}
