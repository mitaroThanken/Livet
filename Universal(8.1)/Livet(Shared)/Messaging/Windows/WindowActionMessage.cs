using System.Windows;
using Windows.UI.Xaml;

namespace Livet.Messaging.Windows
{
    /// <summary>
    /// Windowを最大化・最小化・閉じる・通常化させるための相互作用メッセージです。
    /// </summary>
    public class WindowActionMessage : InteractionMessage
    {
        public WindowActionMessage()
        {
        }

        /// <summary>
        /// メッセージキーを指定して新しい相互作用メッセージのインスタンスを生成します。
        /// </summary>
        /// <param name="messageKey">メッセージキー</param>
        public WindowActionMessage(string messageKey)
            : base(messageKey) { }

        /// <summary>
        /// メッセージキーとWindowが遷移すべき状態を定義して、新しい相互作用メッセージのインスタンスを生成します。
        /// </summary>
        /// <param name="action">Windowが遷移すべき状態を表すWindowAction列挙体</param>
        /// <param name="messageKey">メッセージキー</param>
        public WindowActionMessage(WindowAction action,string messageKey)
            :this(messageKey)
        {
            Action = action;
        }

        /// <summary>
        /// Windowが遷移すべき状態を定義して、新しい相互作用メッセージのインスタンスを生成します。
        /// </summary>
        /// <param name="action">Windowが遷移すべき状態を表すWindowAction列挙体</param>
        public WindowActionMessage(WindowAction action)
            : this(action,null) { }

        // TODO 親が Freezable クラスからの派生ではなくなったため、削除。……大丈夫？
        /*
        /// <summary>
        /// 派生クラスでは必ずオーバーライドしてください。Freezableオブジェクトとして必要な実装です。<br/>
        /// 通常このメソッドは、自身の新しいインスタンスを返すように実装します。
        /// </summary>
        /// <returns>自身の新しいインスタンス</returns>
        protected override Freezable CreateInstanceCore()
        {
            return new WindowActionMessage(MessageKey);
        }
         */

        /// <summary>
        /// Windowが遷移すべき状態を表すWindowAction列挙体を指定、または取得します。
        /// </summary>
        public WindowAction Action
        {
            get { return (WindowAction)GetValue(ActionProperty); }
            set { SetValue(ActionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Action.  This enables animation, styling, binding, etc...
        // TODO 依存関係プロパティーの初期値はこれで問題ないか？
        public static readonly DependencyProperty ActionProperty =
            DependencyProperty.Register("Action", typeof(WindowAction), typeof(WindowActionMessage), new PropertyMetadata(WindowAction.Normal, OnActionChanged));

        /// <summary>
        /// 依存関係プロパティーの定義のため、追加。プロパティーが変化したとしても、何もしない。
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void OnActionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // throw new System.NotImplementedException();
        }
    }
}
