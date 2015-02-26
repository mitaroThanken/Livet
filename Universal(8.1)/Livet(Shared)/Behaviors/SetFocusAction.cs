using System.Windows;

namespace Livet.Behaviors
{
    /// <summary>
    /// アタッチしているコントロールにフォーカスを試みます。
    /// </summary>
    /// TODO FrameworkElement から Control に変更したが……大丈夫？
    public class SetFocusAction : TriggerAction<Windows.UI.Xaml.Controls.Control>
    {
        protected override void Invoke(object parameter)
        {
            AssociatedObject.Focus(Windows.UI.Xaml.FocusState.Programmatic);
        }
    }
}
