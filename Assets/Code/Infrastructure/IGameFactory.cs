using UnityEngine;

namespace Code.Infrastructure
{
    public interface IGameFactory : IService
    {
        GameObject CreatePlayer(GameObject at);
        GameObject PlayerGameObject { get; set; }
        //GameObject CreateIngredient(IngredientTypeId ingredientTypeId, Transform parent);
        //void Cleanup();
        //void Register(ISavedProgressReader progressReader);
    }
}