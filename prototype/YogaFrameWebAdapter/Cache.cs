using System;
using System.Collections.Generic;
using System.Text;
using YogaFrameWebAdapter.GamesJsonTypes;
using YogaFrameWebAdapter.CharactersJsonTypes;

namespace YogaFrameWebAdapter
{
    class Cache
    {
        private Games m_games;
        private Characters m_characters;

        public Games Games
        {
            get { return m_games; }
            set { m_games = value; }
        }

        public Characters Characters
        {
            get { return m_characters; }
            set { m_characters = value; }
        }
    }
}
