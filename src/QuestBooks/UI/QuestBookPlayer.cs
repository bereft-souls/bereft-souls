using Terraria;
using Terraria.GameInput;
using Terraria.ModLoader;

namespace QuestBooks.UI
{
    internal class QuestBookPlayer : ModPlayer
    {
        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if (!QuestBooks.ToggleQuestBookHotkey.JustPressed)
                return;

            QuestBook.Visible = !QuestBook.Visible;
        }

        public override void SetControls()
        {
            if (Main.LocalPlayer.controlInv)
            {
                
            }
        }
    }
}
