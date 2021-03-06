using Code.Infrastructure;
using UnityEngine;

namespace Code.Infrastructure.AssetManager
{
    public interface IAssetProvider : IService
    {
        GameObject Instantiate(string path);
        GameObject Instantiate(string path, Vector3 at);
    }
}