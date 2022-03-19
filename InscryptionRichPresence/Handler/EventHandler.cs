using static DiskCardGame.ViewController;
using DiskCardGame;
using DiscordRPC;

namespace InscryptionRichPresence
{
    public static class EventHandler
    {

        public enum State
        {
            MAP,
            BATTLE,
            CHOOSING_CARD,
            CHOOSING_RARE_CARD,
            TRADE_TOOTH,
            TRADE_PELT,
            TRADE,
            MERGE_CARD,
            UNKNOW
        }


        internal static bool isActive = false;

        public static State currentState;

        public static void SubscribeEvent()
        {
            isActive = true;
        }

        public static void UnsubscribeEvent()
        {
            isActive = false;
        }

        internal static void onViewControlModeSwitch(ControlMode mode)
        {
            State previousState = currentState;
            string state = "";
            switch (mode)
            {
                case ControlMode.CardGameDefault:
                case ControlMode.CardGameChoosingSlot:
                case ControlMode.CardGameChooseDraw:
                case ControlMode.CardGame5Slots:
                    state = !StoryEventsData.EventCompleted(StoryEvent.BasicTutorialCompleted) ? "In tutorial..." : "In battle...";
                    currentState = State.BATTLE;
                    break;
                case ControlMode.Map:
                case ControlMode.MapNoDeckReview:
                    state = "Walking through the map...";
                    currentState = State.MAP;
                    break;
                case ControlMode.CardChoice:
                case ControlMode.CardChoiceCloser:
                    state = "Choosing a card...";
                    currentState = State.CHOOSING_CARD;
                    break;
                case ControlMode.RareCardChoice:
                    state = "Choosing a rare card...";
                    currentState = State.CHOOSING_RARE_CARD;
                    break;
                case ControlMode.TradePelts:
                    state = "Trading for pelts...";
                    currentState = State.TRADE_TOOTH;
                    break;
                case ControlMode.TraderCardsForPeltsPhase:
                    state = "Trading pelts for card...";
                    currentState = State.TRADE_PELT;
                    break;
                case ControlMode.Trading:
                    state = "Trading...";
                    currentState = State.TRADE;
                    break;
                case ControlMode.CardMerging:
                    state = "Merging card...";
                    currentState = State.MERGE_CARD;
                    break;
                default:
                    Plugin.logger.LogError($"Unknown Control Mode: {mode} (Please report to Dev)");
                    state = "Total Misplay";
                    currentState = State.UNKNOW;
                    break;
            }
            if (previousState != currentState) API.PublicRichPresence.SetPresence(new RichPresence()
            {
                Assets = new Assets()
                {
                    LargeImageKey = "icon",
                    LargeImageText = "Inscryption"
                },
                State = state,
                Timestamps = currentState == State.UNKNOW ? Plugin.startTimestamps :  Timestamps.Now
            });
        }

    }
}