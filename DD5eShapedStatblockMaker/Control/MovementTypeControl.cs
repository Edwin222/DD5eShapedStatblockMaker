using DD5eShapedStatblockMaker.CharacterSheet.Definition;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;

namespace DD5eShapedStatblockMaker.Control
{
    public class MovementTypeControl
    {
        readonly StackPanel movementTypePanel;
        readonly Dictionary<MovementType, int> typeSpeedMap;
        readonly TextChangedEventHandler speedChangeHandler;
        readonly MouseButtonEventHandler speedClearHandler;

        public MovementTypeControl(StackPanel movementTypePanel, TextChangedEventHandler speedChangeHandler)
        {
            this.movementTypePanel = movementTypePanel;
            this.speedChangeHandler = speedChangeHandler;
            speedClearHandler = new MouseButtonEventHandler((obj, arg) => ClearSpeedByTextBlock(obj as TextBlock));

            typeSpeedMap = new Dictionary<MovementType, int>();
            typeSpeedMap.Add(MovementType.Walk, 0);
            typeSpeedMap.Add(MovementType.Burrow, -1);
            typeSpeedMap.Add(MovementType.Fly, -1);
            typeSpeedMap.Add(MovementType.Swim, -1);

            Refresh();
        }

        void Refresh()
        {
            movementTypePanel.Children.Clear();

            TryAddSpeedElement(MovementType.Walk);
            TryAddSpeedElement(MovementType.Burrow);
            TryAddSpeedElement(MovementType.Fly);
            TryAddSpeedElement(MovementType.Swim);
        }

        void TryAddSpeedElement(MovementType type)
        {
            if(typeSpeedMap[type] >= 0)
            {
                if(type != MovementType.Walk)
                {
                    var leadingText = new TextBlock();
                    leadingText.Text = $", {type.ToString()} ";
                    leadingText.PreviewMouseDown += speedClearHandler;
                    movementTypePanel.Children.Add(leadingText);
                }

                var speedInputBox = new TextBox();
                speedInputBox.Text = typeSpeedMap[type].ToString();
                speedInputBox.TextChanged += speedChangeHandler;
                movementTypePanel.Children.Add(speedInputBox);

                var trailingText = new TextBlock();
                trailingText.Text = "ft";
                movementTypePanel.Children.Add(trailingText);
            }
        }

        public void SetSpeed(MovementType type, int speed)
        {
            typeSpeedMap[type] = speed;
            Refresh();
        }

        void ClearSpeedByTextBlock(TextBlock block)
        {
            var typeText = block.Text.Trim(' ', ',');

            if (typeText == MovementType.Burrow.ToString())
            {
                SetSpeed(MovementType.Burrow, -1);
            }
            else if (typeText == MovementType.Fly.ToString())
            {
                SetSpeed(MovementType.Fly, -1);
            }
            else if (typeText == MovementType.Swim.ToString())
            {
                SetSpeed(MovementType.Swim, -1);
            }
        }
    }
}
