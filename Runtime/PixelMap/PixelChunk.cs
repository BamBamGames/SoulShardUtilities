using UnityEngine;
namespace SoulShard.PixelMaps
{
    /// <summary>
    /// Manages a spriterenderer into becoming a "pixel chunk",
    /// a single chunk in a manageable grid of pixels.
    /// </summary>
    [RequireComponent(typeof(SpriteRenderer))]
    public class PixelChunk : MonoBehaviour
    {
        #region Vars
        /// <summary>
        /// If this chunk is not given a name on initialization, this name is used.
        /// </summary>
        const string _spriteName = "AutoGeneratedChunkImage";
        /// <summary>
        /// The associated spriterenderer
        /// </summary>
        [HideInInspector] public SpriteRenderer _renderer;
        /// <summary>
        /// The texture this chunk manages
        /// </summary>
        [HideInInspector] public Texture2D texture;
        /// <summary>
        /// The pixels per world unit.
        /// </summary>
        [HideInInspector] public int pixelsPerUnit;
        /// <summary>
        /// The chunk size in pixels.
        /// </summary>
        uint _chunkSize;
        #endregion
        #region Method Vars
        /// <summary>
        /// Converts _chunkSize into a vector2int
        /// </summary>
        Vector2Int _chunkSizeV2I { get => new Vector2Int((int)_chunkSize, (int)_chunkSize); }
        /// <summary>
        /// The chunk size in pixels.
        /// </summary>
        public uint chunkSize { get => _chunkSize; }
        #endregion
        #region RenderInit stuff
        void OnEnable() => _renderer = GetComponent<SpriteRenderer>();
        /// <summary>
        /// Initialize this chunk with some information.
        /// </summary>
        /// <param name="chunkSize">The size of the chunk in pixels</param>
        /// <param name="startTexture">The starting texture.</param>
        /// <param name="pixelsPerUnit">The pixels per unit of the chunk.</param>
        public void Init(uint chunkSize, Texture2D startTexture, int pixelsPerUnit) => Init(chunkSize, "Default", 0, 1, startTexture, pixelsPerUnit);

        /// <summary>
        /// Initialize this chunk with some information.
        /// </summary>
        /// <param name="layerName">The sorting layer name this chunk should be a part of.</param>
        /// <param name="order">The sorting order within the layer this chunk should be.</param>
        /// <param name="transparency">The transparency of the chunk.</param>
        /// <param name="chunkSize">The size of the chunk in pixels</param>
        /// <param name="startTexture">The starting texture.</param>
        /// <param name="pixelsPerUnit">The pixels per unit of the chunk.</param>
        public void Init(uint chunkSize, string layerName, int order, float transparency, Texture2D startTexture, int pixelsPerUnit)
        {
            _renderer.sortingLayerName = layerName;
            _renderer.sortingOrder = order;
            _chunkSize = chunkSize;
            this.pixelsPerUnit = pixelsPerUnit;
            texture = new Texture2D(startTexture.width, startTexture.height, startTexture.format, false);
            texture.name = "PixelChunkTexture:" + gameObject.name;
            SetTexture(startTexture);
            texture.Apply();
            InitRender(transparency);
        }
        /// <summary>
        /// Initialization for the render phase of init.
        /// </summary>
        /// <param name="transparency">The transparency of the chunk.</param>
        void InitRender(float transparency)
        {
            texture.filterMode = FilterMode.Point;
            Sprite sprite = Sprite.Create(texture, new Rect(Vector2.zero, _chunkSizeV2I), Vector2.zero, pixelsPerUnit, 0, SpriteMeshType.FullRect);
            sprite.name = _spriteName;
            _renderer.sprite = sprite;
            Color spriteColor = _renderer.color;
            spriteColor.a = transparency;
            _renderer.color = spriteColor;
        }
        #endregion
        #region Setters
        /// <summary>
        /// Set this chunks texture easily.
        /// </summary>
        /// <param name="tex">The texture to set this chunk to.</param>
        public void SetTexture(Texture2D tex) => texture.LoadRawTextureData(tex.GetRawTextureData());
        #endregion
    }
}