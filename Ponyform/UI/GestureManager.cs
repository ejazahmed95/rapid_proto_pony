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
                            style.positions.Add(new Vector2(839, -402));
                            style.positions.Add(new Vector2(938, -619));
                            style.positions.Add(new Vector2(766, -441));
                            style.positions.Add(new Vector2(573, -410));
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
                            style.positions.Add(new Vector2(890, -289));
                            style.positions.Add(new Vector2(860, -519));
                            style.positions.Add(new Vector2(879, -628));
                            style.positions.Add(new Vector2(776, -517));
                            style.positions.Add(new Vector2(813, -186));
                            style.positions.Add(new Vector2(725, -205));
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
                            style.positions.Add(new Vector2(968, -292));
                            style.positions.Add(new Vector2(923, -387));
                            style.positions.Add(new Vector2(1002, -537));
                            style.positions.Add(new Vector2(863, -613));
                            style.positions.Add(new Vector2(771, -480));
                            style.positions.Add(new Vector2(865, -226));
                            style.positions.Add(new Vector2(703, -96));
                            style.positions.Add(new Vector2(821, -81));

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
                            style.positions.Add(new Vector2(958, -549));
                            style.positions.Add(new Vector2(829, -634));
                            style.positions.Add(new Vector2(763, -399));
                            style.positions.Add(new Vector2(649, -457));
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
                            style.positions.Add(new Vector2(974, -433));
                            style.positions.Add(new Vector2(972, -564));
                            style.positions.Add(new Vector2(856, -540));
                            style.positions.Add(new Vector2(759, -541));
                            style.positions.Add(new Vector2(804, -342));
                            style.positions.Add(new Vector2(717, -394));
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
                            style.positions.Add(new Vector2(1129, -367));
                            style.positions.Add(new Vector2(1210, -359));
                            style.positions.Add(new Vector2(1159, -259));
                            style.positions.Add(new Vector2(1260, -254));
                            style.positions.Add(new Vector2(1204, -154));
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
                            style.positions.Add(new Vector2(1121, -365));
                            style.positions.Add(new Vector2(1139, -426));
                            style.positions.Add(new Vector2(1259, -180));
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
                            style.positions.Add(new Vector2(1136, -357));
                            style.positions.Add(new Vector2(1270, -336));
                            style.positions.Add(new Vector2(1200, -114));
                            style.positions.Add(new Vector2(1316, -43));
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
                            style.positions.Add(new Vector2(1130, -366));
                            style.positions.Add(new Vector2(1209, -368));
                            style.positions.Add(new Vector2(1203, -256));
                            style.positions.Add(new Vector2(1334, -302));
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
                            style.positions.Add(new Vector2(1143, -347));
                            style.positions.Add(new Vector2(1292, -357));
                            style.positions.Add(new Vector2(1168, -314));
                            style.positions.Add(new Vector2(1228, -194));
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
