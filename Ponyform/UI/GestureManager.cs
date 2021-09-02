using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Ponyform.Utilities;
using Ponyform.Game;
using Ponyform.Event;
using Ponyform.Game.View;
using Ponyform.UI;

namespace Ponyform.UI
{
    class GestureManager
    {
        #region Fields

        private AssetManager _am = DI.Get<AssetManager>();
        private EventManager _em = DI.Get<EventManager>();

        #endregion

        #region Properties

        #endregion

        #region Methods

        public GestureManager()
        {

        }

        public GestureAttributes setStyle(DraggableIcon draggableIcon, GroomPart groomPart, int styleNum)
        {
            GestureAttributes style = new GestureAttributes();
            switch (groomPart)
            {
                case GroomPart.Hair:
                    switch (styleNum)
                    {
                        case 0:
                            style.draggableIcon = draggableIcon;
                            style.texture = _am.star;
                            style.positions = new List<Vector2>();
                            style.positions.Add(new Vector2(1000, -500));
                            style.positions.Add(new Vector2(1300, -500));
                            style.positions.Add(new Vector2(1300, -200));
                            style.positions.Add(new Vector2(1000, -200));
                            //...
                            style.size = new Vector2(10, 10);
                            style.nextColor = new Color(0, 0, 0);
                            style.started = () => _em.SendEvent(GameEvent.StartedGrooming, new GroomInfo { groomPart = groomPart, ponyHairStyle = PonyHairStyle.HairStyle1, ponyTailStyle = PonyTailStyle.TailStyle1 });
                            style.finished = () => _em.SendEvent(GameEvent.StoppedGrooming, new GroomInfo { groomPart = groomPart, ponyHairStyle = PonyHairStyle.HairStyle1, ponyTailStyle = PonyTailStyle.TailStyle1 });

                            return style;
                        case 1:
                            style.draggableIcon = draggableIcon;
                            style.texture = _am.star;
                            style.positions = new List<Vector2>();
                            style.positions.Add(new Vector2(1000, -500));
                            style.positions.Add(new Vector2(1300, -500));
                            style.positions.Add(new Vector2(1300, -200));
                            style.positions.Add(new Vector2(1000, -200));
                            //...
                            style.size = new Vector2(10, 10);
                            style.nextColor = new Color(0, 0, 0);
                            style.started = () => _em.SendEvent(GameEvent.StartedGrooming, new GroomInfo { groomPart = groomPart, ponyHairStyle = PonyHairStyle.HairStyle2, ponyTailStyle = PonyTailStyle.TailStyle2 });
                            style.finished = () => _em.SendEvent(GameEvent.StoppedGrooming, new GroomInfo { groomPart = groomPart, ponyHairStyle = PonyHairStyle.HairStyle2, ponyTailStyle = PonyTailStyle.TailStyle2 });

                            return style;
                        case 2:
                            style.draggableIcon = draggableIcon;
                            style.texture = _am.star;
                            style.positions = new List<Vector2>();
                            style.positions.Add(new Vector2(1000, -500));
                            style.positions.Add(new Vector2(1300, -500));
                            style.positions.Add(new Vector2(1300, -200));
                            style.positions.Add(new Vector2(1000, -200));
                            //...
                            style.size = new Vector2(10, 10);
                            style.nextColor = new Color(0, 0, 0);
                            style.started = () => _em.SendEvent(GameEvent.StartedGrooming, new GroomInfo { groomPart = groomPart, ponyHairStyle = PonyHairStyle.HairStyle3, ponyTailStyle = PonyTailStyle.TailStyle3 });
                            style.finished = () => _em.SendEvent(GameEvent.StoppedGrooming, new GroomInfo { groomPart = groomPart, ponyHairStyle = PonyHairStyle.HairStyle3, ponyTailStyle = PonyTailStyle.TailStyle3 });

                            return style;
                        case 3:
                            style.draggableIcon = draggableIcon;
                            style.texture = _am.star;
                            style.positions = new List<Vector2>();
                            style.positions.Add(new Vector2(1000, -500));
                            style.positions.Add(new Vector2(1300, -500));
                            style.positions.Add(new Vector2(1300, -200));
                            style.positions.Add(new Vector2(1000, -200));
                            //...
                            style.size = new Vector2(10, 10);
                            style.nextColor = new Color(0, 0, 0);
                            style.started = () => _em.SendEvent(GameEvent.StartedGrooming, new GroomInfo { groomPart = groomPart, ponyHairStyle = PonyHairStyle.HairStyle4, ponyTailStyle = PonyTailStyle.TailStyle4 });
                            style.finished = () => _em.SendEvent(GameEvent.StoppedGrooming, new GroomInfo { groomPart = groomPart, ponyHairStyle = PonyHairStyle.HairStyle4, ponyTailStyle = PonyTailStyle.TailStyle4 });

                            return style;
                        case 4:
                            style.draggableIcon = draggableIcon;
                            style.texture = _am.star;
                            style.positions = new List<Vector2>();
                            style.positions.Add(new Vector2(1000, -500));
                            style.positions.Add(new Vector2(1300, -500));
                            style.positions.Add(new Vector2(1300, -200));
                            style.positions.Add(new Vector2(1000, -200));
                            //...
                            style.size = new Vector2(10, 10);
                            style.nextColor = new Color(0, 0, 0);
                            style.started = () => _em.SendEvent(GameEvent.StartedGrooming, new GroomInfo { groomPart = groomPart, ponyHairStyle = PonyHairStyle.HairStyle5, ponyTailStyle = PonyTailStyle.TailStyle5 });
                            style.finished = () => _em.SendEvent(GameEvent.StoppedGrooming, new GroomInfo { groomPart = groomPart, ponyHairStyle = PonyHairStyle.HairStyle5, ponyTailStyle = PonyTailStyle.TailStyle5 });

                            return style;
                        default:
                            style.draggableIcon = draggableIcon;
                            style.texture = _am.star;
                            style.positions = new List<Vector2>();
                            style.nextColor = new Color(0, 0, 0);
                            style.started = () => _em.SendEvent(GameEvent.StartedGrooming, new GroomInfo { groomPart = groomPart, ponyHairStyle = PonyHairStyle.HairStyle5, ponyTailStyle = PonyTailStyle.TailStyle5 });
                            style.finished = () => _em.SendEvent(GameEvent.StoppedGrooming, new GroomInfo { groomPart = groomPart, ponyHairStyle = PonyHairStyle.HairStyle5, ponyTailStyle = PonyTailStyle.TailStyle5 });

                            return style;
                    }
                case GroomPart.Tail:
                    switch (styleNum)
                    {
                        case 0:
                            style.draggableIcon = draggableIcon;
                            style.texture = _am.star;
                            style.positions = new List<Vector2>();
                            style.positions.Add(new Vector2(1000, -500));
                            style.positions.Add(new Vector2(1300, -500));
                            style.positions.Add(new Vector2(1300, -200));
                            style.positions.Add(new Vector2(1000, -200));
                            //...
                            style.size = new Vector2(10, 10);
                            style.nextColor = new Color(0, 0, 0);
                            style.started = () => _em.SendEvent(GameEvent.StartedGrooming, new GroomInfo { groomPart = groomPart, ponyHairStyle = PonyHairStyle.HairStyle1, ponyTailStyle = PonyTailStyle.TailStyle1 });
                            style.finished = () => _em.SendEvent(GameEvent.StoppedGrooming, new GroomInfo { groomPart = groomPart, ponyHairStyle = PonyHairStyle.HairStyle1, ponyTailStyle = PonyTailStyle.TailStyle1 });

                            return style;
                        case 1:
                            style.draggableIcon = draggableIcon;
                            style.texture = _am.star;
                            style.positions = new List<Vector2>();
                            style.positions.Add(new Vector2(1000, -500));
                            style.positions.Add(new Vector2(1300, -500));
                            style.positions.Add(new Vector2(1300, -200));
                            style.positions.Add(new Vector2(1000, -200));
                            //...
                            style.size = new Vector2(10, 10);
                            style.nextColor = new Color(0, 0, 0);
                            style.started = () => _em.SendEvent(GameEvent.StartedGrooming, new GroomInfo { groomPart = groomPart, ponyHairStyle = PonyHairStyle.HairStyle2, ponyTailStyle = PonyTailStyle.TailStyle2 });
                            style.finished = () => _em.SendEvent(GameEvent.StoppedGrooming, new GroomInfo { groomPart = groomPart, ponyHairStyle = PonyHairStyle.HairStyle2, ponyTailStyle = PonyTailStyle.TailStyle2 });

                            return style;
                        case 2:
                            style.draggableIcon = draggableIcon;
                            style.texture = _am.star;
                            style.positions = new List<Vector2>();
                            style.positions.Add(new Vector2(1000, -500));
                            style.positions.Add(new Vector2(1300, -500));
                            style.positions.Add(new Vector2(1300, -200));
                            style.positions.Add(new Vector2(1000, -200));
                            //...
                            style.size = new Vector2(10, 10);
                            style.nextColor = new Color(0, 0, 0);
                            style.started = () => _em.SendEvent(GameEvent.StartedGrooming, new GroomInfo { groomPart = groomPart, ponyHairStyle = PonyHairStyle.HairStyle3, ponyTailStyle = PonyTailStyle.TailStyle3 });
                            style.finished = () => _em.SendEvent(GameEvent.StoppedGrooming, new GroomInfo { groomPart = groomPart, ponyHairStyle = PonyHairStyle.HairStyle3, ponyTailStyle = PonyTailStyle.TailStyle3 });

                            return style;
                        case 3:
                            style.draggableIcon = draggableIcon;
                            style.texture = _am.star;
                            style.positions = new List<Vector2>();
                            style.positions.Add(new Vector2(1000, -500));
                            style.positions.Add(new Vector2(1300, -500));
                            style.positions.Add(new Vector2(1300, -200));
                            style.positions.Add(new Vector2(1000, -200));
                            //...
                            style.size = new Vector2(10, 10);
                            style.nextColor = new Color(0, 0, 0);
                            style.started = () => _em.SendEvent(GameEvent.StartedGrooming, new GroomInfo { groomPart = groomPart, ponyHairStyle = PonyHairStyle.HairStyle4, ponyTailStyle = PonyTailStyle.TailStyle4 });
                            style.finished = () => _em.SendEvent(GameEvent.StoppedGrooming, new GroomInfo { groomPart = groomPart, ponyHairStyle = PonyHairStyle.HairStyle4, ponyTailStyle = PonyTailStyle.TailStyle4 });

                            return style;
                        case 4:
                            style.draggableIcon = draggableIcon;
                            style.texture = _am.star;
                            style.positions = new List<Vector2>();
                            style.positions.Add(new Vector2(1000, -500));
                            style.positions.Add(new Vector2(1300, -500));
                            style.positions.Add(new Vector2(1300, -200));
                            style.positions.Add(new Vector2(1000, -200));
                            //...
                            style.size = new Vector2(10, 10);
                            style.nextColor = new Color(0, 0, 0);
                            style.started = () => _em.SendEvent(GameEvent.StartedGrooming, new GroomInfo { groomPart = groomPart, ponyHairStyle = PonyHairStyle.HairStyle5, ponyTailStyle = PonyTailStyle.TailStyle5 });
                            style.finished = () => _em.SendEvent(GameEvent.StoppedGrooming, new GroomInfo { groomPart = groomPart, ponyHairStyle = PonyHairStyle.HairStyle5, ponyTailStyle = PonyTailStyle.TailStyle5 });

                            return style;
                        default:
                            style.draggableIcon = draggableIcon;
                            style.texture = _am.star;
                            style.positions = new List<Vector2>();
                            style.nextColor = new Color(0, 0, 0);
                            style.started = () => _em.SendEvent(GameEvent.StartedGrooming, new GroomInfo { groomPart = groomPart, ponyHairStyle = PonyHairStyle.HairStyle5, ponyTailStyle = PonyTailStyle.TailStyle5 });
                            style.finished = () => _em.SendEvent(GameEvent.StoppedGrooming, new GroomInfo { groomPart = groomPart, ponyHairStyle = PonyHairStyle.HairStyle5, ponyTailStyle = PonyTailStyle.TailStyle5 });

                            return style;
                    }
                default:
                    style.draggableIcon = draggableIcon;
                    style.texture = _am.star;
                    style.positions = new List<Vector2>();
                    style.nextColor = new Color(0, 0, 0);
                    style.started = () => _em.SendEvent(GameEvent.StartedGrooming, new GroomInfo { groomPart = groomPart, ponyHairStyle = PonyHairStyle.HairStyle5, ponyTailStyle = PonyTailStyle.TailStyle5 });
                    style.finished = () => _em.SendEvent(GameEvent.StoppedGrooming, new GroomInfo { groomPart = groomPart, ponyHairStyle = PonyHairStyle.HairStyle5, ponyTailStyle = PonyTailStyle.TailStyle5 });

                    return style;
            }
            }
            
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
