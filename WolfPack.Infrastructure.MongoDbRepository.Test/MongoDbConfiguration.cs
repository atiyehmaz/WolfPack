namespace WolfPack.Infrastructure.MongoDbRepository.Test
{
    public class MongoDbConfiguration
    {
        public string GetConnectionString()
        {
            return  "mongodb+srv://Atiye:pass123@cluster0.9jeoc.mongodb.net/myFirstDatabase?retryWrites=true&w=majority";
        }
    }
}