using System.Text.Json;

namespace StarterM
{
    //靜態類別才可以作為擴充方法使用
    public static class SessionExtensions
    {
        public static void Set<T> (this ISession session, string key, T value)
        {
            //物件轉Json儲存到Session的String類型中
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static T? Get<T> (this ISession session, string key)
        {
            string? value = session.GetString(key);
            return value == null ? default : JsonSerializer.Deserialize<T>(value);
        }
    }
}
