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


        public static State currentState;

        public static void onGameStateChanged(GameState state)
        {
            if (state != GameState.Map && state != GameState.FirstPerson3D) return;
            Utility.SetStatus(state == GameState.FirstPerson3D ? "Walking around..." : getTextFromState(currentState), currentState == State.UNKNOW ? Plugin.startTimestamps : Timestamps.Now);
        }

        public static State getStateFromControlMode(ControlMode mode)
        {
            switch (mode)
            {
                case ControlMode.CardGameDefault:
                case ControlMode.CardGameChoosingSlot:
                case ControlMode.CardGameChooseDraw:
                case ControlMode.CardGame5Slots:
                    return State.BATTLE;
                case ControlMode.Map:
                case ControlMode.MapNoDeckReview:
                    return State.MAP;
                case ControlMode.CardChoice:
                case ControlMode.CardChoiceCloser:
                    return State.CHOOSING_CARD;
                case ControlMode.RareCardChoice:
                    return State.CHOOSING_RARE_CARD;
                case ControlMode.TradePelts:
                    return State.TRADE_TOOTH;
                case ControlMode.TraderCardsForPeltsPhase:
                    return State.TRADE_PELT;
                case ControlMode.Trading:
                    return State.TRADE;
                case ControlMode.CardMerging:
                    return State.MERGE_CARD;
                default:
                    return State.UNKNOW;
            }
        }

        internal static string getTextFromState(State state)
        {
            switch (state)
            {
                case State.BATTLE:
                    return !StoryEventsData.EventCompleted(StoryEvent.BasicTutorialCompleted) ? "In tutorial..." : "In card battle...";
                case State.MAP:
                    return "Travelling through the map...";
                case State.CHOOSING_CARD:
                    return "Choosing a card...";
                case State.CHOOSING_RARE_CARD:
                    return "Choosing a rare card...";
                case State.TRADE_TOOTH:
                    return "Trading for pelts...";
                case State.TRADE_PELT:
                    return "Trading pelts for card...";
                case State.TRADE:
                    return "Trading...";
                case State.MERGE_CARD:
                    return "Merging card...";
                case State.UNKNOW:
                default:
                    return "Unknown state...";
            }
        }

        public static void onViewControlModeSwitch(ControlMode mode)
        {
            State previousState = currentState;
            currentState = getStateFromControlMode(mode);
            if (previousState == currentState) return;
            if (currentState == State.UNKNOW) Plugin.logger.LogError($"Unknown Control Mode: {mode} (Please report to Dev)");
            Utility.SetStatus(getTextFromState(currentState), currentState == State.UNKNOW ? Plugin.startTimestamps : Timestamps.Now);
        }

    }
}