using Terraria.ModLoader;

namespace QuestBooks
{
	// Please read https://github.com/tModLoader/tModLoader/wiki/Basic-tModLoader-Modding-Guide#mod-skeleton-contents for more information about the various files in a mod.
	public class QuestBooks : Mod
	{
		public static ModKeybind ToggleQuestBookHotkey;

        public override void Load()
        {
            ToggleQuestBookHotkey = KeybindLoader.RegisterKeybind(this, "ToggleQuestBook", Microsoft.Xna.Framework.Input.Keys.P);
        }

        public override void Unload()
        {
            ToggleQuestBookHotkey = null;
        }
    }
}
