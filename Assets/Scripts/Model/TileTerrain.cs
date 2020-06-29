using TileMap2D.Presentation;
using UnityEngine;

namespace TileMap2D.Model
{
    public class TileTerrain : Initializable
    {
        [SerializeField] private string _id;
        [SerializeField] private string _type;
        [SerializeField] private string _name;
        [SerializeField] private string _description;
        [SerializeField] private TileTerrainPresenter _presenter;

        public override void Init() => _presenter.Init();
    }
}
