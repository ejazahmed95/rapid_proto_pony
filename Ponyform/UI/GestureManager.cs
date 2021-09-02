using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Ponyform.Utilities;
using Ponyform.Game;

namespace Ponyform.UI
{
    class GestureManager
    {
        #region Fields

        private AssetManager _am = DI.Get<AssetManager>();

        private List<GestureAttributes> _gestureAttributes;

        #endregion

        #region Properties

        #endregion

        #region Methods

        public GestureManager()
        {
            _gestureAttributes = new List<GestureAttributes>();

            _gestureAttributes.Add
        }

        #endregion
    }

    public struct GestureAttributes
    {
        public Texture2D texture;
        public List<Vector2> positions;
        public Vector2 size;
        public DraggableIcon draggableIcon;
        public Color nextColor;
        public Action started;
        public Action finished;
    }
}
