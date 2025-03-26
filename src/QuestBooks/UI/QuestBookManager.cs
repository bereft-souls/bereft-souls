using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;

namespace QuestBooks.UI
{
    internal class QuestBookManager : ModSystem
    {
        #region IO

        public override void Load()
        {
            if (Main.dedServ)
                return;

            QuestBook.Load();
        }
        public override void Unload()
        {
            if (Main.dedServ)
                return;

            QuestBook.Unload();
        }

        #endregion

        #region UI Drawing

        public override void OnModLoad() => Main.OnPreDraw += PrepareRenderTarget;
        public override void OnModUnload() => Main.OnPreDraw -= PrepareRenderTarget;

        public static void PrepareRenderTarget(GameTime gameTime)
        {
            if (!QuestBook.Visible)
                return;

            var targets = Main.spriteBatch.GraphicsDevice.GetRenderTargets();
            Main.spriteBatch.GraphicsDevice.SetRenderTarget(QuestBook.Canvas);
            Main.spriteBatch.Begin();

            QuestBook.Draw(gameTime);

            Main.spriteBatch.End();
            Main.spriteBatch.GraphicsDevice.SetRenderTargets(targets);
        }

        public override void UpdateUI(GameTime gameTime)
        {
            if (QuestBook.Visible)
                QuestBook.Update(gameTime);
        }

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            if (!QuestBook.Visible)
                return;

            int mouseTextIndex = layers.FindIndex(l => l.Name.Equals("Vanilla: Mouse Text"));

            if (mouseTextIndex == -1)
                return;

            layers.Insert(mouseTextIndex, new LegacyGameInterfaceLayer(
                "QuestBooks: Quest Display",
                () =>
                {
                    QuestBook.Render();
                    return true;
                },
                InterfaceScaleType.UI));
        }

        #endregion
    }
}
