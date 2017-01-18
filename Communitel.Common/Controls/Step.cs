using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Communitel.Common.Controls
{
    public class Step : Border
    {
        public Step()
        {
            Margin = new Thickness(200, 0, 200, 0);
        }


        public int StepNumberText
        {
            get { return (int)GetValue(StepNumberTextProperty); }
            set { SetValue(StepNumberTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for StepNumber.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StepNumberTextProperty =
            DependencyProperty.Register("StepNumberText", typeof(int), typeof(Step), new PropertyMetadata(1, ChangeStepNumberTextPropertyChanged));

        private static void ChangeStepNumberTextPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var step = (Step)sender;
            var bc = new System.Windows.Media.BrushConverter();
            var newValue = Convert.ToInt32(e.NewValue);

            Grid grid = (Grid)step.Child;

            foreach (var ctr in grid.Children)
            {
                if (ctr is Border)
                {
                    var border = (Border)ctr;
                    TextBlock textBlock = (TextBlock)border.Child;
                    if (textBlock != null)
                    {
                        border.Background = (Convert.ToInt32(textBlock.Text) == newValue) ? (Brush)bc.ConvertFrom("#FF73B942") : Brushes.White;
                        textBlock.Foreground = (Convert.ToInt32(textBlock.Text) == newValue) ? Brushes.White : (Brush)bc.ConvertFrom("#FF73B942");
                    }

                }
            }

        }

        public int StepNumberCount
        {
            get { return (int)GetValue(StepNumberCountProperty); }
            set { SetValue(StepNumberCountProperty, value); }
        }

        // Using a DependencyProperty as the backing store for StepNumberCount.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StepNumberCountProperty =
            DependencyProperty.Register("StepNumberCount", typeof(int), typeof(Step), new PropertyMetadata(1, ChangeStepNumberCountPropertyChanged));

        private static void ChangeStepNumberCountPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var step = (Step)sender;
            var bc = new System.Windows.Media.BrushConverter();
            int count = Convert.ToInt32(e.NewValue);

            Grid grid = new Grid();

            Border line = new Border()
            {
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Center,
                CornerRadius = new CornerRadius(10),
                Background = (Brush)bc.ConvertFrom("#FF73B942"),
                Height = 15,
            };

            Grid.SetColumn(line, 0);
            Grid.SetColumnSpan(line, count);
            grid.Children.Add(line);

            for (int i = 0; i < count; i++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
                var border = step.CreateStep(i);
                Grid.SetColumn(border, i);
                grid.Children.Add(border);
            }

            step.Child = grid;

        }

        Border CreateStep(int stepNumber)
        {

            var bc = new System.Windows.Media.BrushConverter();
            TextBlock textBlock = new TextBlock
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                TextAlignment = TextAlignment.Center,
                FontSize = 15,
                FontWeight = FontWeights.Bold,
                Foreground = (stepNumber + 1 == this.StepNumberText) ? Brushes.White : (Brush)bc.ConvertFrom("#FF73B942"),
                Text = (stepNumber + 1).ToString(),
            };

            Border border = new Border
            {
                Child = textBlock,// Grid { Children = { textBlock }, VerticalAlignment = VerticalAlignment.Center, HorizontalAlignment = HorizontalAlignment.Center },
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Background = (stepNumber + 1 == this.StepNumberText) ? (Brush)bc.ConvertFrom("#FF73B942") : Brushes.White,
                BorderThickness = new Thickness(3),
                BorderBrush = (Brush)bc.ConvertFrom("#FF73B942"),
                Height = 45,
                Width = 45,
                CornerRadius = new CornerRadius(30),
            };

            return border;
        }

    }
}
