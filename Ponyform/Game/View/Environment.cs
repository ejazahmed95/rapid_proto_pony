using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Ponyform.UI;

namespace Ponyform.Game.View {
    public class Environment: GameObject {
        private Image calendar, carpet, desk, floor, flower1, flower2, light, posters, wall, window;

        private AssetManager am;
        private GameInfra _gameInfra;
        public Environment(){
            am = DI.Get<AssetManager>();
            _gameInfra = DI.Get<GameInfra>();
            calendar = new Image(am.calendar);
            carpet = new Image(am.carpet);
            desk = new Image(am.desk);
            floor = new Image(am.floor);
            flower1 = new Image(am.flower1);
            flower2 = new Image(am.flower2);
            light = new Image(am.light);
            posters = new Image(am.posters);
            wall = new Image(am.wall);
            window = new Image(am.window);
            
            AddAll(wall, floor, desk, flower1, flower2);
            wall.AddAll(posters, window);
            floor.Add(carpet);
            desk.Add(calendar);

            float height = _gameInfra.GetGameHeight();
            float width = _gameInfra.GetGameWidth();
            float groundPos = height * (1 - Layout.groundRatio);
            flower1.SetPosition(width*0.2f, groundPos, Alignment.BOTTOM_LEFT);
            desk.SetPosition(width*0.4f, groundPos, Alignment.BOTTOM_LEFT);
            flower2.SetPosition(width*0.8f, groundPos, Alignment.BOTTOM_LEFT);
            
            // Positioning
            floor.SetPosition(new Vector2(0, height*1f - floor.size.Y));
            desk.SetPosition(new Vector2(width*Layout.deskX, height*Layout.deskY));
        }

        public override void Draw(SpriteBatch batch, Vector2 origin){
            // if (pos.X > 0 && pos.Y > 0){
                base.Draw(batch, origin);
            // }
        }
    }
}