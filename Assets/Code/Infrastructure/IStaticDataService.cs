using Code.StaticData;

namespace Code.Infrastructure
{
    public interface IStaticDataService
    {
        void LoadData();
        PlayerData GetData();
    }
}