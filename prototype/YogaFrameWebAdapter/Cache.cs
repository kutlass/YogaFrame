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
    class Cache
    {
        //
        // Constructor
        //
        public Cache()
        {
            m_games = null;
            m_characters = null;
        }

        //
        // private member fields with corresponding public properties
        //
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

        //
        // Instance methods
        //
        public bool Initialize()
        {
            bool fResult = false;
            const string S_OK = "S_OK";

            //
            // Cache the Games data from the web service
            //
            JSession jSessionWebResponseGames = null;
            jSessionWebResponseGames = WebAdapter.WebGetGames();
            if (S_OK == jSessionWebResponseGames.Dispatch.Message)
            {
                m_games = jSessionWebResponseGames.Games;

                //
                // Cache the Characters data from the web service
                //
                JSession jSessionWebResponseCharacters = null;
                jSessionWebResponseCharacters = WebAdapter.WebGetCharacters();
                if (S_OK == jSessionWebResponseCharacters.Dispatch.Message)
                {
                    //
                    // If we made it this far, this entire Initialze method succeeded
                    //
                    fResult = true;
                    m_characters = jSessionWebResponseCharacters.Characters;
                }
                else
                {
                    fResult = false;
                }
            }
            else
            {
                fResult = false;
            }

            return fResult;
        }
    }
}
