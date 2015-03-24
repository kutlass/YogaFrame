using System;
using System.Collections.Generic;
using System.Text;
using YogaFrameWebAdapter.JSessionJsonTypes;
using YogaFrameWebAdapter.GamesJsonTypes;
using YogaFrameWebAdapter.CharactersJsonTypes;

namespace YogaFrameWebAdapter
{
    //
    // Some remarks before I forget:
    // =============================
    // - Initially, my thinking is to only hold data container state
    //   for *fetched* data.
    // - However, it may be necessary to use Cache.cs to hold "Drafts"
    //   of customers data - ie their works in progress that they'd rather
    //   submit at a later time:
    //       1. Long winded Game or Character descriptions
    //       2. Well thought out forum posts, worthy of "Sticky" or "Pinned"
    //          votes from the community
    //       3. Many other things that'll come to mind...
    // - Will need to flesh these details prior to release.
    //
    public class Cache
    {
        //
        // Constructor
        //
        public Cache()
        {
            m_games = null;
            m_characters = null;
            m_moves = null;
        }

        //
        // private member fields with corresponding public properties
        //
        private Games      m_games;
        private int        m_gamesPositionLastSelected;
        private Characters m_characters;
        private int        m_charactersPositionLastSelected;
        private Moves      m_moves;
        private int        m_movesPositionLastSelected;
        private Sessions   m_sessions;
        private int        m_sessionsPositionLastSelected;
        public Games Games
        {
            get { return m_games; }
            set { m_games = value; }
        }
        public int GamesPositionLastSelected
        {
            get { return m_gamesPositionLastSelected; }
            set { m_gamesPositionLastSelected = value; }
        }
        public Characters Characters
        {
            get { return m_characters; }
            set { m_characters = value; }
        }
        public int CharactersPositionLastSelected
        {
            get { return m_charactersPositionLastSelected; }
            set { m_charactersPositionLastSelected = value; }
        }
        public Moves Moves
        {
            get { return m_moves; }
            set { m_moves = value; }
        }
        public int MovesPositionLastSelected
        {
            get { return m_movesPositionLastSelected; }
            set { m_movesPositionLastSelected = value; }
        }
        public Sessions Sessions
        {
            get { return m_sessions; }
            set { m_sessions = value; }
        }
        public int SessionsPositionLastSelected
        {
            get { return m_sessionsPositionLastSelected; }
            set { m_sessionsPositionLastSelected = value; }
        }
    }
}
