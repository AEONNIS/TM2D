using System;
using UnityEngine;

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
