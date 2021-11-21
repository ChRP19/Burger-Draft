using Code.StaticData;
using UnityEngine;

namespace Code.Infrastructure
{
    public class StaticDataService : IStaticDataService
    {
        private PlayerData _playerData;
        public void LoadData()
        {
            _playerData = Resources.Load<PlayerData>("StaticData/Player");
        }

        public PlayerData GetData() => _playerData != null ? _playerData : null;
    }
}