using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Ponyform.Game;
using Ponyform.Event;
using Ponyform.Game.View;

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
                            style.positions.Add(new Vector2(853, -408));
                            style.positions.Add(new Vector2(976, -618));
                            style.positions.Add(new Vector2(704, -537));
                            style.positions.Add(new Vector2(609, -347));
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
                            style.positions.Add(new Vector2(953, -331));
                            style.positions.Add(new Vector2(852, -432));
                            style.positions.Add(new Vector2(897, -633));
                            style.positions.Add(new Vector2(768, -544));
                            style.positions.Add(new Vector2(806, -163));
                            style.positions.Add(new Vector2(730, -211));
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
                            style.positions.Add(new Vector2(964, -162));
                            style.positions.Add(new Vector2(917, -376));
                            style.positions.Add(new Vector2(965, -586));
                            style.positions.Add(new Vector2(787, -562));
                            style.positions.Add(new Vector2(809, -281));
                            style.positions.Add(new Vector2(681, -79));
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
                            style.positions.Add(new Vector2(958, -544));
                            style.positions.Add(new Vector2(849, -622));
                            style.positions.Add(new Vector2(793, -392));
                            style.positions.Add(new Vector2(644, -480));
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
                            style.positions.Add(new Vector2(958, -427));
                            style.positions.Add(new Vector2(1017, -543));
                            style.positions.Add(new Vector2(854, -519));
                            style.positions.Add(new Vector2(929, -637));
                            style.positions.Add(new Vector2(736, -498));
                            style.positions.Add(new Vector2(817, -331));
                            style.positions.Add(new Vector2(691, -381));
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
                            style.positions.Add(new Vector2(1130, -369));
                            style.positions.Add(new Vector2(1219, -336));
                            style.positions.Add(new Vector2(1147, -251));
                            style.positions.Add(new Vector2(1264, -154));
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
                            style.positions.Add(new Vector2(1137, -325));
                            style.positions.Add(new Vector2(1162, -402));
                            style.positions.Add(new Vector2(1210, -229));
                            style.positions.Add(new Vector2(1219, -98));
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
                            style.positions.Add(new Vector2(1129, -361));
                            style.positions.Add(new Vector2(1246, -369));
                            style.positions.Add(new Vector2(1204, -152));
                            style.positions.Add(new Vector2(1317, -42));
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
                            style.positions.Add(new Vector2(1136, -366));
                            style.positions.Add(new Vector2(1214, -376));
                            style.positions.Add(new Vector2(1202, -240));
                            style.positions.Add(new Vector2(1336, -314));
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
                            style.positions.Add(new Vector2(1136, -333));
                            style.positions.Add(new Vector2(1294, -353));
                            style.positions.Add(new Vector2(1233, -183));
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
