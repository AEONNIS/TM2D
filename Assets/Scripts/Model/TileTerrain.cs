using System;
using TileMap2D.Presentation;
using UnityEngine;

namespace TileMap2D.Model
{
    public class TileTerrain : MonoBehaviour
    {
        [SerializeField] private string _id;
        [SerializeField] private string _type;
        [SerializeField] private string _name;
        [SerializeField] private string _description;
        [SerializeField] private TileTerrainPresenter _presenter;

        private void Start() => _presenter.Init();
    }
}

namespace TileMap2D.Presentation
{
    [Serializable]
    public class TileTerrainPresenter
    {
        [SerializeField] private SpriteRenderer _renderer;
        [SerializeField] private Sprite[] _spritesVariants;

        private readonly System.Random _random = new System.Random(DateTime.Now.Millisecond);

        public void Init() => _renderer.sprite = _spritesVariants[_random.Next(0, _spritesVariants.Length)];
    }
}
